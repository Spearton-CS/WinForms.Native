namespace WinForms.Native;

/// <summary>
/// Represents the type of system command requested via WM_SYSCOMMAND.
/// </summary>
/// <remarks>
/// Note: The four low-order bits of the <c>wParam</c> are used internally by the system. 
/// When testing these values, use the bitwise AND operator with <c>0xFFF0</c>.
/// </remarks>
public enum SysCommandType : int
{
    /// <summary>Sizes the window.</summary>
    Size = 0xF000,
    /// <summary>Moves the window.</summary>
    Move = 0xF010,
    /// <summary>Minimizes the window.</summary>
    Minimize = 0xF020,
    /// <summary>Maximizes the window.</summary>
    Maximize = 0xF030,
    /// <summary>Moves to the next window.</summary>
    NextWindow = 0xF040,
    /// <summary>Moves to the previous window.</summary>
    PrevWindow = 0xF050,
    /// <summary>Closes the window.</summary>
    Close = 0xF060,
    /// <summary>Scrolls vertically.</summary>
    VScroll = 0xF070,
    /// <summary>Scrolls horizontally.</summary>
    HScroll = 0xF080,
    /// <summary>Retrieves the window menu as a result of a mouse click.</summary>
    MouseMenu = 0xF090,
    /// <summary>Retrieves the window menu as a result of a keystroke.</summary>
    KeyMenu = 0xF100,
    /// <summary>Arranges minimized windows.</summary>
    Arrange = 0xF110,
    /// <summary>Restores the window to its normal position and size.</summary>
    Restore = 0xF120,
    /// <summary>Activates the Start menu.</summary>
    TaskList = 0xF130,
    /// <summary>Executes the screen saver application specified in the [boot] section of the SYSTEM.INI file.</summary>
    ScreenSave = 0xF140,
    /// <summary>Activates the window associated with the application-specified hot key.</summary>
    HotKey = 0xF150,
    /// <summary>Selects the default item; the user double-clicked the window menu.</summary>
    Default = 0xF160,
    /// <summary>Sets the state of the display. 1 = low power, 2 = shut off.</summary>
    MonitorPower = 0xF170,
    /// <summary>Changes the cursor to a question mark with a pointer.</summary>
    ContextHelp = 0xF180
}