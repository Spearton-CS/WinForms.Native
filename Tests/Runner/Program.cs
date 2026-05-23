using WinForms.Native;
using WinForms.Native.PInvoke;

namespace Runner;

internal unsafe static class Program
{
    [STAThread]
    private static void Main()
    {
        if (WinFormsApp.Initialize() == 0)
            throw new SystemException();
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
            OnPaint = (delegate* managed<ref WinForm, Handle, RECT, void>)(delegate* managed<ref WinForm, HDC, RECT, void>)&OnFormPaintGDI32
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

    private static void OnFormPaintGDI32(ref WinForm form, HDC hdc, RECT paintRect)
    {
        int width = paintRect.Width;
        int height = paintRect.Height;

        HDC memHdc = GDI32.CreateCompatibleDC(hdc);
        HBITMAP hBitmap = GDI32.CreateCompatibleBitmap(hdc, width, height);
        HGDIOBJ oldBitmap = GDI32.SelectObject(memHdc, hBitmap);

        GdiColor backgroundColor = new(32, 32, 32);
        HGDIOBJ bgBrush = GDI32.CreateSolidBrush(backgroundColor);
        User32.FillRect(memHdc, in paintRect, (Handle)bgBrush);
        GDI32.DeleteObject(bgBrush);

        RECT cardRect = new() { Left = 50, Top = 50, Right = width - 50, Bottom = 150 };

        GdiColor accentColor = new(0, 120, 215); // Windows Blue
        HGDIOBJ cardBrush = GDI32.CreateSolidBrush(new(45, 45, 45));
        HGDIOBJ cardPen = GDI32.CreatePen(0, 2, accentColor);

        HGDIOBJ oldPen = GDI32.SelectObject(memHdc, cardPen);
        HGDIOBJ oldBrush = GDI32.SelectObject(memHdc, cardBrush);

        GDI32.Rectangle(memHdc, cardRect.Left, cardRect.Top, cardRect.Right, cardRect.Bottom);

        HGDIOBJ hFont = GDI32.CreateFontW(
            -18, 0, 0, 0, 700, 0, 0, 0, 1, 0, 0, 6, 0, "Segoe UI");
        HGDIOBJ oldFont = GDI32.SelectObject(memHdc, hFont);

        string title = "Native .NET 10 Dashboard";
        string subTitle = $"Resolution: {width}x{height}";

        GDI32.SetBkMode(memHdc, 1); // TRANSPARENT

        GDI32.SetTextColor(memHdc, new(255, 255, 255));
        GDI32.TextOutW(memHdc, cardRect.X + 20, cardRect.Y + 15, title, title.Length);

        GDI32.SetTextColor(memHdc, new(180, 180, 180));
        GDI32.TextOutW(memHdc, cardRect.X + 20, cardRect.Y + 45, subTitle, subTitle.Length);

        GDI32.SelectObject(memHdc, oldFont);
        GDI32.DeleteObject(hFont);
        GDI32.SelectObject(memHdc, oldPen);
        GDI32.DeleteObject(cardPen);
        GDI32.SelectObject(memHdc, oldBrush);
        GDI32.DeleteObject(cardBrush);

        GDI32.BitBlt(hdc, paintRect.X, paintRect.Y, width, height, memHdc, 0, 0, TernaryRasterOperations.SrcCopy);

        GDI32.SelectObject(memHdc, oldBitmap);
        GDI32.DeleteObject(hBitmap);
        GDI32.DeleteDC(memHdc);
    }
}