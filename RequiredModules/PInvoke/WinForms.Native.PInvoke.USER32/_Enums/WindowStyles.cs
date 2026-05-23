namespace WinForms.Native.PInvoke;

/// <summary>
/// Specifies the standard styles of a window.
/// </summary>
[Flags]
public enum WindowStyles : uint
{
    /// <summary> The window is an overlapped window. An overlapped window has a title bar and a border. </summary>
    Overlapped = 0x00000000,
    /// <summary> The window is a pop-up window. This style cannot be used with the Child style. </summary>
    Popup = 0x80000000,
    /// <summary> The window is a child window. </summary>
    Child = 0x40000000,
    /// <summary> The window is initially minimized. </summary>
    Minimize = 0x20000000,
    /// <summary> The window is initially visible. </summary>
    Visible = 0x10000000,
    /// <summary> The window is initially disabled. </summary>
    Disabled = 0x08000000,
    /// <summary> Clips child windows relative to each other. </summary>
    ClipSiblings = 0x04000000,
    /// <summary> Clips child windows when drawing occurs within the parent window. </summary>
    ClipChildren = 0x02000000,
    /// <summary> The window is initially maximized. </summary>
    Maximize = 0x01000000,
    /// <summary> The window has a thin-line border. </summary>
    Border = 0x00800000,
    /// <summary> The window has a border of a style typically used with dialog boxes. </summary>
    DlgFrame = 0x00400000,
    /// <summary> The window has a vertical scroll bar. </summary>
    VScroll = 0x00200000,
    /// <summary> The window has a horizontal scroll bar. </summary>
    HScroll = 0x00100000,
    /// <summary> The window has a window menu on its title bar. </summary>
    SysMenu = 0x00080000,
    /// <summary> The window has a sizing border (same as SizeBox). </summary>
    ThickFrame = 0x00040000,
    /// <summary> The window is the first control of a group of controls. </summary>
    Group = 0x00020000,
    /// <summary> The window can receive the keyboard focus when the user presses the TAB key. </summary>
    Tabstop = 0x00010000,

    /// <summary> The window has a minimize button. Must be used with SysMenu. </summary>
    MinimizeBox = 0x00020000,
    /// <summary> The window has a maximize button. Must be used with SysMenu. </summary>
    MaximizeBox = 0x00010000,

    /// <summary> Alias for Overlapped. </summary>
    Tiled = Overlapped,
    /// <summary> Alias for Minimize. </summary>
    Iconic = Minimize,
    /// <summary> Alias for ThickFrame. </summary>
    SizeBox = ThickFrame,

    /// <summary> The window has a title bar (includes the Border style). </summary>
    Caption = Border | DlgFrame,
    /// <summary> Standard overlapped window style. </summary>
    OverlappedWindow = Overlapped | Caption | SysMenu | ThickFrame | MinimizeBox | MaximizeBox,
    /// <summary> Alias for OverlappedWindow. </summary>
    TiledWindow = OverlappedWindow,
    /// <summary> Standard popup window style. </summary>
    PopupWindow = Popup | Border | SysMenu,
    /// <summary> Alias for Child. </summary>
    ChildWindow = Child
}