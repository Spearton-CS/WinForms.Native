using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe readonly struct WParam :
    IEqualityOperators<WParam, WParam, bool>, IEquatable<WParam>,
    IEqualityOperators<WParam, nint, bool>, IEquatable<nint>,
    IEqualityOperators<WParam, nuint, bool>, IEquatable<nuint>
{
    public static WParam Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => default;
    }

    public WParam(void* ptr) => PointerValue = ptr;
    public WParam(nint signed) => SignedValue = signed;
    public WParam(nuint unsigned) => UnsignedValue = unsigned;

    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nint SignedValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;

    #region Decomposition

    /// <summary>
    /// Extracts the mouse wheel delta or other high-word values from a window message's WPARAM.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly short GetDelta() => (short)((SignedValue >> 16) & 0xFFFF);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly SysCommandType GetSysCommandType() => (SysCommandType)(SignedValue & 0xFFF0);

    #endregion

    #region Equality

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => (obj is WParam other && this == other)
        || (obj is nint signed && this == signed)
        || (obj is nuint unsigned && this == unsigned);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(WParam other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(WParam left, WParam right) => left.SignedValue == right.SignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(WParam left, WParam right) => left.SignedValue != right.SignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(WParam left, void* right) => left.PointerValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(WParam left, void* right) => left.PointerValue != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(WParam left, nint right) => left.SignedValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(WParam left, nint right) => left.SignedValue != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nuint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(WParam left, nuint right) => left.UnsignedValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(WParam left, nuint right) => left.UnsignedValue != right;

    #endregion

    #region ValueType override

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => SignedValue.GetHashCode();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => SignedValue.ToString("X16");

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(WParam WParam) => WParam.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator WParam(void* ptr) => new(ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(WParam WParam) => WParam.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator WParam(nuint unsigned) => new(unsigned);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(WParam WParam) => WParam.SignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator WParam(nint signed) => new(signed);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator uint(WParam WParam) => (uint)WParam.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator WParam(uint unsigned) => new(unsigned);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int(WParam WParam) => (int)WParam.SignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator WParam(int signed) => new(signed);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle(WParam wParam) => (Handle)(void*)wParam;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator WParam(Handle h) => (WParam)(void*)h;

    #endregion
}