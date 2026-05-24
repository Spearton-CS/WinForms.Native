namespace WinForms.Native.PInvoke;

/// <summary>
/// Specifies the level of debug events to be reported.
/// </summary>
public enum GdipDebugEventLevel : int
{
    /// <summary> No debug events. </summary>
    None = 0,

    /// <summary> Report only fatal errors. </summary>
    Fatal = 1
}