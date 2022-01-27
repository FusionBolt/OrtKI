#pragma once

#include "op_executor.h"
#include "common.h"

namespace ort_ki {
    template<typename SrcType, typename DestType>
    void Cast(SrcType *input, std::vector<int> dimensions, DestType *output, int opset = DEFAULT_OPSET) {
        auto size = std::accumulate(dimensions.begin(), dimensions.end(), 1, std::multiplies<int>());
        ort_ki::OpExecutor op("Cast", opset);
        op.AddAttribute<int64_t>("to", utils::ToTensorProtoElementType<DstType>());
        op.AddInput<SrcType>("input", dimensions, input.data(), size * sizeof(SrcType));
        op.AddOutput<DstType>("output", dimensions, output.data(), size * sizeof(DestType));
        op.Run();
    }
}