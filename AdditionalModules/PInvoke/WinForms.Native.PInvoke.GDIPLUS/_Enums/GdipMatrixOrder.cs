namespace WinForms.Native.PInvoke;

public enum GdipMatrixOrder : int
{
    /// <summary> The new operation is applied before the old operation. </summary>
    Prepend = 0,
    /// <summary> The new operation is applied after the old operation. </summary>
    Append = 1
}