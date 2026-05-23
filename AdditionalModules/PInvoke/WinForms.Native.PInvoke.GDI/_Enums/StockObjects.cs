namespace WinForms.Native.PInvoke;

[Flags]
public enum StockObjects : int
{
    WHITE_BRUSH = 0,
    LTGRAY_BRUSH = 1,
    GRAY_BRUSH = 2,
    DKGRAY_BRUSH = 3,
    BLACK_BRUSH = 4,
    NULL_BRUSH = 5,
    HOLLOW_BRUSH = NULL_BRUSH,
    WHITE_PEN = 6,
    BLACK_PEN = 7,
    NULL_PEN = 8,
}