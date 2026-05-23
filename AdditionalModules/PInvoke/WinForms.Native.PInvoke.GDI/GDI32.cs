using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

public static unsafe partial class GDI32
{
    public const string DLL = "gdi32.dll";

    [LibraryImport(DLL)]
    public static partial HDC CreateCompatibleDC(HDC hdc);

    [LibraryImport(DLL)]
    public static partial HBITMAP CreateCompatibleBitmap(HDC hdc, int cx, int cy);

    [LibraryImport(DLL)]
    public static partial HGDIOBJ SelectObject(HDC hdc, Handle h);

    [LibraryImport(DLL)]
    public static partial BOOL DeleteObject(HGDIOBJ ho);

    [LibraryImport(DLL)]
    public static partial BOOL DeleteDC(HDC hdc);

    [LibraryImport(DLL)]
    public static partial BOOL BitBlt(
        HDC hdcDest, int xDest, int yDest, int w, int h,
        HDC hdcSource, int xSrc, int ySrc, TernaryRasterOperations rop);
    [LibraryImport(DLL)]
    public static partial BOOL PatBlt(HDC hdc,
        int x, int y, int w, int h,
        TernaryRasterOperations rop);

    [LibraryImport(DLL)]
    public static partial HGDIOBJ GetStockObject(StockObjects i);

    [LibraryImport(DLL, StringMarshalling = StringMarshalling.Utf16)]
    public static partial BOOL TextOutW(HDC hdc, int x, int y, char* lpString, int len);
    [LibraryImport(DLL, StringMarshalling = StringMarshalling.Utf16)]
    public static partial BOOL TextOutW(HDC hdc, int x, int y, string lpString, int len);

    [LibraryImport(DLL)]
    public static partial uint SetTextColor(HDC hdc, GdiColor crColor);

    [LibraryImport(DLL)]
    public static partial uint SetBkMode(HDC hdc, int mode); // 1 = TRANSPARENT

    [LibraryImport(DLL)]
    public static partial HGDIOBJ CreateSolidBrush(GdiColor crColor);

    [LibraryImport(DLL)]
    public static partial HGDIOBJ CreatePen(int fnPenStyle, int nWidth, GdiColor crColor);

    [LibraryImport(DLL)]
    public static partial BOOL Rectangle(HDC hdc, int left, int top, int right, int bottom);

    [LibraryImport(DLL)]
    public static partial BOOL GetTextExtentPoint32W(HDC hdc, char* lpString, int len, out SIZE lpSize);
    [LibraryImport(DLL, StringMarshalling = StringMarshalling.Utf16)]
    public static partial BOOL GetTextExtentPoint32W(HDC hdc, string lpString, int len, out SIZE lpSize);

    [LibraryImport(DLL)]
    public static partial HGDIOBJ CreateFontW(
        int nHeight, int nWidth, int nEscapement, int nOrientation,
        int fnWeight, uint fdwItalic, uint fdwUnderline, uint fdwStrikeOut,
        uint fdwCharSet, uint fdwOutputPrecision, uint fdwClipPrecision,
        uint fdwQuality, uint fdwPitchAndFamily, char* lpszFace); //400 - Normal 700 - Bold (fnWeight), 4 - ANTIALIAS, 6 - CLEARTYPE (fdwQuality)
    [LibraryImport(DLL, StringMarshalling = StringMarshalling.Utf16)]
    public static partial HGDIOBJ CreateFontW(
        int nHeight, int nWidth, int nEscapement, int nOrientation,
        int fnWeight, uint fdwItalic, uint fdwUnderline, uint fdwStrikeOut,
        uint fdwCharSet, uint fdwOutputPrecision, uint fdwClipPrecision,
        uint fdwQuality, uint fdwPitchAndFamily, string lpszFace);
}