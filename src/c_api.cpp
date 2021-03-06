#include "c_api.h"
#include <core/session/onnxruntime_cxx_api.h>
#include <core/framework/ort_value.h>
#include "operators.h"

using namespace ortki;
OrtKITensor* make_tensor(void *buffer, DataType data_type, const int* shape, int rank)
{
    std::vector<int64_t> shape_vec(shape, shape + rank);
    return new OrtKITensor(buffer, data_type, shape_vec);
}

OrtKITensor* make_tensor_empty(DataType data_type, const int* shape, int rank)
{
    std::vector<int64_t> shape_vec(shape, shape + rank);
    auto size = ComputeSize(shape_vec);
    auto buffer_length = size * GetDataType(data_type)->Size();
    void *buffer = new char[buffer_length];
    memset(buffer, 0, buffer_length);
    auto *tensor = new OrtKITensor(buffer, data_type, shape_vec);
    return tensor;
}

void tensor_dispose(OrtKITensor* t)
{
    delete t;
}

DataType tensor_data_type(OrtKITensor *tensor) { return tensor->data_type(); }

int tensor_rank(OrtKITensor *tensor) { return tensor->shape().size(); }

void tensor_shape(OrtKITensor *tensor, int *output)
{
    auto &&shape = tensor->shape();
    for(int i = 0; i < shape.size(); ++i)
    {
        output[i] = shape[i];
    }
}

void* tensor_buffer(ortki::OrtKITensor *tensor)
{
#define GET_BUFFER(tensor_type, T) \
    case onnx::TensorProto_DataType_##tensor_type: \
        return reinterpret_cast<void*>(tensor->buffer<T>());                \

#define GET_UNIMPL_BUFFER(tensor_type) \
    case onnx::TensorProto_DataType_##tensor_type: \
        throw std::runtime_error("Unimplemented input type in tensor_buffer");
    DATATYPE_TO_T(tensor->data_type(), GET_BUFFER, GET_UNIMPL_BUFFER);
}

ortki::OpExecutor *make_op_executor(const char* name)
{
    return new OpExecutor(name);
}

int tensor_seq_size(ortki::OrtKITensorSeq *seq)
{
    return seq->size();
}

ortki::OrtKITensor * tensor_seq_get_value(ortki::OrtKITensorSeq *seq, int index)
{
    return seq->get_value(index);
}

void tensor_seq_dispose(ortki::OrtKITensorSeq* seq)
{
    delete seq;
}


// onnxruntime::Tensor don't support directly type cast
ortki::OrtKITensor *tensor_to_type(ortki::OrtKITensor *tensor, ortki::DataType dataType)
{
    return ortki_Cast(tensor, dataType);
}

void tensor_reshape(ortki::OrtKITensor *tensor, int *shape, int size)
{
    tensor->reshape(std::vector<int64_t>(shape, shape + size));
}

void op_executor_dispose(ortki::OpExecutor* executor)
{
    delete executor;
}

BFloat16* make_bf16(float v)
{
    return new BFloat16(v);
}

float bf16_to_float(BFloat16* v)
{
    return v->ToFloat();
}

void bf16_dispose(BFloat16* v)
{
    delete v;
}

uint16_t bf16_to_uint16(BFloat16* v)
{
    return v->val;
}

MLFloat16* make_fp16(float v)
{
    return new MLFloat16(v);
}

float fp16_to_float(MLFloat16* v)
{
    return v->ToFloat();
}

void fp16_dispose(MLFloat16* v)
{
    delete v;
}

uint16_t fp16_to_uint16(MLFloat16* v)
{
    return v->val;
}
