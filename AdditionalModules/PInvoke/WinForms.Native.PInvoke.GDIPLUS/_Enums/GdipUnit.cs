namespace WinForms.Native.PInvoke;

public enum GdipUnit : int
{
    /// <summary>
    /// Specified in transformation
    /// </summary>
    World = 0,
    /// <summary>
    /// For video it's pixels
    /// </summary>
    Display = 1,
    Pixel = 2,
    /// <summary>
    /// 1/72 of inch
    /// </summary>
    Point = 3,
    Inch = 4,
    /// <summary>
    /// 1/300 of inch
    /// </summary>
    Document = 5,
    Millimeter = 6
}