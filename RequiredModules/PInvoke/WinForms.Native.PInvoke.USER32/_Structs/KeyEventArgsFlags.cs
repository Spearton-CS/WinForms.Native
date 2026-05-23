using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

/// <summary>
/// Helper structure to decode keyboard message flags contained in lParam.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly record struct KeyEventArgsFlags(nint lParam)
{
    public const nint
        RepeatCountMask = 0x0000_FFFF,
        ScanCodeMask = 0x00FF_0000,
        ExtendedKeyMask = 0x0100_0000,
        ContextCodeMask = 0x2000_0000,
        PreviousStateMask = 0x4000_0000,
        TransitionStateMask = int.MinValue; // 0x8000_0000

    /// <summary>
    /// The repeat count for the current message.
    /// </summary>
    public int RepeatCount => (int)(lParam & RepeatCountMask);

    /// <summary>
    /// The hardware scan code.
    /// </summary>
    public byte ScanCode => (byte)((lParam & ScanCodeMask) >> 16);

    /// <summary>
    /// Indicates whether the key is an extended key (e.g., right-hand Alt/Ctrl).
    /// </summary>
    public bool IsExtendedKey => (lParam & ExtendedKeyMask) != 0;

    /// <summary>
    /// The context code. True if the ALT key is down while the key is pressed.
    /// </summary>
    public bool IsAltDown => (lParam & ContextCodeMask) != 0;

    /// <summary>
    /// The previous key state. True if the key was down before the message was sent (autorepeat).
    /// </summary>
    public bool IsRepeat => (lParam & PreviousStateMask) != 0;

    /// <summary>
    /// The transition state. False if the key is being pressed, true if it is being released.
    /// </summary>
    public bool IsReleased => (lParam & TransitionStateMask) != 0;
}