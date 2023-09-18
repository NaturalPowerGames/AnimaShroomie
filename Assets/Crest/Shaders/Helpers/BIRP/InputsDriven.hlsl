// Crest Ocean System

// This file is subject to the MIT License as seen in the root of this folder structure (LICENSE)

// Defines missing inputs.

float4x4 _InvViewProjection;
float4x4 _InvViewProjectionRight;

#if defined(STEREO_INSTANCING_ON) || defined(STEREO_MULTIVIEW_ON)
#define UNITY_MATRIX_I_VP (unity_StereoEyeIndex == 0 ? _InvViewProjection : _InvViewProjectionRight)
#else
#define UNITY_MATRIX_I_VP _InvViewProjection
#endif
