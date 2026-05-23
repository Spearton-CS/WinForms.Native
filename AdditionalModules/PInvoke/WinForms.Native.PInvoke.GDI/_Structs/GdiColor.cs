using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Explicit, Size = 4)]
public readonly record struct GdiColor(
    [field: FieldOffset(0)] uint Value)
    : IEqualityOperators<GdiColor, GdiColor, bool>, IEquatable<GdiColor>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public GdiColor(byte r, byte g, byte b) : this(
        r
        | ((uint)g << 8)
        | ((uint)b << 16)) { }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public GdiColor(byte r, byte g, byte b, byte a) : this(
        r
        | ((uint)g << 8)
        | ((uint)b << 16)
        | ((uint)a << 24)) { }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GdiColor FromBgr(uint value) => new(value);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GdiColor FromRgb(uint value)
        => new(
            ((value >> 16) & 0xFF)
            | (value & 0x00FF00)
            | ((value & 0xFF) << 16)
            | 0xFF000000);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GdiColor FromRgba(uint value)
        => new(
            (value >> 24)
            | ((value >> 8) & 0xFF00)
            | ((value << 8) & 0xFF0000)
            | (value << 24));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GdiColor FromArgb(uint value) => new(
            ((value >> 16) & 0xFF)
            | (value & 0xFF00)
            | ((value & 0xFF) << 16)
            | (value & 0xFF000000)
        );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly uint ToBgr() => Value;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly uint ToRgb()
        => (uint)R << 24 | (uint)G << 16 | (uint)B << 8;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly uint ToRgba()
        => (uint)R << 24 | (uint)G << 16 | (uint)B << 8 | A;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly uint ToArgb()
        => (uint)A << 24 | (uint)R << 16 | (uint)G << 8 | B;

    [FieldOffset(0)] public readonly byte R;
    [FieldOffset(1)] public readonly byte G;
    [FieldOffset(2)] public readonly byte B;
    [FieldOffset(3)] public readonly byte A;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator uint(GdiColor gdic) => gdic.Value;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdiColor(uint raw) => new(raw);
}