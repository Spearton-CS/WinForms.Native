namespace WinForms.Native.PInvoke;

[Flags]
public enum TrackMouseEventFlags : uint
{
    Hover = 0x00000001,
    Leave = 0x00000002,
    NonClient = 0x00000010,
    Query = 0x40000000,
    Cancel = 0x80000000,

    HoverDefault = 0xFFFFFFFF
}