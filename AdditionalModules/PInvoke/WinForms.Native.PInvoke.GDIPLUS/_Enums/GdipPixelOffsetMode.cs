namespace WinForms.Native.PInvoke;

public enum GdipPixelOffsetMode : int
{
    Invalid = -1,
    Default = 0,
    HighSpeed = 1,
    HighQuality = 2, // Centers pixels; crucial for 1px lines/borders
    None = 3,
    Half = 4         // Offsets by -0.5, -0.5 for cleanest sharp lines
}