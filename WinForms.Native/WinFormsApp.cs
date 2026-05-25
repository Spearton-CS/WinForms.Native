namespace WinForms.Native;

using System.Runtime.CompilerServices;

using PInvoke;

/// <summary>
/// Provides helpers to register a Win32 window class, create and show WinForm windows, run the native message loop, and
/// request an orderly shutdown.
/// </summary>
public unsafe static class WinFormsApp
{
    /// <summary>
    /// Initializes and registers a window class with default settings for the current module.
    /// </summary>
    /// <remarks>Obtains the current module handle, configures a WNDCLASSEXW with standard class styles, the
    /// default window procedure, an arrow cursor, and the default class name pointer, then calls
    /// User32.RegisterClassExW.</remarks>
    /// <returns>The class atom returned by RegisterClassExW identifying the registered window class, or zero if registration
    /// fails.</returns>
    public static ATOM Initialize()
    {
        HInstance hInst = Kernel32.GetCurrentModule();

        WndClassExW wc = new()
        {
            style = ClassStyles.Standard,
            lpfnWndProc = &WinForm.DefaultWndProc,
            hInstance = hInst,
            hCursor = User32.LoadCursorW(default, (char*)(int)DefaultCursors.Arrow),
            lpszClassName = WinForm.DefaultClassNamePointer
        };

        return User32.RegisterClassExW(in wc);
    }

    /// <summary>
    /// Creates and shows a WinForm window, assigns its HWND, and runs the native message loop until the window exits.
    /// </summary>
    /// <remarks>Blocks until the message loop exits (GetMessageW returns 0). If window creation fails (HWND
    /// is default), the method returns without entering the message loop. Uses CreateWindowExW, ShowWindow,
    /// TranslateMessage and DispatchMessageW.</remarks>
    /// <param name="winForm">The WinForm instance to initialize and run; its HWND is set to the created window handle.</param>
    /// <param name="initialTitle">Optional pointer to the initial window title; if null, the default class name is used.</param>
    /// <param name="hWndParent">Handle of the parent window; defaults to none to create a top-level window.</param>
    public static void Run(ref WinForm winForm, char* initialTitle = null, HWND hWndParent = default)
    {
        HInstance hInst = Kernel32.GetCurrentModule();
        fixed (WinForm* pForm = &winForm)
            winForm.HWND = User32.CreateWindowExW(
                WindowExStyles.None,
                WinForm.DefaultClassNamePointer,
                initialTitle is null ? WinForm.DefaultClassNamePointer : initialTitle,
                WindowStyles.OverlappedWindow,
                User32Consts.CW_USEDEFAULT, User32Consts.CW_USEDEFAULT,
                User32Consts.CW_USEDEFAULT, User32Consts.CW_USEDEFAULT,
                hWndParent, default, hInst, pForm
            );

        if (winForm.HWND == Handle.Zero)
            return;

        User32.ShowWindow(winForm.HWND, ShowWindowCommand.Show);

        while (User32.GetMessageW(out MSG msg, default, 0, 0))
        {
            User32.TranslateMessage(in msg);
            User32.DispatchMessageW(in msg);
        }
    }

    /// <summary>
    /// Creates and shows a WinForm window, assigns its HWND, and runs the native message loop until the window exits.
    /// </summary>
    /// <remarks>Blocks until the message loop exits (GetMessageW returns 0). If window creation fails (HWND
    /// is default), the method returns without entering the message loop. Uses CreateWindowExW, ShowWindow,
    /// TranslateMessage and DispatchMessageW.</remarks>
    /// <param name="winForm">The WinForm instance to initialize and run; its HWND is set to the created window handle.</param>
    /// <param name="initialTitle">Optional pointer to the initial window title; if null, the default class name is used.</param>
    /// <param name="hWndParent">Handle of the parent window; defaults to none to create a top-level window.</param>
    public static void Run(ref WinForm winForm, string? initialTitle = null, HWND hWndParent = default)
    {
        HInstance hInst = Kernel32.GetCurrentModule();
        fixed (WinForm* pForm = &winForm)
            winForm.HWND = User32.CreateWindowExW(
                WindowExStyles.None,
                WinForm.DefaultClassNameConst,
                initialTitle is null ? WinForm.DefaultClassNameConst : initialTitle,
                WindowStyles.OverlappedWindow,
                User32Consts.CW_USEDEFAULT, User32Consts.CW_USEDEFAULT,
                User32Consts.CW_USEDEFAULT, User32Consts.CW_USEDEFAULT,
                hWndParent, default, hInst, pForm
            );

        if (winForm.HWND == default(Handle))
            return;

        User32.ShowWindow(winForm.HWND, ShowWindowCommand.Show);

        while (User32.GetMessageW(out MSG msg, default, 0, 0))
        {
            User32.TranslateMessage(in msg);
            User32.DispatchMessageW(in msg);
        }
    }

    /// <summary>
    /// Posts a WM_QUIT message to the calling thread's message queue to request an orderly shutdown of its message
    /// loop.
    /// </summary>
    /// <remarks>Does not force immediate termination; the message loop must retrieve WM_QUIT and exit.
    /// Affects only the calling thread's windows and message queue.</remarks>
    /// <param name="nExitCode">The exit code to post with the WM_QUIT message; defaults to 0.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SoftExit(int nExitCode = 0) => User32.PostQuitMessage(nExitCode);
}