using System.Runtime.InteropServices;

namespace FFX_FSR2
{
    public static class FSR2Types
    {
        public const int MAX_NUM_SRVS = 16;
        public const int MAX_NUM_UAVS = 8;
        public const int MAX_NUM_CONST_BUFFERS = 2;
        public const int MAX_CONST_SIZE = 64;

        public enum SurfaceFormat
        {
            FFX_SURFACE_FORMAT_UNKNOWN,
            FFX_SURFACE_FORMAT_R32G32B32A32_TYPELESS,
            FFX_SURFACE_FORMAT_R32G32B32A32_FLOAT,
            FFX_SURFACE_FORMAT_R16G16B16A16_FLOAT,
            FFX_SURFACE_FORMAT_R16G16B16A16_UNORM,
            FFX_SURFACE_FORMAT_R32G32_FLOAT,
            FFX_SURFACE_FORMAT_R32_UINT,
            FFX_SURFACE_FORMAT_R8G8B8A8_TYPELESS,
            FFX_SURFACE_FORMAT_R8G8B8A8_UNORM,
            FFX_SURFACE_FORMAT_R11G11B10_FLOAT,
            FFX_SURFACE_FORMAT_R16G16_FLOAT,
            FFX_SURFACE_FORMAT_R16G16_UINT,
            FFX_SURFACE_FORMAT_R16_FLOAT,
            FFX_SURFACE_FORMAT_R16_UINT,
            FFX_SURFACE_FORMAT_R16_UNORM,
            FFX_SURFACE_FORMAT_R16_SNORM,
            FFX_SURFACE_FORMAT_R8_UNORM,
            FFX_SURFACE_FORMAT_R8_UINT,
            FFX_SURFACE_FORMAT_R8G8_UNORM,
            FFX_SURFACE_FORMAT_R32_FLOAT
        }

        public enum ResourceUsage
        {
            FFX_RESOURCE_USAGE_READ_ONLY = 0,
            FFX_RESOURCE_USAGE_RENDERTARGET = (1 << 0),
            FFX_RESOURCE_USAGE_UAV = (1 << 1),
        }

        public enum ResourceStates
        {
            FFX_RESOURCE_STATE_UNORDERED_ACCESS = (1 << 0),
            FFX_RESOURCE_STATE_COMPUTE_READ = (1 << 1),
            FFX_RESOURCE_STATE_COPY_SRC = (1 << 2),
            FFX_RESOURCE_STATE_COPY_DEST = (1 << 3),
            FFX_RESOURCE_STATE_GENERIC_READ = (FFX_RESOURCE_STATE_COPY_SRC | FFX_RESOURCE_STATE_COMPUTE_READ),
        }

        public enum ResourceFlags
        {
            FFX_RESOURCE_FLAGS_NONE = 0,
            FFX_RESOURCE_FLAGS_ALIASABLE = (1 << 0),
        }

        public enum FilterType
        {
            FFX_FILTER_TYPE_POINT,
            FFX_FILTER_TYPE_LINEAR
        }

        public enum ShaderModel
        {
            FFX_SHADER_MODEL_5_1,
            FFX_SHADER_MODEL_6_0,
            FFX_SHADER_MODEL_6_1,
            FFX_SHADER_MODEL_6_2,
            FFX_SHADER_MODEL_6_3,
            FFX_SHADER_MODEL_6_4,
            FFX_SHADER_MODEL_6_5,
            FFX_SHADER_MODEL_6_6,
            FFX_SHADER_MODEL_6_7,
        }

        public enum ResourceType
        {
            FFX_RESOURCE_TYPE_BUFFER,
            FFX_RESOURCE_TYPE_TEXTURE1D,
            FFX_RESOURCE_TYPE_TEXTURE2D,
            FFX_RESOURCE_TYPE_TEXTURE3D,
        }

        public enum HeapType
        {
            FFX_HEAP_TYPE_DEFAULT = 0,
            FFX_HEAP_TYPE_UPLOAD
        }

        public enum GpuJobType
        {
            FFX_GPU_JOB_CLEAR_FLOAT = 0,
            FFX_GPU_JOB_COPY = 1,
            FFX_GPU_JOB_COMPUTE = 2,
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct DeviceCapabilities
        {
            public ShaderModel minimumSupportedShaderModel;
            public uint waveLaneCountMin;
            public uint waveLaneCountMax;
            public byte fp16Supported;
            public byte raytracingSupported;
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
            public ResourceType type;
            public SurfaceFormat format;
            public uint width;
            public uint height;
            public uint depth;
            public uint mipCount;
            public ResourceFlags flags;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public unsafe struct Resource
        {
            public void* resource;
            public fixed ushort name[64];
            public ResourceDescription description;
            public ResourceStates state;
            public byte isDepth;
            public ulong descriptorData;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct ResourceInternal
        {
            public const int SIZE = 4;

            public int internalIndex;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public unsafe struct ResourceBinding
        {
            public const int SIZE = 136;

            public uint slotIndex;
            public uint resourceIdentifier;
            public fixed ushort name[64];
        }

        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public unsafe struct PipelineState
        {
            public void* rootSignature;
            public void* pipeline;
            public uint uavCount;
            public uint srvCount;
            public uint constCount;

            public fixed byte uavResourceBindings[ResourceBinding.SIZE * MAX_NUM_UAVS];
            public fixed byte srvResourceBindings[ResourceBinding.SIZE * MAX_NUM_SRVS]; 
            public fixed byte cbResourceBindings[ResourceBinding.SIZE * MAX_NUM_CONST_BUFFERS];
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public unsafe struct CreateResourceDescription
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
        public unsafe struct PipelineDescription
        {
            public uint contextFlags;
            public FilterType* samplers;
            public nuint samplerCount;
            public uint* rootConstantBufferSizes;
            public uint rootConstantBufferCount;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public unsafe struct ConstantBuffer
        {
            public const int SIZE = 260;

            public uint Uint32Size;
            public fixed uint Data[MAX_CONST_SIZE];
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public unsafe struct ClearFloatJobDescription
        {
            public fixed float Color[4];
            public ResourceInternal Target;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public unsafe struct ComputeJobDescription
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
        public unsafe struct GpuJobDescription
        {
            [FieldOffset(0)] public GpuJobType JobType;

            [FieldOffset(8)] public ClearFloatJobDescription ClearJobDescriptor;
            [FieldOffset(8)] public CopyJobDescription CopyJobDescriptor;
            [FieldOffset(8)] public ComputeJobDescription ComputeJobDescriptor;
        };
    }
}
