namespace WinForms.Native;

/// <summary>
/// Defines flags indicating the state of mouse buttons and modifier keys during mouse events.
/// </summary>
/// <remarks>
/// Primarily used to decode the <c>WPARAM</c> of mouse messages such as <c>WM_LBUTTONDOWN</c> 
/// or <c>WM_MOUSEMOVE</c>, mapping directly to <c>MK_*</c> native constants.
/// </remarks>
[Flags]
public enum MouseButtons : int
{
    None = 0x0000,
    Left = 0x0001,    // MK_LBUTTON
    Right = 0x0002,   // MK_RBUTTON
    Shift = 0x0004,   // MK_SHIFT
    Control = 0x0008, // MK_CONTROL
    Middle = 0x0010,  // MK_MBUTTON
    XButton1 = 0x0020,
    XButton2 = 0x0040
}