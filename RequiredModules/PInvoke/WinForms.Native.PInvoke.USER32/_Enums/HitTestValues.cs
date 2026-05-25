namespace WinForms.Native;

/// <summary>
/// Defines the return values for the WM_NCHITTEST message, indicating which part of the window the cursor is over.
/// </summary>
public enum HitTestValues : int
{
    /// <summary>On the screen background or on a dividing line between windows (same as Nowhere, but sends a beep). </summary>
    Error = -2,
    /// <summary>In a window currently covered by another window in the same thread. </summary>
    Transparent = -1,
    /// <summary>On the screen background or on a dividing line between windows. </summary>
    Nowhere = 0,
    /// <summary>In a client area. </summary>
    Client = 1,
    /// <summary>In a title bar. </summary>
    Caption = 2,
    /// <summary>In a window menu or in a Help button of a title bar. </summary>
    SysMenu = 3,
    /// <summary>In a size box (same as GrowBox). </summary>
    GrowBox = 4,
    /// <summary>In a menu. </summary>
    Menu = 5,
    /// <summary>In a horizontal scroll bar. </summary>
    HScroll = 6,
    /// <summary>In the vertical scroll bar. </summary>
    VScroll = 7,
    /// <summary>In a Minimize button. </summary>
    MinButton = 8,
    /// <summary>In a Maximize button. </summary>
    MaxButton = 9,
    /// <summary>In the left border of a resizable window. </summary>
    Left = 10,
    /// <summary>In the right border of a resizable window. </summary>
    Right = 11,
    /// <summary>In the upper-horizontal border of a window. </summary>
    Top = 12,
    /// <summary>In the upper-left corner of a window border. </summary>
    TopLeft = 13,
    /// <summary>In the upper-right corner of a window border. </summary>
    TopRight = 14,
    /// <summary>In the lower-horizontal border of a resizable window. </summary>
    Bottom = 15,
    /// <summary>In the lower-left corner of a border of a resizable window. </summary>
    BottomLeft = 16,
    /// <summary>In the lower-right corner of a border of a resizable window. </summary>
    BottomRight = 17,
    /// <summary>In the border of a window that does not have a sizing border. </summary>
    Border = 18,
    /// <summary>In a Close button. </summary>
    Close = 20,
    /// <summary>In a Help button. </summary>
    Help = 21
}