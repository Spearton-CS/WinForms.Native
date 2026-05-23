namespace WinForms.Native.PInvoke;

[Flags]
public enum GdiFontPitchAndFamily : byte
{
    // Pitch
    DefaultPitch = 0,
    FixedPitch = 1,
    VariablePitch = 2,

    // Families
    DontCare = 0 << 4,
    Roman = 1 << 4,
    Swiss = 2 << 4,
    Modern = 3 << 4,
    Script = 4 << 4,
    Decorative = 5 << 4
}