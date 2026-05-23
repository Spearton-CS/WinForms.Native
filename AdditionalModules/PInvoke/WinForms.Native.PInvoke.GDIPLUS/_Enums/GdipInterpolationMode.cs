namespace WinForms.Native.PInvoke;

public enum GdipInterpolationMode : int
{
    Invalid = -1,
    Default = 0,
    LowQuality = 1,
    HighQuality = 2,
    Bilinear = 3,
    Bicubic = 4,
    NearestNeighbor = 5,
    HighQualityBilinear = 6,
    HighQualityBicubic = 7
}