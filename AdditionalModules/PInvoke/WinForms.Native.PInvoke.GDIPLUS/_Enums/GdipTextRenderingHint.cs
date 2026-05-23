namespace WinForms.Native.PInvoke;

public enum TextRenderingHint : int
{
    SystemDefault = 0,
    SingleBitPerPixelGridFit = 1,
    SingleBitPerPixel = 2,
    AntiAliasGridFit = 3,
    AntiAlias = 4,
    ClearTypeGridFit = 5 // Best quality for LCD screens
}