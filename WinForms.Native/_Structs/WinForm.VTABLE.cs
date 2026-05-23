using System.Runtime.InteropServices;

namespace WinForms.Native;

using PInvoke;

unsafe partial struct WinForm
{
    /// <summary>
    /// Represents the virtual method table for native window event handling.
    /// </summary>
    /// <remarks>
    /// This structure acts as a dispatch table for the WndProc. By using unmanaged function pointers 
    /// (<c>delegate* managed</c>), it achieves zero-allocation polymorphism. The table is fixed at 1024 bytes, 
    /// providing high-speed access to event handlers and a reserved space for custom user data.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, Size = 1024)]
    public struct VTABLE
    {
        /// <summary>
        /// The primary entry point for window messages. If provided, overrides the default WndProc logic.
        /// </summary>
        [FieldOffset(0)] public delegate* managed<Handle, WndProcMsgType, nint, nint, nint> WndProc;

        /// <summary>
        /// Occurs when the window is first initialized, before it becomes visible.
        /// </summary>
        [FieldOffset(8)] public delegate* managed<ref WinForm, void> OnLoad;
        /// <summary>
        /// Occurs just before the form memory is released or the object is destroyed.
        /// </summary>
        [FieldOffset(16)] public delegate* managed<ref WinForm, void> OnUnload;

        /// <summary>
        /// Occurs the first time the window is shown.
        /// </summary>
        [FieldOffset(24)] public delegate* managed<ref WinForm, void> Shown;
        /// <summary>
        /// Occurs when the window is about to close. Return <c>false</c> to cancel the closure.
        /// </summary>
        [FieldOffset(32)] public delegate* managed<ref WinForm, bool> OnClosing;
        /// <summary>
        /// Occurs after the window has been closed and its handle destroyed.
        /// </summary>
        [FieldOffset(40)] public delegate* managed<ref WinForm, void> OnClosed;

        /// <summary>
        /// Occurs when the window's visibility state changes to visible.
        /// </summary>
        [FieldOffset(48)] public delegate* managed<ref WinForm, void> OnShow;
        /// <summary>
        /// Occurs when the window's visibility state changes to hidden.
        /// </summary>
        [FieldOffset(56)] public delegate* managed<ref WinForm, void> OnHide;
        /// <summary>
        /// Occurs when the window is minimized to the taskbar.
        /// </summary>
        [FieldOffset(64)] public delegate* managed<ref WinForm, void> OnMinimize;
        /// <summary>
        /// Occurs when the window is maximized to full screen.
        /// </summary>
        [FieldOffset(72)] public delegate* managed<ref WinForm, void> OnMaximize;

        /// <summary>
        /// Occurs when the window dimensions have changed.
        /// </summary>
        [FieldOffset(80)] public delegate* managed<ref WinForm, SIZE, void> OnResize;
        /// <summary>
        /// Occurs when the window has been moved to new coordinates.
        /// </summary>
        [FieldOffset(88)] public delegate* managed<ref WinForm, POINT, void> OnMove;

        /// <summary>
        /// Occurs when the window title (text) has been modified.
        /// </summary>
        [FieldOffset(96)] public delegate* managed<ref WinForm, char*, void> OnTextChanged;

        /// <summary>
        /// Occurs when the standard window styles (WS_*) have changed.
        /// </summary>
        [FieldOffset(104)] public delegate* managed<ref WinForm, WindowStyles, WindowStyles, void> OnStyleChanged;
        /// <summary>
        /// Occurs when the extended window styles (WS_EX_*) have changed.
        /// </summary>
        [FieldOffset(112)] public delegate* managed<ref WinForm, WindowExStyles, WindowExStyles, void> OnExStyleChanged;

        /// <summary>
        /// Occurs when the TopMost state of the window is toggled.
        /// </summary>
        [FieldOffset(120)] public delegate* managed<ref WinForm, bool, void> OnTopMostChanged;

        /// <summary>
        /// Occurs when the window gains or loses keyboard focus.
        /// </summary>
        [FieldOffset(128)] public delegate* managed<ref WinForm, bool, void> OnFocusChanged;
        /// <summary>
        /// Occurs when the window becomes or ceases to be the foreground window.
        /// </summary>
        [FieldOffset(136)] public delegate* managed<ref WinForm, bool, bool, void> OnActivateChanged;

        /// <summary>
        /// Occurs when a physical key is pressed down.
        /// </summary>
        [FieldOffset(144)] public delegate* managed<ref WinForm, VirtualKey, KeyEventArgsFlags, void> OnKeyDown;
        /// <summary>
        /// Occurs when a physical key is released.
        /// </summary>
        [FieldOffset(152)] public delegate* managed<ref WinForm, VirtualKey, KeyEventArgsFlags, void> OnKeyUp;
        /// <summary>
        /// Occurs when a character key is pressed (WM_CHAR).
        /// </summary>
        [FieldOffset(160)] public delegate* managed<ref WinForm, char, void> OnKeyPress;

        /// <summary>
        /// Occurs when a mouse button is pressed over the client area.
        /// </summary>
        [FieldOffset(168)] public delegate* managed<ref WinForm, MouseButtons, short, short, void> OnMouseDown;
        /// <summary>
        /// Occurs when a mouse button is released over the client area.
        /// </summary>
        [FieldOffset(176)] public delegate* managed<ref WinForm, MouseButtons, short, short, void> OnMouseUp;
        /// <summary>
        /// Occurs when a mouse button is clicked (pressed and released).
        /// </summary>
        [FieldOffset(184)] public delegate* managed<ref WinForm, MouseButtons, short, short, void> OnMousePress;

        /// <summary>
        /// Occurs when the mouse cursor enters the client area.
        /// </summary>
        [FieldOffset(192)] public delegate* managed<ref WinForm, short, short, void> OnMouseEnter;
        /// <summary>
        /// Occurs when the mouse cursor leaves the client area.
        /// </summary>
        [FieldOffset(200)] public delegate* managed<ref WinForm, void> OnMouseLeave;
        /// <summary>
        /// Occurs when the mouse hovers over the client area for a specified period.
        /// </summary>
        [FieldOffset(208)] public delegate* managed<ref WinForm, short, short, void> OnMouseHover;
        /// <summary>
        /// Occurs when the mouse cursor is moved within the client area.
        /// </summary>
        [FieldOffset(216)] public delegate* managed<ref WinForm, short, short, void> OnMouseMove;

        /// <summary>
        /// The main drawing event. Occurs when the window or a part of it needs to be redrawn.
        /// </summary>
        [FieldOffset(224)] public delegate* managed<ref WinForm, Handle, RECT, void> OnPaint;
        /// <summary>
        /// Occurs when the window background needs to be painted.
        /// </summary>
        [FieldOffset(232)] public delegate* managed<ref WinForm, Handle, void> OnPaintBackground;
        /// <summary>
        /// Occurs when the non-client area (borders and title bar) needs painting.
        /// </summary>
        [FieldOffset(240)] public delegate* managed<ref WinForm, Handle, void> OnNcPaint;
        /// <summary>
        /// Occurs when the window background must be erased (e.g., during resizing).
        /// </summary>
        [FieldOffset(248)] public delegate* managed<ref WinForm, Handle, void> OnEraseBackground;

        /// <summary>
        /// Occurs when a request is made to draw the window into a specified device context (HDC).
        /// </summary>
        [FieldOffset(256)] public delegate* managed<ref WinForm, Handle, PrintFlags, void> OnPrint;
        /// <summary>
        /// Occurs when a request is made to draw only the client area into an HDC.
        /// </summary>
        [FieldOffset(264)] public delegate* managed<ref WinForm, Handle, PrintFlags, void> OnPrintClient;

        /// <summary>
        /// Occurs when the display DPI settings for the window have changed.
        /// </summary>
        [FieldOffset(272)] public delegate* managed<ref WinForm, uint, ref RECT, void> OnDpiChanged;
        /// <summary>
        /// Occurs when the Desktop Window Manager (DWM) composition state changes.
        /// </summary>
        [FieldOffset(280)] public delegate* managed<ref WinForm, void> OnCompositionChanged;

        /// <summary>
        /// Occurs when the display resolution or color depth has changed.
        /// </summary>
        [FieldOffset(288)] public delegate* managed<ref WinForm, byte, short, short, void> OnDisplayChange;

        /// <summary>
        /// Occurs when a periodic timer event is triggered.
        /// </summary>
        [FieldOffset(296)] public delegate* managed<ref WinForm, nuint, void> OnTimer;

        /// <summary>
        /// Occurs when a control sends a command message or a menu item is selected.
        /// </summary>
        [FieldOffset(304)] public delegate* managed<ref WinForm, ushort, ushort, Handle, void> OnCommand;

        /// <summary>
        /// Occurs when the mouse wheel is rotated.
        /// </summary>
        [FieldOffset(312)] public delegate* managed<ref WinForm, short, short, short, void> OnMouseWheel;

        /// <summary>
        /// Occurs while the window is being resized. Allows modification of the sizing rectangle.
        /// </summary>
        [FieldOffset(320)] public delegate* managed<ref WinForm, ref RECT, void> OnSizing;
        /// <summary>
        /// Occurs while the window is being moved. Allows modification of the moving rectangle.
        /// </summary>
        [FieldOffset(328)] public delegate* managed<ref WinForm, ref RECT, void> OnMoving;

        /// <summary>
        /// Occurs when the cursor needs to be set (e.g., when moving between controls).
        /// </summary>
        [FieldOffset(336)] public delegate* managed<ref WinForm, HitTestValues, WndProcMsgType, void> OnSetCursor;

        /// <summary>
        /// Occurs when the mouse is clicked in an inactive window, determining if it should activate.
        /// </summary>
        [FieldOffset(344)] public delegate* managed<ref WinForm, Handle, HitTestValues, WndProcMsgType, nint> OnMouseActivate;

        /// <summary>
        /// Occurs when the application to which the window belongs is activated or deactivated.
        /// </summary>
        [FieldOffset(352)] public delegate* managed<ref WinForm, bool, uint, void> OnActivateApp;

        /// <summary>
        /// Occurs when a system command (e.g., Maximize, Close via title bar) is invoked.
        /// </summary>
        [FieldOffset(360)] public delegate* managed<ref WinForm, SysCommandType, int, bool> OnSysCommand;

        /// <summary>
        /// Occurs to determine which part of the window the mouse is over (Hit Testing).
        /// </summary>
        [FieldOffset(368)] public delegate* managed<ref WinForm, short, short, HitTestValues> OnNcHitTest;

        /// <summary>
        /// Occurs when a mouse button is double-clicked.
        /// </summary>
        [FieldOffset(376)] public delegate* managed<ref WinForm, MouseButtons, short, short, void> OnMouseDoubleClick;

        /// <summary>
        /// A high-priority hook to intercept messages before any other processing.
        /// </summary>
        [FieldOffset(384)] public delegate* managed<ref WinForm, WndProcMsgType, nint, nint, nint?> PreProcessWndProc;
        /// <summary>
        /// A fallback hook to handle messages that were not recognized by the default logic.
        /// </summary>
        [FieldOffset(392)] public delegate* managed<ref WinForm, WndProcMsgType, nint, nint, nint?> ProcessUnknownWndProc;

        /// <summary>
        /// Occurs when the enabled/disabled state of the window changes.
        /// </summary>
        [FieldOffset(400)] public delegate* managed<ref WinForm, void> OnEnabledChanged;

        /// <summary>
        /// Occurs when the horizontal mouse wheel is tilted or rotated.
        /// </summary>
        [FieldOffset(408)] public delegate* managed<ref WinForm, short, short, short, void> OnMouseHWheel;

        [FieldOffset(416)] public delegate* managed<ref WinForm, void> OnChildActivate;

        [FieldOffset(424)] public delegate* managed<ref WinForm, void> OnCancelMode;

        [FieldOffset(432)] public delegate* managed<ref WinForm, char*, bool> OnSetText;
        
        [FieldOffset(440)] public delegate* managed<ref WinForm, bool, void> OnSetRedraw;

        [FieldOffset(448)] public delegate* managed<ref WinForm, void> OnSysColorChange;
        [FieldOffset(456)] public delegate* managed<ref WinForm, nuint, char*, void> OnSettingChange;
        [FieldOffset(464)] public delegate* managed<ref WinForm, void> OnFontChange;
        [FieldOffset(472)] public delegate* managed<ref WinForm, void> OnTimeChange;

        [FieldOffset(480)] public delegate* managed<ref WinForm, uint, bool> OnQueryEndSession;
        [FieldOffset(488)] public delegate* managed<ref WinForm, bool, uint, void> OnEndSession;
        [FieldOffset(496)] public delegate* managed<ref WinForm, bool> OnQueryOpen;

        [FieldOffset(504)] public delegate* managed<ref WinForm, void*, void> OnGetMinMaxInfo;

        [FieldOffset(512)] public delegate* managed<ref WinForm, Handle, Handle, Handle> OnCtlColorMsgBox;
        [FieldOffset(520)] public delegate* managed<ref WinForm, Handle, Handle, Handle> OnCtlColorDlg;

        [FieldOffset(528)] public delegate* managed<ref WinForm, void> OnQueuedSync;

        [FieldOffset(536)] public delegate* managed<ref WinForm, int, void> OnQuit;

        [FieldOffset(544)] public delegate* managed<ref WinForm, char*, nuint, nint> OnGetText;
        [FieldOffset(552)] public delegate* managed<ref WinForm, nint> OnGetTextLength;

        [FieldOffset(560)] public delegate* managed<ref WinForm, Handle, Handle, Handle> OnCtlColor;

        /// <summary>
        /// Reserved 64-byte block for storing custom user data or additional function pointers within the VTABLE.
        /// </summary>
        [FieldOffset(960)] public fixed byte UserDefined[64];
    }
}