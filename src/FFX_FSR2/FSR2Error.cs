namespace FFX_FSR2
{
    public static class FSR2Error
    {
        public enum ErrorCode : uint
        {
            OK = 0,
            InvalidPointer = 0x80000000,
            InvalidAlignment = 0x80000001,
            InvalidSize = 0x80000002,
            EOF = 0x80000003,
            InvalidPath = 0x80000004,
            ErrorEof = 0x80000005,
            MalformedData = 0x80000006,
            OutOfMemory = 0x80000007,
            IncompleteInterface = 0x80000008,
            InvalidEnum = 0x80000009,
            InvalidArgument = 0x8000000a,
            OutOfRange = 0x8000000b,
            NullDevice = 0x8000000c,
            BackendApiError = 0x8000000d,
            InsufficientMemory = 0x8000000e,
        }
    }
}
