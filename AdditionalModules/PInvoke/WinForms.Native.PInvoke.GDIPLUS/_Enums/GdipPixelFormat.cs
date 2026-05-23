namespace WinForms.Native.PInvoke;

public enum GdipPixelFormat
{
    Undefined = 0,
    Format1bppIndexed = 0x30101,
    Format4bppIndexed = 0x30402,
    Format8bppIndexed = 0x30803,
    Format16bppGrayScale = 0x10504,
    Format16bppRGB555 = 0x20505,
    Format16bppRGB565 = 0x20506,
    Format24bppRGB = 0x21808,
    Format32bppRGB = 0x22009,
    Format32bppARGB = 0x26200A, // Standard for UI
    Format32bppPARGB = 0xE200B,
    Format48bppRGB = 0x3030F,
    Format64bppARGB = 0x342010
}