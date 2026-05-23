using System.Runtime.InteropServices;

namespace WinForms.Native;

using System.Runtime.CompilerServices;

using Extensions;

using PInvoke;

unsafe partial struct WinForm
{
    /// <summary>
    /// The core window procedure (WndProc) that dispatches native messages to the <see cref="VTABLE"/> handlers.
    /// </summary>
    /// <remarks>
    /// Uses <c>EntryPoint</c> for <c>UnmanagedCallersOnly</c>, allowing it to be passed directly to <c>WNDCLASSEXW</c>.
    /// It performs a high-speed lookup of the <see cref="WinForm"/> instance via <c>GetWindowLongPtr</c> (GWLP_USERDATA).
    /// </remarks>
    [UnmanagedCallersOnly(EntryPoint = "WinForm_DefaultWndProc")]
    public static nint DefaultWndProc(Handle hwnd, WndProcMsgType msg, nint wParam, nint lParam)
    {
        WinForm* form = (WinForm*)User32.GetWindowLongPtrW(hwnd, WindowLongIndex.UserData);
        VTABLE* vtable;
        if (form is null && msg is WndProcMsgType.NcCreate)
        {
            var createStruct = (CREATESTRUCTW*)lParam;
            form = (WinForm*)createStruct->lpCreateParams;
            User32.SetWindowLongPtrW(hwnd, WindowLongIndex.UserData, (nint)form);
            form->HWND = hwnd;
            form->Flags = form->Flags.RawWithoutFlag(WndProcReservedFlags.Reserved);

            vtable = form->INSTANCE_VTABLE;
        }
        if (form is not null)
        {
            vtable = form->INSTANCE_VTABLE;
            var wndProc = vtable->WndProc;
            var preProcessWndProc = vtable->PreProcessWndProc;
            nint? userDefinedWndProcResult;
            if (wndProc is not null)
                return wndProc(hwnd, msg, wParam, lParam);
            else if (preProcessWndProc is not null
                && (userDefinedWndProcResult = preProcessWndProc(ref *form, msg, wParam, lParam)) is not null)
                return userDefinedWndProcResult.Value;
            else
                return DefaultWndProc_WindowMsgSwitch(hwnd, form, vtable, msg, wParam, lParam);
        }
        else
            return User32.DefWindowProcW(hwnd, msg, wParam, lParam);
    }

    /// <summary>
    /// A high-performance switch-based dispatcher for standard window messages.
    /// </summary>
    /// <remarks>
    /// Maps <see cref="WndProcMsgType"/> to the corresponding delegates in the <see cref="VTABLE"/>.
    /// Handles critical window lifecycle stages: creation, drawing, mouse/keyboard input, and destruction.
    /// </remarks>
    public static nint DefaultWndProc_WindowMsgSwitch(
        Handle hwnd,
        WinForm* form,
        VTABLE* vtable,
        WndProcMsgType msg,
        nint wParam,
        nint lParam)
    {
        switch (msg)
        {
            #region LIVE events

            case WndProcMsgType.NcCreate:
                var onLoad = vtable->OnLoad;
                if (onLoad is not null)
                    onLoad(ref *form);
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);
            case WndProcMsgType.Create:
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.Destroy:
                var onClosed = vtable->OnClosed;
                if (onClosed is not null)
                    onClosed(ref *form);
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.NcDestroy:
                User32.SetWindowLongPtrW(hwnd, WindowLongIndex.UserData, 0);
                var onUnload = vtable->OnUnload;
                if (onUnload is not null)
                    onUnload(ref *form);
                if (!form->HasParent)
                    User32.PostQuitMessage(0);
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            #endregion

            #region VIEW events

            case WndProcMsgType.SysColorChange:
                var onSysColorChange = vtable->OnSysColorChange;
                if (onSysColorChange is not null)
                {
                    onSysColorChange(ref *form);
                    return 0;
                }
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.SetRedraw:
                var onSetRedraw = vtable->OnSetRedraw;
                if (onSetRedraw is not null)
                    onSetRedraw(ref *form, wParam != 0);
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.Paint:
                var onPaint = vtable->OnPaint;
                if (onPaint is not null)
                {
                    Handle hdc = User32.BeginPaint(hwnd, out PAINTSTRUCT ps);
                    try
                    {
                        onPaint(ref *form, hdc, ps.rcPaint);
                    }
                    finally
                    {
                        User32.EndPaint(hwnd, in ps);
                    }
                    return 0;
                }
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.EraseBkgnd:
                var onPaintBackground = vtable->OnPaintBackground;
                if (onPaintBackground is not null)
                {
                    onPaintBackground(ref *form, (Handle)wParam);
                    return 1;
                }
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.SetCursor:
                var onSetCursor = vtable->OnSetCursor;
                if (onSetCursor is not null)
                {
                    onSetCursor(ref *form, (HitTestValues)(lParam & 0xFFFF), (WndProcMsgType)((lParam >> 16) & 0xFFFF));
                    return 1;
                }
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.Enable:
                var onEnabledChanged = vtable->OnEnabledChanged;
                if (onEnabledChanged is not null)
                    onEnabledChanged(ref *form);
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);
            case WndProcMsgType.SetFocus:
                {
                    var focused = vtable->OnFocusChanged;
                    if (focused is not null)
                    {
                        focused(ref *form, true);
                        return 0;
                    }
                    else
                        return User32.DefWindowProcW(hwnd, msg, wParam, lParam);
                }
            case WndProcMsgType.KillFocus:
                {
                    var focused = vtable->OnFocusChanged;
                    if (focused is not null)
                    {
                        focused(ref *form, false);
                        return 0;
                    }
                    else
                        return User32.DefWindowProcW(hwnd, msg, wParam, lParam);
                }

            case WndProcMsgType.CtlColor:
                var onCtlColor = vtable->OnCtlColor;
                if (onCtlColor is not null)
                    return onCtlColor(ref *form, (Handle)wParam, (Handle)lParam).SignedValue;
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.FontChange:
                var onFontChange = vtable->OnFontChange;
                if (onFontChange is not null)
                {
                    onFontChange(ref *form);
                    return 0;
                }
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.CtlColorMsgBox:
                var onCtlColorMsgBox = vtable->OnCtlColorMsgBox;
                if (onCtlColorMsgBox is not null)
                    return onCtlColorMsgBox(ref *form, (Handle)wParam, (Handle)lParam).SignedValue;
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);
            case WndProcMsgType.CtlColorDlg:
                var onCtlColorDlg = vtable->OnCtlColorDlg;
                if (onCtlColorDlg is not null)
                    return onCtlColorDlg(ref *form, (Handle)wParam, (Handle)lParam).SignedValue;
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            #endregion

            #region NON-CLIENT VIEW events

            case WndProcMsgType.NcPaint:
                var onNcPaint = vtable->OnNcPaint;
                if (onNcPaint is not null)
                {
                    onNcPaint(ref *form, (Handle)wParam);
                    return 0;
                }
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.SetText:
                var onSetText = vtable->OnSetText;
                if (onSetText is not null)
                    onSetText(ref *form, (char*)lParam);
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);
            case WndProcMsgType.GetText:
                var onGetText = vtable->OnGetText;
                if (onGetText is not null)
                    return onGetText(ref *form, (char*)lParam, (nuint)wParam);
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);
            case WndProcMsgType.GetTextLength:
                var onGetTextLength = vtable->OnGetTextLength;
                if (onGetTextLength is not null)
                    return onGetTextLength(ref *form);
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            #endregion

            #region WINDOW events

            case WndProcMsgType.ShowWindow:
                var shown = vtable->Shown;
                if (shown is not null && wParam != 0 && !form->Flags.HasFlag(WndProcReservedFlags.ShownPassed))
                {
                    shown(ref *form);
                    form->Flags |= WndProcReservedFlags.ShownPassed;
                }
                var onShow = vtable->OnShow;
                if (onShow is not null && wParam != 0)
                    onShow(ref *form);
                var onHide = vtable->OnHide;
                if (onHide is not null && wParam == 0)
                    onHide(ref *form);
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.Size:
                var onResize = vtable->OnResize;
                if (onResize is not null)
                    onResize(ref *form, new((int)(lParam & 0xFFFF), (int)((lParam >> 16) & 0xFFFF)));
                var onMinimize = vtable->OnMinimize;
                var onMaximize = vtable->OnMaximize;
                if (wParam == 1 && onMinimize is not null)
                    onMinimize(ref *form);
                else if (wParam == 2 && onMaximize is not null)
                    onMaximize(ref *form);
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.Move:
                var onMove = vtable->OnMove;
                if (onMove is not null)
                    onMove(ref *form, new((short)(lParam & 0xFFFF), (short)((lParam >> 16) & 0xFFFF)));
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.Close:
                var onClosing = vtable->OnClosing;
                if (onClosing is not null && onClosing(ref *form))
                    return 0;
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.Activate:
                var onActivated = vtable->OnActivateChanged;
                if (onActivated is not null)
                {
                    onActivated(ref *form,
                        ((nuint)wParam & 0xFFFF) != 0,
                        ((nuint)wParam >> 16) != 0);
                    return 0;
                }
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.CancelMode:
                var onCancelMode = vtable->OnCancelMode;
                if (onCancelMode is not null)
                {
                    onCancelMode(ref *form);
                    return 0;
                }
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.ChildActivate:
                var onChildActivate = vtable->OnChildActivate;
                if (onChildActivate is not null)
                {
                    onChildActivate(ref *form);
                    return 0;
                }
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.GetMinMaxInfo:
                var onGetMinMaxInfo = vtable->OnGetMinMaxInfo;
                if (onGetMinMaxInfo is not null)
                {
                    onGetMinMaxInfo(ref *form, (void*)lParam);
                    return 0;
                }
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            #endregion

            #region MOUSE events

            case WndProcMsgType.MouseActivate:
                var onMouseActivate = vtable->OnMouseActivate;
                if (onMouseActivate is not null)
                    return onMouseActivate(ref *form, (Handle)wParam, (HitTestValues)(lParam & 0xFFFF), (WndProcMsgType)((lParam >> 16) & 0xFFFF));
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.MouseMove:
                if (!form->Flags.HasFlag(WndProcReservedFlags.MouseTrack))
                {
                    form->Flags |= WndProcReservedFlags.MouseTrack;
                    TRACKMOUSEEVENT tme = new(TRACKMOUSEEVENT.TME_LEAVE, hwnd, default);
                    User32.TrackMouseEvent(ref tme);

                    var onMouseEnter = vtable->OnMouseEnter;
                    if (onMouseEnter is not null)
                        onMouseEnter(ref *form, GetX(lParam), GetY(lParam));
                }
                var onMouseMove = vtable->OnMouseMove;
                if (onMouseMove is not null)
                    onMouseMove(ref *form, GetX(lParam), GetY(lParam));
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.MouseWheel:
                var onMouseWheel = vtable->OnMouseWheel;
                if (onMouseWheel is not null)
                {
                    onMouseWheel(ref *form, GetDelta(wParam), GetX(lParam), GetY(lParam));
                    return 0;
                }
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);
            case WndProcMsgType.MouseHWheel:
                var onMouseHWheel = vtable->OnMouseHWheel;
                if (onMouseHWheel is not null)
                {
                    onMouseHWheel(ref *form, GetDelta(wParam), GetX(lParam), GetY(lParam));
                    return 0;
                }
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.MouseHover:
                var onMouseHover = vtable->OnMouseHover;
                if (onMouseHover is not null)
                {
                    onMouseHover(ref *form, GetX(lParam), GetY(lParam));
                    return 0;
                }
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);
            case WndProcMsgType.MouseLeave:
                form->Flags &= ~WndProcReservedFlags.MouseTrack;
                var onMouseLeave = vtable->OnMouseLeave;
                if (onMouseLeave is not null)
                {
                    onMouseLeave(ref *form);
                    return 0;
                }
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.LButtonDown:
                {
                    var onMouseDown = vtable->OnMouseDown;
                    if (onMouseDown is not null)
                        onMouseDown(ref *form, MouseButtons.Left, GetX(lParam), GetY(lParam));
                }
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);
            case WndProcMsgType.RButtonDown:
                {
                    var onMouseDown = vtable->OnMouseDown;
                    if (onMouseDown is not null)
                        onMouseDown(ref *form, MouseButtons.Right, GetX(lParam), GetY(lParam));
                }
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);
            case WndProcMsgType.MButtonDown:
                {
                    var onMouseDown = vtable->OnMouseDown;
                    if (onMouseDown is not null)
                        onMouseDown(ref *form, MouseButtons.Middle, GetX(lParam), GetY(lParam));
                }
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.LButtonDblClk:
                {
                    var onMouseDoubleClick = vtable->OnMouseDoubleClick;
                    if (onMouseDoubleClick is not null)
                        onMouseDoubleClick(ref *form, MouseButtons.Left, GetX(lParam), GetY(lParam));
                }
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);
            case WndProcMsgType.RButtonDblClk:
                {
                    var onMouseDoubleClick = vtable->OnMouseDoubleClick;
                    if (onMouseDoubleClick is not null)
                        onMouseDoubleClick(ref *form, MouseButtons.Right, GetX(lParam), GetY(lParam));
                }
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);
            case WndProcMsgType.MButtonDblClk:
                {
                    var onMouseDoubleClick = vtable->OnMouseDoubleClick;
                    if (onMouseDoubleClick is not null)
                        onMouseDoubleClick(ref *form, MouseButtons.Middle, GetX(lParam), GetY(lParam));
                }
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.LButtonUp:
                {
                    var onMouseUp = vtable->OnMouseUp;
                    if (onMouseUp is not null)
                        onMouseUp(ref *form, MouseButtons.Left, GetX(lParam), GetY(lParam));
                }
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);
            case WndProcMsgType.RButtonUp:
                {
                    var onMouseUp = vtable->OnMouseUp;
                    if (onMouseUp is not null)
                        onMouseUp(ref *form, MouseButtons.Right, GetX(lParam), GetY(lParam));
                }
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);
            case WndProcMsgType.MButtonUp:
                {
                    var onMouseUp = vtable->OnMouseUp;
                    if (onMouseUp is not null)
                        onMouseUp(ref *form, MouseButtons.Middle, GetX(lParam), GetY(lParam));
                }
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.NcHitTest:
                var onNcHitTest = vtable->OnNcHitTest;
                if (onNcHitTest is not null)
                    return (nint)onNcHitTest(ref *form, GetX(lParam), GetY(lParam));
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            #endregion

            #region KEYBOARD events

            case WndProcMsgType.KeyDown:
                var onKeyDown = vtable->OnKeyDown;
                if (onKeyDown is not null)
                    onKeyDown(ref *form, (VirtualKey)wParam, new KeyEventArgsFlags(lParam));
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.KeyUp:
                var onKeyUp = vtable->OnKeyUp;
                if (onKeyUp is not null)
                    onKeyUp(ref *form, (VirtualKey)wParam, new KeyEventArgsFlags(lParam));
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.Char: // <-- КРИТИЧЕСКИ ВАЖНО ДЛЯ ВВОДА ТЕКСТА
                var onKeyPress = vtable->OnKeyPress;
                if (onKeyPress is not null)
                    onKeyPress(ref *form, (char)wParam);
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            #endregion

            #region SYSTEM events

            case WndProcMsgType.SysCommand:
                var onSysCommand = vtable->OnSysCommand;
                if (onSysCommand is not null
                    && onSysCommand(ref *form, (SysCommandType)(wParam & 0xFFF0), (int)lParam))
                    return 0;
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.ActivateApp:
                var onActivateApp = vtable->OnActivateApp;
                if (onActivateApp is not null)
                    onActivateApp(ref *form, wParam != 0, (uint)lParam);
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.Timer:
                var onTimer = vtable->OnTimer;
                if (onTimer is not null)
                    onTimer(ref *form, unchecked((nuint)wParam));
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.QueryEndSession:
                var onQueryEndSession = vtable->OnQueryEndSession;
                if (onQueryEndSession is not null)
                    return vtable->OnQueryEndSession(ref *form, (uint)lParam) ? 1 : 0;
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.Quit:
                var onQuit = vtable->OnQuit;
                if (onQuit is not null)
                    onQuit(ref *form, (int)wParam);
                return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.QueryOpen:
                var onQueryOpen = vtable->OnQueryOpen;
                if (onQueryOpen is not null)
                    return vtable->OnQueryOpen(ref *form) ? 1 : 0;
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.EndSession:
                var onEndSession = vtable->OnEndSession;
                if (onEndSession is not null)
                {
                    vtable->OnEndSession(ref *form, wParam != 0, (uint)lParam);
                    return 0;
                }
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.SettingChange:
                var settingChange = vtable->OnSettingChange;
                if (settingChange is not null)
                {
                    settingChange(ref *form, (nuint)wParam, (char*)lParam);
                    return 0;
                }
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.TimeChange:
                var onTimeChange = vtable->OnTimeChange;
                if (onTimeChange is not null)
                {
                    onTimeChange(ref *form);
                    return 0;
                }
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            case WndProcMsgType.QueuedSync:
                var onQueuedSync = vtable->OnQueuedSync;
                if (onQueuedSync is not null)
                {
                    onQueuedSync(ref *form);
                    return 0;
                }
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);

            #endregion

            default:
                nint? userDefinedWndProcResult;
                var processUnknownWndProc = vtable->ProcessUnknownWndProc;
                if (processUnknownWndProc is not null
                    && (userDefinedWndProcResult = processUnknownWndProc(ref *form, msg, wParam, lParam)) is not null)
                    return userDefinedWndProcResult.Value;
                else
                    return User32.DefWindowProcW(hwnd, msg, wParam, lParam);
        }
    }
    /// <summary>
    /// A specialized dispatcher for dialog-specific messages (currently not implemented).
    /// </summary>
    public static nint DefaultWndProc_DialogMsgSwitch(
        Handle hwnd,
        WinForm* form,
        VTABLE* vtable,
        WndProcMsgType msg,
        nint wParam,
        nint lParam)
    {
        throw new NotImplementedException();
        switch ((WndProcDialogMsgType)msg)
        {
            default:
                return DefaultWndProc_WindowMsgSwitch(hwnd, form, vtable, msg, wParam, lParam);
        }
    }

    /// <summary>
    /// Extracts the horizontal (X) coordinate from a window message's LPARAM.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short GetX(nint lParam) => (short)(lParam & 0xFFFF);
    /// <summary>
    /// Extracts the vertical (Y) coordinate from a window message's LPARAM.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short GetY(nint lParam) => (short)((lParam >> 16) & 0xFFFF);
    /// <summary>
    /// Extracts the mouse wheel delta or other high-word values from a window message's WPARAM.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short GetDelta(nint wParam) => (short)((wParam >> 16) & 0xFFFF);
    /// <summary>
    /// Combines two 16-bit values into a single 32/64-bit LPARAM, typically for coordinates.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nint MakeLParam(short x, short y) => (ushort)y << 16 | (ushort)x;
}