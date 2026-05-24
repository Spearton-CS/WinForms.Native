using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

public static unsafe partial class GDI32
{
    public const string DLL = "gdi32.dll";

    #region Live-cycle

    #region Create

    [LibraryImport(DLL, SetLastError = true)]
    public static partial GdiHDC CreateCompatibleDC(GdiHDC hdc);
    [LibraryImport(DLL, SetLastError = true)]
    public static partial GdiHBitmap CreateCompatibleBitmap(GdiHDC hdc, int cx, int cy);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial GdiHBrush CreateSolidBrush(GdiColor crColor);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial GdiHPen CreatePen(GdiPenStyle fnPenStyle, int nWidth, GdiColor crColor);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial GdiHFont CreateFontW(
        int nHeight, int nWidth, int nEscapement, int nOrientation,
        GdiFontWeight fnWeight, byte fdwItalic, byte fdwUnderline, byte fdwStrikeOut,
        GdiFontCharSet fdwCharSet, GdiFontOutputPrecision fdwOutputPrecision, GdiFontClipPrecision fdwClipPrecision,
        GdiFontQuality fdwQuality, GdiFontPitchAndFamily fdwPitchAndFamily, char* lpszFace); //400 - Normal 700 - Bold (fnWeight), 4 - ANTIALIAS, 6 - CLEARTYPE (fdwQuality)
    [LibraryImport(DLL, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial GdiHFont CreateFontW(
        int nHeight, int nWidth, int nEscapement, int nOrientation,
        GdiFontWeight fnWeight, byte fdwItalic, byte fdwUnderline, byte fdwStrikeOut,
        GdiFontCharSet fdwCharSet, GdiFontOutputPrecision fdwOutputPrecision, GdiFontClipPrecision fdwClipPrecision,
        GdiFontQuality fdwQuality, GdiFontPitchAndFamily fdwPitchAndFamily, string lpszFace);

    #endregion

    #region Delete

    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL DeleteObject(GdiHObj ho);
    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL DeleteDC(GdiHDC hdc);

    #endregion

    [LibraryImport(DLL, SetLastError = true)]
    public static partial GdiHObj SelectObject(GdiHDC hdc, Handle h);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial GdiHObj GetStockObject(GdiStockObjects i);

    #endregion

    #region Draw text

    [LibraryImport(DLL, SetLastError = true)]
    public static partial GdiColor SetTextColor(GdiHDC hdc, GdiColor crColor);

    [LibraryImport(DLL, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial BOOL TextOutW(GdiHDC hdc, int x, int y, char* lpString, int len);
    [LibraryImport(DLL, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial BOOL TextOutW(GdiHDC hdc, int x, int y, string lpString, int len);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL GetTextExtentPoint32W(GdiHDC hdc, char* lpString, int len, out Size lpSize);
    [LibraryImport(DLL, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial BOOL GetTextExtentPoint32W(GdiHDC hdc, string lpString, int len, out Size lpSize);

    #endregion

    #region Draw images

    [LibraryImport(DLL, SetLastError = true)]
    public static partial GdiHBitmap CreateDIBSection(
        GdiHDC hdc,
        ref GdiBitmapInfo pbmi,
        GdiDibIUsage iUsage,
        out byte* ppvBits,
        Handle hSection, uint dwOffset);

    #endregion

    #region Draw

    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL BitBlt(
        GdiHDC hdcDest, int xDest, int yDest, int w, int h,
        GdiHDC hdcSource, int xSrc, int ySrc, GdiTernaryRasterOperations rop);
    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL PatBlt(GdiHDC hdc,
        int x, int y, int w, int h,
        GdiTernaryRasterOperations rop);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial GdiBackgroundMode SetBkMode(GdiHDC hdc, GdiBackgroundMode mode);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL Rectangle(GdiHDC hdc, int left, int top, int right, int bottom);
    [LibraryImport(DLL, SetLastError = true)]
    public static partial int FillRect(GdiHDC hdc, ref Rect lprc, GdiHBrush hbr);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL MoveToEx(GdiHDC hdc, int x, int y, ref Point lpPoint);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static BOOL MoveToEx(GdiHDC hdc, int x, int y) => MoveToEx(hdc, x, y, ref Unsafe.NullRef<Point>());

    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL LineTo(GdiHDC hdc, int x, int y);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial BOOL Ellipse(GdiHDC hdc, int left, int top, int right, int bottom);

    #endregion

    #region Clipping & Regions

    [LibraryImport(DLL, SetLastError = true)]
    public static partial GdiHRegion CreateRectRgn(int x1, int y1, int x2, int y2);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial GdiRegionType SelectClipRgn(GdiHDC hdc, GdiHRegion hrgn);

    #endregion

    #region Transparency

    [LibraryImport("msimg32.dll", SetLastError = true)]
    public static partial BOOL AlphaBlend(
        GdiHDC hdcDest,
        int xDest, int yDest, int wDest, int hDest,
        GdiHDC hdcSrc,
        int xSrc, int ySrc, int wSrc, int hSrc,
        MsimgBlendFunction blendFunction);

    #endregion
}