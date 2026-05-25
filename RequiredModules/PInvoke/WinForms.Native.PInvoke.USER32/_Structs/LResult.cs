using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe readonly struct LResult :
    IEqualityOperators<LResult, LResult, bool>, IEquatable<LResult>,
    IEqualityOperators<LResult, nint, bool>, IEquatable<nint>,
    IEqualityOperators<LResult, nuint, bool>, IEquatable<nuint>
{
    public static LResult Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => default;
    }

    public LResult(void* ptr) => PointerValue = ptr;
    public LResult(nint signed) => SignedValue = signed;
    public LResult(nuint unsigned) => UnsignedValue = unsigned;

    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nint SignedValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;

    #region Decomposition



    #endregion

    #region Equality

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => (obj is LResult other && this == other)
        || (obj is nint signed && this == signed)
        || (obj is nuint unsigned && this == unsigned);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(LResult other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(LResult left, LResult right) => left.SignedValue == right.SignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(LResult left, LResult right) => left.SignedValue != right.SignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(LResult left, void* right) => left.PointerValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(LResult left, void* right) => left.PointerValue != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(LResult left, nint right) => left.SignedValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(LResult left, nint right) => left.SignedValue != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nuint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(LResult left, nuint right) => left.UnsignedValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(LResult left, nuint right) => left.UnsignedValue != right;

    #endregion

    #region ValueType override

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => SignedValue.GetHashCode();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => SignedValue.ToString("X16");

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(LResult LResult) => LResult.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LResult(void* ptr) => new(ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(LResult LResult) => LResult.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LResult(nuint unsigned) => new(unsigned);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator nint(LResult LResult) => LResult.SignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator LResult(nint signed) => new(signed);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator uint(LResult LResult) => (uint)LResult.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LResult(uint unsigned) => new(unsigned);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int(LResult LResult) => (int)LResult.SignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator LResult(int signed) => new(signed);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle(LResult lResult) => (Handle)(void*)lResult;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LResult(Handle h) => (LResult)(void*)h;

    #endregion
}