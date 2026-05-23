using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

/// <summary>
/// Contains information for an application that can be used to paint the client area of a window owned by that application.
/// </summary>
/// <remarks>
/// Directly compatible with the native Win32 <c>PAINTSTRUCT</c> structure.
/// Size is explicitly set to 72 bytes to match the x64 alignment requirements.
/// </remarks>
[StructLayout(LayoutKind.Explicit, Size = 72)]
public unsafe struct PAINTSTRUCT
    : IEqualityOperators<PAINTSTRUCT, PAINTSTRUCT, bool>, IEquatable<PAINTSTRUCT>
{
    /// <summary> A handle to the display DC to be used for painting. </summary>
    [FieldOffset(0)] public Handle hdc;

    /// <summary> Indicates whether the background must be erased. </summary>
    [FieldOffset(8)] public BOOL fErase;

    /// <summary> A <see cref="RECT"/> structure that specifies the upper left and lower right corners of the rectangle in which the painting is requested. </summary>
    [FieldOffset(12)] public RECT rcPaint;

    /// <summary> Reserved; used internally by the system. </summary>
    [FieldOffset(28)] public BOOL fRestore;

    /// <summary> Reserved; used internally by the system. </summary>
    [FieldOffset(32)] public BOOL fIncUpdate;

    /// <summary> Reserved; used internally by the system. </summary>
    [FieldOffset(40)] internal fixed byte rgbReserved[32];

    /// <summary>
    /// Provides a view of the structure as a span of bytes for efficient memory operations.
    /// </summary>
    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly Span<byte> AsSpan()
        => MemoryMarshal.CreateSpan(ref Unsafe
                        .As<Handle, byte>(ref Unsafe
                        .AsRef(in hdc)), sizeof(PAINTSTRUCT));

    /// <summary> Determines whether the specified object is equal to the current structure. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly bool Equals([NotNullWhen(true)] object? obj)
        => obj is PAINTSTRUCT other && this == other;

    /// <summary> Compares this instance to another <see cref="PAINTSTRUCT"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(PAINTSTRUCT other) => this == other;

    /// <summary> Compares two <see cref="PAINTSTRUCT"/> instances for equality using byte-wise comparison. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PAINTSTRUCT left, PAINTSTRUCT right) => left.AsSpan().SequenceEqual(right.AsSpan());

    /// <summary> Compares two <see cref="PAINTSTRUCT"/> instances for inequality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PAINTSTRUCT left, PAINTSTRUCT right) => !(left == right);

    /// <summary> Returns a hash code for this instance. </summary>
    /// <remarks> Always returns -1 as the structure is mutable and large; avoid using as a key in hash-based collections. </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly int GetHashCode() => -1;
}