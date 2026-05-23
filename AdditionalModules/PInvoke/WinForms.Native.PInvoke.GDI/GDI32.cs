using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

public static unsafe partial class GDI32
{
    public const string DLL = "gdi32.dll";

    [LibraryImport(DLL)]
    public static partial GdiHDC CreateCompatibleDC(GdiHDC hdc);

    [LibraryImport(DLL)]
    public static partial GdiHBitmap CreateCompatibleBitmap(GdiHDC hdc, int cx, int cy);

    [LibraryImport(DLL)]
    public static partial GdiHObj SelectObject(GdiHDC hdc, Handle h);

    [LibraryImport(DLL)]
    public static partial BOOL DeleteObject(GdiHObj ho);

    [LibraryImport(DLL)]
    public static partial BOOL DeleteDC(GdiHDC hdc);

    [LibraryImport(DLL)]
    public static partial BOOL BitBlt(
        GdiHDC hdcDest, int xDest, int yDest, int w, int h,
        GdiHDC hdcSource, int xSrc, int ySrc, GdiTernaryRasterOperations rop);
    [LibraryImport(DLL)]
    public static partial BOOL PatBlt(GdiHDC hdc,
        int x, int y, int w, int h,
        GdiTernaryRasterOperations rop);

    [LibraryImport(DLL)]
    public static partial GdiHObj GetStockObject(GdiStockObjects i);

    [LibraryImport(DLL, StringMarshalling = StringMarshalling.Utf16)]
    public static partial BOOL TextOutW(GdiHDC hdc, int x, int y, char* lpString, int len);
    [LibraryImport(DLL, StringMarshalling = StringMarshalling.Utf16)]
    public static partial BOOL TextOutW(GdiHDC hdc, int x, int y, string lpString, int len);

    [LibraryImport(DLL)]
    public static partial GdiColor SetTextColor(GdiHDC hdc, GdiColor crColor);

    [LibraryImport(DLL)]
    public static partial GdiBackgroundMode SetBkMode(GdiHDC hdc, GdiBackgroundMode mode);

    [LibraryImport(DLL)]
    public static partial GdiHBrush CreateSolidBrush(GdiColor crColor);

    [LibraryImport(DLL)]
    public static partial GdiHPen CreatePen(GdiPenStyle fnPenStyle, int nWidth, GdiColor crColor);

    [LibraryImport(DLL)]
    public static partial BOOL Rectangle(GdiHDC hdc, int left, int top, int right, int bottom);

    [LibraryImport(DLL)]
    public static partial BOOL GetTextExtentPoint32W(GdiHDC hdc, char* lpString, int len, out SIZE lpSize);
    [LibraryImport(DLL, StringMarshalling = StringMarshalling.Utf16)]
    public static partial BOOL GetTextExtentPoint32W(GdiHDC hdc, string lpString, int len, out SIZE lpSize);

    [LibraryImport(DLL)]
    public static partial GdiHFont CreateFontW(
        int nHeight, int nWidth, int nEscapement, int nOrientation,
        GdiFontWeight fnWeight, byte fdwItalic, byte fdwUnderline, byte fdwStrikeOut,
        GdiFontCharSet fdwCharSet, GdiFontOutputPrecision fdwOutputPrecision, GdiFontClipPrecision fdwClipPrecision,
        GdiFontQuality fdwQuality, GdiFontPitchAndFamily fdwPitchAndFamily, char* lpszFace); //400 - Normal 700 - Bold (fnWeight), 4 - ANTIALIAS, 6 - CLEARTYPE (fdwQuality)
    [LibraryImport(DLL, StringMarshalling = StringMarshalling.Utf16)]
    public static partial GdiHFont CreateFontW(
        int nHeight, int nWidth, int nEscapement, int nOrientation,
        GdiFontWeight fnWeight, byte fdwItalic, byte fdwUnderline, byte fdwStrikeOut,
        GdiFontCharSet fdwCharSet, GdiFontOutputPrecision fdwOutputPrecision, GdiFontClipPrecision fdwClipPrecision,
        GdiFontQuality fdwQuality, GdiFontPitchAndFamily fdwPitchAndFamily, string lpszFace);
}