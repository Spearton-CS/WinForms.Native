using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Explicit, Size = 40)]
public struct MinMaxInfo
{
    [FieldOffset(0)] public POINT ptReserved;
    [FieldOffset(8)] public POINT ptMaxSize;
    [FieldOffset(16)] public POINT ptMaxPosition;
    [FieldOffset(24)] public POINT ptMinTrackSize;
    [FieldOffset(32)] public POINT ptMaxTrackSize;
}