using System.Runtime.InteropServices;

namespace FFX_FSR2
{
    public static unsafe partial class FSR2
    {
        public static partial class GL
        {
#if DEBUG
            private const string LIBARY_NAME = "C:/Programming/VS/GitClones/FidelityFX-FSR2/bin/ffx_fsr2_api_gl_x64d";
#else
            private const string LIBARY_NAME = "C:/Programming/VS/GitClones/FidelityFX-FSR2/bin/ffx_fsr2_api_gl_x64";
#endif

            [LibraryImport(LIBARY_NAME, EntryPoint = "ffxFsr2GetScratchMemorySizeGL")]
            public static partial nuint GetScratchMemorySize();

            public delegate nint DelegateGetProcAddress([MarshalAs(UnmanagedType.LPStr)] string name);

            [LibraryImport(LIBARY_NAME, EntryPoint = "ffxFsr2GetInterfaceGL")]
            public static partial FSR2Error.ErrorCode GetInterface(out FSR2Interface.Interface outInterface, ref byte scratchBuffer, nuint scratchBufferSize, DelegateGetProcAddress getProcAddress);


            [LibraryImport(LIBARY_NAME, EntryPoint = "ffxGetTextureResourceGL")]
            public static partial FSR2Types.Resource GetTextureResource(uint imageGL, uint width, uint height, uint imgFormat, in ushort name = 0);
        }
    }
}