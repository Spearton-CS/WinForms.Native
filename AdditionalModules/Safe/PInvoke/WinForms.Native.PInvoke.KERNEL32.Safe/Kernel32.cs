using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Core = WinForms.Native.PInvoke.Kernel32;

namespace WinForms.Native.PInvoke.Safe;

public static class Kernel32
{
    #region Modules

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe Handle GetModuleHandle(char* lpModuleName)
    {
        Handle result = Core.GetModuleHandleW(lpModuleName);
        if (result == default(Handle))
            throw new Kernel32PInvokeException(nameof(GetModuleHandle), Marshal.GetLastPInvokeError(), Marshal.GetLastPInvokeErrorMessage());
        else
            return result;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Handle GetModuleHandle(string lpModuleName)
    {
        Handle result = Core.GetModuleHandleW(lpModuleName);
        if (result == default(Handle))
            throw new Kernel32PInvokeException(nameof(GetModuleHandle), Marshal.GetLastPInvokeError(), Marshal.GetLastPInvokeErrorMessage());
        else
            return result;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe Handle GetCurrentModule() => GetModuleHandle((char*)null);

    #endregion
}