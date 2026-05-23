using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Explicit, Size = 20)]
public struct GdipStartupInput
{
    [FieldOffset(0)] public uint GdiplusVersion;
    [FieldOffset(4)] public nint DebugEventCallback;
    [FieldOffset(12)] public int SuppressBackgroundThread;
    [FieldOffset(16)] public int SuppressExternalCodecs;

    public static readonly GdipStartupInput Default = new() { GdiplusVersion = 1 };
}