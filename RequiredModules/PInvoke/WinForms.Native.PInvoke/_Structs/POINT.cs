using System.Numerics;
using System.Runtime.InteropServices;

namespace WinForms.Native;

/// <summary>
/// Defines the x- and y-coordinates of a point.
/// </summary>
/// <remarks>
/// Directly compatible with the native Win32 <c>POINT</c> structure.
/// </remarks>
[StructLayout(LayoutKind.Explicit, Size = 8)]
public readonly record struct Point(
    [field: FieldOffset(0)] int X,
    [field: FieldOffset(4)] int Y)
    : IEqualityOperators<Point, Point, bool>, IEquatable<Point>;