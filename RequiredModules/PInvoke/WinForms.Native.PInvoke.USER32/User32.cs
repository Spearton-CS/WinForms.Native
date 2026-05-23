using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

/// <summary>
/// Provides a comprehensive wrapper for user interface functions (user32.dll).
/// </summary>
public static unsafe partial class User32
{
    /// <summary>
    /// The name of the native library.
    /// </summary>
    public const string DLL = "user32.dll";

    #region ClassEx

    /// <summary> Registers a window class for subsequent use in calls to the CreateWindowExW function. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial ushort RegisterClassExW(in WNDCLASSEXW unnamedParam1);

    #endregion

    #region WindowEx

    /// <summary> Creates an overlapped, pop-up, or child window with an extended window style. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Handle CreateWindowExW(
        uint dwExStyle, char* lpClassName, char* lpWindowName, WindowStyles dwStyle,
        int X, int Y, int nWidth, int nHeight, Handle hWndParent, Handle hMenu, Handle hInstance, void* lpParam);

    /// <summary> Creates a window using managed strings for class and window names. </summary>
    [LibraryImport(DLL, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial Handle CreateWindowExW(
        uint dwExStyle, string? lpClassName, string? lpWindowName, WindowStyles dwStyle,
        int X, int Y, int nWidth, int nHeight, Handle hWndParent, Handle hMenu, Handle hInstance, void* lpParam);

    /// <summary> Destroys the specified window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL DestroyWindow(Handle hwnd);

    #endregion

    #region WndProc

    /// <summary> Calls the default window procedure to provide default processing for any window messages. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial nint DefWindowProcW(Handle hWnd, WndProcMsgType Msg, nint wParam, nint lParam);

    /// <summary> Indicates to the system that a thread has made a request to terminate (quit). </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial void PostQuitMessage(int nExitCode);

    /// <summary> Retrieves a message from the calling thread's message queue. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial int GetMessageW(out MSG lpMsg, Handle hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
    /// <summary> Translates virtual-key messages into character messages. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL TranslateMessage(in MSG lpMsg);
    /// <summary> Dispatches a message to a window procedure. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial nint DispatchMessageW(in MSG lpMsg);
    /// <summary> Places (posts) a message in the message queue associated with the thread that created the specified window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL PostMessageW(Handle hWnd, WndProcMsgType Msg, nint wParam, nint lParam);

    /// <summary> Retrieves information about the specified window. </summary>
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GetWindowLongPtrW")]
    public static partial void* GetWindowLongPtrW(Handle hWnd, WindowLongIndex nIndex);
    /// <summary> Changes an attribute of the specified window. </summary>
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "SetWindowLongPtrW")]
    public static partial void* SetWindowLongPtrW(Handle hWnd, WindowLongIndex nIndex, nint dwNewLong);

    #endregion

    #region Window size & position

    /// <summary> Sets the specified window's show state. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL ShowWindow(Handle hWnd, ShowWindowCommand nCmdShow);
    /// <summary> Determines the visibility state of the specified window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL IsWindowVisible(Handle hWnd);

    /// <summary> Changes the position and dimensions of the specified window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL MoveWindow(Handle hWnd, int X, int Y, int nWidth, int nHeight, BOOL bRepaint);

    /// <summary> Changes the size, position, and Z order of a child, pop-up, or top-level window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL SetWindowPos(Handle hWnd, Handle hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

    /// <summary> Retrieves the dimensions of the bounding rectangle of the specified window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL GetWindowRect(Handle hWnd, out RECT lpRect);
    /// <summary> Retrieves the coordinates of a window's client area. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL GetClientRect(Handle hWnd, out RECT lpRect);
    /// <summary> Calculates the required size of the window rectangle, based on the desired client-rectangle size. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL AdjustWindowRectEx(ref RECT lpRect, WindowStyles dwStyle, BOOL bMenu, WindowExStyles dwExStyle);

    #endregion

    #region Non-Client area

    /// <summary> Changes the text of the specified window's title bar (if it has one). </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial void SetWindowTextW(Handle hWnd, char* lpText);
    /// <summary> Changes the window text using a managed string. </summary>
    [LibraryImport(DLL, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial void SetWindowTextW(Handle hWnd, string lpText);

    /// <summary> Copies the text of the specified window's title bar into a buffer. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial int GetWindowTextW(Handle hWnd, char* lpString, int nMaxCount);
    /// <summary> Copies the window text into a managed char array. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial int GetWindowTextW(Handle hWnd, [Out] char[] lpString, int nMaxCount);

    /// <summary> Retrieves the length, in characters, of the specified window's title bar text. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial int GetWindowTextLengthW(Handle hWnd);

    #endregion

    #region Z-Order

    /// <summary> Sets the keyboard focus to the specified window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Handle SetFocus(Handle hWnd);
    /// <summary> Retrieves the handle to the window that has the keyboard focus. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Handle GetFocus();

    /// <summary> Brings the thread that created the specified window into the foreground and activates the window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL SetForegroundWindow(Handle hWnd);
    /// <summary> Retrieves a handle to the foreground window (the window with which the user is currently working). </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Handle GetForegroundWindow();


    #endregion

    #region Parenting

    /// <summary> Retrieves a handle to the specified window's parent or owner. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Handle GetParent(Handle hWnd);
    /// <summary> Changes the parent window of the specified child window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Handle SetParent(Handle hWndChild, Handle hWndNewParent);

    #endregion

    #region Cursor

    /// <summary> Loads the specified cursor resource from the executable file associated with an application instance. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Handle LoadCursorW(Handle hInstance, char* lpCursorName);
    /// <summary> Loads the specified cursor resource using a managed string. </summary>
    [LibraryImport(DLL, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial Handle LoadCursorW(Handle hInstance, string lpCursorName);

    #endregion

    #region Painting

    /// <summary> Adds a rectangle to the specified window's update region. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL InvalidateRect(Handle hWnd, in RECT lpRect, BOOL bErase);
    /// <summary> Invalidates the entire client area of the specified window. </summary>
    public static BOOL InvalidateRect(Handle hWnd, BOOL bErase)
        => InvalidateRect(hWnd, in Unsafe.NullRef<RECT>(), bErase);
    /// <summary> Updates the client area of the specified window by sending a WM_PAINT message. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL UpdateWindow(Handle hWnd);

    /// <summary> Prepares the specified window for painting and fills a <see cref="PAINTSTRUCT"/> structure. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Handle BeginPaint(Handle hWnd, out PAINTSTRUCT lpPaint);
    /// <summary> Marks the end of painting in the specified window. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL EndPaint(Handle hWnd, in PAINTSTRUCT lpPaint);

    /// <summary> Fills a rectangle by using the specified brush. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial int FillRect(Handle hDC, in RECT lprc, Handle hbr);

    #endregion

    #region Input

    /// <summary> Posts messages when the mouse pointer leaves a window or hovers over a window for a specified amount of time. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL TrackMouseEvent(ref TRACKMOUSEEVENT lpEventTrack);

    #endregion

    #region System & Environment

    /// <summary> Retrieves the specified system metric or system configuration setting. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial int GetSystemMetrics(SystemMetricIndex nIndex);

    #endregion
}