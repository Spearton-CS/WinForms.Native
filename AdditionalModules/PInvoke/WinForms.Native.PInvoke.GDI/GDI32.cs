using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

public static unsafe partial class GDI32
{
    public const string DLL = "gdi32.dll";

    #region Live-cycle

    #region Create

    [LibraryImport(DLL)]
    public static partial GdiHDC CreateCompatibleDC(GdiHDC hdc);
    [LibraryImport(DLL)]
    public static partial GdiHBitmap CreateCompatibleBitmap(GdiHDC hdc, int cx, int cy);

    [LibraryImport(DLL)]
    public static partial GdiHBrush CreateSolidBrush(GdiColor crColor);

    [LibraryImport(DLL)]
    public static partial GdiHPen CreatePen(GdiPenStyle fnPenStyle, int nWidth, GdiColor crColor);

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

    #endregion

    #region Delete

    [LibraryImport(DLL)]
    public static partial BOOL DeleteObject(GdiHObj ho);
    [LibraryImport(DLL)]
    public static partial BOOL DeleteDC(GdiHDC hdc);

    #endregion

    [LibraryImport(DLL)]
    public static partial GdiHObj SelectObject(GdiHDC hdc, Handle h);

    [LibraryImport(DLL)]
    public static partial GdiHObj GetStockObject(GdiStockObjects i);

    #endregion

    #region Draw text

    [LibraryImport(DLL)]
    public static partial GdiColor SetTextColor(GdiHDC hdc, GdiColor crColor);

    [LibraryImport(DLL, StringMarshalling = StringMarshalling.Utf16)]
    public static partial BOOL TextOutW(GdiHDC hdc, int x, int y, char* lpString, int len);
    [LibraryImport(DLL, StringMarshalling = StringMarshalling.Utf16)]
    public static partial BOOL TextOutW(GdiHDC hdc, int x, int y, string lpString, int len);

    [LibraryImport(DLL)]
    public static partial BOOL GetTextExtentPoint32W(GdiHDC hdc, char* lpString, int len, out SIZE lpSize);
    [LibraryImport(DLL, StringMarshalling = StringMarshalling.Utf16)]
    public static partial BOOL GetTextExtentPoint32W(GdiHDC hdc, string lpString, int len, out SIZE lpSize);

    #endregion

    #region Draw images

    [LibraryImport(DLL)]
    public static partial GdiHBitmap CreateDIBSection(
        GdiHDC hdc,
        ref GdiBitmapInfo pbmi,
        GdiDibIUsage iUsage,
        out byte* ppvBits,
        Handle hSection, uint dwOffset);

    #endregion

    #region Draw

    [LibraryImport(DLL)]
    public static partial BOOL BitBlt(
        GdiHDC hdcDest, int xDest, int yDest, int w, int h,
        GdiHDC hdcSource, int xSrc, int ySrc, GdiTernaryRasterOperations rop);
    [LibraryImport(DLL)]
    public static partial BOOL PatBlt(GdiHDC hdc,
        int x, int y, int w, int h,
        GdiTernaryRasterOperations rop);

    [LibraryImport(DLL)]
    public static partial GdiBackgroundMode SetBkMode(GdiHDC hdc, GdiBackgroundMode mode);

    [LibraryImport(DLL)]
    public static partial BOOL Rectangle(GdiHDC hdc, int left, int top, int right, int bottom);
    [LibraryImport(DLL)]
    public static partial int FillRect(GdiHDC hdc, ref RECT lprc, GdiHBrush hbr);

    [LibraryImport(DLL)]
    public static partial BOOL MoveToEx(GdiHDC hdc, int x, int y, ref POINT lpPoint);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static BOOL MoveToEx(GdiHDC hdc, int x, int y) => MoveToEx(hdc, x, y, ref Unsafe.NullRef<POINT>());

    [LibraryImport(DLL)]
    public static partial BOOL LineTo(GdiHDC hdc, int x, int y);

    [LibraryImport(DLL)]
    public static partial BOOL Ellipse(GdiHDC hdc, int left, int top, int right, int bottom);

    #endregion

    #region Clipping & Regions

    [LibraryImport(DLL)]
    public static partial GdiHRegion CreateRectRgn(int x1, int y1, int x2, int y2);

    [LibraryImport(DLL)]
    public static partial GdiRegionType SelectClipRgn(GdiHDC hdc, GdiHRegion hrgn);

    #endregion

    #region Transparency

    [LibraryImport("msimg32.dll")]
    public static partial BOOL AlphaBlend(
        GdiHDC hdcDest,
        int xDest, int yDest, int wDest, int hDest,
        GdiHDC hdcSrc,
        int xSrc, int ySrc, int wSrc, int hSrc,
        MsimgBlendFunction blendFunction);

    #endregion
}