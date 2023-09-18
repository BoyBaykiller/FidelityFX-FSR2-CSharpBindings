using System.Runtime.InteropServices;

namespace FFX_FSR2
{
    public static unsafe partial class FSR2
    {
        public static partial class GL
        {
            private const string LIBRARY_NAME = "ffx_fsr2_api_gl_x64.dll";

            [LibraryImport(LIBRARY_NAME, EntryPoint = "ffxFsr2GetScratchMemorySizeGL")]
            public static partial nuint GetScratchMemorySize();

            public delegate nint DelegateGetProcAddress(string name);

            [LibraryImport(LIBRARY_NAME, EntryPoint = "ffxFsr2GetInterfaceGL")]
            public static partial FSR2Error.ErrorCode GetInterface(out FSR2Interface.Interface outInterface, ref byte scratchBuffer, nuint scratchBufferSize, DelegateGetProcAddress getProcAddress);

            [LibraryImport(LIBRARY_NAME, EntryPoint = "ffxGetTextureResourceGL")]
            public static partial FSR2Types.Resource GetTextureResource(uint textureGL, uint width, uint height, uint imgFormat, in ushort name = 0);
        }
    }
}