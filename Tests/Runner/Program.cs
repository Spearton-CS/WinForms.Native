using WinForms.Native;
using WinForms.Native.PInvoke;

namespace Runner;

internal unsafe static class Program
{
    [STAThread]
    private static void Main()
    {
        if (WinFormsApp.Initialize() == default)
            throw new SystemException();
        GdipStatus status = GDIP.Startup(out nint gdipToken, in GdipStartupInput.Default, nint.Zero);
        if (status != GdipStatus.Ok)
            throw new Exception($"GDI+ Failed to start: {status}");
        _ = SHCORE.SetProcessDpiAwareness(PROCESS_DPI_AWARENESS.PER_MONITOR_DPI_AWARE);

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
            //OnPaint = (delegate* managed<ref WinForm, Handle, RECT, void>)(delegate* managed<ref WinForm, GdiHDC, RECT, void>)&OnFormPaintGDI32
            OnPaint = (delegate* managed<ref WinForm, Handle, RECT, void>)(delegate* managed<ref WinForm, GdiHDC, RECT, void>)&OnFormPaintGDIP
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

    //private static void OnFormPaintGDI32(ref WinForm form, GdiHDC hdc, RECT paintRect)
    //{
    //    int width = paintRect.Width;
    //    int height = paintRect.Height;

    //    GdiHDC memHdc = GDI32.CreateCompatibleDC(hdc);
    //    GdiHBitmap hBitmap = GDI32.CreateCompatibleBitmap(hdc, width, height);
    //    GdiHObj oldBitmap = GDI32.SelectObject(memHdc, hBitmap);

    //    GdiColor backgroundColor = new(32, 32, 32);
    //    GdiHBrush bgBrush = GDI32.CreateSolidBrush(backgroundColor);
    //    User32.FillRect(memHdc, in paintRect, bgBrush);
    //    GDI32.DeleteObject(bgBrush);

    //    RECT cardRect = new() { Left = 50, Top = 50, Right = width - 50, Bottom = 150 };

    //    GdiColor accentColor = new(0, 120, 215); // Windows Blue
    //    GdiHObj cardBrush = GDI32.CreateSolidBrush(new(45, 45, 45));
    //    GdiHPen cardPen = GDI32.CreatePen(0, 2, accentColor);

    //    GdiHObj oldPen = GDI32.SelectObject(memHdc, cardPen);
    //    GdiHObj oldBrush = GDI32.SelectObject(memHdc, cardBrush);

    //    GDI32.Rectangle(memHdc, cardRect.Left, cardRect.Top, cardRect.Right, cardRect.Bottom);

    //    GdiHFont hFont = GDI32.CreateFontW(
    //        -18, 0,
    //        0, 0,
    //        GdiFontWeight.Bold,
    //        0, 0, 0,
    //        GdiFontCharSet.Default,
    //        0, 0,
    //        GdiFontQuality.ClearTypeNatural, 0, "Segoe UI");
    //    GdiHObj oldFont = GDI32.SelectObject(memHdc, hFont);

    //    string title = "Native .NET 10 Dashboard";
    //    string subTitle = $"Resolution: {width}x{height}";

    //    GDI32.SetBkMode(memHdc, GdiBackgroundMode.Transparent);

    //    GDI32.SetTextColor(memHdc, new(255, 255, 255));
    //    GDI32.TextOutW(memHdc, cardRect.X + 20, cardRect.Y + 15, title, title.Length);

    //    GDI32.SetTextColor(memHdc, new(180, 180, 180));
    //    GDI32.TextOutW(memHdc, cardRect.X + 20, cardRect.Y + 45, subTitle, subTitle.Length);

    //    GDI32.SelectObject(memHdc, oldFont);
    //    GDI32.DeleteObject(hFont);
    //    GDI32.SelectObject(memHdc, oldPen);
    //    GDI32.DeleteObject(cardPen);
    //    GDI32.SelectObject(memHdc, oldBrush);
    //    GDI32.DeleteObject(cardBrush);

    //    GDI32.BitBlt(hdc, paintRect.X, paintRect.Y, width, height, memHdc, 0, 0, GdiTernaryRasterOperations.SrcCopy);

    //    GDI32.SelectObject(memHdc, oldBitmap);
    //    GDI32.DeleteObject(hBitmap);
    //    GDI32.DeleteDC(memHdc);
    //}

    private static void OnFormPaintGDIP(ref WinForm form, GdiHDC hdc, RECT paintRect)
    {
        const bool BEAUTIFUL = true;
        int width = paintRect.Width;
        int height = paintRect.Height;

        // --- 1. DOUBLE BUFFERING SETUP (Fixes Ghosting/Flash) ---
        GdiHDC memHdc = GDI32.CreateCompatibleDC(hdc);
        GdiHBitmap memBitmap = GDI32.CreateCompatibleBitmap(hdc, width, height);
        GdiHObj oldBmp = GDI32.SelectObject(memHdc, memBitmap);

        // Create Graphics on the memory buffer, NOT the screen HDC
        GDIP.CreateFromHDC(memHdc, out GdipHGraphics graphics);
        GDIP.SetSmoothingMode(graphics, GdipSmoothingMode.AntiAlias);
        GDIP.SetTextRenderingHint(graphics, TextRenderingHint.ClearTypeGridFit);

        if (BEAUTIFUL)
        {
            int sidebarW = 220;
            int headerH = 48;

            int contentX = sidebarW + 1;
            int contentY = headerH;

            // ===== COLORS (R, G, B, A) =====
            // Windows Explorer Dark Mode Palette
            var bgColor = new GdipColor(32, 32, 32, 255);        // Main Background (#202020)
            var sidebarColor = new GdipColor(28, 28, 28, 255);   // Sidebar (#1C1C1C)
            var headerColor = new GdipColor(32, 32, 32, 255);    // Header (#202020)

            var cardColor = new GdipColor(43, 43, 43, 255);      // Drive Cards (#2B2B2B)
            var borderColor = new GdipColor(60, 60, 60, 255);    // Border/Separator

            var textPrimary = new GdipColor(255, 255, 255, 255); // White Text
            var textSecondary = new GdipColor(160, 160, 160, 255);// Grey Text

            var accentColor = new GdipColor(0, 120, 212, 255);   // Windows Blue (#0078D4)
            var selectedBgColor = new GdipColor(62, 62, 66, 255);// Selection Highlight

            // ===== BRUSHES =====
            GDIP.CreateSolidBrush(bgColor, out var bgBrush);
            GDIP.CreateSolidBrush(sidebarColor, out var sidebarBrush);
            GDIP.CreateSolidBrush(headerColor, out var headerBrush);

            GDIP.CreateSolidBrush(cardColor, out var cardBrush);
            GDIP.CreateSolidBrush(textPrimary, out var textBrush);
            GDIP.CreateSolidBrush(textSecondary, out var subTextBrush);

            GDIP.CreateSolidBrush(accentColor, out var accentBrush);
            GDIP.CreateSolidBrush(selectedBgColor, out var selectedBrush);

            // ===== PEN =====
            GDIP.CreatePen(borderColor, 1f, GdipUnit.Pixel, out var borderPen);

            // ===== FONT + FORMAT =====
            GDIP.CreateFontFamilyFromName("Segoe UI", default, out var family);
            GDIP.CreateFont(family, 12f, GdipFontStyle.Regular, GdipUnit.Pixel, out var font);
            GDIP.CreateFont(family, 10f, GdipFontStyle.Regular, GdipUnit.Pixel, out var fontSmall);

            GDIP.CreateStringFormat(0, 0, out var format);
            GDIP.SetStringFormatAlign(format, GdipStringAlignment.Near);
            GDIP.SetStringFormatLineAlign(format, GdipStringAlignment.Near);

            try
            {
                // ===== BACKGROUND =====
                GDIP.FillRectangle(graphics, bgBrush, 0, 0, width, height);

                // ===== SIDEBAR =====
                GDIP.FillRectangle(graphics, sidebarBrush, 0, 0, sidebarW, height);

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
                        GDIP.FillRectangle(graphics, selectedBrush, 8, navY - 2, sidebarW - 16, itemH);
                        GDIP.FillRectangle(graphics, accentBrush, 8, navY - 2, 3, itemH);
                    }

                    var rect = new GdipRectF(20, navY, sidebarW - 24, itemH);
                    GDIP.DrawString(graphics, navItems[i], navItems[i].Length, font, rect, format, textBrush);

                    navY += itemH;
                }

                // ===== HEADER =====
                GDIP.FillRectangle(graphics, headerBrush, sidebarW, 0, width - sidebarW, headerH);

                {
                    string txt = "This PC";
                    var rect = new GdipRectF(sidebarW + 16, 12, 400, 24);
                    GDIP.DrawString(graphics, txt, txt.Length, font, rect, format, textBrush);
                }

                // ===== CLIP =====
                GDIP.SetClipRect(graphics,
                    contentX,
                    contentY,
                    width - contentX,
                    height - contentY,
                    GdipCombineMode.Replace);

                float startY = contentY + 20;

                {
                    string txt = "Devices and drives";
                    var rect = new GdipRectF(contentX + 20, startY, 400, 30);
                    GDIP.DrawString(graphics, txt, txt.Length, font, rect, format, textBrush);
                }

                // ===== CARDS =====
                float cardW = 240;
                float cardH = 90;
                float gap = 16;

                float x = contentX + 20;
                float y = startY + 40;

                for (int i = 0; i < 3; i++)
                {
                    GDIP.FillRectangle(graphics, cardBrush, x, y, cardW, cardH);
                    GDIP.DrawRectangle(graphics, borderPen, x, y, cardW, cardH);

                    float titleY = y + 18;
                    float subY = titleY + 20;

                    var titleRect = new GdipRectF(x + 16, titleY, cardW - 32, 20);
                    var subRect = new GdipRectF(x + 16, subY, cardW - 32, 20);

                    string t = $"Drive {i + 1}";
                    string s = "100 GB free of 200 GB";

                    GDIP.DrawString(graphics, t, t.Length, font, titleRect, format, textBrush);
                    GDIP.DrawString(graphics, s, s.Length, fontSmall, subRect, format, subTextBrush);

                    float barY = y + cardH - 20;

                    GDIP.FillRectangle(graphics, selectedBrush, x + 16, barY, cardW - 32, 6);
                    GDIP.FillRectangle(graphics, accentBrush, x + 16, barY, (cardW - 32) * 0.6f, 6);

                    x += cardW + gap;
                }

                GDIP.DeleteGraphics(graphics);

                GDIP.ResetClip(graphics);
            }
            finally
            {
                GDIP.DeleteBrush(bgBrush);
                GDIP.DeleteBrush(sidebarBrush);
                GDIP.DeleteBrush(headerBrush);
                GDIP.DeleteBrush(cardBrush);
                GDIP.DeleteBrush(textBrush);
                GDIP.DeleteBrush(subTextBrush);
                GDIP.DeleteBrush(accentBrush);
                GDIP.DeleteBrush(selectedBrush);

                GDIP.DeletePen(borderPen);

                GDIP.DeleteFont(font);
                GDIP.DeleteFont(fontSmall);
                GDIP.DeleteFontFamily(family);
                GDIP.DeleteStringFormat(format);
            }
        }
        else
        {
            // 2. Clear background with a dark GDI+ color (ARGB: 255, 32, 32, 32)
            GDIP.Clear(graphics, new GdipColor(255, 32, 32, 32));

            // 3. Define Card with Transparency (Alpha = 180 for a slight glass effect)
            GdipRectF cardRect = new(50, 50, width - 100, 100);
            GDIP.CreateSolidBrush(new GdipColor(180, 45, 45, 45), out GdipHBrush cardBrush);

            // GDI+ Accent: Semi-transparent Blue Pen with thickness 1.5 for a "retina" look
            GDIP.CreatePen(new GdipColor(255, 0, 120, 215), 1.5f, GdipUnit.Pixel, out GdipHPen cardPen);

            // 4. Draw Card
            GDIP.FillRectangle(graphics, cardBrush, cardRect.X, cardRect.Y, cardRect.Width, cardRect.Height);
            GDIP.DrawRectangle(graphics, cardPen, cardRect.X, cardRect.Y, cardRect.Width, cardRect.Height);

            // 5. Text Logic
            GDIP.CreateFontFamilyFromName("Segoe UI", default, out GdipHFontFamily family);
            GDIP.CreateFont(family, 14, GdipFontStyle.Bold, GdipUnit.Pixel, out GdipHFont titleFont);
            GDIP.CreateFont(family, 11, GdipFontStyle.Regular, GdipUnit.Pixel, out GdipHFont subFont);

            GDIP.CreateSolidBrush(new GdipColor(255, 255, 255, 255), out GdipHBrush whiteBrush);
            GDIP.CreateSolidBrush(new GdipColor(150, 180, 180, 180), out GdipHBrush grayBrush);

            string title = "GDI+ Accelerated Dashboard";
            string subTitle = $"Hardware: GDI+ Flat API | Mode: {GdipSmoothingMode.AntiAlias}";

            // Draw strings directly using Rects (No need to capture old state)
            GdipRectF titlePos = new(cardRect.X + 20, cardRect.Y + 20, cardRect.Width, 30);
            GdipRectF subPos = new(cardRect.X + 20, cardRect.Y + 55, cardRect.Width, 30);

            GDIP.DrawString(graphics, title, title.Length, titleFont, in titlePos, default, whiteBrush);
            GDIP.DrawString(graphics, subTitle, subTitle.Length, subFont, in subPos, default, grayBrush);

            // 6. Modern Feature: A Gradient-like Path (Simulated Glow)
            GDIP.CreatePath(GdipFillMode.Alternate, out GdipHPath path);
            GDIP.AddPathLine(path, 50, 160, width - 50, 160);
            GDIP.DrawPath(graphics, cardPen, path);

            // 7. Cleanup (Explicit GDI+ Disposal)
            GDIP.DeletePath(path);
            GDIP.DeleteBrush(whiteBrush);
            GDIP.DeleteBrush(grayBrush);
            GDIP.DeleteFont(titleFont);
            GDIP.DeleteFont(subFont);
            GDIP.DeleteFontFamily(family);
            GDIP.DeletePen(cardPen);
            GDIP.DeleteBrush(cardBrush);
            GDIP.DeleteGraphics(graphics);
        }
        // --- 3. FINALIZING (BitBlt to screen) ---
        // Graphics is now deleted, so the memory buffer (memHdc) is fully updated.
        GDI32.BitBlt(hdc, 0, 0, width, height, memHdc, 0, 0, GdiTernaryRasterOperations.SrcCopy);

        // Cleanup Memory DC
        GDI32.SelectObject(memHdc, oldBmp);
        GDI32.DeleteObject(memBitmap);
        GDI32.DeleteDC(memHdc);
    }
}