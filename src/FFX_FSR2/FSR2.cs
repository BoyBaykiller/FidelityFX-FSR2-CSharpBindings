using System.Runtime.InteropServices;

using static FFX_FSR2.FSR2Error;
using static FFX_FSR2.FSR2Interface;
using static FFX_FSR2.FSR2Types;

namespace FFX_FSR2
{
    public static unsafe partial class FSR2
    {
#if DEBUG
        private const string LIBARY_NAME = "C:/Programming/VS/FidelityFX-FSR2/bin/FFX_FSR2_api_x64d";
#else
        private const string LIBARY_NAME = "C:/Programming/VS/FidelityFX-FSR2/bin/FFX_FSR2_api_x64";
#endif

        public const int FFX_FSR2_CONTEXT_SIZE = 16536;

        public enum QualityMode
        {
            Quality = 1,
            Balanced = 2,
            Performance = 3,
            UltraPerformance = 4
        }

        public enum InitializationFlagBits : uint
        {
            EnableHighDynamicRange = (1 << 0),
            EnableDisplayResolutionMotionVectors = (1 << 1),
            EnableMotionVectorsJitterCancellation = (1 << 2),
            EnableDepthInverted = (1 << 3),
            EnableDepthInfinite = (1 << 4),
            EnableAutoExposure = (1 << 5),
            EnableDynamicResolution = (1 << 6),
            EnableTexture1DUsage = (1 << 7),
            EnableDebugChecking = (1 << 8),
            AllowNullDeviceAndCommandList = (1 << 9)
        }

        public delegate void DelegateMessage(MsgType type, [MarshalAs(UnmanagedType.LPWStr)] string message);

        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct ContextDescription
        {
            public InitializationFlagBits Flags;
            public Dimensions2D MaxRenderSize;
            public Dimensions2D DisplaySize;
            public Interface Callbacks;
            public void* Device;

            public delegate* unmanaged<MsgType, string, void> FpMessage;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct DispatchDescription
        {
            public void* CommandList;
            public Resource Color;
            public Resource Depth;
            public Resource MotionVectors;
            public Resource Exposure;
            public Resource Reactive;
            public Resource TransparencyAndComposition;
            public Resource Output;
            public FloatCoords2D JitterOffset;
            public FloatCoords2D MotionVectorScale;
            public Dimensions2D RenderSize;
            public byte EnableSharpening;
            public float Sharpness;
            public float FrameTimeDelta;
            public float PreExposure;
            public byte Reset;
            public float CameraNear;
            public float CameraFar;
            public float CameraFovAngleVertical;
            public float ViewSpaceToMetersFactor;
            public byte DeviceDepthNegativeOneToOne;

            // EXPERIMENTAL eactive mask generation parameters
            public byte EnableAutoReactive;
            public Resource ColorOpaqueOnly;
            public float AutoTcThreshold;
            public float AutoTcScale;
            public float AutoReactiveScale;
            public float AutoReactiveMax;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public unsafe struct GenerateReactiveDescription
        {
            public void* CommandList;
            public Resource ColorOpaqueOnly;
            public Resource ColorPreUpscale;
            public Resource OutReactive;
            public Dimensions2D RenderSize;
            public float Scale;
            public float CutoffThreshold;
            public float BinaryValue;
            public uint Flags;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct Context
        {
            public fixed uint Data[FFX_FSR2_CONTEXT_SIZE];
        }


        [LibraryImport(LIBARY_NAME, EntryPoint = "ffxFsr2ContextCreate")]
        public static partial ErrorCode ContextCreate(out Context context, in ContextDescription contextDescription);


        [LibraryImport(LIBARY_NAME, EntryPoint = "ffxFsr2ContextDispatch")]
        public static partial ErrorCode ContextDispatch(ref Context context, in DispatchDescription dispatchDescription);


        [LibraryImport(LIBARY_NAME, EntryPoint = "ffxFsr2ContextDestroy")]
        public static partial ErrorCode ContextDestroy(ref Context context);


        [LibraryImport(LIBARY_NAME, EntryPoint = "ffxFsr2GetUpscaleRatioFromQualityMode")]
        public static partial float GetUpscaleRatioFromQualityMode(QualityMode qualityMode);


        [LibraryImport(LIBARY_NAME, EntryPoint = "ffxFsr2GetRenderResolutionFromQualityMode")]
        public static partial ErrorCode GetRenderResolutionFromQualityMode(out uint renderWidth, out uint renderHeight, uint displayWidth, uint displayHeight, QualityMode qualityMode);


        [LibraryImport(LIBARY_NAME, EntryPoint = "ffxFsr2GetJitterPhaseCount")]
        public static partial int GetJitterPhaseCount(int renderWidth, int displayWidth);


        [LibraryImport(LIBARY_NAME, EntryPoint = "ffxFsr2GetJitterOffset")]
        public static partial ErrorCode GetJitterOffset(out float outX, out float outY, int index, int phaseCount);
    }
}