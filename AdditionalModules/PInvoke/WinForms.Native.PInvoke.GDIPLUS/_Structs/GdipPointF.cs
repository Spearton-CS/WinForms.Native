using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native;

/// <summary>
/// Defines the x- and y-coordinates of a point.
/// </summary>
/// <remarks>
/// Directly compatible with the native Win32 <c>POINT</c> structure.
/// </remarks>
[StructLayout(LayoutKind.Explicit, Size = 8)]
public readonly record struct GdipPointF(
    [field: FieldOffset(0)] float X,
    [field: FieldOffset(4)] float Y) :
    IEqualityOperators<GdipPointF, GdipPointF, bool>, IEquatable<GdipPointF>,
    IEqualityOperators<GdipPointF, POINT, bool>, IEquatable<POINT>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(POINT other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdipPointF left, POINT right)
        => left.X == right.X && left.Y == right.Y;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdipPointF left, POINT right)
        => left.X != right.X || left.Y != right.Y;
}