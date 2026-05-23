using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

/// <summary>
/// Contains message information from a thread's message queue.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 40)]
public struct MSG
{
    /// <summary> A handle to the window whose window procedure receives the message. </summary>
    [FieldOffset(0)] public Handle hwnd;
    /// <summary> The message identifier. </summary>
    [FieldOffset(8)] public uint message;
    /// <summary> Additional information about the message. The exact meaning depends on the value of the message member. </summary>
    [FieldOffset(12)] public nint wParam;
    /// <summary> Additional information about the message. </summary>
    [FieldOffset(20)] public nint lParam;
    /// <summary> The time at which the message was posted. </summary>
    [FieldOffset(28)] public uint time;
    /// <summary> The cursor position, in screen coordinates, when the message was posted. </summary>
    [FieldOffset(32)] public int ptX;
    /// <summary> The Y-coordinate of the cursor position. </summary>
    [FieldOffset(36)] public int ptY;
}