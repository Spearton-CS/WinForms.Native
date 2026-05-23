namespace WinForms.Native.PInvoke;

[Flags]
public enum TernaryRasterOperations : uint
{
    /// <summary>
    /// Direct copy
    /// </summary>
    SrcCopy = 0x00CC0020,
    /// <summary>
    /// OR
    /// </summary>
    SrcPaint = 0x00EE0086,
    /// <summary>
    /// AND
    /// </summary>
    SrcAnd = 0x008800C6,
    /// <summary>
    /// XOR
    /// </summary>
    SrcInvert = 0x00660046,
    SrcErase = 0x00440328,
    NotSrcCopy = 0x00330008,
    NotSrcErase = 0x001100A6,
    MergeCopy = 0x00C000CA,
    MergePaint = 0x00BB0226,
    PatCopy = 0x00F00021,
    PatPaint = 0x00FB0A09,
    PatInvert = 0x005A0049,
    DstInvert = 0x00550009,
    Blackness = 0x00000042,
    Whiteness = 0x00FF0062
}