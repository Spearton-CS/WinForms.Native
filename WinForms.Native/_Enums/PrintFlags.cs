namespace WinForms.Native;

/// <summary>
/// Specifies options for drawing a window into a device context via the WM_PRINT and WM_PRINTCLIENT messages.
/// </summary>
[Flags]
public enum PrintFlags : int
{
    /// <summary> Draws the window only if it is visible. </summary>
    CheckVisible = 0x01,
    /// <summary> Draws the non-client area (borders, title bar) of the window. </summary>
    NonClient = 0x02,
    /// <summary> Draws the client area of the window. </summary>
    Client = 0x04,
    /// <summary> Erases the background before drawing the window. </summary>
    EraseBkgnd = 0x08,
    /// <summary> Draws all visible children windows. </summary>
    PrintChildren = 0x10,
    /// <summary> Draws all owned windows. </summary>
    PrintOwned = 0x20
}