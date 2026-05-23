namespace WinForms.Native.PInvoke;

/// <summary>
/// Specifies the window class styles.
/// </summary>
[Flags]
public enum ClassStyles : uint
{
    /// <summary> No class styles. </summary>
    None = 0x0000,
    /// <summary> Redraws the entire window if a movement or size adjustment changes the height of the client area. </summary>
    VRedraw = 0x0001,
    /// <summary> Redraws the entire window if a movement or size adjustment changes the width of the client area. </summary>
    HRedraw = 0x0002,
    /// <summary> Sends a double-click message to the window procedure when the user double-clicks the mouse. </summary>
    DoubleClicks = 0x0008,
    /// <summary> Allocates a unique device context for each window in the class. </summary>
    OwnDC = 0x0020,
    /// <summary> Allocates one device context to be shared by all windows in the class. </summary>
    ClassDC = 0x0040,
    /// <summary> Sets the clipping rectangle of the child window to that of the parent window. </summary>
    ParentDC = 0x0080,
    /// <summary> Disables Close on the window menu. </summary>
    NoClose = 0x0200,
    /// <summary> Saves, as a bitmap, the portion of the screen image obscured by a window of this class. </summary>
    SaveBits = 0x0800,
    /// <summary> Indicates that the window class is an application-global class. </summary>
    GlobalClass = 0x4000,

    /// <summary> Standard style for generic windows (VRedraw | HRedraw). </summary>
    Standard = VRedraw | HRedraw
}