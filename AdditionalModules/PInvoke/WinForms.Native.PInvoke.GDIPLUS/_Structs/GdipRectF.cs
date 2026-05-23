using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Explicit, Size = 32)]
public readonly record struct GdipRectF(
    [field: FieldOffset(0)] float X,
    [field: FieldOffset(4)] float Y,
    [field: FieldOffset(8)] float Width,
    [field: FieldOffset(12)] float Height
    )
    : IEqualityOperators<GdipRectF, GdipRectF, bool>, IEquatable<GdipRectF>,
    IEqualityOperators<GdipRectF, RECT, bool>, IEquatable<RECT>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(RECT other)
        => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdipRectF left, RECT right)
        => left.X == right.X && left.Y == right.Y
            && left.Width == right.Width && left.Height == right.Height;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdipRectF left, RECT right)
        => left.X != right.X || left.Y != right.Y
            || left.Width != right.Width || left.Height != right.Height;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void ToLTBR(out float left, out float top, out float bottom, out float right)
    {
        left = X; top = Y;
        bottom = Y + Height; right = X + Width;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GdipRectF FromLTBR(float left, float top, float bottom, float right)
        => new(left, top, bottom - top, right - left);
}