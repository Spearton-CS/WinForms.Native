namespace WinForms.Native.PInvoke;

/// <summary>
/// Specifies the system metric or configuration setting to retrieve.
/// </summary>
public enum SystemMetricIndex : uint
{
    /// <summary> Width of the screen of the primary display monitor, in pixels. </summary>
    CXSCREEN = 0,
    /// <summary> Height of the screen of the primary display monitor, in pixels. </summary>
    CYSCREEN = 1,
    /// <summary> Width of a vertical scroll bar, in pixels. </summary>
    CXVSCROLL = 2,
    /// <summary> Height of a horizontal scroll bar, in pixels. </summary>
    CYHSCROLL = 3,
    /// <summary> Height of a caption area, in pixels. </summary>
    CYCAPTION = 4,
    /// <summary> Width of a window border, in pixels. </summary>
    CXBORDER = 5,
    /// <summary> Height of a window border, in pixels. </summary>
    CYBORDER = 6,
    /// <summary> Width of a fixed frame border, in pixels. </summary>
    CXDLGFRAME = 7,
    /// <summary> Height of a fixed frame border, in pixels. </summary>
    CYDLGFRAME = 8,
    /// <summary> Default width of an icon, in pixels. </summary>
    CXICON = 11,
    /// <summary> Default height of an icon, in pixels. </summary>
    CYICON = 12,
    /// <summary> Default width of a cursor, in pixels. </summary>
    CXCURSOR = 13,
    /// <summary> Default height of a cursor, in pixels. </summary>
    CYCURSOR = 14,
    /// <summary> Height of a single-line menu bar, in pixels. </summary>
    CYMENU = 15,
    /// <summary> Width of the client area for a full-screen window on the primary display monitor, in pixels. </summary>
    CXFULLSCREEN = 16,
    /// <summary> Height of the client area for a full-screen window on the primary display monitor, in pixels. </summary>
    CYFULLSCREEN = 17
}