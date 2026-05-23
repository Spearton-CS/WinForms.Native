using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

/// <summary>
/// Represents a color in ARGB format (0xAARRGGBB), as required by GDI+.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 4)]
public readonly record struct GdipColor(
    [field: FieldOffset(0)] uint Argb)
    : IEqualityOperators<GdipColor, GdipColor, bool>, IEquatable<GdipColor>
{
    [FieldOffset(0)] public readonly byte B;
    [FieldOffset(1)] public readonly byte G;
    [FieldOffset(2)] public readonly byte R;
    [FieldOffset(3)] public readonly byte A;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public GdipColor(byte r, byte g, byte b, byte a = 255) : this(
        b | ((uint)g << 8) | ((uint)r << 16) | ((uint)a << 24))
    { }

    /// <summary> Creates a GdipColor from an ARGB integer (0xAARRGGBB). </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GdipColor FromArgb(uint argb) => new(argb);

    /// <summary> Creates a GdipColor from an RGB integer (0xRRGGBB). Alpha is set to 255. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GdipColor FromRgb(uint rgb) => new(0xFF000000 | rgb);

    /// <summary> Returns the color as a standard ARGB integer. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly uint ToArgb() => Argb;

    /// <summary> Implicit conversion for easier interoperability. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator uint(GdipColor color) => color.Argb;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator GdipColor(uint argb) => new(argb);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdiColor(GdipColor c) => new(c.R, c.G, c.B, c.A);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdipColor(GdiColor c) => new(c.R, c.G, c.B, c.A);
}