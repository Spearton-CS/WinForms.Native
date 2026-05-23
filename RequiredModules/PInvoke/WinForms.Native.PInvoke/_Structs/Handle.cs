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
[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe readonly struct Handle
    : IEqualityOperators<Handle, Handle, bool>, IEquatable<Handle>,
    IEqualityOperators<Handle, nint, bool>, IEquatable<nint>,
    IEqualityOperators<Handle, nuint, bool>, IEquatable<nuint>
{
    /// <summary> Initializes a new instance of <see cref="Handle"/> using a raw pointer. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Handle(void* ptr) => Pointer = ptr;

    /// <summary> The handle interpreted as a raw untyped pointer. </summary>
    [FieldOffset(0)] public readonly void* Pointer;

    /// <summary> Initializes a new instance of <see cref="Handle"/> using a signed native integer. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Handle(nint ptr) => SignedValue = ptr;

    /// <summary> The handle interpreted as a signed native integer (<c>long</c> on x64). </summary>
    [FieldOffset(0)] public readonly nint SignedValue;

    /// <summary> Initializes a new instance of <see cref="Handle"/> using an unsigned native integer. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Handle(nuint ptr) => UnsignedValue = ptr;

    /// <summary> The handle interpreted as an unsigned native integer (<c>ulong</c> on x64). </summary>
    [FieldOffset(0)] public readonly nuint UnsignedValue;

    #region Equality

    /// <summary> Determines whether the specified object is equal to the current handle. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly bool Equals([NotNullWhen(true)] object? obj)
        => (obj is Handle h && this == h)
        || (obj is nuint unsigned && this == unsigned)
        || (obj is nint signed && this == signed);

    /// <summary> Compares this handle to another handle for equality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Handle other) => this == other;

    /// <summary> Compares two handles by their underlying pointer addresses. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Handle a, Handle b) => a.Pointer == b.Pointer;

    /// <summary> Compares two handles for inequality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Handle a, Handle b) => a.Pointer != b.Pointer;

    /// <summary> Compares the handle to a signed native integer for equality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nint other) => this == other;

    /// <summary> Compares a handle and a signed native integer for equality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Handle a, nint b) => a.SignedValue == b;

    /// <summary> Compares a handle and a signed native integer for inequality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Handle a, nint b) => a.SignedValue != b;

    /// <summary> Compares the handle to an unsigned native integer for equality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nuint other) => this == other;

    /// <summary> Compares a handle and an unsigned native integer for equality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Handle a, nuint b) => a.UnsignedValue == b;

    /// <summary> Compares a handle and an unsigned native integer for inequality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Handle a, nuint b) => a.UnsignedValue != b;

    #endregion

    #region Cast

    /// <summary> Explicitly converts a <see cref="Handle"/> to a raw pointer. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(Handle handle) => handle.Pointer;

    /// <summary> Explicitly converts a <see cref="Handle"/> to a signed native integer. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(Handle handle) => handle.SignedValue;

    /// <summary> Explicitly converts a <see cref="Handle"/> to an unsigned native integer. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(Handle handle) => handle.UnsignedValue;

    /// <summary> Explicitly converts a raw pointer to a <see cref="Handle"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle(void* ptr) => new(ptr);

    /// <summary> Explicitly converts a signed native integer to a <see cref="Handle"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle(nint ptr) => new(ptr);

    /// <summary> Explicitly converts an unsigned native integer to a <see cref="Handle"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle(nuint ptr) => new(ptr);

    #endregion

    /// <summary> Returns a hexadecimal string representation of the handle. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly string ToString() => UnsignedValue.ToString("X16");

    /// <summary> Returns the hash code for the handle based on its unsigned value. </summary>
    public override readonly int GetHashCode() => UnsignedValue.GetHashCode();
}