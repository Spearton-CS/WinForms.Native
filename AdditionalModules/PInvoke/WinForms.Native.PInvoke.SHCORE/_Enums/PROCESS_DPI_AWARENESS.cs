namespace WinForms.Native.PInvoke;

/// <summary>
/// Defines DPI-awareness levels for a process that control how Windows scales the process on displays with different
/// DPI settings.
/// </summary>
/// <remarks>Used with Windows DPI APIs to control scaling behavior</remarks>
public enum PROCESS_DPI_AWARENESS
{
    /// <summary>
    /// Old behavior, Windows does stretching of window... Worst one
    /// </summary>
    DPI_UNAWARE = 0,

    /// <summary>
    /// Indicates the application is DPI-aware for the primary monitor only.
    /// </summary>
    /// <remarks>Does not support per-monitor DPI. When moved to a monitor with a different DPI, the system
    /// may scale the window bitmap and cause blurring.</remarks>
    SYSTEM_DPI_AWARE = 1,

    /// <summary>
    /// Application is per-monitor DPI aware and re-renders when the DPI changes or when moved between monitors so
    /// rendering remains pixel-perfect.
    /// </summary>
    /// <remarks>Supported on Windows 8.1 and later. The application must handle DPI-change notifications (for
    /// example, WM_DPICHANGED) and scale or redraw UI and resources when the DPI changes. Opt in using a per-monitor
    /// DPI-aware manifest or the appropriate DPI-awareness APIs.</remarks>
    PER_MONITOR_DPI_AWARE = 2
}