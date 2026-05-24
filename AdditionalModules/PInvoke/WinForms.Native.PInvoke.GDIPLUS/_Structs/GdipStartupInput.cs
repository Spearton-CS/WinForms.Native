using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Explicit, Size = 20)]
public unsafe struct GdipStartupInput
{
    [FieldOffset(0)] public uint GdiplusVersion;
    [FieldOffset(4)] public delegate* unmanaged<GdipDebugEventLevel, nint, void> DebugEventCallback;
    [FieldOffset(12)] public BOOL SuppressBackgroundThread;
    [FieldOffset(16)] public BOOL SuppressExternalCodecs;

    public static readonly GdipStartupInput Default = new()
    {
        GdiplusVersion = 1,
        SuppressBackgroundThread = false,
        SuppressExternalCodecs = false,
        DebugEventCallback = null
    };
}