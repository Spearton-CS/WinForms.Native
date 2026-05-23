namespace WinForms.Native.PInvoke;

/// <summary>
/// Specifies DPI measurement modes for a monitor.
/// </summary>
/// <remarks>Values are expressed in dots per inch (DPI). Use EFFECTIVE_DPI for UI scaling, ANGULAR_DPI for
/// angular/optical rendering, and RAW_DPI for the monitor's EDID-reported native DPI, which may differ from logical or
/// OS-scaled DPI.</remarks>
public enum MONITOR_DPI_TYPE
{
    /// <summary>
    /// The effective DPI used to determine the scale factor for UI elements.
    /// </summary>
    /// <remarks>Expressed in dots per inch (DPI); use when calculating UI scaling across display
    /// densities.</remarks>
    EFFECTIVE_DPI = 0,

    /// <summary>
    /// Angular dots-per-inch (DPI) measurement used for specific optical rendering.
    /// </summary>
    /// <remarks>Represents the angular DPI mode used by optical rendering subsystems to control angular
    /// resolution.</remarks>
    ANGULAR_DPI = 1,

    /// <summary>
    /// Raw DPI value reported by the monitor's EDID.
    /// </summary>
    /// <remarks>EDID (Extended Display Identification Data) reported native dots-per-inch; may differ from OS
    /// scaling or logical DPI.</remarks>
    RAW_DPI = 2
}