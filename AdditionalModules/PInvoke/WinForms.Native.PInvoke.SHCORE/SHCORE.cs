using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

/// <summary>
/// Provides P/Invoke signatures for shcore.dll functions to manage process DPI awareness and to retrieve monitor DPI.
/// </summary>
/// <remarks>Contains native imports for Windows 8.1 and later. Call SetProcessDpiAwareness before creating any UI
/// or windows and do not mix with SetProcessDPIAware; changing awareness after initialization may fail. Callers must
/// handle HRESULTs returned by the native functions.</remarks>
public static unsafe partial class SHCORE
{
    public const string DLL = "shcore.dll";

    #region DPI

    /// <summary>
    /// Sets the DPI awareness for the current process.
    /// </summary>
    /// <remarks>Call before creating any UI or windows. Available on Windows 8.1 and later. Do not mix with
    /// SetProcessDPIAware; attempting to change awareness after initialization may fail.</remarks>
    /// <param name="value">One of the PROCESS_DPI_AWARENESS values that specifies the desired DPI awareness level for the process.</param>
    /// <returns>HRESULT indicating success or failure. S_OK if the awareness was set; otherwise an error code such as
    /// E_INVALIDARG or E_ACCESSDENIED.</returns>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial int SetProcessDpiAwareness(PROCESS_DPI_AWARENESS value);
    /// <summary>
    /// Retrieves the dots-per-inch (DPI) for the specified monitor.
    /// </summary>
    /// <remarks>Supported on Windows 8.1 and later. The dpiType parameter selects between effective, angular,
    /// or raw DPI; results depend on the process's DPI awareness. Callers must supply a valid monitor handle and handle
    /// failed HRESULTs.</remarks>
    /// <param name="hmonitor">Handle to the monitor.</param>
    /// <param name="dpiType">Type of DPI to retrieve, specified as a MONITOR_DPI_TYPE value.</param>
    /// <param name="dpiX">Receives the horizontal DPI value.</param>
    /// <param name="dpiY">Receives the vertical DPI value.</param>
    /// <returns>An HRESULT value: S_OK on success; otherwise an error code.</returns>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial int GetDpiForMonitor(nint hmonitor, MONITOR_DPI_TYPE dpiType, out uint dpiX, out uint dpiY);

    #endregion
}