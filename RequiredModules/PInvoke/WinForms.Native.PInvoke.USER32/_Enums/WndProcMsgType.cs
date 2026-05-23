namespace WinForms.Native.PInvoke;

/// <summary>
/// Exhaustive Windows Message Identifiers (WM_*).
/// Defines the message codes sent to a window procedure (WndProc) in Windows 10 / 11.
/// </summary>
public enum WndProcMsgType : uint
{
    #region Lifecycle & General

    /// <summary>Performs no operation. An application sends a WM_NULL message if it wants to post a message that the recipient window will ignore.</summary>
    Null = 0x0000,
    /// <summary>Sent when an application requests that a window be created by calling the CreateWindowEx or CreateWindow function.</summary>
    Create = 0x0001,
    /// <summary>Sent when a window is being destroyed. It is sent to the window procedure of the window being destroyed after the window is removed from the screen.</summary>
    Destroy = 0x0002,
    /// <summary>Sent after a window has been moved.</summary>
    Move = 0x0003,
    /// <summary>Sent to a window after its size has changed.</summary>
    Size = 0x0005,
    /// <summary>Sent to both the window being activated and the window being deactivated.</summary>
    Activate = 0x0006,
    /// <summary>Sent to a window after it has gained the keyboard focus.</summary>
    SetFocus = 0x0007,
    /// <summary>Sent to a window immediately before it loses the keyboard focus.</summary>
    KillFocus = 0x0008,
    /// <summary>Sent when an application changes its enabled state.</summary>
    Enable = 0x000A,
    /// <summary>An application sends the WM_SETREDRAW message to a window to allow changes in that window to be redrawn or to prevent changes in that window from being redrawn.</summary>
    SetRedraw = 0x000B,
    /// <summary>Sets the text of a window.</summary>
    SetText = 0x000C,
    /// <summary>Copies the text that corresponds to a window into a buffer provided by the caller.</summary>
    GetText = 0x000D,
    /// <summary>Determines the length, in characters, of the text associated with a window.</summary>
    GetTextLength = 0x000E,
    /// <summary>Sent when the system or another application makes a request to paint a portion of an application's window.</summary>
    Paint = 0x000F,
    /// <summary>Sent as a signal that a window or an application should terminate.</summary>
    Close = 0x0010,
    /// <summary>Sent to an application when the user chooses to end the session or when an application calls one of the shutdown functions.</summary>
    QueryEndSession = 0x0011,
    /// <summary>Indicates a request to terminate an application and is generated when the application calls the PostQuitMessage function.</summary>
    Quit = 0x0012,
    /// <summary>Sent to an icon when the user requests that the icon be opened into a window.</summary>
    QueryOpen = 0x0013,
    /// <summary>Sent when the window background must be erased (for example, when a window is resized).</summary>
    EraseBkgnd = 0x0014,
    /// <summary>Sent to all top-level windows when a change is made to a system color setting.</summary>
    SysColorChange = 0x0015,
    /// <summary>Sent to an application when the session ends.</summary>
    EndSession = 0x0016,
    /// <summary>Sent to a window when the ShowWindow function is called.</summary>
    ShowWindow = 0x0018,
    /// <summary>Sent to the parent window of a system-defined control before the system draws the control.</summary>
    CtlColor = 0x0019,
    /// <summary>Sent to all top-level windows after the SetLocaleInfo function changes the system locale or after the user changes settings in Control Panel.</summary>
    SettingChange = 0x001A,
    /// <summary>Sent to both the application being activated and the application being deactivated.</summary>
    ActivateApp = 0x001C,
    /// <summary>Sent to a window when the font used by the window is about to change.</summary>
    FontChange = 0x001D,
    /// <summary>Sent to an application when there is a change in the time zone settings of the system.</summary>
    TimeChange = 0x001E,
    /// <summary>Sent to a window when the user cancels the window's tracking of a popup menu.</summary>
    CancelMode = 0x001F,
    /// <summary>Sent to a window if the mouse causes the cursor to move within a window and mouse input is not captured.</summary>
    SetCursor = 0x0020,
    /// <summary>Sent when the cursor is in an inactive window and the user presses a mouse button.</summary>
    MouseActivate = 0x0021,
    /// <summary>Sent to a child window when the user clicks the child window's title bar, or when the window is activated, moved, or sized.</summary>
    ChildActivate = 0x0022,
    /// <summary>Sent by the computer-based training (CBT) application to a CBTProc hook procedure before any window is created, activated, moved, sized, minimized, maximized, or destroyed.</summary>
    QueuedSync = 0x0025,
    /// <summary>Sent to a window when the size or position of the window is about to change. Allows restricting window bounds.</summary>
    GetMinMaxInfo = 0x0024,
    CtlColorMsgBox = 0x135,
    CtlColorDlg = 0x0138,

    #endregion

    #region Window layout & Drawing hooks

    /// <summary>Sent to a minimized window when the background of the icon must be filled before painting the icon.</summary>
    IconEraseBkgnd = 0x0027,
    /// <summary>Sent to a window whose owner is an iconized window before the system draws the icon.</summary>
    NextDlgProc = 0x0028,
    /// <summary>Sent to all windows when the user changes the system's spooler settings.</summary>
    SpoolerStatus = 0x002A,
    /// <summary>Sent to the parent window of an owner-drawn button, combo box, list box, or menu when a visual aspect of the control has changed.</summary>
    DrawItem = 0x002B,
    /// <summary>Sent to the parent window of an owner-drawn button, combo box, list box, or menu when the control is created.</summary>
    MeasureItem = 0x002C,
    /// <summary>Sent to the owner of a list box or combo box when the list box or combo box is destroyed or when items are removed.</summary>
    DeleteItem = 0x002D,
    /// <summary>Sent by a list box or combo box to its owner window to request the visual representation of an item.</summary>
    VKeyToItem = 0x002E,
    /// <summary>Sent by a list box with the LBS_WANTKEYBOARDINPUT style to its owner in response to a WM_KEYDOWN message.</summary>
    CharToItem = 0x002F,
    /// <summary>Sets the font that a control is to use when drawing text.</summary>
    SetFont = 0x0030,
    /// <summary>Retrieves the font with which a control is currently drawing its text.</summary>
    GetFont = 0x0031,
    /// <summary>Sent to a window to associate a hot key with the window.</summary>
    SetHotKey = 0x0032,
    /// <summary>Sent to a window to determine the hot key associated with that window.</summary>
    GetHotKey = 0x0033,
    /// <summary>Sent to a minimized (iconic) window when the window is about to be dragged by the user but does not have an icon defined for its class.</summary>
    QueryDragIcon = 0x0037,
    /// <summary>Sent to determine the relative position of a new item in the sorted list of an owner-drawn combo box or list box.</summary>
    CompareItem = 0x0039,
    /// <summary>Sent by the Microsoft Active Accessibility runtime to request an accessibility object.</summary>
    GetObject = 0x003D,
    /// <summary>Informs a window that the system is low on memory.</summary>
    Compacting = 0x0041,
    /// <summary>Sent to a window whose size or position is about to change as a result of a call to the SetWindowPos function or another window-management function.</summary>
    WindowPosChanging = 0x0046,
    /// <summary>Sent to a window whose size or position has changed as a result of a call to the SetWindowPos function or another window-management function.</summary>
    WindowPosChanged = 0x0047,

    /// <summary>Sent by the Windows or TaskBar for getting window's icon. If not proceed - Alt+Tab and TaskBar can just loose any icons</summary>
    GetIcon = 0x007F,
    /// <summary>For dynamic changing of window's icon</summary>
    SetIcon = 0x0080,

    #endregion

    #region Infrastructure & Communication

    /// <summary>Sent by a common control to its parent window when an event has occurred or the control requires some information.</summary>
    Notify = 0x004E,
    /// <summary>Sent to a window when the user selects a new input language.</summary>
    InputLangChangeRequest = 0x0050,
    /// <summary>Sent to the topmost affected windows after the application's input language has been changed.</summary>
    InputLangChange = 0x0051,
    /// <summary>Sent to an application that has initiated a training session with Microsoft Windows Tutorial.</summary>
    TCard = 0x0052,
    /// <summary>Indicates that the user pressed the F1 key or clicked the Help button.</summary>
    Help = 0x0053,
    /// <summary>Sent to all windows when the user logs on or off.</summary>
    UserChanged = 0x0054,
    /// <summary>Sent to a window when the system detects that the monitor display resolution or color depth has changed.</summary>
    DisplayChange = 0x007E,
    /// <summary>Sent to a window when the user clicks the right mouse button or presses Shift+F10 over it.</summary>
    ContextMenu = 0x007B,

    #endregion

    #region Non-client area

    /// <summary>Sent to a window when its non-client area is being created.</summary>
    NcCreate = 0x0081,
    /// <summary>Sent to a window when its non-client area is being destroyed.</summary>
    NcDestroy = 0x0082,
    /// <summary>Sent when the size and position of a window's client area must be calculated.</summary>
    NcCalcSize = 0x0083,
    /// <summary>Sent to a window in order to determine what part of the window corresponds to a particular mouse coordinate.</summary>
    NcHitTest = 0x0084,
    /// <summary>Sent to a window when its frame (non-client area) must be painted.</summary>
    NcPaint = 0x0085,
    /// <summary>Sent to a window when its non-client area needs to be changed to indicate an active or inactive state.</summary>
    NcActivate = 0x0086,
    /// <summary>Sent to the parent window of a control when the control is about to be drawn (Standard Controls dynamic styling).</summary>
    GetDlgCode = 0x0087,
    /// <summary>Sent to a window when the mouse pointer moves within its non-client area.</summary>
    NcMouseMove = 0x00A0,
    /// <summary>Sent when the user presses the left mouse button while the cursor is within the non-client area of a window.</summary>
    NcLButtonDown = 0x00A1,
    /// <summary>Sent when the user releases the left mouse button while the cursor is within the non-client area of a window.</summary>
    NcLButtonUp = 0x00A2,
    /// <summary>Sent when the user double-clicks the left mouse button while the cursor is within the non-client area of a window.</summary>
    NcLButtonDblClk = 0x00A3,
    /// <summary>Sent when the user presses the right mouse button while the cursor is within the non-client area of a window.</summary>
    NcRButtonDown = 0x00A4,
    /// <summary>Sent when the user releases the right mouse button while the cursor is within the non-client area of a window.</summary>
    NcRButtonUp = 0x00A5,
    /// <summary>Sent when the user double-clicks the right mouse button while the cursor is within the non-client area of a window.</summary>
    NcRButtonDblClk = 0x00A6,
    /// <summary>Sent when the user presses the middle mouse button while the cursor is within the non-client area of a window.</summary>
    NcMButtonDown = 0x00A7,
    /// <summary>Sent when the user releases the middle mouse button while the cursor is within the non-client area of a window.</summary>
    NcMButtonUp = 0x00A8,
    /// <summary>Sent when the user double-clicks the middle mouse button while the cursor is within the non-client area of a window.</summary>
    NcMButtonDblClk = 0x00A9,

    /// <summary>Undocumented XP/Vista/Win7/10/11 Internal theme message for drawing caption headers.</summary>
    NcUahDrawCaption = 0x00AE,
    /// <summary>Undocumented XP/Vista/Win7/10/11 Internal theme message for drawing window frames.</summary>
    NcUahDrawFrame = 0x00AF,

    #endregion

    #region Keyboard input

    /// <summary>Sent to the window with the keyboard focus when a nonsystem key is pressed.</summary>
    KeyDown = 0x0100,
    /// <summary>Sent to the window with the keyboard focus when a nonsystem key is released.</summary>
    KeyUp = 0x0101,
    /// <summary>Sent to the window with the keyboard focus when a WM_KEYDOWN message is translated by the TranslateMessage function.</summary>
    Char = 0x0102,
    /// <summary>Sent to the window with the keyboard focus when the user presses a dead key.</summary>
    DeadChar = 0x0103,
    /// <summary>Sent to the window with the keyboard focus when the user presses the F10 key (which activates the menu bar) or holds down the ALT key and then presses another key.</summary>
    SysKeyDown = 0x0104,
    /// <summary>Sent to the window with the keyboard focus when the user releases a key that was pressed while the ALT key was held down.</summary>
    SysKeyUp = 0x0105,
    /// <summary>Sent to the window with the keyboard focus when a WM_SYSKEYDOWN message is translated by the TranslateMessage function.</summary>
    SysChar = 0x0106,
    /// <summary>Sent to the window with the keyboard focus when the user releases a dead key.</summary>
    SysDeadChar = 0x0107,

    #endregion

    #region Input Method Editor (IME) & Raw Input

    /// <summary>Sent to the window when the IME composition status changes.</summary>
    ImeComposition = 0x010F,
    /// <summary>Sent to an application when the IME generates a character.</summary>
    ImeChar = 0x0286,
    /// <summary>Sent to an application to provide IME window positioning and execution context data.</summary>
    ImeSetContext = 0x0281,
    /// <summary>Sent to an application when an IME window changes state.</summary>
    ImeNotify = 0x0282,
    /// <summary>Sent to an application to direct the IME window to perform a command.</summary>
    ImeControl = 0x0283,
    /// <summary>Sent to the window that is receiving raw input from a HID device (Mouse/Keyboard/Gamepad).</summary>
    Input = 0x00FF,

    #endregion

    #region UI commands & System menus

    /// <summary>Sent when the user selects a command item from a menu, when a control sends a notification message to its parent window, or when an accelerator keystroke is translated.</summary>
    Command = 0x0111,
    /// <summary>Sent when the user selects a command from the Window menu (formerly known as the system or control menu) or when the user chooses the maximize button, minimize button, restore button, or close button.</summary>
    SysCommand = 0x0112,
    /// <summary>Sent to the window procedure associated with a timer when the timer expires.</summary>
    Timer = 0x0113,
    /// <summary>Sent when a horizontal scroll bar receives a scroll event.</summary>
    HScroll = 0x0114,
    /// <summary>Sent when a vertical scroll bar receives a scroll event.</summary>
    VScroll = 0x0115,
    /// <summary>Sent when a menu is about to become active.</summary>
    InitMenu = 0x0116,
    /// <summary>Sent when a drop-down menu or submenu is about to become active.</summary>
    InitMenuPopup = 0x0117,
    /// <summary>Sent when the user selects a menu item.</summary>
    MenuSelect = 0x011F,
    /// <summary>Sent when a menu character is pressed that doesn't match any mnemonic.</summary>
    MenuChar = 0x0120,
    /// <summary>Sent to the window that owns a list box when the list box is entering an idle state.</summary>
    EnterIdle = 0x0121,

    #endregion

    #region Client area mouse input

    /// <summary>Sent to a window when the mouse pointer moves.</summary>
    MouseMove = 0x0200,
    /// <summary>Sent when the user presses the left mouse button while the cursor is in the client area of a window.</summary>
    LButtonDown = 0x0201,
    /// <summary>Sent when the user releases the left mouse button while the cursor is in the client area of a window.</summary>
    LButtonUp = 0x0202,
    /// <summary>Sent when the user double-clicks the left mouse button while the cursor is in the client area of a window.</summary>
    LButtonDblClk = 0x0203,
    /// <summary>Sent when the user presses the right mouse button while the cursor is in the client area of a window.</summary>
    RButtonDown = 0x0204,
    /// <summary>Sent when the user releases the right mouse button while the cursor is in the client area of a window.</summary>
    RButtonUp = 0x0205,
    /// <summary>Sent when the user double-clicks the right mouse button while the cursor is in the client area of a window.</summary>
    RButtonDblClk = 0x0206,
    /// <summary>Sent when the user presses the middle mouse button while the cursor is in the client area of a window.</summary>
    MButtonDown = 0x0207,
    /// <summary>Sent when the user releases the middle mouse button while the cursor is in the client area of a window.</summary>
    MButtonUp = 0x0208,
    /// <summary>Sent when the user double-clicks the middle mouse button while the cursor is in the client area of a window.</summary>
    MButtonDblClk = 0x0209,
    /// <summary>Sent to the focus window when the mouse wheel is rotated.</summary>
    MouseWheel = 0x020A,
    /// <summary>Sent to the focus window when the mouse horizontal wheel is tilted or rotated.</summary>
    MouseHWheel = 0x020E,
    MouseHover = 0x02A1,
    MouseLeave = 0x02A3,

    #endregion

    #region Touch, Pen & Gestures

    /// <summary>Sent to a window when one or more touch points (fingers) touch the screen.</summary>
    Touch = 0x0240,
    /// <summary>Sent to a window when a gesture (pan, zoom, rotate via trackpad or screen) is detected.</summary>
    Gesture = 0x0119,
    /// <summary>Sent to a window before a gesture is processed to allow the window to configure what gestures it wants to receive.</summary>
    GestureNotify = 0x011A,

    #endregion

    #region Window sizing & Drag-drop state

    /// <summary>Sent to a window that the user is resizing. Inspecting this allows changing resize behavior dynamically.</summary>
    Sizing = 0x0214,
    /// <summary>Sent once to a window after it enters the moving or sizing modal loop.</summary>
    EnterSizeMove = 0x0231,
    /// <summary>Sent once to a window after it exits the moving or sizing modal loop.</summary>
    ExitSizeMove = 0x0232,
    /// <summary>Sent to a window that the user is moving.</summary>
    Moving = 0x0216,
    /// <summary>Sent to the parent window of a child window when the child window is created or destroyed, or when the user clicks a mouse button while the cursor is over the child window.</summary>
    ParentNotify = 0x0210,

    #endregion

    #region Modern windows 10|11 integration

    /// <summary>Sent when the effective dots per inch (dpi) for a window has changed.</summary>
    DpiChanged = 0x02E0,
    /// <summary>Sent to all top-level windows when the Desktop Window Manager (DWM) composition state changes (e.g., Aero/Acrylic toggles).</summary>
    DwmCompositionChanged = 0x031E,
    /// <summary>Sent to all windows when the user changes the current OS visual style theme.</summary>
    ThemeChanged = 0x031A,
    /// <summary>Sent to a window when the layout of the title bar buttons is requested (e.g., Windows 11 Snap Layouts metrics).</summary>
    GetTitleBarInfoEx = 0x033F,
    DpiChangedBeforeParent = 0x02E2,
    DpiChangedAfterParent = 0x02E3,

    #endregion

    #region Power Management & Session

    /// <summary>Notifies an application of power management events (battery state, low power, suspension, resume).</summary>
    PowerBroadcast = 0x0218,
    /// <summary>Informs the application about changes in the remote desktop or local terminal session status (lock/unlock screen).</summary>
    WtsSessionChange = 0x02B1,

    #endregion

    #region System printing & Context hooks

    /// <summary>Requests that a window draw its client and non-client areas into a specified device context (DC).</summary>
    Print = 0x0317,
    /// <summary>Requests that a window draw its client area into a specified device context (typically for printing/screenshots).</summary>
    PrintClient = 0x0318,

    #endregion

    #region Clipboard

    /// <summary>Sent to the clipboard owner when the clipboard contains data in the CF_OWNERDISPLAY format and the clipboard application's client area needs repainting.</summary>
    PaintClipboard = 0x0309,
    /// <summary>Sent to the clipboard owner when the clipboard contains data in the CF_OWNERDISPLAY format and the clipboard application's client area is destroyed.</summary>
    DestroyClipboard = 0x0307,
    /// <summary>Sent to the clipboard owner when the clipboard is emptied by a call to the EmptyClipboard function.</summary>
    Clear = 0x0303,
    /// <summary>An application sends the WM_CUT message to an edit control or combo box to delete the current selection and copy it to the clipboard.</summary>
    Cut = 0x0300,
    /// <summary>An application sends the WM_COPY message to an edit control or combo box to copy the current selection to the clipboard.</summary>
    Copy = 0x0301,
    /// <summary>An application sends the WM_PASTE message to an edit control or combo box to copy the current content of the clipboard into the control.</summary>
    Paste = 0x0302,

    #endregion

    #region Extensibility limits (User & App ranges)

    /// <summary>Used to define private messages for use by private window classes, usually of the form WM_USER+X.</summary>
    User = 0x0400,
    /// <summary>Used to define private messages for use by the application, usually of the form WM_APP+X.</summary>
    App = 0x8000

    #endregion
}

/// <summary>
/// Dialog Box Window Messages (WM_DM_* / DM_*).
/// Specific messages sent to dialog boxes or control procedures within a dialog.
/// </summary>
public enum WndProcDialogMsgType : uint
{
    /// <summary>Sent to the dialog box procedure to set the default push button control for a dialog box.</summary>
    SetDefId = 0x0401, // DM_SETDEFID

    /// <summary>Sent to the dialog box procedure to retrieve the identifier of the default push button control.</summary>
    GetDefId = 0x0402, // DM_GETDEFID

    /// <summary>Sent to a dialog box to force it to re-evaluate its layout and control positioning.</summary>
    Reposition = 0x0403, // DM_REPOSITION

    /// <summary>Sent to the dialog box procedure to initiate dialog initialization before display.</summary>
    InitDialog = 0x0110, // WM_INITDIALOG

    /// <summary>Sent to the dialog box to determine the next control to receive focus based on the TAB key navigation.</summary>
    NextDlgCtl = 0x0028, // WM_NEXTDLGPROC / WM_NEXTDLGCTL

    /// <summary>Internal dialog engine message for initializing 3D container rendering hooks (legacy but sent by Win11 for compatibility).</summary>
    W32CtlContainer = 0x0119, // WM_WTHREEDCONTAINER (Overrides WM_GESTURE in dialog context)

    /// <summary>Sent by the dialog engine to retrieve the underlying accessibility or HTML object inside an MSHTML dialog host.</summary>
    HtmlGetObject = 0x011A // WM_HTML_GETOBJECT (Overrides WM_GESTURENOTIFY in dialog context)
}

/// <summary>
/// Windows Menu Architecture Messages (WM_MENU*).
/// Sent to the owner window of a menu during its lifecycle and interactions.
/// </summary>
public enum WndProcMenuMsgType : uint
{
    InitMenu = 0x0116,
    /// <summary>Sent when a drop-down menu or submenu is about to be displayed. Allows dynamic modification of items.</summary>
    InitMenuPopup = 0x0117,

    /// <summary>Sent when the user selects a menu item but before it is clicked/executed.</summary>
    MenuSelect = 0x011F,

    /// <summary>Sent when a menu character is pressed that does not match any mnemonic character defined for the current menu.</summary>
    MenuChar = 0x0120,

    EnterIdle = 0x0121,

    /// <summary>Sent to the owner window when a popup menu has been systematically destroyed.</summary>
    UninitMenuPopup = 0x0125,

    /// <summary>Sent when the user loops through menu items via keyboard or touch swipe navigation.</summary>
    MenuDrag = 0x0123,

    /// <summary></summary>
    MenuRButtonUp = 0x0122,

    /// <summary>Sent to the window procedure of a menu's owner when the user releases the right mouse button while the cursor is over a menu item.</summary>
    MenuGetObject = 0x0124,

    /// <summary>Sent to the owner window when a menu command is processed via a keyboard shortcut accelerator.</summary>
    MenuCommand = 0x0126
}

/// <summary>
/// Multiple-Document Interface Messages (WM_MDI*).
/// Sent to an MDI client window to control or query child windows.
/// </summary>
public enum WndProcMdiMsgType : uint
{
    /// <summary>Creates an MDI child window.</summary>
    Create = 0x0220, // WM_MDICREATE

    /// <summary>Destroys an MDI child window.</summary>
    Destroy = 0x0221, // WM_MDIDESTROY

    /// <summary>Activates a alternative MDI child window.</summary>
    Activate = 0x0222, // WM_MDIACTIVATE

    /// <summary>Restores an MDI child window from maximized or minimized state.</summary>
    Restore = 0x0223, // WM_MDIRESTORE

    /// <summary>Activates the next MDI child window in the Z-order chain.</summary>
    Next = 0x0224, // WM_MDINEXT

    /// <summary>Maximizes an MDI child window.</summary>
    Maximize = 0x0225, // WM_MDIMAXIMIZE

    /// <summary>Arranges all the child windows of an MDI client window in a cascade layout.</summary>
    Cascade = 0x0226, // WM_MDICASCADE

    /// <summary>Arranges all the child windows of an MDI client window in a tile layout.</summary>
    Tile = 0x0227, // WM_MDITILE

    /// <summary>Arranges all minimized MDI child windows. It does not affect child windows that are not minimized.</summary>
    IconArrange = 0x0228, // WM_MDIICONARRANGE

    /// <summary>Retrieves the handle to the active MDI child window.</summary>
    GetActive = 0x0229, // WM_MDIGETACTIVE

    /// <summary>Replaces the menu of an MDI frame window, a whole menu bar, or a specific popup menu drop-down.</summary>
    SetMenu = 0x0230, // WM_MDISETMENU

    /// <summary>Refreshes the menu bar of the MDI frame window, updating the window list dynamically.</summary>
    RefreshMenu = 0x0234 // WM_MDIREFRESHMENU
}