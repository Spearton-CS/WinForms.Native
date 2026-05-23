using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Explicit)]
public struct MsimgBlendFunction
{
    [FieldOffset(0)] public int SignedRaw;
    [FieldOffset(0)] public uint UnsignedRaw;

    [FieldOffset(0)] public byte BlendOp;
    [FieldOffset(1)] public byte BlendFlags;
    [FieldOffset(2)] public byte SourceConstantAlpha;
    [FieldOffset(3)] public byte AlphaFormat;
}