using System.Numerics;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

/// <summary>
/// Used by the TrackMouseEvent function to track when the mouse pointer leaves a window or hovers over a window.
/// </summary>
/// <param name="dwFlags">The services requested.</param>
/// <param name="hwndTrack">A handle to the window to track.</param>
/// <param name="dwHoverTime">The hover time-out in milliseconds.</param>
[StructLayout(LayoutKind.Explicit, Size = 24)]
public readonly record struct TrackMouseEvent(
    [field: FieldOffset(4)] TrackMouseEventFlags dwFlags,
    [field: FieldOffset(8)] HWND hwndTrack,
    [field: FieldOffset(16)] uint dwHoverTime)
    : IEqualityOperators<TrackMouseEvent, TrackMouseEvent, bool>, IEquatable<TrackMouseEvent>
{
    /// <summary> The size of the TRACKMOUSEEVENT structure, in bytes. </summary>
    [FieldOffset(0)] public readonly uint cbSize = 24;
}