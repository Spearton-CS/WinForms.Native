using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace WinForms.Native;

using PInvoke;

/// <summary>
/// Represents a high-performance, zero-allocation native window handle wrapper.
/// </summary>
/// <remarks>
/// This structure uses an explicit memory layout to ensure binary compatibility with native Win32 API calls 
/// while maintaining a fixed size of 64 bytes (matching a standard CPU cache line). 
/// It integrates with a VTABLE-based event system to provide polymorphic behavior without the overhead 
/// of managed objects or garbage collection.
/// </remarks>
[StructLayout(LayoutKind.Explicit, Size = 64)]
public unsafe partial struct WinForm
{
    /// <summary>
    /// The default window class name used for registration in the Windows subsystem.
    /// </summary>
    public const string DefaultClassNameConst = "DotNetWinForm";
    /// <summary>
    /// A constant pointer to the null-terminated string representing the default class name.
    /// </summary>
    /// <remarks>Used during <c>RegisterClassExW</c> and <c>CreateWindowExW</c> calls to avoid repeated string marshaling.</remarks>
    public readonly static char* DefaultClassNamePointer;

    static WinForm()
    {
        fixed (char* ptr = DefaultClassNameConst)
            DefaultClassNamePointer = ptr;
    }

    #region Fields

    /// <summary>
    /// The native window handle (HWND) assigned to this form by the OS.
    /// </summary>
    /// <remarks>Stored at offset 0. A value of zero (default) indicates the window has not been created yet.</remarks>
    [FieldOffset(0)] public HWND HWND;
    /// <summary>
    /// Pointer to the virtual method table (VTABLE) containing function pointers for event handling.
    /// </summary>
    /// <remarks>Stored at offset 8. Allows for polymorphic-like behavior in a native-friendly, zero-allocation way.</remarks>
    [FieldOffset(8)] public VTABLE* INSTANCE_VTABLE;
    /// <summary>
    /// Bitmask for window state and behavior flags.
    /// </summary>
    /// <remarks>The first 16 bits are reserved for internal WndProc logic; bits 16-63 are available for user-defined states.</remarks>
    [FieldOffset(16)] public ulong Flags;
    /// <summary>
    /// Reserved memory block to maintain a fixed structure size of 64 bytes.
    /// </summary>
    /// <remarks>Ensures cache-line alignment and provides space for future internal extensions without breaking layout.</remarks>
    [FieldOffset(32)] public fixed byte Reserved[32];

    /// <summary>
    /// Gets a value indicating whether the window has been successfully created and has a valid handle.
    /// </summary>
    /// <remarks>Returns true if the <see cref="HWND"/> is non-zero.</remarks>
    public readonly bool IsCreated
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => HWND != default;
    }

    /// <summary>
    /// Gets the user-defined portion of the <see cref="Flags"/> bitmask.
    /// </summary>
    /// <remarks>Filters out the internal reserved bits used by the default WndProc.</remarks>
    public readonly ulong UserDefinedFlags
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Extensions.EnumExtensions64.RawWithoutFlag(Flags, WndProcReservedFlags.Reserved);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the window styles (WS_* flags) for the associated window.
    /// </summary>
    /// <remarks>Accesses the native window style via GetWindowLongPtr/SetWindowLongPtr. Changes affect window
    /// appearance and behavior; use SetWindowPos with SWP_FRAMECHANGED or recreate the window to apply certain style
    /// changes. Some styles may not be modifiable at runtime.</remarks>
    public readonly WindowStyles Style
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (WindowStyles)(uint)User32.GetWindowLongPtrW(HWND, WindowLongIndex.Style);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => User32.SetWindowLongPtrW(HWND, WindowLongIndex.Style, (nint)value);
    }
    /// <summary>
    /// Gets or sets the extended window styles for the associated window.
    /// </summary>
    /// <remarks>The value is a bitwise combination of WS_EX_* flags defined by WindowExStyles. Accessors call
    /// GetWindowLongPtrW and SetWindowLongPtrW and require a valid window handle; changes may require calling
    /// SetWindowPos with SWP_FRAMECHANGED or forcing a redraw to take effect.</remarks>
    public readonly WindowExStyles ExStyle
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (WindowExStyles)(uint)User32.GetWindowLongPtrW(HWND, WindowLongIndex.ExStyle);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => User32.SetWindowLongPtrW(HWND, WindowLongIndex.ExStyle, (nint)value);
    }

    /// <summary>
    /// Gets the length, in characters, of the window's title text.
    /// </summary>
    /// <remarks>Invokes GetWindowTextLengthW. The returned value is the character count excluding the
    /// terminating null character. A zero return can mean an empty text or a failure; results may be unreliable for
    /// windows owned by other processes.</remarks>
    public readonly int TextLength
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => User32.GetWindowTextLengthW(HWND);
    }
    /// <summary>
    /// Copies the window's title text into the specified buffer using the Unicode GetWindowTextW API.
    /// </summary>
    /// <remarks>If bufferLength is smaller than the text length, the text is truncated to bufferLength - 1
    /// characters and the buffer is null-terminated. GetWindowText behavior may vary for windows in other processes and
    /// for certain control types.</remarks>
    /// <param name="buffer">Pointer to a buffer that receives the null-terminated UTF-16 window text.</param>
    /// <param name="bufferLength">Size of the buffer, in characters, including space for the terminating null character.</param>
    /// <returns>The number of characters copied into the buffer, not including the terminating null character. Returns zero if
    /// the window has no text or on failure; call GetLastError to distinguish failure.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int GetText(char* buffer, int bufferLength) => User32.GetWindowTextW(HWND, buffer, bufferLength);
    /// <summary>
    /// Copies the window's title text into the specified buffer using the Unicode GetWindowTextW API.
    /// </summary>
    /// <remarks>If bufferLength is smaller than the text length, the text is truncated to bufferLength - 1
    /// characters and the buffer is null-terminated. GetWindowText behavior may vary for windows in other processes and
    /// for certain control types.</remarks>
    /// <param name="buffer">Pointer to a buffer that receives the null-terminated UTF-16 window text.</param>
    /// <returns>The number of characters copied into the buffer, not including the terminating null character. Returns zero if
    /// the window has no text or on failure; call GetLastError to distinguish failure.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int GetText(char[] buffer) => User32.GetWindowTextW(HWND, buffer, buffer.Length);
    /// <summary>
    /// Sets the window text from a pointer to a null-terminated UTF-16 (wide) string.
    /// </summary>
    /// <remarks>Invokes the Win32 SetWindowTextW function on the underlying HWND. Requires an unsafe context
    /// and that the calling thread owns the window; the HWND must be valid. Failure details are provided by the
    /// underlying Win32 API.</remarks>
    /// <param name="text">Pointer to a null-terminated UTF-16 (wide) string. May be null to clear the window text. Caller must ensure the
    /// pointer is valid for the duration of the call.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void SetText(char* text) => User32.SetWindowTextW(HWND, text);

    /// <summary>
    /// Gets or sets the window's bounding rectangle in screen coordinates.
    /// </summary>
    /// <remarks>The getter retrieves the current window rectangle via User32.GetWindowRect. The setter moves
    /// and resizes the window using User32.SetWindowPos and does not change the window's z-order (NoZOrder).
    /// Coordinates are in screen (device) pixels.</remarks>
    public readonly Rect Bounds
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            User32.GetWindowRect(HWND, out Rect rect);
            return rect;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => User32.SetWindowPos(HWND, default, value.X, value.Y, value.Width, value.Height,
                SetWindowPosFlags.NoZOrder);
    }

    /// <summary>
    /// Gets or sets the window's top-left position in screen coordinates.
    /// </summary>
    /// <remarks>Getting returns the current top-left point of the window bounds. Setting moves the window to
    /// the specified coordinates without changing its size or z-order.</remarks>
    public readonly Point Position
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Bounds.Point;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => User32.SetWindowPos(HWND, default, value.X, value.Y, 0, 0,
                SetWindowPosFlags.NoSize | SetWindowPosFlags.NoZOrder);
    }
    /// <summary>
    /// Gets or sets the size of the bounding rectangle.
    /// </summary>
    /// <remarks>Setting preserves the left and top edges and updates Right to Left + Width and Bottom to Top
    /// + Height.</remarks>
    public readonly Size Size
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Bounds.Size;
        set
        {
            var bounds = Bounds;
            Bounds = bounds with { Right = bounds.Left + value.Width, Bottom = bounds.Top + value.Height };
        }
    }

    /// <summary>
    /// Gets or sets the X coordinate of the Position.
    /// </summary>
    /// <remarks>Setting replaces the Position using record 'with' semantics. Accessors are marked for
    /// aggressive inlining.</remarks>
    public readonly int X
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Position.X;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Position = Position with { X = value };
    }
    /// <summary>
    /// Gets or sets the Y coordinate of the Position.
    /// </summary>
    /// <remarks>The getter returns Position.Y. The setter updates Position by creating a new instance using a
    /// with-expression: Position = Position with { Y = value }.</remarks>
    public readonly int Y
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Position.Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Position = Position with { Y = value };
    }
    /// <summary>
    /// Gets or sets the width component of the Size.
    /// </summary>
    /// <remarks>Setting replaces the Size with a new instance that has the specified Width.</remarks>
    public readonly int Width
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Size.Width;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Size = Size with { Width = value };
    }
    /// <summary>
    /// Gets or sets the height component of the Size.
    /// </summary>
    /// <remarks>Setting replaces Size with a new instance created by copying the existing Size with the
    /// specified Height.</remarks>
    public readonly int Height
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Size.Height;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Size = Size with { Height = value };
    }

    /// <summary>
    /// Gets the window's client-area rectangle in client coordinates. Setting resizes the window so its client area
    /// matches the specified rectangle.
    /// </summary>
    /// <remarks>Getter calls User32.GetClientRect and returns a RECT with origin at (0,0). Setter calls
    /// User32.AdjustWindowRectEx with the current Style and ExStyle and User32.SetWindowPos to resize the window; the
    /// rectangle's position is ignored and only Width/Height are applied. Requires a valid HWND and invokes native
    /// User32 APIs; call from the UI thread.</remarks>
    public readonly Rect ClientBounds
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            User32.GetClientRect(HWND, out Rect rect);
            return rect;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            Rect rect = value;
            User32.AdjustWindowRectEx(ref rect, Style, false, ExStyle);
            User32.SetWindowPos(HWND, default, 0, 0, rect.Width, rect.Height,
                SetWindowPosFlags.NoMove | SetWindowPosFlags.NoZOrder);
        }
    }

    /// <summary>
    /// The client-area position as a POINT in client coordinates.
    /// </summary>
    /// <remarks>Equivalent to ClientBounds.Point. Value is expressed in the control's client coordinate
    /// space.</remarks>
    public readonly Point ClientPosition
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ClientBounds.Point;
    }
    /// <summary>
    /// Gets or sets the size of the client area.
    /// </summary>
    /// <remarks>Getting returns ClientBounds.Size. Setting replaces ClientBounds with a rectangle at (0, 0)
    /// and the specified width and height.</remarks>
    public readonly Size ClientSize
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ClientBounds.Size;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => ClientBounds = new(0, 0, value.Width, value.Height);
    }

    /// <summary>
    /// Gets or sets the width, in pixels, of the client area.
    /// </summary>
    /// <remarks>Setting updates ClientSize while preserving the current height. Changing the width may
    /// trigger layout or resize handling.</remarks>
    public readonly int ClientWidth
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ClientSize.Width;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => ClientSize = ClientSize with { Width = value };
    }
    /// <summary>
    /// Gets or sets the height, in pixels, of the client area.
    /// </summary>
    /// <remarks>Setting updates the Height component of ClientSize; value is measured in pixels and may
    /// trigger layout updates.</remarks>
    public readonly int ClientHeight
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ClientSize.Height;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => ClientSize = ClientSize with { Height = value };
    }

    /// <summary>
    /// Gets or sets whether the window is visible.
    /// </summary>
    /// <remarks>The getter queries the OS using User32.IsWindowVisible. The setter shows or hides the window
    /// by calling Show with ShowWindowCommand.Show or ShowWindowCommand.Hide.</remarks>
    public readonly bool Visible
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => User32.IsWindowVisible(HWND);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Show(value ? ShowWindowCommand.Show : ShowWindowCommand.Hide);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the window is minimized.
    /// </summary>
    /// <remarks>The getter tests the WindowStyles.Minimize flag in the window style. The setter invokes Show
    /// with ShowWindowCommand.Minimize when true or ShowWindowCommand.Restore when false.</remarks>
    public readonly bool Minimized
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (Style & WindowStyles.Minimize) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Show(value ? ShowWindowCommand.Minimize : ShowWindowCommand.Restore);
    }
    /// <summary>
    /// Gets or sets a value indicating whether the window is maximized.
    /// </summary>
    /// <remarks>Setting true maximizes the window; setting false restores it. The getter reflects the
    /// window's current style.</remarks>
    public readonly bool Maximized
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (Style & WindowStyles.Maximize) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Show(value ? ShowWindowCommand.Maximize : ShowWindowCommand.Restore);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the window should be placed above all non-topmost windows.
    /// </summary>
    /// <remarks>The getter checks the <see cref="WindowExStyles.TopMost"/> flag. The setter calls 
    /// <see cref="User32.SetWindowPos"/> with <c>HWND_TOPMOST</c> (-1) or <c>HWND_NOTOPMOST</c> (-2).</remarks>
    public readonly bool TopMost
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (ExStyle & WindowExStyles.TopMost) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => User32.SetWindowPos(HWND, (HWND)(Handle)(value ? -1 : -2), 0, 0, 0, 0,
            SetWindowPosFlags.NoMove | SetWindowPosFlags.NoSize); //-1 == TopMost, -2 == NoTopMost
    }

    /// <summary>
    /// Gets or sets whether the window currently has keyboard focus.
    /// </summary>
    /// <remarks>The getter compares <see cref="User32.GetFocus"/> with the current HWND. 
    /// The setter calls <see cref="User32.SetFocus"/> if the value is true.</remarks>
    public readonly bool Focused
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => User32.GetFocus() == HWND;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if (value)
                User32.SetFocus(HWND);
        }
    }
    /// <summary>
    /// Gets or sets whether the window is the current foreground window (active window).
    /// </summary>
    /// <remarks>The getter compares <see cref="User32.GetForegroundWindow"/> with the current HWND. 
    /// The setter brings the window to the foreground via <see cref="User32.SetForegroundWindow"/>.</remarks>
    public readonly bool Active
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => User32.GetForegroundWindow() == HWND;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if (value)
                User32.SetForegroundWindow(HWND);
        }
    }

    /// <summary>
    /// Gets or sets the handle to the parent window or owner window.
    /// </summary>
    /// <remarks>Invokes <see cref="User32.GetParent"/> and <see cref="User32.SetParent"/>. 
    /// Changing the parent re-parents the window at the OS level.</remarks>
    public readonly HWND ParentHWND
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => User32.GetParent(HWND);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => User32.SetParent(HWND, value);
    }
    /// <summary>
    /// Gets a value indicating whether the window has a parent window.
    /// </summary>
    /// <remarks>Checks if <see cref="ParentHWND"/> is not <c>default(Handle)</c>.</remarks>
    public readonly bool HasParent
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ParentHWND != default(Handle);
    }

    #endregion

    #region Actions

    /// <summary>
    /// Invalidates the window's client area and updates the window to force an immediate repaint.
    /// </summary>
    /// <remarks>Calls User32.InvalidateRect for the full client area and User32.UpdateWindow so WM_PAINT is
    /// processed immediately. Call on the thread that owns the window; not thread-safe.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void Refresh()
    {
        User32.InvalidateRect(HWND, true);
        User32.UpdateWindow(HWND);
    }

    /// <summary>
    /// Shows, hides, or activates the window according to the specified ShowWindowCommand.
    /// </summary>
    /// <remarks>Invokes the native User32.ShowWindow function with the instance HWND and the provided
    /// command.</remarks>
    /// <param name="command">Specifies how the window is displayed; defaults to ShowWindowCommand.Show.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void Show(ShowWindowCommand command = ShowWindowCommand.Show)
        => User32.ShowWindow(HWND, command);

    /// <summary>
    /// Posts a WM_CLOSE message to the window identified by the instance handle, requesting that the window close.
    /// </summary>
    /// <remarks>The message is posted to the thread's message queue and processed asynchronously by the
    /// window procedure; the call returns immediately. The window can ignore or delay closing. Use DestroyWindow to
    /// force immediate destruction.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void Close()
        => User32.PostMessageW(HWND, WndProcMsgType.Close, (WParam)0, (LParam)0);

    #endregion
}