namespace WinForms.Native.PInvoke;

/// <summary>
/// Specifies the extended window styles.
/// </summary>
[Flags]
public enum WindowExStyles : uint
{
    /// <summary> No extended styles. </summary>
    None = 0x00000000,
    /// <summary> The window has a double border. </summary>
    DlgModalFrame = 0x00000001,
    /// <summary> The child window does not send the WM_PARENTNOTIFY message to its parent when created or destroyed. </summary>
    NoParentNotify = 0x00000004,
    /// <summary> The window should be placed above all non-topmost windows. </summary>
    TopMost = 0x00000008,
    /// <summary> The window accepts drag-and-drop files. </summary>
    AcceptFiles = 0x00000010,
    /// <summary> The window should not be painted until siblings beneath it have been painted. </summary>
    Transparent = 0x00000020,
    /// <summary> The window is a MDI child window. </summary>
    MdiChild = 0x00000040,
    /// <summary> The window is intended to be used as a floating toolbar. </summary>
    ToolWindow = 0x00000080,
    /// <summary> The window has a border with a raised edge. </summary>
    WindowEdge = 0x00000100,
    /// <summary> The window has a border with a sunken edge. </summary>
    ClientEdge = 0x00000200,
    /// <summary> The title bar of the window includes a question mark. </summary>
    ContextHelp = 0x00000400,
    /// <summary> The window has generic right-aligned properties. </summary>
    Right = 0x00001000,
    /// <summary> The window has generic left-aligned properties (default). </summary>
    Left = 0x00000000,
    /// <summary> The window text is displayed using right-to-left reading-order properties. </summary>
    RtlReading = 0x00002000,
    /// <summary> The window text is displayed using left-to-right reading-order properties (default). </summary>
    LtrReading = 0x00000000,
    /// <summary> The vertical scroll bar (if present) is to the left of the client area. </summary>
    LeftScrollbar = 0x00004000,
    /// <summary> The vertical scroll bar is to the right of the client area (default). </summary>
    RightScrollbar = 0x00000000,
    /// <summary> The window itself contains child windows that should take part in dialog box navigation. </summary>
    ControlParent = 0x00010000,
    /// <summary> The window has a three-dimensional border style intended to be used for items that do not accept user input. </summary>
    StaticEdge = 0x00020000,
    /// <summary> Forces a top-level window onto the taskbar when the window is visible. </summary>
    AppWindow = 0x00040000,
    /// <summary> The window is a layered window. </summary>
    Layered = 0x00080000,
    /// <summary> The window does not inherit its layout from its parent. </summary>
    NoInheritLayout = 0x00100000,
    /// <summary> The window has right-to-left layout. </summary>
    LayoutRtl = 0x00400000,
    /// <summary> Paints all descendants of a window in bottom-to-top painting order using double-buffering. </summary>
    Composited = 0x02000000,
    /// <summary> A top-level window created with this style does not become the foreground window when the user clicks it. </summary>
    NoActivate = 0x08000000,

    /// <summary> Combination of WindowEdge and ClientEdge. </summary>
    OverlappedWindow = WindowEdge | ClientEdge,
    /// <summary> Combination of WindowEdge, ToolWindow, and TopMost. </summary>
    PaletteWindow = WindowEdge | ToolWindow | TopMost
}