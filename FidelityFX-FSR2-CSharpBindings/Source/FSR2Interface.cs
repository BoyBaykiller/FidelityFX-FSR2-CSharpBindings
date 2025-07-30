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
            public delegate* unmanaged<Interface*, void*, ErrorCode> FpCreateBackendContext;
            public delegate* unmanaged<Interface*, DeviceCapabilities*, void*, ErrorCode> FpGetDeviceCapabilities;
            public delegate* unmanaged<Interface*, ErrorCode> FpDestroyBackendContext;
            public delegate* unmanaged<Interface*, CreateResourceDescription*, ResourceInternal*, ErrorCode> FpCreateResource;
            public delegate* unmanaged<Interface*, Resource*, ResourceInternal*, ErrorCode> FpRegisterResource;
            public delegate* unmanaged<Interface*, ErrorCode> FpUnregisterResources;
            public delegate* unmanaged<Interface*, ResourceInternal, ResourceDescription> FpGetResourceDescription;
            public delegate* unmanaged<Interface*, ResourceInternal, ErrorCode> FpDestroyResource;
            public delegate* unmanaged<Interface*, Pass, PipelineDescription*, PipelineState*, ErrorCode> FpCreatePipeline;
            public delegate* unmanaged<Interface*, PipelineState*, ErrorCode> FpDestroyPipeline;
            public delegate* unmanaged<Interface*, GpuJobDescription*, ErrorCode> FpScheduleGpuJob;
            public delegate* unmanaged<Interface*, void*, ErrorCode> FpExecuteGpuJobs;

            public void* ScratchBuffer;
            public nuint ScratchBufferSize;
        }
    }
}
