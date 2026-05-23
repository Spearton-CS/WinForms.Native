using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

/// <summary>
/// Defines the initialization parameters passed to the window procedure of an application.
/// </summary>
[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode, Size = 72)]
public unsafe struct CREATESTRUCTW
{
    /// <summary>
    /// Contains additional data which may be used to create the window. 
    /// Typically contains a pointer to the <c>WinForm</c> instance.
    /// </summary>
    [FieldOffset(0)] public void* lpCreateParams;
    /// <summary> A handle to the module that owns the new window. </summary>
    [FieldOffset(8)] public Handle hInstance;
    /// <summary> A handle to the menu to be used by the new window. </summary>
    [FieldOffset(16)] public Handle hMenu;
    /// <summary> A handle to the parent window, if the window is a child window. </summary>
    [FieldOffset(24)] public Handle hwndParent;
    /// <summary> The height of the new window, in pixels. </summary>
    [FieldOffset(32)] public int cy;
    /// <summary> The width of the new window, in pixels. </summary>
    [FieldOffset(36)] public int cx;
    /// <summary> The Y-coordinate of the upper-left corner of the new window. </summary>
    [FieldOffset(40)] public int y;
    /// <summary> The X-coordinate of the upper-left corner of the new window. </summary>
    [FieldOffset(44)] public int x;
    /// <summary> The style for the new window. </summary>
    [FieldOffset(48)] public WindowStyles style;
    /// <summary> Pointer to a null-terminated string that specifies the name of the new window. </summary>
    [FieldOffset(52)] public char* lpszName;
    /// <summary> Pointer to a null-terminated string that specifies the name of the class of the new window. </summary>
    [FieldOffset(60)] public char* lpszClass;
    /// <summary> The extended window style for the new window. </summary>
    [FieldOffset(68)] public WindowExStyles dwExStyle;
}