using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

/// <summary>
/// Represents a Win32 4-byte boolean value.
/// </summary>
/// <remarks>
/// In native Windows API, <c>BOOL</c> is a 32-bit integer where 0 is <c>FALSE</c> 
/// and any non-zero value is <c>TRUE</c>. This structure ensures correct marshaling 
/// and provides seamless integration with .NET <see cref="bool"/>.
/// </remarks>
[StructLayout(LayoutKind.Explicit)]
public readonly struct BOOL
    : IEqualityOperators<BOOL, BOOL, bool>, IEquatable<BOOL>,
    IEqualityOperators<BOOL, bool, bool>, IEquatable<bool>
{
    /// <summary> Initializes a new instance with a raw unsigned integer value. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public BOOL(uint raw) => RawUnsigned = raw;

    /// <summary> The raw unsigned 32-bit representation of the boolean value. </summary>
    [FieldOffset(0)] public readonly uint RawUnsigned;

    /// <summary> Initializes a new instance with a raw signed integer value. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public BOOL(int raw) => RawSigned = raw;

    /// <summary> The raw signed 32-bit representation of the boolean value. </summary>
    [FieldOffset(0)] public readonly int RawSigned;

    /// <summary> Returns true if the <see cref="BOOL"/> represents a non-zero value. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator true(BOOL win32) => (bool)win32;

    /// <summary> Returns true if the <see cref="BOOL"/> represents a zero value. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator false(BOOL win32) => !(bool)win32;

    /// <summary> Compares this instance to a specified object. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly bool Equals([NotNullWhen(true)] object? obj)
        => (obj is BOOL win32 && this == win32) || (obj is bool dotnet && this == dotnet);

    /// <summary> Compares this instance to another <see cref="BOOL"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(BOOL other) => this == other;

    /// <summary> Compares two <see cref="BOOL"/> values for equality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(BOOL a, BOOL b) => (bool)a == (bool)b;

    /// <summary> Compares two <see cref="BOOL"/> values for inequality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(BOOL a, BOOL b) => (bool)a != (bool)b;

    /// <summary> Compares this instance to a standard .NET <see cref="bool"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(bool other) => this == other;

    /// <summary> Compares a <see cref="BOOL"/> with a <see cref="bool"/> for equality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(BOOL a, bool b) => (bool)a == b;

    /// <summary> Compares a <see cref="BOOL"/> with a <see cref="bool"/> for inequality. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(BOOL a, bool b) => (bool)a != b;

    /// <summary> Implicitly converts a <see cref="BOOL"/> to a .NET <see cref="bool"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator bool(BOOL win32) => win32.RawUnsigned != 0;

    /// <summary> Implicitly converts a .NET <see cref="bool"/> to a <see cref="BOOL"/>. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator BOOL(bool dotnet) => new(dotnet ? 1u : 0u);

    /// <summary> Returns the string representation of the boolean value. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly string ToString() => ((bool)this).ToString();

    /// <summary> Returns the hash code for this instance. </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly int GetHashCode() => ((bool)this).GetHashCode();
}