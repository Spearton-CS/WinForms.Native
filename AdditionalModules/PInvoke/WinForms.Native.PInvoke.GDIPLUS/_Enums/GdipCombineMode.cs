namespace WinForms.Native.PInvoke;

public enum GdipCombineMode : int
{
    Replace = 0, // default, overwrite clip
    Intersect = 1,
    Union = 2,
    Xor = 3,
    Exclude = 4,
    Complement = 5
}