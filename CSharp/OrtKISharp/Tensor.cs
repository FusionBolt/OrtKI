using System.Collections;
using System.Numerics.Tensors;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Linq;
using System.Reflection;

namespace OrtKISharp;

public static class TensorHelper
{
    public static Tensor MakeOrtTensor<T>(T[] buffer, int[] shape) 
        where T : unmanaged
    {
        return Tensor.MakeTensor(buffer, shape);
    }
    
    public static Tensor MakeOrtTensor<T>(T[] buffer) 
        where T : unmanaged
    {
        return Tensor.MakeTensor(buffer, new[] {buffer.Length});
    }
    
    public static Tensor OrtTensorFromScalar<T>(T x) where T : unmanaged
    {
        return Tensor.FromScalar(x);
    }
}

public partial class Tensor : IDisposable, IEquatable<Tensor>
{
    public IntPtr Handle { get; private set; }

    public IntPtr Mem { get; private set; }

    // 1. data, type, shape
    // 2. spec type Array
    // 3. DenseTensor
    
    public Tensor(ReadOnlySpan<byte> data, OrtDataType dataType, int[] shape)
    {
        (Handle, Mem) = MakeTensorHandle(data, dataType, shape);
    }

    public static Tensor FromScalar<T>(T x) where T : unmanaged
    {
        return MakeTensor(new[] {x}, Array.Empty<int>());
    }

    internal Tensor(IntPtr handle, IntPtr mem)
    {
        Handle = handle;
        Mem = mem;
    }

    internal Tensor(IntPtr handle)
    {
        Handle = handle;
        Mem = IntPtr.Zero;
    }

    ~Tensor()
    {
        Dispose(false);    
    }
    
    public static Tensor MakeTensor<T>(T[] buffer, int[] shape) 
        where T : unmanaged
    {
        return MakeTensor<T>(buffer.AsSpan(), shape);
    }
    
    public static Tensor MakeTensor<T>(T[] buffer) 
        where T : unmanaged
    {
        return MakeTensor<T>(buffer.AsSpan(), new[] {buffer.Length});
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public unsafe byte[] BufferToArray()
    {
        var byteSize = Length * TypeUtil.GetLength(DataType);
        byte[] array = new byte[byteSize];
        fixed (byte* dest = array)
        {
            System.Buffer.MemoryCopy(GetMemory().ToPointer(), (void*) dest, byteSize, byteSize);
        }

        return array;
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (Handle != IntPtr.Zero)
        {
            tensor_dispose(Handle);
            Handle = IntPtr.Zero;
        }

        if (Mem != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(Mem);
            Mem = IntPtr.Zero;
        }
    }

    private IntPtr GetMemory()
    {
        // When mem is not 0, the data is stored in mem
        // and in the other case, it is stored in handle
        return Mem != IntPtr.Zero ? Mem : tensor_buffer(Handle);
    }
    
    [DllImport("ortki")]
    internal static extern unsafe IntPtr make_tensor(
        [In] IntPtr buffer, OrtDataType dataType,
        [In] int* shape, int shape_size);

    [DllImport("ortki")]
    internal static extern unsafe IntPtr make_tensor_empty(OrtDataType dataType, [In] int* shape, int rank);

    public static unsafe Tensor Empty(int[] shape, OrtDataType dataType = OrtDataType.Float)
    {
        fixed (int* shape_ptr = shape)
        {
            return new Tensor(make_tensor_empty(dataType, shape_ptr, shape.Length));
        }
    }

    [DllImport("ortki")]
    internal static extern void tensor_dispose(IntPtr tensor);

    [DllImport("ortki")]
    internal static extern OrtDataType tensor_data_type(IntPtr tensor);
    
    [DllImport("ortki")]
    internal static extern unsafe IntPtr tensor_shape(IntPtr tensor, int *output);
    
    [DllImport("ortki")]
    internal static extern int tensor_rank(IntPtr tensor);
    
    [DllImport("ortki")]
    internal static extern IntPtr tensor_buffer(IntPtr tensor);
    
    [DllImport("ortki")]
    internal static extern IntPtr tensor_to_type(IntPtr tensor, OrtDataType dataType);

    [DllImport("ortki")]
    internal static extern void tensor_reshape(IntPtr tensor, int[] shape, int size);
    
    public OrtDataType DataType => tensor_data_type(Handle);

    public int Rank => tensor_rank(Handle);

    public unsafe int[] Shape
    {
        get
        {
            var rank = tensor_rank(Handle);
            var shape = new int[rank];
            fixed (int* shapePtr = shape)
            {
                tensor_shape(Handle, shapePtr);
            }

            return shape;
        }
    }

    public bool IsScalar()
    {
        return Shape.Length == 0;
    }
    
    public static Tensor MakeTensor<T>(ReadOnlySpan<T> buffer, int[] shape) 
        where T : unmanaged
    {
        return MakeTensor(
            MemoryMarshal.AsBytes(buffer), 
            TypeUtil.FromType(typeof(T)), 
            shape);
    }

    public static Tensor MakeTensor(ReadOnlySpan<byte> buffer, OrtDataType dataType, int[] shape)
    {
        var (handle, mem) = MakeTensorHandle(buffer, dataType, shape);
        return new Tensor(handle, mem);
    }

    private static unsafe (IntPtr, IntPtr) MakeTensorHandle(ReadOnlySpan<byte> buffer, OrtDataType dataType,
        int[] shape)
    {
        var bytes = buffer.Length;
        var memPtr = Marshal.AllocHGlobal(bytes);
        buffer.CopyTo(
            new Span<byte>((void*) memPtr, bytes));
        fixed (int* shape_ptr = shape)
        {
            var handle = make_tensor(memPtr, dataType, shape_ptr, shape.Length);
            return (handle, memPtr);
        }
    }

    public static Tensor FromDense<T>(DenseTensor<T> tensor, int[] shape)
        where T : unmanaged
    {
        return MakeTensor<T>(tensor.Buffer.Span, shape);
    }
    
    int ComputeSize(ReadOnlySpan<int> shape)
    {
        return shape.ToArray().Aggregate(1, (x, y) => x * y);
    }
    
    public int Length => ComputeSize(Shape);

    public unsafe DenseTensor<T> ToDense<T>()
        where T : unmanaged
    {
        var t = ToDenseImpl<T>();
        if (typeof(T) == TypeUtil.ToType(DataType))
        {
            return t;
        }
        else
        {
            return ToType(TypeUtil.FromType(typeof(T))).ToDenseImpl<T>();
        }
    }

    private unsafe DenseTensor<T> ToDenseImpl<T>()
    {
        var tensor = new DenseTensor<T>(Length);
        new Span<T>(GetMemory().ToPointer(), Length).CopyTo(tensor.Buffer.Span);
        return tensor;
    }
    
    public unsafe T[] ToArray<T>() where T : unmanaged
    {
        return ToDense<T>().ToArray();
    }

    public Tensor ToType(OrtDataType dataType)
    {
        if (DataType == dataType)
        {
            return this;
        }
        return new Tensor(tensor_to_type(Handle, dataType));
    }

    public void Reshape(int[] shape)
    {
        tensor_reshape(Handle, shape, shape.Length);
    }

    public Tensor BroadcastTo(int[] shape)
    {
        return this + Empty(shape);
    }

    public bool Equals(Tensor? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        if (!(StructuralComparisons.StructuralEqualityComparer.Equals(Shape, other.Shape) 
              && DataType == other.DataType)) return false;
        if (GetMemory() == other.GetMemory()) return true;
        return StructuralComparisons.StructuralEqualityComparer.Equals(BufferToArray(), other.BufferToArray());
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Tensor) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Handle, Mem);
    }
}

public class TensorSeq : IDisposable
{
    IntPtr Handle;
    
    [DllImport("ortki")]
    private static extern void tensor_seq_dispose(IntPtr seq);
    
    [DllImport("ortki")]
    private static extern int tensor_seq_size(IntPtr seq);
    
    [DllImport("ortki")]
    private static extern IntPtr tensor_seq_get_value(IntPtr seq, int index);

    internal Tensor GetValue(int index)
    {
        return new Tensor(tensor_seq_get_value(Handle, index));
    }

    internal TensorSeq(IntPtr handle)
    {
        Handle = handle;
    }
    
    public Tensor[] ToTensorArray()
    {
        return Enumerable.Range(0, tensor_seq_size(Handle)).Select(GetValue).ToArray();
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (Handle != IntPtr.Zero)
        {
            tensor_seq_dispose(Handle);
            Handle = IntPtr.Zero;
        }
    }
}