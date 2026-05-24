using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

/// <summary>
/// Provides a unified, type-safe wrapper for native handles (HWND, HDC, HINSTANCE, etc.).
/// </summary>
/// <remarks>
/// This structure uses a 64-bit explicit layout to alias pointers, signed integers, and unsigned integers. 
/// It simplifies interop by providing consistent equality operators across different numeric representations 
/// of a memory address.
/// </remarks>
[StructLayout(LayoutKind.Explicit, Size = 2)]
public unsafe readonly struct Handle16 :
    IEqualityOperators<Handle16, Handle16, bool>, IEquatable<Handle16>,
    IEqualityOperators<Handle16, short, bool>, IEquatable<short>,
    IEqualityOperators<Handle16, ushort, bool>, IEquatable<ushort>
{
    public static Handle16 Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => default;
    }

    /// <summary> Initializes a new instance of <see cref="Handle16"/> using a signed native integer. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Handle16(short ptr) => SignedValue = ptr;

    /// <summary> The handle interpreted as a signed native integer (<c>long</c> on x64). </summary>
    [FieldOffset(0)] public readonly short SignedValue;

    /// <summary> Initializes a new instance of <see cref="Handle16"/> using an unsigned native integer. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Handle16(ushort ptr) => UnsignedValue = ptr;

    /// <summary> The handle interpreted as an unsigned native integer (<c>ulong</c> on x64). </summary>
    [FieldOffset(0)] public readonly ushort UnsignedValue;

    #region Equality

    /// <summary> Determines whether the specified object is equal to the current handle. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly bool Equals([NotNullWhen(true)] object? obj)
        => (obj is Handle16 h && this == h)
        || (obj is ushort unsigned && this == unsigned)
        || (obj is short signed && this == signed);

    /// <summary> Compares this handle to another handle for equality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Handle16 other) => this == other;

    /// <summary> Compares two handles by their underlying unsigned values. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Handle16 a, Handle16 b) => a.UnsignedValue == b.UnsignedValue;

    /// <summary> Compares two handles for inequality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Handle16 a, Handle16 b) => a.UnsignedValue != b.UnsignedValue;

    /// <summary> Compares the handle to a signed native integer for equality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(short other) => this == other;

    /// <summary> Compares a handle and a signed native integer for equality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Handle16 a, short b) => a.SignedValue == b;

    /// <summary> Compares a handle and a signed native integer for inequality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Handle16 a, short b) => a.SignedValue != b;

    /// <summary> Compares the handle to an unsigned native integer for equality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(ushort other) => this == other;

    /// <summary> Compares a handle and an unsigned native integer for equality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Handle16 a, ushort b) => a.UnsignedValue == b;

    /// <summary> Compares a handle and an unsigned native integer for inequality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Handle16 a, ushort b) => a.UnsignedValue != b;

    #endregion

    #region Cast

    /// <summary> Explicitly converts a <see cref="Handle16"/> to a signed native integer. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator short(Handle16 handle) => handle.SignedValue;

    /// <summary> Explicitly converts a <see cref="Handle16"/> to an unsigned native integer. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ushort(Handle16 handle) => handle.UnsignedValue;

    /// <summary> Explicitly converts a signed native integer to a <see cref="Handle16"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle16(short ptr) => new(ptr);

    /// <summary> Explicitly converts an unsigned native integer to a <see cref="Handle16"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle16(ushort ptr) => new(ptr);

    #endregion

    /// <summary> Returns a hexadecimal string representation of the handle. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly string ToString() => UnsignedValue.ToString("X4");

    /// <summary> Returns the hash code for the handle based on its unsigned value. </summary>
    public override readonly int GetHashCode() => UnsignedValue.GetHashCode();
}