using System.Runtime.CompilerServices;

namespace WinForms.Native.PInvoke;

/// <summary>
/// Provides common constants and special handle values for User32 operations.
/// </summary>
public static class User32Consts
{
    /// <summary> Used with CreateWindowEx to let Windows choose the default position or size. </summary>
    public const int CW_USEDEFAULT = unchecked((int)0x80000000);

    /// <summary> Places the window at the top of the Z order. </summary>
    public static Handle HWND_TOP
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (Handle)(nint)0;
    }

    /// <summary> Places the window at the bottom of the Z order. </summary>
    public static Handle HWND_BOTTOM
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (Handle)(nint)1;
    }

    /// <summary> Places the window above all non-topmost windows. </summary>
    public static Handle HWND_TOPMOST
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (Handle)(-1);
    }

    /// <summary> Places the window above all non-topmost windows (behind all topmost windows). </summary>
    public static Handle HWND_NOTOPMOST
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (Handle)(-2);
    }
}