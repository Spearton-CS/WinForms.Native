namespace WinForms.Native.PInvoke;

[Flags]
public enum GdipFontStyle : int
{
    Regular = 0,
    Bold = 1,
    Italic = 2,
    BoldItalic = 3,
    Underline = 4,
    Strikeout = 8
}