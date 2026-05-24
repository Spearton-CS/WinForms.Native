using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

public static unsafe partial class GDIP
{
    public const string DLL = "gdiplus.dll";

    #region Init|Deinit GDI+ for process

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdiplusStartup")]
    //[UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])] //IDK needed it or LibraryImport will decide it self...
    public static partial GdipStatus Startup(out GdipHSessionToken token, in GdipStartupInput input, GdipStartupOutput* output);
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdiplusStartup")]
    public static partial GdipStatus Startup(out GdipHSessionToken token, in GdipStartupInput input, out GdipStartupOutput output);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GdipStatus Startup(out GdipHSessionToken token, in GdipStartupInput input)
        => Startup(out token, in input, null);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdiplusShutdown")]
    public static partial void Shutdown(GdipHSessionToken token);

    #endregion

    #region Live-cycle

    #region Create

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateFromHDC")]
    public static partial GdipStatus CreateFromHDC(GdiHDC hdc, out GdipHGraphics graphics);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateBitmapFromHBITMAP")]
    public static partial GdipStatus CreateBitmapFromHBITMAP(
        GdiHBitmap hbm, GdiHPalette hpal, out GdipHBitmap bitmap);
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateBitmapFromScan0")]
    public static partial GdipStatus CreateBitmapFromScan0(
        int width, int height,
        int stride, GdipPixelFormat format,
        byte* scan0, out GdipHBitmap bitmap);

    /// <summary> Creates a pen object with a specified color and width. </summary>
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreatePen1")]
    public static partial GdipStatus CreatePen(GdipColor color, float width, GdipUnit unit, out GdipHPen pen);

    /// <summary> Creates a solid color brush. </summary>
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateSolidFill")]
    public static partial GdipStatus CreateSolidBrush(GdipColor color, out GdipHBrush brush);
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateLineBrushI")]
    public static partial GdipStatus CreateLineBrush(
        in Point pt1, in Point pt2,
        GdipColor color1, GdipColor color2,
        GdipWrapMode wrapMode, out GdipHBrush brush);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateFontFamilyFromName")]
    public static partial GdipStatus CreateFontFamilyFromName(
        char* name, GdipHFontCollection fontCollection, out GdipHFontFamily fontFamily);
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateFontFamilyFromName", StringMarshalling = StringMarshalling.Utf16)]
    public static partial GdipStatus CreateFontFamilyFromName(
        string name, GdipHFontCollection fontCollection, out GdipHFontFamily fontFamily);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateFont")]
    public static partial GdipStatus CreateFont(
        GdipHFontFamily fontFamily,
        float emSize, GdipFontStyle style, GdipUnit unit,
        out GdipHFont font);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreatePath")]
    public static partial GdipStatus CreatePath(GdipFillMode fillMode, out GdipHPath path);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateStringFormat")]
    public static partial GdipStatus CreateStringFormat(
        GdipStringFormatAttributes formatAttributes, LanguageId language, out GdipHStringFormat format);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateMatrix")]
    public static partial GdipStatus CreateMatrix(out GdipHMatrix matrix);

    #endregion

    #region Load

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipLoadImageFromFile")]
    public static partial GdipStatus LoadImageFromFile(char* filename, out GdipHImage image);
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipLoadImageFromFile", StringMarshalling = StringMarshalling.Utf16)]
    public static partial GdipStatus LoadImageFromFile(string filename, out GdipHImage image);

    #endregion

    #region Delete

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDeleteGraphics")]
    public static partial GdipStatus DeleteGraphics(GdipHGraphics graphics);

    /// <summary> Cleans up the pen object and releases its native memory. </summary>
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDeletePen")]
    public static partial GdipStatus DeletePen(GdipHPen pen);

    /// <summary> Cleans up the brush object. </summary>
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDeleteBrush")]
    public static partial GdipStatus DeleteBrush(GdipHBrush brush);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDeleteFont")]
    public static partial GdipStatus DeleteFont(GdipHFont font);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDeleteFontFamily")]
    public static partial GdipStatus DeleteFontFamily(GdipHFontFamily fontFamily);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDeletePath")]
    public static partial GdipStatus DeletePath(GdipHPath path);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDeleteStringFormat")]
    public static partial GdipStatus DeleteStringFormat(GdipHStringFormat format);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDeleteMatrix")]
    public static partial GdipStatus DeleteMatrix(GdipHMatrix matrix);

    #endregion

    #region Dispose

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDisposeImage")]
    public static partial GdipStatus DisposeImage(GdipHImage image);

    #endregion

    #endregion

    #region Draw

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDrawLine")]
    public static partial GdipStatus DrawLine(
        GdipHGraphics graphics, GdipHPen pen,
        float x1, float y1, float x2, float y2);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDrawRectangle")]
    public static partial GdipStatus DrawRectangle(
        GdipHGraphics graphics, GdipHPen pen,
        float x, float y, float width, float height);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDrawPath")]
    public static partial GdipStatus DrawPath(GdipHGraphics graphics, GdipHPen pen, GdipHPath path);

    #endregion

    #region Fill

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipGraphicsClear")]
    public static partial GdipStatus Clear(GdipHGraphics graphics, GdipColor color);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipFillRectangle")]
    public static partial GdipStatus FillRectangle(
        GdipHGraphics graphics, GdipHBrush brush,
        float x, float y, float width, float height);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipFillPath")]
    public static partial GdipStatus FillPath(GdipHGraphics graphics, GdipHBrush brush, GdipHPath path);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDrawEllipse")]
    public static partial GdipStatus DrawEllipse(
        GdipHGraphics graphics, GdipHPen pen,
        float x, float y, float width, float height);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipFillEllipse")]
    public static partial GdipStatus FillEllipse(
        GdipHGraphics graphics, GdipHBrush brush,
        float x, float y, float width, float height);

    #endregion

    #region Draw text

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipMeasureString", StringMarshalling = StringMarshalling.Utf16)]
    public static partial GdipStatus MeasureString(
        GdipHGraphics graphics,
        string text, int length, GdipHFont font,
        in GdipRectF layoutRect, GdipHStringFormat stringFormat, out GdipRectF boundingBox,
        out int codepointsFitted, out int linesFilled);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipMeasureString")]
    public static partial GdipStatus MeasureString(
        GdipHGraphics graphics,
        char* text, int length, GdipHFont font,
        in GdipRectF layoutRect, GdipHStringFormat stringFormat, out GdipRectF boundingBox,
        out int codepointsFitted, out int linesFilled);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDrawString")]
    public static partial GdipStatus DrawString(
        GdipHGraphics graphics,
        char* text, int length, GdipHFont font,
        in GdipRectF layoutRect, GdipHStringFormat stringFormat,
        GdipHBrush brush);
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDrawString", StringMarshalling = StringMarshalling.Utf16)]
    public static partial GdipStatus DrawString(
        GdipHGraphics graphics,
        string text, int length, GdipHFont font,
        in GdipRectF layoutRect, GdipHStringFormat stringFormat,
        GdipHBrush brush);

    #endregion

    #region Draw image

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipGetImageWidth")]
    public static partial GdipStatus GetImageWidth(GdipHImage image, out uint width);
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipGetImageHeight")]
    public static partial GdipStatus GetImageHeight(GdipHImage image, out uint height);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDrawImage")]
    public static partial GdipStatus DrawImage(GdipHGraphics graphics, GdipHImage image, float x, float y);

    #endregion

    #region Path

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipAddPathLine")]
    public static partial GdipStatus AddPathLine(GdipHPath path, float x1, float y1, float x2, float y2);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipClosePathFigure")]
    public static partial GdipStatus ClosePathFigure(GdipHPath path);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipAddPathRectangle")]
    public static partial GdipStatus AddPathRectangle(
        GdipHPath path,
        float x, float y, float width, float height);

    #endregion

    #region Settings of Graphics

    /// <summary> Sets the rendering quality (Antialiasing). </summary>
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipSetSmoothingMode")]
    public static partial GdipStatus SetSmoothingMode(GdipHGraphics graphics, GdipSmoothingMode smoothingMode);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipSetTextRenderingHint")]
    public static partial GdipStatus SetTextRenderingHint(GdipHGraphics graphics, TextRenderingHint hint);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipSetPixelOffsetMode")]
    public static partial GdipStatus SetPixelOffsetMode(
    GdipHGraphics graphics, GdipPixelOffsetMode pixelOffsetMode);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipSetInterpolationMode")]
    public static partial GdipStatus SetInterpolationMode(
        GdipHGraphics graphics, GdipInterpolationMode interpolationMode);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipSetWorldTransform")]
    public static partial GdipStatus SetWorldTransform(GdipHGraphics graphics, GdipHMatrix matrix);

    #endregion

    #region Settings of StringFormat

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipSetStringFormatAlign")]
    public static partial GdipStatus SetStringFormatAlign(GdipHStringFormat format, GdipStringAlignment align);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipSetStringFormatLineAlign")]
    public static partial GdipStatus SetStringFormatLineAlign(GdipHStringFormat format, GdipStringAlignment align);

    #endregion

    #region Coordinates

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipTranslateWorldTransform")]
    public static partial GdipStatus TranslateWorldTransform(
        GdipHGraphics graphics,
        float dx, float dy,
        GdipMatrixOrder order);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipScaleWorldTransform")]
    public static partial GdipStatus ScaleWorldTransform(
        GdipHGraphics graphics,
        float sx, float sy,
        GdipMatrixOrder order);

    #endregion

    #region Clipping and containering

    #region Clip

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipSetClipRectI")]
    public static partial int SetClipRect(GdipHGraphics graphics,
        int x, int y, int w, int h, GdipCombineMode combineMode);
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipSetClipRect")]
    public static partial int SetClipRect(GdipHGraphics graphics,
        float x, float y, float w, float h, GdipCombineMode combineMode);
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipResetClip")]
    public static partial int ResetClip(GdipHGraphics graphics);

    #endregion

    #region Container

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipBeginContainer")]
    public static partial GdipStatus BeginContainer(
        GdipHGraphics graphics,
        in GdipRectF dstRect, in GdipRectF srcRect,
        GdipUnit unit, out uint state);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipEndContainer")]
    public static partial GdipStatus EndContainer(GdipHGraphics graphics, uint state);

    #endregion

    #endregion
}