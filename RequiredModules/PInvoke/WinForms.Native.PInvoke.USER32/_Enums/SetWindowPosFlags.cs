namespace WinForms.Native.PInvoke;

/// <summary>
/// Specifies the window sizing and positioning flags.
/// </summary>
[Flags]
public enum SetWindowPosFlags : uint
{
    /// <summary> Retains the current size (ignores the cx and cy parameters). </summary>
    NoSize = 0x0001,
    /// <summary> Retains the current position (ignores X and Y parameters). </summary>
    NoMove = 0x0002,
    /// <summary> Retains the current Z order (ignores the hWndInsertAfter parameter). </summary>
    NoZOrder = 0x0004,
    /// <summary> Does not redraw changes. </summary>
    NoRedraw = 0x0008,
    /// <summary> Does not activate the window. </summary>
    NoActivate = 0x0010,
    /// <summary> Applies new frame styles set using the SetWindowLong function. Sends WM_NCCALCSIZE. </summary>
    FrameChanged = 0x0020,
    /// <summary> Displays the window. </summary>
    ShowWindow = 0x0040,
    /// <summary> Hides the window. </summary>
    HideWindow = 0x0080,
    /// <summary> Discards the entire contents of the client area. </summary>
    NoCopyBits = 0x0100,
    /// <summary> Does not change the owner window's position in the Z order. </summary>
    NoOwnerZOrder = 0x0200,
    /// <summary> Prevents the window from receiving the WM_WINDOWPOSCHANGING message. </summary>
    NoSendChanging = 0x0400,
    /// <summary> Same as the <see cref="NoRedraw"/> flag. </summary>
    DeferErase = 0x2000,
    /// <summary> If the calling thread does not own the window, the system posts the request to the thread that owns the window. </summary>
    AsyncWindowPos = 0x4000
}