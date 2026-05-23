namespace WinForms.Native.PInvoke;

[Flags]
public enum GdiFontClipPrecision : byte
{
    Default = 0,
    Character = 1,
    Stroke = 2,
    Mask = 15,
    LeftHandAngles = 16,
    TT_Always = 32,
    DFA_Disable = 64,
    Embedded = 128
}