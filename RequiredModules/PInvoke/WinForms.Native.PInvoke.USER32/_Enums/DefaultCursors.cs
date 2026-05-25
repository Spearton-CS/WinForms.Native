namespace WinForms.Native.PInvoke;

/// <summary>
/// Standard system cursor identifiers. 
/// To use, cast the integer value to (char*) and pass to <see cref="User32.LoadCursorW(HInstance, char*)"/>.
/// </summary>
public enum DefaultCursors : int
{
    /// <summary> Standard arrow cursor. </summary>
    Arrow = 32512,
    /// <summary> I-beam cursor (text selection). </summary>
    IBeam = 32513,
    /// <summary> Wait cursor (hourglass). </summary>
    Wait = 32514,
    /// <summary> Crosshair cursor. </summary>
    Cross = 32515,
    /// <summary> Vertical arrow cursor. </summary>
    UpArrow = 32516,
    /// <summary> Double-pointed arrow pointing northwest and southeast (Obsolete). </summary>
    Size = 32640,
    /// <summary> Empty icon (Obsolete). </summary>
    Icon = 32641,
    /// <summary> Double-pointed arrow pointing northwest and southeast. </summary>
    SizeNWSE = 32642,
    /// <summary> Double-pointed arrow pointing northeast and southwest. </summary>
    SizeNESW = 32643,
    /// <summary> Double-pointed arrow pointing left and right. </summary>
    SizeWE = 32644,
    /// <summary> Double-pointed arrow pointing up and down. </summary>
    SizeNS = 32645,
    /// <summary> Four-pointed arrow pointing north, south, east, and west. </summary>
    SizeAll = 32646,
    /// <summary> Slashed circle cursor. </summary>
    No = 32648,
    /// <summary> Hand cursor. </summary>
    Hand = 32649,
    /// <summary> Standard arrow and small hourglass cursor. </summary>
    AppStarting = 32650,
    /// <summary> Arrow and question mark cursor. </summary>
    Help = 32651
}