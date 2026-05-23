using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

/// <summary>
/// Contains window class information. It is used with the RegisterClassEx and GetClassInfoEx functions.
/// </summary>
[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode, Size = 80)]
public unsafe struct WNDCLASSEXW
{
    /// <summary> The size, in bytes, of this structure. </summary>
    [FieldOffset(0)] public uint cbSize;
    /// <summary> The class style(s). </summary>
    [FieldOffset(4)] public ClassStyles style;
    /// <summary> A pointer to the window procedure (WndProc). </summary>
    [FieldOffset(8)] public delegate* unmanaged<Handle, WndProcMsgType, nint, nint, nint> lpfnWndProc;
    /// <summary> The number of extra bytes to allocate following the window-class structure. </summary>
    [FieldOffset(16)] public int cbClsExtra;
    /// <summary> The number of extra bytes to allocate following the window instance. </summary>
    [FieldOffset(20)] public int cbWndExtra;
    /// <summary> A handle to the instance that contains the window procedure for the class. </summary>
    [FieldOffset(24)] public Handle hInstance;
    /// <summary> A handle to the class icon. </summary>
    [FieldOffset(32)] public Handle hIcon;
    /// <summary> A handle to the class cursor. </summary>
    [FieldOffset(40)] public Handle hCursor;
    /// <summary> A handle to the class background brush. </summary>
    [FieldOffset(48)] public Handle hbrBackground;
    /// <summary> Pointer to a null-terminated character string that specifies the resource name of the class menu. </summary>
    [FieldOffset(56)] public char* lpszMenuName;
    /// <summary> Pointer to a null-terminated string or is an atom. Specifies the window class name. </summary>
    [FieldOffset(64)] public char* lpszClassName;
    /// <summary> A handle to a small icon that is associated with the window class. </summary>
    [FieldOffset(72)] public Handle hIconSm;
}