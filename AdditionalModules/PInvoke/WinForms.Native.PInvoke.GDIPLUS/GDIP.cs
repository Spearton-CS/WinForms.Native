using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

public static unsafe partial class GDIP
{
    public const string DLL = "gdiplus.dll";

    [LibraryImport(DLL, EntryPoint = "GdiplusStartup")]
    public static partial GdipStatus Startup(out nint token, in GdipStartupInput input, nint output);
    [LibraryImport(DLL, EntryPoint = "GdiplusShutdown")]
    public static partial void Shutdown(nint token);

    [LibraryImport(DLL, EntryPoint = "GdipCreateFromHDC")]
    public static partial GdipStatus CreateFromHDC(GdiHDC hdc, out GdipHGraphics graphics);

    [LibraryImport(DLL, EntryPoint = "GdipGraphicsClear")]
    public static partial GdipStatus Clear(GdipHGraphics graphics, GdipColor color);

    [LibraryImport(DLL, EntryPoint = "GdipDrawLine")]
    public static partial GdipStatus DrawLine(
        GdipHGraphics graphics, GdipHPen pen,
        float x1, float y1, float x2, float y2);

    [LibraryImport(DLL, EntryPoint = "GdipDeleteGraphics")]
    public static partial GdipStatus DeleteGraphics(GdipHGraphics graphics);

    /// <summary> Creates a pen object with a specified color and width. </summary>
    [LibraryImport(DLL, EntryPoint = "GdipCreatePen1")]
    public static partial GdipStatus CreatePen(GdipColor color, float width, GdipUnit unit, out GdipHPen pen);

    /// <summary> Cleans up the pen object and releases its native memory. </summary>
    [LibraryImport(DLL, EntryPoint = "GdipDeletePen")]
    public static partial GdipStatus DeletePen(GdipHPen pen);

    /// <summary> Creates a solid color brush. </summary>
    [LibraryImport(DLL, EntryPoint = "GdipCreateSolidFill")]
    public static partial GdipStatus CreateSolidFill(GdipColor color, out GdipHBrush brush);

    /// <summary> Cleans up the brush object. </summary>
    [LibraryImport(DLL, EntryPoint = "GdipDeleteBrush")]
    public static partial GdipStatus DeleteBrush(GdipHBrush brush);

    /// <summary> Sets the rendering quality (Antialiasing). </summary>
    [LibraryImport(DLL, EntryPoint = "GdipSetSmoothingMode")]
    public static partial GdipStatus SetSmoothingMode(GdipHGraphics graphics, GdipSmoothingMode smoothingMode);

    [LibraryImport(DLL, EntryPoint = "GdipDrawRectangle")]
    public static partial GdipStatus DrawRectangle(
        GdipHGraphics graphics, GdipHPen pen,
        float x, float y, float width, float height);

    [LibraryImport(DLL, EntryPoint = "GdipFillRectangle")]
    public static partial GdipStatus FillRectangle(
        GdipHGraphics graphics, GdipHBrush brush,
        float x, float y, float width, float height);

    [LibraryImport(DLL, EntryPoint = "GdipCreateFontFamilyFromName")]
    public static partial GdipStatus CreateFontFamilyFromName(
        char* name, GdipHFontCollection fontCollection, out GdipHFontFamily fontFamily);
    [LibraryImport(DLL, EntryPoint = "GdipCreateFontFamilyFromName", StringMarshalling = StringMarshalling.Utf16)]
    public static partial GdipStatus CreateFontFamilyFromName(
        string name, GdipHFontCollection fontCollection, out GdipHFontFamily fontFamily);

    [LibraryImport(DLL, EntryPoint = "GdipCreateFont")]
    public static partial GdipStatus CreateFont(
        GdipHFontFamily fontFamily,
        float emSize, GdipFontStyle style, GdipUnit unit,
        out GdipHFont font);

    [LibraryImport(DLL, EntryPoint = "GdipDrawString")]
    public static partial GdipStatus DrawString(
        GdipHGraphics graphics,
        char* text, int length, GdipHFont font,
        in GdipRectF layoutRect, GdipHStringFormat stringFormat,
        GdipHBrush brush);
    [LibraryImport(DLL, EntryPoint = "GdipDrawString", StringMarshalling = StringMarshalling.Utf16)]
    public static partial GdipStatus DrawString(
        GdipHGraphics graphics,
        string text, int length, GdipHFont font,
        in GdipRectF layoutRect, GdipHStringFormat stringFormat,
        GdipHBrush brush);

    [LibraryImport(DLL, EntryPoint = "GdipDeleteFont")]
    public static partial GdipStatus DeleteFont(GdipHFont font);

    [LibraryImport(DLL, EntryPoint = "GdipDeleteFontFamily")]
    public static partial GdipStatus DeleteFontFamily(GdipHFontFamily fontFamily);

    [LibraryImport(DLL, EntryPoint = "GdipCreatePath")]
    public static partial GdipStatus CreatePath(GdipFillMode fillMode, out GdipHPath path);

    [LibraryImport(DLL, EntryPoint = "GdipAddPathLine")]
    public static partial GdipStatus AddPathLine(GdipHPath path, float x1, float y1, float x2, float y2);

    [LibraryImport(DLL, EntryPoint = "GdipClosePathFigure")]
    public static partial GdipStatus ClosePathFigure(GdipHPath path);

    [LibraryImport(DLL, EntryPoint = "GdipDrawPath")]
    public static partial GdipStatus DrawPath(GdipHGraphics graphics, GdipHPen pen, GdipHPath path);

    [LibraryImport(DLL, EntryPoint = "GdipFillPath")]
    public static partial GdipStatus FillPath(GdipHGraphics graphics, GdipHBrush brush, GdipHPath path);

    [LibraryImport(DLL, EntryPoint = "GdipDeletePath")]
    public static partial GdipStatus DeletePath(GdipHPath path);

    [LibraryImport(DLL, EntryPoint = "GdipTranslateWorldTransform")]
    public static partial GdipStatus TranslateWorldTransform(
        GdipHGraphics graphics,
        float dx, float dy,
        GdipMatrixOrder order);

    [LibraryImport(DLL, EntryPoint = "GdipScaleWorldTransform")]
    public static partial GdipStatus ScaleWorldTransform(
        GdipHGraphics graphics,
        float sx, float sy,
        GdipMatrixOrder order);

    [LibraryImport(DLL, EntryPoint = "GdipCreateBitmapFromHBITMAP")]
    public static partial GdipStatus CreateBitmapFromHBITMAP(
        GdiHBitmap hbm, GdiHPalette hpal, out GdipHBitmap bitmap);

    [LibraryImport(DLL, EntryPoint = "GdipSetTextRenderingHint")]
    public static partial GdipStatus SetTextRenderingHint(GdipHGraphics graphics, TextRenderingHint hint);

    [LibraryImport(DLL, EntryPoint = "GdipMeasureString", StringMarshalling = StringMarshalling.Utf16)]
    public static partial GdipStatus MeasureString(
        GdipHGraphics graphics,
        string text, int length, GdipHFont font,
        in GdipRectF layoutRect, GdipHStringFormat stringFormat, out GdipRectF boundingBox,
        out int codepointsFitted, out int linesFilled);

    [LibraryImport(DLL, EntryPoint = "GdipMeasureString")]
    public static partial GdipStatus MeasureString(
        GdipHGraphics graphics,
        char* text, int length, GdipHFont font,
        in GdipRectF layoutRect, GdipHStringFormat stringFormat, out GdipRectF boundingBox,
        out int codepointsFitted, out int linesFilled);

    [LibraryImport(DLL, EntryPoint = "GdipSetPixelOffsetMode")]
    public static partial GdipStatus SetPixelOffsetMode(
        GdipHGraphics graphics, GdipPixelOffsetMode pixelOffsetMode);

    [LibraryImport(DLL, EntryPoint = "GdipSetInterpolationMode")]
    public static partial GdipStatus SetInterpolationMode(
        GdipHGraphics graphics, GdipInterpolationMode interpolationMode);

    [LibraryImport(DLL, EntryPoint = "GdipCreateStringFormat")]
    public static partial GdipStatus CreateStringFormat(
        GdipStringFormatAttributes formatAttributes, LanguageId language, out GdipHStringFormat format);

    [LibraryImport(DLL, EntryPoint = "GdipDeleteStringFormat")]
    public static partial GdipStatus DeleteStringFormat(GdipHStringFormat format);

    [LibraryImport(DLL, EntryPoint = "GdipDisposeImage")]
    public static partial GdipStatus DisposeImage(GdipHImage image);

    [LibraryImport(DLL, EntryPoint = "GdipGetImageWidth")]
    public static partial GdipStatus GetImageWidth(GdipHImage image, out uint width);

    [LibraryImport(DLL, EntryPoint = "GdipGetImageHeight")]
    public static partial GdipStatus GetImageHeight(GdipHImage image, out uint height);

    [LibraryImport(DLL, EntryPoint = "GdipSetStringFormatAlign")]
    public static partial GdipStatus SetStringFormatAlign(GdipHStringFormat format, GdipStringAlignment align);

    [LibraryImport(DLL, EntryPoint = "GdipSetStringFormatLineAlign")]
    public static partial GdipStatus SetStringFormatLineAlign(GdipHStringFormat format, GdipStringAlignment align);

    [LibraryImport(DLL, EntryPoint = "GdipAddPathRectangle")]
    public static partial GdipStatus AddPathRectangle(
        GdipHPath path,
        float x, float y, float width, float height);

    [LibraryImport(DLL, EntryPoint = "GdipFillEllipse")]
    public static partial GdipStatus FillEllipse(
        GdipHGraphics graphics, GdipHBrush brush,
        float x, float y, float width, float height);
    [LibraryImport(DLL, EntryPoint = "GdipDrawEllipse")]
    public static partial GdipStatus DrawEllipse(
        GdipHGraphics graphics, GdipHPen pen,
        float x, float y, float width, float height);

    [LibraryImport(DLL, EntryPoint = "GdipSetClipRectI")]
    public static partial int SetClipRect(GdipHGraphics graphics,
        int x, int y, int w, int h, GdipCombineMode combineMode);
    [LibraryImport(DLL, EntryPoint = "GdipSetClipRect")]
    public static partial int SetClipRect(GdipHGraphics graphics,
        float x, float y, float w, float h, GdipCombineMode combineMode);
    [LibraryImport(DLL, EntryPoint = "GdipResetClip")]
    public static partial int ResetClip(GdipHGraphics graphics);

    [LibraryImport(DLL, EntryPoint = "GdipLoadImageFromFile")]
    public static partial GdipStatus LoadImageFromFile(char* filename, out GdipHImage image);
    [LibraryImport(DLL, EntryPoint = "GdipLoadImageFromFile", StringMarshalling = StringMarshalling.Utf16)]
    public static partial GdipStatus LoadImageFromFile(string filename, out GdipHImage image);

    [LibraryImport(DLL, EntryPoint = "GdipDrawImage")]
    public static partial GdipStatus DrawImage(GdipHGraphics graphics, GdipHImage image, float x, float y);

    [LibraryImport(DLL, EntryPoint = "GdipCreateBitmapFromScan0")]
    public static partial GdipStatus CreateBitmapFromScan0(
        int width, int height,
        int stride, GdipPixelFormat format,
        byte* scan0, out GdipHBitmap bitmap);

    [LibraryImport(DLL, EntryPoint = "GdipCreateLineBrushI")]
    public static partial GdipStatus CreateLineBrush(
        in POINT pt1, in POINT pt2,
        GdipColor color1, GdipColor color2,
        GdipWrapMode wrapMode, out GdipHBrush brush);

    [LibraryImport(DLL, EntryPoint = "GdipBeginContainer")]
    public static partial GdipStatus BeginContainer(
        GdipHGraphics graphics,
        in GdipRectF dstRect, in GdipRectF srcRect,
        GdipUnit unit, out uint state);

    [LibraryImport(DLL, EntryPoint = "GdipEndContainer")]
    public static partial GdipStatus EndContainer(GdipHGraphics graphics, uint state);

    [LibraryImport(DLL, EntryPoint = "GdipCreateMatrix")]
    public static partial GdipStatus CreateMatrix(out GdipHMatrix matrix);

    [LibraryImport(DLL, EntryPoint = "GdipSetWorldTransform")]
    public static partial GdipStatus SetWorldTransform(GdipHGraphics graphics, GdipHMatrix matrix);

    [LibraryImport(DLL, EntryPoint = "GdipDeleteMatrix")]
    public static partial GdipStatus DeleteMatrix(GdipHMatrix matrix);
}