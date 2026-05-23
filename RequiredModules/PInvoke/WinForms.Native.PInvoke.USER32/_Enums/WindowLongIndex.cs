namespace WinForms.Native.PInvoke;

/// <summary>
/// Specifies the zero-based offset to the value to be retrieved/set in a window's extra memory.
/// </summary>
public enum WindowLongIndex : int
{
    /// <summary> Sets a new address for the window procedure. </summary>
    WndProc = -4,
    /// <summary> Sets a new handle to the application instance. </summary>
    Instance = -6,
    /// <summary> Sets a new handle to the parent window, if any. </summary>
    HwndParent = -8,
    /// <summary> Sets a new identifier of the child window. </summary>
    Id = -12,
    /// <summary> Sets a new window style. </summary>
    Style = -16,
    /// <summary> Sets a new extended window style. </summary>
    ExStyle = -20,
    /// <summary> Sets the user data associated with the window. </summary>
    /// <remarks> Use this to store your class instance pointer. </remarks>
    UserData = -21,
}