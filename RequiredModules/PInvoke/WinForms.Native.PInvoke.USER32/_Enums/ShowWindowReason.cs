namespace WinForms.Native.PInvoke;

/// <summary>
/// Specifies the reason why the WM_SHOWWINDOW message was sent.
/// </summary>
public enum ShowWindowReason : int
{
    /// <summary> The window is being shown or hidden as a result of a call to the ShowWindow function. </summary>
    DirectCall = 0,
    /// <summary> The window's owner window is being minimized, or a pop-up window is being hidden. </summary>
    ParentClosing = 1,
    /// <summary> The window's owner window is being restored, or a pop-up window is being shown. </summary>
    ParentOpening = 2
}