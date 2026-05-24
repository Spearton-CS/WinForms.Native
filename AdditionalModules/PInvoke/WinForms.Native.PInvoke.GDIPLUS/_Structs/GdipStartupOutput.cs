using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Explicit, Size = 16)]
public unsafe struct GdipStartupOutput
{
    /// <summary>
    /// The hook procedure called by GDI+ to start a background thread.
    /// </summary>
    [FieldOffset(0)] public delegate* unmanaged[Stdcall]<out nint, delegate* unmanaged[Stdcall]<void>, GdipStatus> NotificationHook;

    /// <summary>
    /// The unhook procedure called by GDI+ to terminate a background thread.
    /// </summary>
    [FieldOffset(8)] public delegate* unmanaged[Stdcall]<nint, void> NotificationUnhook;
}