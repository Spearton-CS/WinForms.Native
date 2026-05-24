using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Core = WinForms.Native.PInvoke.ShCore;

namespace WinForms.Native.PInvoke.Safe;

public static class ShCore
{
    #region DPI

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetProcessDpiAwareness(PROCESS_DPI_AWARENESS value)
    {
        HResult hresult = Core.SetProcessDpiAwareness(value);
        if (hresult.IsError)
            throw new ShCorePInvokeException(nameof(SetProcessDpiAwareness), hresult, Marshal.GetPInvokeErrorMessage((int)hresult));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GetDpiForMonitor(HMonitor hmon, MONITOR_DPI_TYPE dpiType, out uint dpiX, out uint dpiY)
    {
        HResult hresult = Core.GetDpiForMonitor(hmon, dpiType, out dpiX, out dpiY);
        if (hresult.IsError)
            throw new ShCorePInvokeException(nameof(GetDpiForMonitor), hresult, Marshal.GetPInvokeErrorMessage((int)hresult));
    }

    #endregion
}