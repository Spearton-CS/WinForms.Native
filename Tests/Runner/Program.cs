using TypedWinAPI.User32;
using TypedWinAPI.GDIPlus;

using WinForms.Native;
using TypedWinAPI.SHCore;
using TypedWinAPI;
using TypedWinAPI.GDI32;

namespace Runner;

internal unsafe static class Program
{
    [STAThread]
    private static void Main()
    {
        if (WinFormsApp.Initialize() == (ATOM)0u)
            throw new SystemException();
        Status status = GDIPlus.GdiplusStartup(out GpSessionToken gdipToken, new GdiplusStartupInput(), null);
        if (status != Status.Ok)
            throw new Exception($"GDI+ Failed to start: {status}");
        SHCore.SetProcessDpiAwareness(PROCESS_DPI_AWARENESS.PerMonitorAware);

        if (File.Exists(".log"))
            File.Delete(".log");

        //Thread brother = new(static () =>
        //{
        //    WinForm.VTABLE vtable = new()
        //    {
        //        OnLoad = &OnFormLoad,
        //        Shown = &OnFormShown,
        //        OnClosed = &OnFormClosed
        //    };
        //    WinForm test = new()
        //    {
        //        INSTANCE_VTABLE = &vtable
        //    };

        //    fixed (char* title = Environment.CurrentManagedThreadId.ToString())
        //        WinFormsApp.Run(ref test, title);
        //});
        //brother.Start();
        WinForm.VTABLE vtable = new()
        {
            OnLoad = &OnFormLoad,
            Shown = &OnFormShown,
            OnClosed = &OnFormClosed,
            //OnPaint = (delegate* managed<ref WinForm, HANDLE, RECT, void>)(delegate* managed<ref WinForm, HDC, RECT, void>)&OnFormPaintGDI32
            OnPaint = (delegate* managed<ref WinForm, HANDLE, RECT, void>)(delegate* managed<ref WinForm, HDC, RECT, void>)&OnFormPaintGDIP
        };
        WinForm test = new()
        {
            INSTANCE_VTABLE = &vtable
        };

        WinFormsApp.Run(ref test, Environment.CurrentManagedThreadId.ToString());
    }

    private static void OnFormLoad(ref WinForm form)
    {
        form.Size = new(600, 400);
        form.Style &= ~WindowStyles.MinimizeBox;
    }

    private static void OnFormShown(ref WinForm form)
    {
        //Thread.Sleep(100);
        form.Visible = true;
    }

    private static void OnFormClosed(ref WinForm form)
    {
        File.AppendAllLines(".log", [form.HWND.ToString()]);
    }

    //private static void OnFormPaintGDI32(ref WinForm form, HDC hdc, RECT paintRECT)
    //{
    //    int width = paintRECT.Width;
    //    int height = paintRECT.Height;

    //    HDC memHdc = GDI32.CreateCompatibleDC(hdc);
    //    HBITMAP hBitmap = GDI32.CreateCompatibleBitmap(hdc, width, height);
    //    HGDIOBJ oldBitmap = GDI32.SelectObject(memHdc, hBitmap);

    //    GdiColor backgroundColor = new(32, 32, 32);
    //    GdiHBrush bgBrush = GDI32.CreateSolidBrush(backgroundColor);
    //    User32.FillRECT(memHdc, in paintRECT, bgBrush);
    //    GDI32.DeleteObject(bgBrush);

    //    RECT cardRECT = new() { Left = 50, Top = 50, Right = width - 50, Bottom = 150 };

    //    GdiColor accentColor = new(0, 120, 215); // Windows Blue
    //    HGDIOBJ cardBrush = GDI32.CreateSolidBrush(new(45, 45, 45));
    //    GdiHPen cardPen = GDI32.CreatePen(0, 2, accentColor);

    //    HGDIOBJ oldPen = GDI32.SelectObject(memHdc, cardPen);
    //    HGDIOBJ oldBrush = GDI32.SelectObject(memHdc, cardBrush);

    //    GDI32.RECTangle(memHdc, cardRECT.Left, cardRECT.Top, cardRECT.Right, cardRECT.Bottom);

    //    GdiHFont hFont = GDI32.CreateFontW(
    //        -18, 0,
    //        0, 0,
    //        GdiFontWeight.Bold,
    //        0, 0, 0,
    //        GdiFontCharSet.Default,
    //        0, 0,
    //        GdiFontQuality.ClearTypeNatural, 0, "Segoe UI");
    //    HGDIOBJ oldFont = GDI32.SelectObject(memHdc, hFont);

    //    string title = "Native .NET 10 Dashboard";
    //    string subTitle = $"Resolution: {width}x{height}";

    //    GDI32.SetBkMode(memHdc, GdiBackgroundMode.Transparent);

    //    GDI32.SetTextColor(memHdc, new(255, 255, 255));
    //    GDI32.TextOutW(memHdc, cardRECT.X + 20, cardRECT.Y + 15, title, title.Length);

    //    GDI32.SetTextColor(memHdc, new(180, 180, 180));
    //    GDI32.TextOutW(memHdc, cardRECT.X + 20, cardRECT.Y + 45, subTitle, subTitle.Length);

    //    GDI32.SelectObject(memHdc, oldFont);
    //    GDI32.DeleteObject(hFont);
    //    GDI32.SelectObject(memHdc, oldPen);
    //    GDI32.DeleteObject(cardPen);
    //    GDI32.SelectObject(memHdc, oldBrush);
    //    GDI32.DeleteObject(cardBrush);

    //    GDI32.BitBlt(hdc, paintRECT.X, paintRECT.Y, width, height, memHdc, 0, 0, GdiTernaryRasterOperations.SrcCopy);

    //    GDI32.SelectObject(memHdc, oldBitmap);
    //    GDI32.DeleteObject(hBitmap);
    //    GDI32.DeleteDC(memHdc);
    //}

    private static void OnFormPaintGDIP(ref WinForm form, HDC hdc, RECT paintRECT)
    {
        const bool BEAUTIFUL = true;
        int width = paintRECT.Width;
        int height = paintRECT.Height;

        // --- 1. DOUBLE BUFFERING SETUP (Fixes Ghosting/Flash) ---
        HDC memHdc = GDI32.CreateCompatibleDC(hdc);
        HBITMAP memBitmap = GDI32.CreateCompatibleBitmap(hdc, width, height);
        HGDIOBJ oldBmp = GDI32.SelectObject(memHdc, memBitmap);

        // Create Graphics on the memory buffer, NOT the screen HDC
        GDIPlus.GdipCreateFromHDC(memHdc, out GpGraphics graphics);
        GDIPlus.GdipSetSmoothingMode(graphics, SmoothingMode.AntiAlias);
        GDIPlus.GdipSetTextRenderingHint(graphics, TextRenderingHint.ClearTypeGridFit);

        if (BEAUTIFUL)
        {
            int sidebarW = 220;
            int headerH = 48;

            int contentX = sidebarW + 1;
            int contentY = headerH;

            // ===== COLORS (R, G, B, A) =====
            // Windows Explorer Dark Mode Palette
            var bgColor = new ARGB(32, 32, 32, 255);        // Main Background (#202020)
            var sidebarColor = new ARGB(28, 28, 28, 255);   // Sidebar (#1C1C1C)
            var headerColor = new ARGB(32, 32, 32, 255);    // Header (#202020)

            var cardColor = new ARGB(43, 43, 43, 255);      // Drive Cards (#2B2B2B)
            var borderColor = new ARGB(60, 60, 60, 255);    // Border/Separator

            var textPrimary = new ARGB(255, 255, 255, 255); // White Text
            var textSecondary = new ARGB(160, 160, 160, 255);// Grey Text

            var accentColor = new ARGB(0, 120, 212, 255);   // Windows Blue (#0078D4)
            var selectedBgColor = new ARGB(62, 62, 66, 255);// Selection Highlight

            // ===== BRUSHES =====
            GDIPlus.GdipCreateSolidBrushFill(bgColor, out var bgBrush);
            GDIPlus.GdipCreateSolidBrushFill(sidebarColor, out var sidebarBrush);
            GDIPlus.GdipCreateSolidBrushFill(headerColor, out var headerBrush);

            GDIPlus.GdipCreateSolidBrushFill(cardColor, out var cardBrush);
            GDIPlus.GdipCreateSolidBrushFill(textPrimary, out var textBrush);
            GDIPlus.GdipCreateSolidBrushFill(textSecondary, out var subTextBrush);

            GDIPlus.GdipCreateSolidBrushFill(accentColor, out var accentBrush);
            GDIPlus.GdipCreateSolidBrushFill(selectedBgColor, out var selectedBrush);

            // ===== PEN =====
            GDIPlus.GdipCreatePen1(borderColor, 1f, Unit.Pixel, out var borderPen);

            // ===== FONT + FORMAT =====
            GDIPlus.GdipCreateFontFamilyFromName("Segoe UI", default, out var family);
            GDIPlus.GdipCreateFont(family, 12f, FontStyle.Regular, Unit.Pixel, out var font);
            GDIPlus.GdipCreateFont(family, 10f, FontStyle.Regular, Unit.Pixel, out var fontSmall);

            GDIPlus.GdipCreateStringFormat(0, 0, out var format);
            GDIPlus.GdipSetStringFormatAlign(format, StringAlignment.Near);
            GDIPlus.GdipSetStringFormatLineAlign(format, StringAlignment.Near);

            try
            {
                // ===== BACKGROUND =====
                GDIPlus.GdipFillRectangle(graphics, bgBrush, 0, 0, width, height);

                // ===== SIDEBAR =====
                GDIPlus.GdipFillRectangle(graphics, sidebarBrush, 0, 0, sidebarW, height);

                int navY = 60;
                int itemH = 26;

                string[] navItems =
                {
            "Quick access","Desktop","Downloads","Documents",
            "Pictures","Music","Videos","This PC"
        };

                for (int i = 0; i < navItems.Length; i++)
                {
                    bool selected = navItems[i] == "This PC";

                    if (selected)
                    {
                        GDIPlus.GdipFillRectangle(graphics, selectedBrush, 8, navY - 2, sidebarW - 16, itemH);
                        GDIPlus.GdipFillRectangle(graphics, accentBrush, 8, navY - 2, 3, itemH);
                    }

                    var rect = new RectF(20, navY, sidebarW - 24, itemH);
                    GDIPlus.GdipDrawString(graphics, navItems[i], navItems[i].Length, font, rect, format, textBrush);

                    navY += itemH;
                }

                // ===== HEADER =====
                GDIPlus.GdipFillRectangle(graphics, headerBrush, sidebarW, 0, width - sidebarW, headerH);

                {
                    string txt = "This PC";
                    var rect = new RectF(sidebarW + 16, 12, 400, 24);
                    GDIPlus.GdipDrawString(graphics, txt, txt.Length, font, rect, format, textBrush);
                }

                // ===== CLIP =====
                GDIPlus.GdipSetClipRect(graphics,
                    contentX,
                    contentY,
                    width - contentX,
                    height - contentY,
                    CombineMode.Replace);

                float startY = contentY + 20;

                {
                    string txt = "Devices and drives";
                    var rect = new RectF(contentX + 20, startY, 400, 30);
                    GDIPlus.GdipDrawString(graphics, txt, txt.Length, font, rect, format, textBrush);
                }

                // ===== CARDS =====
                float cardW = 240;
                float cardH = 90;
                float gap = 16;

                float x = contentX + 20;
                float y = startY + 40;

                for (int i = 0; i < 3; i++)
                {
                    GDIPlus.GdipFillRectangle(graphics, cardBrush, x, y, cardW, cardH);
                    GDIPlus.GdipDrawRectangle(graphics, borderPen, x, y, cardW, cardH);

                    float titleY = y + 18;
                    float subY = titleY + 20;

                    var titleRECT = new RectF(x + 16, titleY, cardW - 32, 20);
                    var subRECT = new RectF(x + 16, subY, cardW - 32, 20);

                    string t = $"Drive {i + 1}";
                    string s = "100 GB free of 200 GB";

                    GDIPlus.GdipDrawString(graphics, t, t.Length, font, titleRECT, format, textBrush);
                    GDIPlus.GdipDrawString(graphics, s, s.Length, fontSmall, subRECT, format, subTextBrush);

                    float barY = y + cardH - 20;

                    GDIPlus.GdipFillRectangle(graphics, selectedBrush, x + 16, barY, cardW - 32, 6);
                    GDIPlus.GdipFillRectangle(graphics, accentBrush, x + 16, barY, (cardW - 32) * 0.6f, 6);

                    x += cardW + gap;
                }

                GDIPlus.GdipDeleteGraphics(graphics);

                GDIPlus.GdipResetClip(graphics);
            }
            finally
            {
                GDIPlus.GdipDeleteBrush(bgBrush);
                GDIPlus.GdipDeleteBrush(sidebarBrush);
                GDIPlus.GdipDeleteBrush(headerBrush);
                GDIPlus.GdipDeleteBrush(cardBrush);
                GDIPlus.GdipDeleteBrush(textBrush);
                GDIPlus.GdipDeleteBrush(subTextBrush);
                GDIPlus.GdipDeleteBrush(accentBrush);
                GDIPlus.GdipDeleteBrush(selectedBrush);

                GDIPlus.GdipDeletePen(borderPen);

                GDIPlus.GdipDeleteFont(font);
                GDIPlus.GdipDeleteFont(fontSmall);
                GDIPlus.GdipDeleteFontFamily(family);
                GDIPlus.GdipDeleteStringFormat(format);
            }
        }
        else
        {
            // 2. Clear background with a dark GDI+ color (ARGB: 255, 32, 32, 32)
            GDIPlus.GdipGraphicsClear(graphics, new ARGB(255, 32, 32, 32));

            // 3. Define Card with Transparency (Alpha = 180 for a slight glass effect)
            RectF cardRECT = new(50, 50, width - 100, 100);
            GDIPlus.GdipCreateSolidBrushFill(new ARGB(180, 45, 45, 45), out var cardBrush);

            // GDI+ Accent: Semi-transparent Blue Pen with thickness 1.5 for a "retina" look
            GDIPlus.GdipCreatePen1(new ARGB(255, 0, 120, 215), 1.5f, Unit.Pixel, out var cardPen);

            // 4. Draw Card
            GDIPlus.GdipFillRectangle(graphics, cardBrush, cardRECT.X, cardRECT.Y, cardRECT.Width, cardRECT.Height);
            GDIPlus.GdipDrawRectangle(graphics, cardPen, cardRECT.X, cardRECT.Y, cardRECT.Width, cardRECT.Height);

            // 5. Text Logic
            GDIPlus.GdipCreateFontFamilyFromName("Segoe UI", default, out var family);
            GDIPlus.GdipCreateFont(family, 14, FontStyle.Bold, Unit.Pixel, out var titleFont);
            GDIPlus.GdipCreateFont(family, 11, FontStyle.Regular, Unit.Pixel, out var subFont);

            GDIPlus.GdipCreateSolidBrushFill(new ARGB(255, 255, 255, 255), out var whiteBrush);
            GDIPlus.GdipCreateSolidBrushFill(new ARGB(150, 180, 180, 180), out var grayBrush);

            string title = "GDI+ Accelerated Dashboard";
            string subTitle = $"Hardware: GDI+ Flat API | Mode: {SmoothingMode.AntiAlias}";

            // Draw strings directly using RECTs (No need to capture old state)
            RectF titlePos = new(cardRECT.X + 20, cardRECT.Y + 20, cardRECT.Width, 30);
            RectF subPos = new(cardRECT.X + 20, cardRECT.Y + 55, cardRECT.Width, 30);

            GDIPlus.GdipDrawString(graphics, title, title.Length, titleFont, in titlePos, default, whiteBrush);
            GDIPlus.GdipDrawString(graphics, subTitle, subTitle.Length, subFont, in subPos, default, grayBrush);

            // 6. Modern Feature: A Gradient-like Path (Simulated Glow)
            GDIPlus.GdipCreatePath(FillMode.Alternate, out var path);
            GDIPlus.GdipAddPathLine(path, 50, 160, width - 50, 160);
            GDIPlus.GdipDrawPath(graphics, cardPen, path);

            // 7. Cleanup (Explicit GDI+ Disposal)
            GDIPlus.GdipDeletePath(path);
            GDIPlus.GdipDeleteBrush(whiteBrush);
            GDIPlus.GdipDeleteBrush(grayBrush);
            GDIPlus.GdipDeleteFont(titleFont);
            GDIPlus.GdipDeleteFont(subFont);
            GDIPlus.GdipDeleteFontFamily(family);
            GDIPlus.GdipDeletePen(cardPen);
            GDIPlus.GdipDeleteBrush(cardBrush);
            GDIPlus.GdipDeleteGraphics(graphics);
        }
        // --- 3. FINALIZING (BitBlt to screen) ---
        // Graphics is now deleted, so the memory buffer (memHdc) is fully updated.
        GDI32.BitBlt(hdc, 0, 0, width, height, memHdc, 0, 0, TernaryRasterOperations.SrcCopy);

        // Cleanup Memory DC
        GDI32.SelectObject(memHdc, oldBmp);
        GDI32.DeleteObject(memBitmap);
        GDI32.DeleteDC(memHdc);
    }
}