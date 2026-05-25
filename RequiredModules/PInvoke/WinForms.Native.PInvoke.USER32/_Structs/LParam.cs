using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe readonly struct LParam :
    IEqualityOperators<LParam, LParam, bool>, IEquatable<LParam>,
    IEqualityOperators<LParam, nint, bool>, IEquatable<nint>,
    IEqualityOperators<LParam, nuint, bool>, IEquatable<nuint>
{
    public static LParam Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => default;
    }

    public LParam(void* ptr) => PointerValue = ptr;
    public LParam(nint signed) => SignedValue = signed;
    public LParam(nuint unsigned) => UnsignedValue = unsigned;

    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nint SignedValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;

    #region Decomposition

    /// <summary>
    /// Extracts the horizontal (X) coordinate from a window message's LPARAM.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly short GetX() => (short)(SignedValue & 0xFFFF);
    /// <summary>
    /// Extracts the vertical (Y) coordinate from a window message's LPARAM.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly short GetY() => (short)((SignedValue >> 16) & 0xFFFF);
    /// <summary>
    /// Combines two 16-bit values into a single 32/64-bit LPARAM, typically for coordinates.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static LParam MakeLParam(short x, short y) => new((ushort)y << 16 | (ushort)x);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly HitTestValues GetHitTestValues() => (HitTestValues)(SignedValue & 0xFFFF);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly WndProcMsgType GetWndProcMsgType() => (WndProcMsgType)((SignedValue >> 16) & 0xFFFF);

    #endregion

    #region Equality

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => (obj is LParam other && this == other)
        || (obj is nint signed && this == signed)
        || (obj is nuint unsigned && this == unsigned);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(LParam other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(LParam left, LParam right) => left.SignedValue == right.SignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(LParam left, LParam right) => left.SignedValue != right.SignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(LParam left, void* right) => left.PointerValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(LParam left, void* right) => left.PointerValue != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(LParam left, nint right) => left.SignedValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(LParam left, nint right) => left.SignedValue != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nuint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(LParam left, nuint right) => left.UnsignedValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(LParam left, nuint right) => left.UnsignedValue != right;

    #endregion

    #region ValueType override

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => SignedValue.GetHashCode();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => SignedValue.ToString("X16");

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(LParam lParam) => lParam.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LParam(void* ptr) => new(ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(LParam lParam) => lParam.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LParam(nuint unsigned) => new(unsigned);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(LParam lParam) => lParam.SignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LParam(nint signed) => new(signed);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator uint(LParam lParam) => (uint)lParam.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LParam(uint unsigned) => new(unsigned);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int(LParam lParam) => (int)lParam.SignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LParam(int signed) => new(signed);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle(LParam lParam) => (Handle)(void*)lParam;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LParam(Handle h) => (LParam)(void*)h;

    #endregion
}