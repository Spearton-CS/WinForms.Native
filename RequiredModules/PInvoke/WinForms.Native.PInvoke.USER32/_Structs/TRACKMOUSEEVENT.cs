using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

/// <summary>
/// Used by the TrackMouseEvent function to track when the mouse pointer leaves a window or hovers over a window.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 24)]
public unsafe struct TRACKMOUSEEVENT(uint dwFlags, Handle hwndTrack, uint dwHoverTime)
{
    /// <summary> The size of the TRACKMOUSEEVENT structure, in bytes. </summary>
    [FieldOffset(0)] public uint cbSize = 24;
    /// <summary> The services requested. </summary>
    [FieldOffset(4)] public uint dwFlags = dwFlags;
    /// <summary> A handle to the window to track. </summary>
    [FieldOffset(8)] public Handle hwndTrack = hwndTrack;
    /// <summary> The hover time-out in milliseconds. </summary>
    [FieldOffset(16)] public uint dwHoverTime = dwHoverTime;

    public const uint TME_HOVER = 0x00000001;
    public const uint TME_LEAVE = 0x00000002;
    public const uint TME_NONCLIENT = 0x00000010;
    public const uint TME_QUERY = 0x40000000;
    public const uint TME_CANCEL = 0x80000000;
    public const uint HOVER_DEFAULT = 0xFFFFFFFF;
}