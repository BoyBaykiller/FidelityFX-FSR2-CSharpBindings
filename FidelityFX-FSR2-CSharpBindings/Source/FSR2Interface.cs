using static FFX_FSR2.FSR2Error;
using static FFX_FSR2.FSR2Types;

namespace FFX_FSR2
{
    public static unsafe class FSR2Interface
    {
        public enum Pass
        {
            DepthClip = 0,
            PreviousDepth = 1,
            Lock = 2,
            Accumulate = 3,
            Sharpen = 4,
            RCAS = 5,
            LuminancePyramid = 6,
            Reactive = 7,
            Autogenerate = 8,

            Count
        }

        public enum MsgType
        {
            Error = 0,
            Warning = 1,
            Count
        }

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
