using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native;

/// <summary>
/// Defines the coordinates of the upper-left and lower-right corners of a rectangle.
/// </summary>
/// <remarks>
/// This structure uses memory overlapping to provide access via both <c>Left/Top/Right/Bottom</c> 
/// and <c>X/Y/Point</c> fields without extra memory overhead.
/// </remarks>
[StructLayout(LayoutKind.Explicit, Size = 16)]
public readonly record struct RECT(
    /// <summary> The x-coordinate of the upper-left corner. </summary>
    [field: FieldOffset(0)] int Left,
    /// <summary> The y-coordinate of the upper-left corner. </summary>
    [field: FieldOffset(4)] int Top,
    /// <summary> The x-coordinate of the lower-right corner. </summary>
    [field: FieldOffset(8)] int Right,
    /// <summary> The y-coordinate of the lower-right corner. </summary>
    [field: FieldOffset(12)] int Bottom)
    : IEqualityOperators<RECT, RECT, bool>, IEquatable<RECT>
{
    /// <summary> The x-coordinate of the upper-left corner (aliases <see cref="Left"/>). </summary>
    [FieldOffset(0)] public readonly int X;
    /// <summary> The y-coordinate of the upper-left corner (aliases <see cref="Top"/>). </summary>
    [FieldOffset(4)] public readonly int Y;
    /// <summary> The upper-left corner as a <see cref="POINT"/> structure. </summary>
    [FieldOffset(0)] public readonly POINT Point;

    /// <summary> Gets the width of the rectangle (Right - Left). </summary>
    public readonly int Width
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Right - Left;
    }
    /// <summary> Gets the height of the rectangle (Bottom - Top). </summary>
    public readonly int Height
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Bottom - Top;
    }
    /// <summary> Gets the dimensions of the rectangle as a <see cref="SIZE"/>. </summary>
    public readonly SIZE Size
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(Width, Height);
    }

    /// <summary> Creates a new <see cref="RECT"/> from the specified position and dimensions. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RECT FromXYWH(int x, int y, int width, int height) => new(x, y, x + width, y + height);
    /// <summary> Deconstructs the rectangle into its X, Y, Width, and Height components. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void ToXYWH(out int x, out int y, out int width, out int height)
    {
        x = X; y = Y;
        width = Width; height = Height;
    }
}