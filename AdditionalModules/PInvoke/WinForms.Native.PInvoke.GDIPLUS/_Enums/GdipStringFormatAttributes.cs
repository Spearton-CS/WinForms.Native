namespace WinForms.Native.PInvoke;

[Flags]
public enum GdipStringFormatAttributes : int
{
    DirectionVertical = 0x00000001,
    DirectionRightToLeft = 0x00000002,
    DirectionFarToNear = 0x00000004,
    NoFontFallback = 0x00000400,
    NoWrap = 0x00001000,
    NoClip = 0x00004000,
    DisplayFormatControl = 0x00000020,
    LineLimit = 0x00002000,
    MeasureTrailingSpaces = 0x00000800
}