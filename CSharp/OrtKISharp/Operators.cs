using System.Runtime.InteropServices;

namespace OrtKISharp;

public partial class OrtKI
{
//This file is automatically generated from the onnx def files via tools/gen_operators.py.
[DllImport("ortki")]
private static extern IntPtr ortki_Abs(IntPtr X);
[DllImport("ortki")]
private static extern IntPtr ortki_Acos(IntPtr input);
[DllImport("ortki")]
private static extern IntPtr ortki_Acosh(IntPtr input);
[DllImport("ortki")]
private static extern IntPtr ortki_Add(IntPtr A, IntPtr B);
[DllImport("ortki")]
private static extern IntPtr ortki_And(IntPtr A, IntPtr B);
[DllImport("ortki")]
private static extern IntPtr ortki_ArgMax(IntPtr data, long axis, long keepdims, long select_last_index);
[DllImport("ortki")]
private static extern IntPtr ortki_ArgMin(IntPtr data, long axis, long keepdims, long select_last_index);
[DllImport("ortki")]
private static extern IntPtr ortki_Asin(IntPtr input);
[DllImport("ortki")]
private static extern IntPtr ortki_Asinh(IntPtr input);
[DllImport("ortki")]
private static extern IntPtr ortki_Atan(IntPtr input);
[DllImport("ortki")]
private static extern IntPtr ortki_Atanh(IntPtr input);
[DllImport("ortki")]
private static extern IntPtr ortki_AveragePool(IntPtr X, String auto_pad, long ceil_mode, long count_include_pad, long[] kernel_shape, int kernel_shape_size, long[] pads, int pads_size, long[] strides, int strides_size);
[DllImport("ortki")]
private static extern IntPtr ortki_BitShift(IntPtr X, IntPtr Y, String direction);
[DllImport("ortki")]
private static extern IntPtr ortki_Cast(IntPtr input, long to);
[DllImport("ortki")]
private static extern IntPtr ortki_Ceil(IntPtr X);
[DllImport("ortki")]
private static extern IntPtr ortki_Celu(IntPtr X, float alpha);
[DllImport("ortki")]
private static extern IntPtr ortki_Clip(IntPtr input, IntPtr min, IntPtr max);
[DllImport("ortki")]
private static extern IntPtr ortki_Compress(IntPtr input, IntPtr condition, long axis);
[DllImport("ortki")]
private static extern IntPtr ortki_Concat(IntPtr[] inputs, int input_size, long axis);
[DllImport("ortki")]
private static extern IntPtr ortki_ConcatFromSequence(IntPtr[] input_sequence, int input_size, long axis, long new_axis);
[DllImport("ortki")]
private static extern IntPtr ortki_Conv(IntPtr X, IntPtr W, IntPtr B, String auto_pad, long[] dilations, int dilations_size, long group, long[] kernel_shape, int kernel_shape_size, long[] pads, int pads_size, long[] strides, int strides_size);
[DllImport("ortki")]
private static extern IntPtr ortki_ConvInteger(IntPtr x, IntPtr w, IntPtr x_zero_point, IntPtr w_zero_point, String auto_pad, long[] dilations, int dilations_size, long group, long[] kernel_shape, int kernel_shape_size, long[] pads, int pads_size, long[] strides, int strides_size);
[DllImport("ortki")]
private static extern IntPtr ortki_ConvTranspose(IntPtr X, IntPtr W, IntPtr B, String auto_pad, long[] dilations, int dilations_size, long group, long[] kernel_shape, int kernel_shape_size, long[] output_padding, int output_padding_size, long[] output_shape, int output_shape_size, long[] pads, int pads_size, long[] strides, int strides_size);
[DllImport("ortki")]
private static extern IntPtr ortki_Cos(IntPtr input);
[DllImport("ortki")]
private static extern IntPtr ortki_Cosh(IntPtr input);
[DllImport("ortki")]
private static extern IntPtr ortki_CumSum(IntPtr x, IntPtr axis, long exclusive, long reverse);
[DllImport("ortki")]
private static extern IntPtr ortki_DepthToSpace(IntPtr input, long blocksize, String mode);
[DllImport("ortki")]
private static extern IntPtr ortki_DequantizeLinear(IntPtr x, IntPtr x_scale, IntPtr x_zero_point, long axis);
[DllImport("ortki")]
private static extern IntPtr ortki_Det(IntPtr X);
[DllImport("ortki")]
private static extern IntPtr ortki_Div(IntPtr A, IntPtr B);
[DllImport("ortki")]
private static extern IntPtr ortki_Dropout(IntPtr data, IntPtr ratio, IntPtr training_mode, long seed);
[DllImport("ortki")]
private static extern IntPtr ortki_DynamicQuantizeLinear(IntPtr x);
[DllImport("ortki")]
private static extern IntPtr ortki_Einsum(IntPtr[] Inputs, int input_size, String equation);
[DllImport("ortki")]
private static extern IntPtr ortki_Elu(IntPtr X, float alpha);
[DllImport("ortki")]
private static extern IntPtr ortki_Equal(IntPtr A, IntPtr B);
[DllImport("ortki")]
private static extern IntPtr ortki_Erf(IntPtr input);
[DllImport("ortki")]
private static extern IntPtr ortki_Exp(IntPtr input);
[DllImport("ortki")]
private static extern IntPtr ortki_Expand(IntPtr input, IntPtr shape);
[DllImport("ortki")]
private static extern IntPtr ortki_EyeLike(IntPtr input, long dtype, long k);
[DllImport("ortki")]
private static extern IntPtr ortki_Flatten(IntPtr input, long axis);
[DllImport("ortki")]
private static extern IntPtr ortki_Floor(IntPtr X);
[DllImport("ortki")]
private static extern IntPtr ortki_GRU(IntPtr X, IntPtr W, IntPtr R, IntPtr B, IntPtr sequence_lens, IntPtr initial_h, float[] activation_alpha, int activation_alpha_size, float[] activation_beta, int activation_beta_size, String[] activations, int activations_size, float clip, String direction, long hidden_size, long layout, long linear_before_reset);
[DllImport("ortki")]
private static extern IntPtr ortki_Gather(IntPtr data, IntPtr indices, long axis);
[DllImport("ortki")]
private static extern IntPtr ortki_GatherElements(IntPtr data, IntPtr indices, long axis);
[DllImport("ortki")]
private static extern IntPtr ortki_GatherND(IntPtr data, IntPtr indices, long batch_dims);
[DllImport("ortki")]
private static extern IntPtr ortki_Gemm(IntPtr A, IntPtr B, IntPtr C, float alpha, float beta, long transA, long transB);
[DllImport("ortki")]
private static extern IntPtr ortki_GlobalAveragePool(IntPtr X);
[DllImport("ortki")]
private static extern IntPtr ortki_GlobalLpPool(IntPtr X, long p);
[DllImport("ortki")]
private static extern IntPtr ortki_GlobalMaxPool(IntPtr X);
[DllImport("ortki")]
private static extern IntPtr ortki_Greater(IntPtr A, IntPtr B);
[DllImport("ortki")]
private static extern IntPtr ortki_GreaterOrEqual(IntPtr A, IntPtr B);
[DllImport("ortki")]
private static extern IntPtr ortki_HardSigmoid(IntPtr X, float alpha, float beta);
[DllImport("ortki")]
private static extern IntPtr ortki_HardSwish(IntPtr X);
[DllImport("ortki")]
private static extern IntPtr ortki_Hardmax(IntPtr input, long axis);
[DllImport("ortki")]
private static extern IntPtr ortki_Identity(IntPtr input);
[DllImport("ortki")]
private static extern IntPtr ortki_InstanceNormalization(IntPtr input, IntPtr scale, IntPtr B, float epsilon);
[DllImport("ortki")]
private static extern IntPtr ortki_IsInf(IntPtr X, long detect_negative, long detect_positive);
[DllImport("ortki")]
private static extern IntPtr ortki_IsNaN(IntPtr X);
[DllImport("ortki")]
private static extern IntPtr ortki_LRN(IntPtr X, float alpha, float beta, float bias, long size);
[DllImport("ortki")]
private static extern IntPtr ortki_LSTM(IntPtr X, IntPtr W, IntPtr R, IntPtr B, IntPtr sequence_lens, IntPtr initial_h, IntPtr initial_c, IntPtr P, float[] activation_alpha, int activation_alpha_size, float[] activation_beta, int activation_beta_size, String[] activations, int activations_size, float clip, String direction, long hidden_size, long input_forget, long layout);
[DllImport("ortki")]
private static extern IntPtr ortki_LeakyRelu(IntPtr X, float alpha);
[DllImport("ortki")]
private static extern IntPtr ortki_Less(IntPtr A, IntPtr B);
[DllImport("ortki")]
private static extern IntPtr ortki_LessOrEqual(IntPtr A, IntPtr B);
[DllImport("ortki")]
private static extern IntPtr ortki_Log(IntPtr input);
[DllImport("ortki")]
private static extern IntPtr ortki_LogSoftmax(IntPtr input, long axis);
[DllImport("ortki")]
private static extern IntPtr ortki_LpNormalization(IntPtr input, long axis, long p);
[DllImport("ortki")]
private static extern IntPtr ortki_LpPool(IntPtr X, String auto_pad, long[] kernel_shape, int kernel_shape_size, long p, long[] pads, int pads_size, long[] strides, int strides_size);
[DllImport("ortki")]
private static extern IntPtr ortki_MatMul(IntPtr A, IntPtr B);
[DllImport("ortki")]
private static extern IntPtr ortki_MatMulInteger(IntPtr A, IntPtr B, IntPtr a_zero_point, IntPtr b_zero_point);
[DllImport("ortki")]
private static extern IntPtr ortki_Max(IntPtr[] data_0, int input_size);
[DllImport("ortki")]
private static extern IntPtr ortki_MaxPool(IntPtr X, String auto_pad, long ceil_mode, long[] dilations, int dilations_size, long[] kernel_shape, int kernel_shape_size, long[] pads, int pads_size, long storage_order, long[] strides, int strides_size);
[DllImport("ortki")]
private static extern IntPtr ortki_MaxRoiPool(IntPtr X, IntPtr rois, long[] pooled_shape, int pooled_shape_size, float spatial_scale);
[DllImport("ortki")]
private static extern IntPtr ortki_MaxUnpool(IntPtr X, IntPtr I, IntPtr output_shape, long[] kernel_shape, int kernel_shape_size, long[] pads, int pads_size, long[] strides, int strides_size);
[DllImport("ortki")]
private static extern IntPtr ortki_Mean(IntPtr[] data_0, int input_size);
[DllImport("ortki")]
private static extern IntPtr ortki_MeanVarianceNormalization(IntPtr X, long[] axes, int axes_size);
[DllImport("ortki")]
private static extern IntPtr ortki_Min(IntPtr[] data_0, int input_size);
[DllImport("ortki")]
private static extern IntPtr ortki_Mod(IntPtr A, IntPtr B, long fmod);
[DllImport("ortki")]
private static extern IntPtr ortki_Mul(IntPtr A, IntPtr B);
[DllImport("ortki")]
private static extern IntPtr ortki_Multinomial(IntPtr input, long dtype, long sample_size, float seed);
[DllImport("ortki")]
private static extern IntPtr ortki_Neg(IntPtr X);
[DllImport("ortki")]
private static extern IntPtr ortki_NegativeLogLikelihoodLoss(IntPtr input, IntPtr target, IntPtr weight, long ignore_index, String reduction);
[DllImport("ortki")]
private static extern IntPtr ortki_NonMaxSuppression(IntPtr boxes, IntPtr scores, IntPtr max_output_boxes_per_class, IntPtr iou_threshold, IntPtr score_threshold, long center_point_box);
[DllImport("ortki")]
private static extern IntPtr ortki_NonZero(IntPtr X);
[DllImport("ortki")]
private static extern IntPtr ortki_Not(IntPtr X);
[DllImport("ortki")]
private static extern IntPtr ortki_OneHot(IntPtr indices, IntPtr depth, IntPtr values, long axis);
[DllImport("ortki")]
private static extern IntPtr ortki_Or(IntPtr A, IntPtr B);
[DllImport("ortki")]
private static extern IntPtr ortki_PRelu(IntPtr X, IntPtr slope);
[DllImport("ortki")]
private static extern IntPtr ortki_Pad(IntPtr data, IntPtr pads, IntPtr constant_value, String mode);
[DllImport("ortki")]
private static extern IntPtr ortki_Pow(IntPtr X, IntPtr Y);
[DllImport("ortki")]
private static extern IntPtr ortki_QLinearConv(IntPtr x, IntPtr x_scale, IntPtr x_zero_point, IntPtr w, IntPtr w_scale, IntPtr w_zero_point, IntPtr y_scale, IntPtr y_zero_point, IntPtr B, String auto_pad, long[] dilations, int dilations_size, long group, long[] kernel_shape, int kernel_shape_size, long[] pads, int pads_size, long[] strides, int strides_size);
[DllImport("ortki")]
private static extern IntPtr ortki_QLinearMatMul(IntPtr a, IntPtr a_scale, IntPtr a_zero_point, IntPtr b, IntPtr b_scale, IntPtr b_zero_point, IntPtr y_scale, IntPtr y_zero_point);
[DllImport("ortki")]
private static extern IntPtr ortki_QuantizeLinear(IntPtr x, IntPtr y_scale, IntPtr y_zero_point, long axis);
[DllImport("ortki")]
private static extern IntPtr ortki_RNN(IntPtr X, IntPtr W, IntPtr R, IntPtr B, IntPtr sequence_lens, IntPtr initial_h, float[] activation_alpha, int activation_alpha_size, float[] activation_beta, int activation_beta_size, String[] activations, int activations_size, float clip, String direction, long hidden_size, long layout);
[DllImport("ortki")]
private static extern IntPtr ortki_RandomNormal(long dtype, float mean, float scale, float seed, long[] shape, int shape_size);
[DllImport("ortki")]
private static extern IntPtr ortki_RandomNormalLike(IntPtr input, long dtype, float mean, float scale, float seed);
[DllImport("ortki")]
private static extern IntPtr ortki_RandomUniform(long dtype, float high, float low, float seed, long[] shape, int shape_size);
[DllImport("ortki")]
private static extern IntPtr ortki_RandomUniformLike(IntPtr input, long dtype, float high, float low, float seed);
[DllImport("ortki")]
private static extern IntPtr ortki_Range(IntPtr start, IntPtr limit, IntPtr delta);
[DllImport("ortki")]
private static extern IntPtr ortki_Reciprocal(IntPtr X);
[DllImport("ortki")]
private static extern IntPtr ortki_ReduceL1(IntPtr data, long[] axes, int axes_size, long keepdims);
[DllImport("ortki")]
private static extern IntPtr ortki_ReduceL2(IntPtr data, long[] axes, int axes_size, long keepdims);
[DllImport("ortki")]
private static extern IntPtr ortki_ReduceLogSum(IntPtr data, long[] axes, int axes_size, long keepdims);
[DllImport("ortki")]
private static extern IntPtr ortki_ReduceLogSumExp(IntPtr data, long[] axes, int axes_size, long keepdims);
[DllImport("ortki")]
private static extern IntPtr ortki_ReduceMax(IntPtr data, long[] axes, int axes_size, long keepdims);
[DllImport("ortki")]
private static extern IntPtr ortki_ReduceMean(IntPtr data, long[] axes, int axes_size, long keepdims);
[DllImport("ortki")]
private static extern IntPtr ortki_ReduceMin(IntPtr data, long[] axes, int axes_size, long keepdims);
[DllImport("ortki")]
private static extern IntPtr ortki_ReduceProd(IntPtr data, long[] axes, int axes_size, long keepdims);
[DllImport("ortki")]
private static extern IntPtr ortki_ReduceSum(IntPtr data, IntPtr axes, long keepdims, long noop_with_empty_axes);
[DllImport("ortki")]
private static extern IntPtr ortki_ReduceSumSquare(IntPtr data, long[] axes, int axes_size, long keepdims);
[DllImport("ortki")]
private static extern IntPtr ortki_Relu(IntPtr X);
[DllImport("ortki")]
private static extern IntPtr ortki_Reshape(IntPtr data, IntPtr shape, long allowzero);
[DllImport("ortki")]
private static extern IntPtr ortki_ReverseSequence(IntPtr input, IntPtr sequence_lens, long batch_axis, long time_axis);
[DllImport("ortki")]
private static extern IntPtr ortki_RoiAlign(IntPtr X, IntPtr rois, IntPtr batch_indices, String mode, long output_height, long output_width, long sampling_ratio, float spatial_scale);
[DllImport("ortki")]
private static extern IntPtr ortki_Round(IntPtr X);
[DllImport("ortki")]
private static extern IntPtr ortki_Scatter(IntPtr data, IntPtr indices, IntPtr updates, long axis);
[DllImport("ortki")]
private static extern IntPtr ortki_ScatterElements(IntPtr data, IntPtr indices, IntPtr updates, long axis);
[DllImport("ortki")]
private static extern IntPtr ortki_ScatterND(IntPtr data, IntPtr indices, IntPtr updates);
[DllImport("ortki")]
private static extern IntPtr ortki_Selu(IntPtr X, float alpha, float gamma);
[DllImport("ortki")]
private static extern IntPtr ortki_SequenceAt(IntPtr[] input_sequence, int input_size, IntPtr position);
[DllImport("ortki")]
private static extern IntPtr ortki_SequenceConstruct(IntPtr[] inputs, int input_size);
[DllImport("ortki")]
private static extern IntPtr ortki_SequenceEmpty(long dtype);
[DllImport("ortki")]
private static extern IntPtr ortki_SequenceErase(IntPtr[] input_sequence, int input_size, IntPtr position);
[DllImport("ortki")]
private static extern IntPtr ortki_SequenceInsert(IntPtr[] input_sequence, int input_size, IntPtr tensor, IntPtr position);
[DllImport("ortki")]
private static extern IntPtr ortki_SequenceLength(IntPtr[] input_sequence, int input_size);
[DllImport("ortki")]
private static extern IntPtr ortki_Shape(IntPtr data);
[DllImport("ortki")]
private static extern IntPtr ortki_Shrink(IntPtr input, float bias, float lambd);
[DllImport("ortki")]
private static extern IntPtr ortki_Sigmoid(IntPtr X);
[DllImport("ortki")]
private static extern IntPtr ortki_Sign(IntPtr input);
[DllImport("ortki")]
private static extern IntPtr ortki_Sin(IntPtr input);
[DllImport("ortki")]
private static extern IntPtr ortki_Sinh(IntPtr input);
[DllImport("ortki")]
private static extern IntPtr ortki_Size(IntPtr data);
[DllImport("ortki")]
private static extern IntPtr ortki_Slice(IntPtr data, IntPtr starts, IntPtr ends, IntPtr axes, IntPtr steps);
[DllImport("ortki")]
private static extern IntPtr ortki_Softmax(IntPtr input, long axis);
[DllImport("ortki")]
private static extern IntPtr ortki_SoftmaxCrossEntropyLoss(IntPtr scores, IntPtr labels, IntPtr weights, long ignore_index, String reduction);
[DllImport("ortki")]
private static extern IntPtr ortki_Softplus(IntPtr X);
[DllImport("ortki")]
private static extern IntPtr ortki_Softsign(IntPtr input);
[DllImport("ortki")]
private static extern IntPtr ortki_SpaceToDepth(IntPtr input, long blocksize);
[DllImport("ortki")]
private static extern IntPtr ortki_SplitToSequence(IntPtr input, IntPtr split, long axis, long keepdims);
[DllImport("ortki")]
private static extern IntPtr ortki_Sqrt(IntPtr X);
[DllImport("ortki")]
private static extern IntPtr ortki_Squeeze(IntPtr data, IntPtr axes);
[DllImport("ortki")]
private static extern IntPtr ortki_StringNormalizer(IntPtr X, String case_change_action, long is_case_sensitive, String locale, String[] stopwords, int stopwords_size);
[DllImport("ortki")]
private static extern IntPtr ortki_Sub(IntPtr A, IntPtr B);
[DllImport("ortki")]
private static extern IntPtr ortki_Sum(IntPtr[] data_0, int input_size);
[DllImport("ortki")]
private static extern IntPtr ortki_Tan(IntPtr input);
[DllImport("ortki")]
private static extern IntPtr ortki_Tanh(IntPtr input);
[DllImport("ortki")]
private static extern IntPtr ortki_TfIdfVectorizer(IntPtr X, long max_gram_length, long max_skip_count, long min_gram_length, String mode, long[] ngram_counts, int ngram_counts_size, long[] ngram_indexes, int ngram_indexes_size, long[] pool_int64s, int pool_int64s_size, String[] pool_strings, int pool_strings_size, float[] weights, int weights_size);
[DllImport("ortki")]
private static extern IntPtr ortki_ThresholdedRelu(IntPtr X, float alpha);
[DllImport("ortki")]
private static extern IntPtr ortki_Tile(IntPtr input, IntPtr repeats);
[DllImport("ortki")]
private static extern IntPtr ortki_TopK(IntPtr X, IntPtr K, long axis, long largest, long sorted);
[DllImport("ortki")]
private static extern IntPtr ortki_Transpose(IntPtr data, long[] perm, int perm_size);
[DllImport("ortki")]
private static extern IntPtr ortki_Trilu(IntPtr input, IntPtr k, long upper);
[DllImport("ortki")]
private static extern IntPtr ortki_Unique(IntPtr X, long axis, long sorted);
[DllImport("ortki")]
private static extern IntPtr ortki_Unsqueeze(IntPtr data, IntPtr axes);
[DllImport("ortki")]
private static extern IntPtr ortki_Upsample(IntPtr X, IntPtr scales, String mode);
[DllImport("ortki")]
private static extern IntPtr ortki_Where(IntPtr condition, IntPtr X, IntPtr Y);
[DllImport("ortki")]
private static extern IntPtr ortki_Xor(IntPtr A, IntPtr B);
[DllImport("ortki")]
private static extern IntPtr ortki_ArrayFeatureExtractor(IntPtr X, IntPtr Y);
[DllImport("ortki")]
private static extern IntPtr ortki_Binarizer(IntPtr X, float threshold);
[DllImport("ortki")]
private static extern IntPtr ortki_CastMap(IntPtr X, String cast_to, String map_form, long max_map);
[DllImport("ortki")]
private static extern IntPtr ortki_CategoryMapper(IntPtr X, long[] cats_int64s, int cats_int64s_size, String[] cats_strings, int cats_strings_size, long default_int64, String default_string);
[DllImport("ortki")]
private static extern IntPtr ortki_DictVectorizer(IntPtr X, long[] int64_vocabulary, int int64_vocabulary_size, String[] string_vocabulary, int string_vocabulary_size);
[DllImport("ortki")]
private static extern IntPtr ortki_FeatureVectorizer(IntPtr[] X, int input_size, long[] inputdimensions, int inputdimensions_size);
[DllImport("ortki")]
private static extern IntPtr ortki_Imputer(IntPtr X, float[] imputed_value_floats, int imputed_value_floats_size, long[] imputed_value_int64s, int imputed_value_int64s_size, float replaced_value_float, long replaced_value_int64);
[DllImport("ortki")]
private static extern IntPtr ortki_LabelEncoder(IntPtr X, float default_float, long default_int64, String default_string, float[] keys_floats, int keys_floats_size, long[] keys_int64s, int keys_int64s_size, String[] keys_strings, int keys_strings_size, float[] values_floats, int values_floats_size, long[] values_int64s, int values_int64s_size, String[] values_strings, int values_strings_size);
[DllImport("ortki")]
private static extern IntPtr ortki_LinearClassifier(IntPtr X, long[] classlabels_ints, int classlabels_ints_size, String[] classlabels_strings, int classlabels_strings_size, float[] coefficients, int coefficients_size, float[] intercepts, int intercepts_size, long multi_class, String post_transform);
[DllImport("ortki")]
private static extern IntPtr ortki_LinearRegressor(IntPtr X, float[] coefficients, int coefficients_size, float[] intercepts, int intercepts_size, String post_transform, long targets);
[DllImport("ortki")]
private static extern IntPtr ortki_Normalizer(IntPtr X, String norm);
[DllImport("ortki")]
private static extern IntPtr ortki_OneHotEncoder(IntPtr X, long[] cats_int64s, int cats_int64s_size, String[] cats_strings, int cats_strings_size, long zeros);
[DllImport("ortki")]
private static extern IntPtr ortki_SVMClassifier(IntPtr X, long[] classlabels_ints, int classlabels_ints_size, String[] classlabels_strings, int classlabels_strings_size, float[] coefficients, int coefficients_size, float[] kernel_params, int kernel_params_size, String kernel_type, String post_transform, float[] prob_a, int prob_a_size, float[] prob_b, int prob_b_size, float[] rho, int rho_size, float[] support_vectors, int support_vectors_size, long[] vectors_per_class, int vectors_per_class_size);
[DllImport("ortki")]
private static extern IntPtr ortki_SVMRegressor(IntPtr X, float[] coefficients, int coefficients_size, float[] kernel_params, int kernel_params_size, String kernel_type, long n_supports, long one_class, String post_transform, float[] rho, int rho_size, float[] support_vectors, int support_vectors_size);
[DllImport("ortki")]
private static extern IntPtr ortki_Scaler(IntPtr X, float[] offset, int offset_size, float[] scale, int scale_size);
[DllImport("ortki")]
private static extern IntPtr ortki_TreeEnsembleClassifier(IntPtr X, float[] base_values, int base_values_size, long[] class_ids, int class_ids_size, long[] class_nodeids, int class_nodeids_size, long[] class_treeids, int class_treeids_size, float[] class_weights, int class_weights_size, long[] classlabels_int64s, int classlabels_int64s_size, String[] classlabels_strings, int classlabels_strings_size, long[] nodes_falsenodeids, int nodes_falsenodeids_size, long[] nodes_featureids, int nodes_featureids_size, float[] nodes_hitrates, int nodes_hitrates_size, long[] nodes_missing_value_tracks_true, int nodes_missing_value_tracks_true_size, String[] nodes_modes, int nodes_modes_size, long[] nodes_nodeids, int nodes_nodeids_size, long[] nodes_treeids, int nodes_treeids_size, long[] nodes_truenodeids, int nodes_truenodeids_size, float[] nodes_values, int nodes_values_size, String post_transform);
[DllImport("ortki")]
private static extern IntPtr ortki_TreeEnsembleRegressor(IntPtr X, String aggregate_function, float[] base_values, int base_values_size, long n_targets, long[] nodes_falsenodeids, int nodes_falsenodeids_size, long[] nodes_featureids, int nodes_featureids_size, float[] nodes_hitrates, int nodes_hitrates_size, long[] nodes_missing_value_tracks_true, int nodes_missing_value_tracks_true_size, String[] nodes_modes, int nodes_modes_size, long[] nodes_nodeids, int nodes_nodeids_size, long[] nodes_treeids, int nodes_treeids_size, long[] nodes_truenodeids, int nodes_truenodeids_size, float[] nodes_values, int nodes_values_size, String post_transform, long[] target_ids, int target_ids_size, long[] target_nodeids, int target_nodeids_size, long[] target_treeids, int target_treeids_size, float[] target_weights, int target_weights_size);
[DllImport("ortki")]
private static extern IntPtr ortki_ZipMap(IntPtr X, long[] classlabels_int64s, int classlabels_int64s_size, String[] classlabels_strings, int classlabels_strings_size);
[DllImport("ortki")]
private static extern IntPtr ortki_Adagrad(IntPtr R, IntPtr T, IntPtr inputs, float decay_factor, float epsilon, float norm_coefficient);
[DllImport("ortki")]
private static extern IntPtr ortki_Adam(IntPtr R, IntPtr T, IntPtr inputs, float alpha, float beta, float epsilon, float norm_coefficient, float norm_coefficient_post);
[DllImport("ortki")]
private static extern IntPtr ortki_Gradient(IntPtr[] Inputs, int input_size, String[] xs, int xs_size, String y, String[] zs, int zs_size);
[DllImport("ortki")]
private static extern IntPtr ortki_Momentum(IntPtr R, IntPtr T, IntPtr inputs, float alpha, float beta, String mode, float norm_coefficient);
}