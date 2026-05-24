using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Core = WinForms.Native.PInvoke.User32;

namespace WinForms.Native.PInvoke.Safe;

public static class User32
{
    #region ClassEx

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ATOM RegisterClassEx(in WndClassExW classEx)
    {
        ATOM result = Core.RegisterClassExW(in classEx);
        if (result == default)
            throw new User32PInvokeException(nameof(RegisterClassEx), Marshal.GetLastPInvokeError(), Marshal.GetLastPInvokeErrorMessage());
        else
            return result;
    }

    #endregion

    #region WindowEx

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe HWND CreateWindowEx(
        WindowExStyles dwExStyle, char* lpClassName, char* lpWindowName, WindowStyles dwStyle,
        int x, int y, int nWidth, int nHeight, HWND hWndParent, HMenu hMenu, HInstance hInstance, void* lParam)
    {
        HWND result = Core.CreateWindowExW(
            dwExStyle, lpClassName, lpWindowName, dwStyle,
            x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lParam);
        if (result == default)
            throw new User32PInvokeException(nameof(CreateWindowEx), Marshal.GetLastPInvokeError(), Marshal.GetLastPInvokeErrorMessage());
        else
            return result;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe HWND CreateWindowEx(
        WindowExStyles dwExStyle, string? lpClassName, string? lpWindowName, WindowStyles dwStyle,
        int x, int y, int nWidth, int nHeight, HWND hWndParent, HMenu hMenu, HInstance hInstance, void* lParam)
    {
        HWND result = Core.CreateWindowExW(
            dwExStyle, lpClassName, lpWindowName, dwStyle,
            x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lParam);
        if (result == default)
            throw new User32PInvokeException(nameof(CreateWindowEx), Marshal.GetLastPInvokeError(), Marshal.GetLastPInvokeErrorMessage());
        else
            return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool DestroyWindow(HWND hwnd)
    {
        if (Core.DestroyWindow(hwnd))
            return true;
        else
            throw new User32PInvokeException(nameof(DestroyWindow), Marshal.GetLastPInvokeError(), Marshal.GetLastPInvokeErrorMessage());
    }

    #endregion
}