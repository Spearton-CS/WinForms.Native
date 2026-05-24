using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Core = WinForms.Native.PInvoke.Kernel32;

namespace WinForms.Native.PInvoke.Safe;

public static class Kernel32
{
    #region Modules

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe HInstance GetModuleHandle(char* lpModuleName)
    {
        HInstance result = Core.GetModuleHandleW(lpModuleName);
        if (result == default)
            throw new Kernel32PInvokeException(nameof(GetModuleHandle), (HResult)Marshal.GetLastPInvokeError(), Marshal.GetLastPInvokeErrorMessage());
        else
            return result;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance GetModuleHandle(string lpModuleName)
    {
        HInstance result = Core.GetModuleHandleW(lpModuleName);
        if (result == default)
            throw new Kernel32PInvokeException(nameof(GetModuleHandle), (HResult)Marshal.GetLastPInvokeError(), Marshal.GetLastPInvokeErrorMessage());
        else
            return result;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe HInstance GetCurrentModule() => GetModuleHandle((char*)null);

    #endregion
}