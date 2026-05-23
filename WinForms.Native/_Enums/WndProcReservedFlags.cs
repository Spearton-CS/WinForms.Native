namespace WinForms.Native;

/// <summary>
/// Internal state flags used by the <see cref="WinForm"/> message loop and user-defined logic.
/// </summary>
[Flags]
public enum WndProcReservedFlags : ulong
{
    /// <summary>No flags set. </summary>
    None = 0,
    /// <summary>Bitmask for flags reserved by the framework (first 16 bits). </summary>
    Reserved = 0xFFFF,
    /// <summary>Bitmask for user-defined flags (bits 16-63). </summary>
    UserDefined = 0xFFFFFFFFFFFF0000,

    /// <summary>Internal: Indicates that the <c>Shown</c> event has already been triggered for the current load cycle. </summary>
    ShownPassed = 1 << 0,
    /// <summary>Internal: Indicates that mouse tracking (<c>TrackMouseEvent</c>) is currently active for the window. </summary>
    MouseTrack = 1 << 1,
}