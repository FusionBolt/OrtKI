using System;
using System.Linq;
using System.Runtime.InteropServices;
using OrtKISharp;
using Xunit;

namespace OrtKITest;

public class TensorTest
{
    [Fact]
    public void TestConstructor()
    {
        var expect = new[] {1, 3};
        var shape = new[] {2};
        var t1 = Tensor.MakeTensor(new[] {1, 3}, shape);
        Assert.Equal(expect, t1.ToArray<int>());
        
        var bytes = MemoryMarshal.AsBytes(
            new ReadOnlySpan<int>(new[] {1, 3}));
        var t2 = new Tensor(bytes, OrtDataType.Int32, shape);
        Assert.Equal(expect, t2.ToArray<int>());
        // var t2 Tensor.MakeTensor(new[] {1, 3}, )
        // var span = new[] {1, 3}.AsMemory();
        // var t3 = new Tensor(span, OrtDataType.Int32, new []{2})
    }
    
    [Fact]
    public void TestAttribute()
    {
        var tensor = Tensor.MakeTensor(new[] {1, 3, 4, 2, 5, 6}, new[] {2, 3});
        Assert.Equal(OrtDataType.Int32, tensor.DataType);
        Assert.Equal(2, tensor.Rank);
        Assert.Equal(new[] {2, 3}, tensor.Shape);
        Assert.Equal(new[] {1, 3, 4, 2, 5, 6}, tensor.ToDense<int>().ToArray());
    }

    [Fact]
    public void TestForCompute()
    {
        var tensor1 = Tensor.MakeTensor(new[] {1, 2, 3}, new[] {3});
        var tensor2 = Tensor.MakeTensor(new[] {2, 2, 3}, new[] {3});
        var result = tensor1 + tensor2;
        Assert.Equal(new[] {3, 4, 6}, result.ToDense<int>().ToArray());
    }

    [Fact]
    public void TestEmptyTensor()
    {
        var t = Tensor.Empty(new[] {2, 2, 1}, OrtDataType.Int32);
        Assert.Equal(new[] {0, 0, 0, 0}, t.ToArray<int>());
    }

    [Fact]
    public void TestEmptyArrToTensor()
    {
        var t = Tensor.MakeTensor(Array.Empty<float>());
        Assert.Equal(t.Shape, new[] {0});
        Assert.Equal(t.DataType, OrtDataType.Float);
    }

    [Fact]
    public void TestScalar()
    {
        var t = Tensor.FromScalar(1f);
        var n = t + 1f;
        Assert.Equal(1, t.Length);
        Assert.Equal(OrtDataType.Float, t.DataType);
    }

    [Fact]
    public void TestToDiffTypeArray()
    {
        var t = Tensor.MakeTensor(new long[] {1, 2, 3});
        Assert.Equal(new[] {1, 2, 3}, t.ToArray<int>());
    }

    [Fact]
    public void TestTensorCompare()
    {
        var t1 = Tensor.MakeTensor(new long[] {1, 2, 3}); 
        var t2 = Tensor.MakeTensor(new long[] {1, 2, 3});
        Assert.Equal(t1, t2);
    }

    [Fact]
    public void TestEmptyShape()
    {
        var t = Tensor.MakeTensor(new[] {2});
        t.Reshape(Array.Empty<int>());
        Assert.Equal(t.Shape, Array.Empty<int>());
        
        var t1 = Tensor.MakeTensor(new[] {1}, new int[] { });
        var s = t1.Shape;
        var n = t1 + t1;
        Assert.Equal(n.Shape, Array.Empty<int>());
    }
}