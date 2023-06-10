using System.Runtime.InteropServices;

namespace FFX_FSR2
{
    public static unsafe partial class FSR2
    {
        public static partial class GL
        {
#if DEBUG
            private const string LIBARY_NAME = "C:/Programming/VS/FidelityFX-FSR2/bin/ffx_fsr2_api_gl_x64d";
#else
            private const string LIBARY_NAME = "C:/Programming/VS/FidelityFX-FSR2/bin/ffx_fsr2_api_gl_x64";
#endif

            [LibraryImport(LIBARY_NAME, EntryPoint = "ffxFsr2GetScratchMemorySizeGL")]
            public static partial nint GetScratchMemorySize();

            public delegate nint DelegateGetProcAddress([MarshalAs(UnmanagedType.LPStr)] string name);

            [LibraryImport(LIBARY_NAME, EntryPoint = "ffxFsr2GetInterfaceGL")]
            public static partial FSR2Error.ErrorCode GetInterface(out FSR2Interface.Interface outInterface, ref byte scratchBuffer, nint scratchBufferSize, DelegateGetProcAddress getProcAddress);


            [LibraryImport(LIBARY_NAME, EntryPoint = "ffxGetTextureResourceGL")]
            public static partial FSR2Types.Resource GetTextureResource(ref Context context, uint imageGL, uint width, uint height, uint imgFormat, in ushort name = 0, FSR2Types.ResourceStates state = FSR2Types.ResourceStates.FFX_RESOURCE_STATE_COMPUTE_READ);
        }
    }
}