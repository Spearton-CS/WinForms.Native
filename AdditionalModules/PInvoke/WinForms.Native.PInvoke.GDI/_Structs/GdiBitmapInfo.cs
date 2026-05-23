using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Explicit, Size = 40)]
public unsafe struct GdiBitmapInfo()
{
    [FieldOffset(0)] public int biSize = sizeof(GdiBitmapInfo);
    [FieldOffset(4)] public int biWidth;
    [FieldOffset(8)] public int biHeight;
    [FieldOffset(12)] public short biPlanes;
    [FieldOffset(14)] public GdiBitCount biBitCount;
    [FieldOffset(16)] public GdiCompression biCompression;
    [FieldOffset(20)] public int biSizeImage;
    [FieldOffset(24)] public int biXPelsPerMeter;
    [FieldOffset(28)] public int biYPelsPerMeter;
    [FieldOffset(32)] public int biClrUsed;
    [FieldOffset(36)] public int biClrImportant;
}