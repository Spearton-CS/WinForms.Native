using System.Numerics;
using System.Runtime.InteropServices;

namespace WinForms.Native;

/// <summary>
/// Specifies the width and height of a rectangle.
/// </summary>
/// <remarks>
/// Directly compatible with the native Win32 <c>SIZE</c> structure.
/// </remarks>
[StructLayout(LayoutKind.Explicit, Size = 8)]
public readonly record struct SIZE(
    [field: FieldOffset(0)] int Width,
    [field: FieldOffset(4)] int Height)
    : IEqualityOperators<SIZE, SIZE, bool>, IEquatable<SIZE>;