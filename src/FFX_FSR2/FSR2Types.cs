using System.Runtime.InteropServices;

namespace FFX_FSR2
{
    public static unsafe class FSR2Types
    {
        public const int MAX_NUM_SRVS = 16;
        public const int MAX_NUM_UAVS = 8;
        public const int MAX_NUM_CONST_BUFFERS = 2;
        public const int MAX_CONST_SIZE = 64;

        public enum SurfaceFormat
        {
            Unknown,
            R32G32B32A32Typeless,
            R32G32B32A32Float,
            R16G16B16A16Float,
            R16G16B16A16Unorm,
            R32G32Float,
            R32Uint,
            R8G8B8A8Typeless,
            R8G8B8A8Unorm,
            R11G11B10Float,
            R16G16Float,
            R16G16Uint,
            R16Float,
            R16Uint,
            R16Unorm,
            R16Snorm,
            R8Unorm,
            R8Uint,
            R8G8Unorm,
            R32Float
        }

        public enum ResourceUsage
        {
            ReadOnly = 0,
            Rendertarget = (1 << 0),
            UAV = (1 << 1),
        }

        public enum ResourceStates
        {
            UnorderedAccess = (1 << 0),
            ComputeRead = (1 << 1),
            CopySrc = (1 << 2),
            CopyDest = (1 << 3),
            GenericRead = (CopySrc | ComputeRead),
        }

        public enum ResourceFlags
        {
            None = 0,
            Aliasable = (1 << 0),
        }

        public enum FilterType
        {
            Point,
            Linear
        }

        public enum ShaderModel
        {
            Model5_1,
            Model6_0,
            Model6_1,
            Model6_2,
            Model6_3,
            Model6_4,
            Model6_5,
            Model6_6,
            Model6_7,
        }

        public enum ResourceType
        {
            Buffer,
            Texture1D,
            Texture2D,
            Texture3D,
        }

        public enum HeapType
        {
            Default = 0,
            Upload
        }

        public enum GpuJobType
        {
            ClearFloat = 0,
            Copy = 1,
            Compute = 2,
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct DeviceCapabilities
        {
            public ShaderModel MinimumSupportedShaderModel;
            public uint WaveLaneCountMin;
            public uint WaveLaneCountMax;
            public byte Fp16Supported;
            public byte RaytracingSupported;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct Dimensions2D
        {
            public uint Width;
            public uint Height;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct FloatCoords2D
        {
            public float X;
            public float Y;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct ResourceDescription
        {
            public ResourceType Type;
            public SurfaceFormat Format;
            public uint Width;
            public uint Height;
            public uint Depth;
            public uint MipCount;
            public ResourceFlags Flags;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct Resource
        {
            public void* _Resource;
            public fixed ushort Name[64];
            public ResourceDescription Description;
            public ResourceStates State;
            public byte IsDepth;
            public ulong DescriptorData;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct ResourceInternal
        {
            public const int SIZE = 4;

            public int InternalIndex;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct ResourceBinding
        {
            public const int SIZE = 136;

            public uint SlotIndex;
            public uint ResourceIdentifier;
            public fixed ushort Name[64];
        }

        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct PipelineState
        {
            public void* RootSignature;
            public void* Pipeline;
            public uint UAVCount;
            public uint SRVCount;
            public uint ConstCount;

            public fixed byte UAVResourceBindings[ResourceBinding.SIZE * MAX_NUM_UAVS];
            public fixed byte SRVResourceBindings[ResourceBinding.SIZE * MAX_NUM_SRVS]; 
            public fixed byte CBResourceBindings[ResourceBinding.SIZE * MAX_NUM_CONST_BUFFERS];
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct CreateResourceDescription
        {
            public HeapType HeapType;
            public ResourceDescription ResourceDescription;
            public ResourceStates InitalState;
            public uint InitDataSize;
            public void* InitData;
            public ushort* Name;
            public ResourceUsage Usage;
            public uint Id;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct PipelineDescription
        {
            public uint ContextFlags;
            public FilterType* Samplers;
            public nuint SamplerCount;
            public uint* RootConstantBufferSizes;
            public uint RootConstantBufferCount;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct ConstantBuffer
        {
            public const int SIZE = 260;

            public uint Uint32Size;
            public fixed uint Data[MAX_CONST_SIZE];
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct ClearFloatJobDescription
        {
            public fixed float Color[4];
            public ResourceInternal Target;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct ComputeJobDescription
        {
            public PipelineState Pipeline;
            public fixed uint Dimensions[3];

            public fixed byte SRVs[ResourceInternal.SIZE * MAX_NUM_SRVS];
            public fixed ushort SRVNames[MAX_NUM_SRVS * 64];

            public fixed byte UAVs[ResourceInternal.SIZE * MAX_NUM_UAVS];
            public fixed uint UAVMip[MAX_NUM_UAVS];
            public fixed ushort UAVNames[MAX_NUM_UAVS * 64];

            public fixed byte CBs[ConstantBuffer.SIZE * MAX_NUM_CONST_BUFFERS];
            public fixed ushort CBNames[MAX_NUM_CONST_BUFFERS * 64];
            public fixed uint CBSlotIndex[MAX_NUM_CONST_BUFFERS];
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct CopyJobDescription
        {
            public ResourceInternal Src;
            public ResourceInternal Dst;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct GpuJobDescription
        {
            [FieldOffset(0)] public GpuJobType JobType;

            [FieldOffset(8)] public ClearFloatJobDescription ClearJobDescriptor;
            [FieldOffset(8)] public CopyJobDescription CopyJobDescriptor;
            [FieldOffset(8)] public ComputeJobDescription ComputeJobDescriptor;
        };
    }
}
