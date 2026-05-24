using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Explicit, Size = 40)]
public struct MinMaxInfo
{
    [FieldOffset(0)] public Point ptReserved;
    [FieldOffset(8)] public Point ptMaxSize;
    [FieldOffset(16)] public Point ptMaxPosition;
    [FieldOffset(24)] public Point ptMinTrackSize;
    [FieldOffset(32)] public Point ptMaxTrackSize;
}