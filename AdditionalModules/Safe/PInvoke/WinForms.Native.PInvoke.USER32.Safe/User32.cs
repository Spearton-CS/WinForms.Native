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
            throw new User32PInvokeException(nameof(RegisterClassEx), (HResult)Marshal.GetLastPInvokeError(), Marshal.GetLastPInvokeErrorMessage());
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
            throw new User32PInvokeException(nameof(CreateWindowEx), (HResult)Marshal.GetLastPInvokeError(), Marshal.GetLastPInvokeErrorMessage());
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
            throw new User32PInvokeException(nameof(CreateWindowEx), (HResult)Marshal.GetLastPInvokeError(), Marshal.GetLastPInvokeErrorMessage());
        else
            return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool DestroyWindow(HWND hwnd)
    {
        if (Core.DestroyWindow(hwnd))
            return true;
        else
            throw new User32PInvokeException(nameof(DestroyWindow), (HResult)Marshal.GetLastPInvokeError(), Marshal.GetLastPInvokeErrorMessage());
    }

    #endregion

    #region WndProc

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static LResult DefWindowProcW(HWND hWnd, WndProcMsgType msg, WParam wParam, LParam lParam)
        => Core.DefWindowProcW(hWnd, msg, wParam, lParam);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void PostQuitMessage(int nExitCode)
        => Core.PostQuitMessage(nExitCode);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool GetMessageW(out MSG lpMsg, HWND hWnd, uint wMsgFilterMin, uint wMsgFilterMax)
    {
        BOOL result = Core.GetMessageW(out lpMsg, hWnd, wMsgFilterMin, wMsgFilterMax);
        if (result.RawSigned == -1)
            throw new User32PInvokeException(nameof(GetMessageW), (HResult)Marshal.GetLastPInvokeError(), Marshal.GetLastPInvokeErrorMessage());
        else
            return result;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TranslateMessage(in MSG lpMsg)
        => Core.TranslateMessage(lpMsg);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static LResult DispatchMessageW(in MSG lpMsg)
        => Core.DispatchMessageW(in lpMsg);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool PostMessageW(HWND hWnd, WndProcMsgType msg, WParam wParam, LParam lParam)
    {
        if (Core.PostMessageW(hWnd, msg, wParam, lParam))
            return true;
        else
            throw new User32PInvokeException(nameof(PostMessageW), (HResult)Marshal.GetLastPInvokeError(), Marshal.GetLastPInvokeErrorMessage());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void* GetWindowLongPtrW(HWND hWnd, WindowLongIndex nIndex)
    {
        Marshal.SetLastPInvokeError(0);
        void* result = Core.GetWindowLongPtrW(hWnd, nIndex);
        HResult hresult;
        if (result is null && (hresult = (HResult)Marshal.GetLastPInvokeError()) != HResult.S_OK)
            throw new User32PInvokeException(nameof(GetWindowLongPtrW), hresult, Marshal.GetLastPInvokeErrorMessage());
        else
            return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void* SetWindowLongPtrW(HWND hWnd, WindowLongIndex nIndex, nint dwNewLong)
    {
        Marshal.SetLastPInvokeError(0);
        void* result = Core.SetWindowLongPtrW(hWnd, nIndex, dwNewLong);
        HResult hresult = (HResult)Marshal.GetLastPInvokeError();
        if (hresult != HResult.S_OK)
            throw new User32PInvokeException(nameof(SetWindowLongPtrW), hresult, Marshal.GetLastPInvokeErrorMessage());
        else
            return result;
    }

    #endregion

    #region Window size & position



    #endregion

    #region Non-Client area



    #endregion

    #region Z-Order



    #endregion

    #region Parenting



    #endregion

    #region Cursor



    #endregion

    #region Painting



    #endregion

    #region Input



    #endregion

    #region System & Environment



    #endregion
}