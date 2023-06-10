using System.Runtime.InteropServices;
using static FFX_FSR2.FSR2Error;
using static FFX_FSR2.FSR2Types;

namespace FFX_FSR2
{
    public static unsafe class FSR2Interface
    {
        public enum Pass
        {
            FFX_FSR2_PASS_DEPTH_CLIP = 0,
            FFX_FSR2_PASS_RECONSTRUCT_PREVIOUS_DEPTH = 1,
            FFX_FSR2_PASS_LOCK = 2,
            FFX_FSR2_PASS_ACCUMULATE = 3,
            FFX_FSR2_PASS_ACCUMULATE_SHARPEN = 4,
            FFX_FSR2_PASS_RCAS = 5,
            FFX_FSR2_PASS_COMPUTE_LUMINANCE_PYRAMID = 6,
            FFX_FSR2_PASS_GENERATE_REACTIVE = 7,
            FFX_FSR2_PASS_TCR_AUTOGENERATE = 8,

            FFX_FSR2_PASS_COUNT
        }

        public enum MsgType
        {
            FFX_FSR2_MESSAGE_TYPE_ERROR = 0,
            FFX_FSR2_MESSAGE_TYPE_WARNING = 1,
            FFX_FSR2_MESSAGE_TYPE_COUNT
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct Interface
        {
            public delegate* unmanaged<ref Interface, void*, ErrorCode> FpCreateBackendContext;
            public delegate* unmanaged<ref Interface, ref DeviceCapabilities, void*, ErrorCode> FpGetDeviceCapabilities;
            public delegate* unmanaged<ref Interface, ErrorCode> FpDestroyBackendContext;
            public delegate* unmanaged<ref Interface, in CreateResourceDescription, ref ResourceInternal, ErrorCode> FpCreateResource;
            public delegate* unmanaged<ref Interface, in Resource, ref ResourceInternal, ErrorCode> FpRegisterResource;
            public delegate* unmanaged<ref Interface, ErrorCode> FpUnregisterResources;
            public delegate* unmanaged<ref Interface, ResourceInternal, ResourceDescription> FpGetResourceDescription;
            public delegate* unmanaged<ref Interface, ResourceInternal, ErrorCode> FpDestroyResource;
            public delegate* unmanaged<ref Interface, Pass, in PipelineDescription, ref PipelineState, ErrorCode> FpCreatePipeline;
            public delegate* unmanaged<ref Interface, ref PipelineState, ErrorCode> FpDestroyPipeline;
            public delegate* unmanaged<ref Interface, in GpuJobDescription, ErrorCode> FpScheduleGpuJob;
            public delegate* unmanaged<ref Interface, void*, ErrorCode> FpExecuteGpuJobs;

            public void* ScratchBuffer;
            public nuint ScratchBufferSize;
        }

    }
}
