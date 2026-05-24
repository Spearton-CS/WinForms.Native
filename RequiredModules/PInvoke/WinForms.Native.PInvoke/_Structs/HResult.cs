using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Explicit, Size = 4)]
public readonly record struct HResult([field: FieldOffset(0)] int Raw) :
    IEqualityOperators<HResult, HResult, bool>, IEquatable<HResult>,
    IEqualityOperators<HResult, int, bool>, IEquatable<int>
{
    #region Consts

    public static HResult S_OK
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => default;
    }
    public static HResult E_InvalidArg
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(unchecked((int)0x80070057));
    }
    public static HResult E_AccessDenied
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(unchecked((int)0x80070005));
    }

    #endregion

    #region Bits

    public bool IsSuccess
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Raw >= 0;
    }
    public bool IsError
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Raw < 0;
    }

    public bool IsCustomerFacility
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (Raw & 0x20000000) != 0;
    }
    public bool IsReservedSet
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (Raw & 0x10000000) != 0;
    }

    public ushort Facility
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (ushort)((Raw >> 16) & 0x1FFF);
    }
    public ushort Code
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (ushort)(Raw & 0xFFFF);
    }

    #endregion

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(int raw) => this == raw;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HResult left, int right) => left.Raw == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HResult left, int right) => left.Raw != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int(HResult hresult) => hresult.Raw;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HResult(int raw) => new(raw);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => IsSuccess ? $"Success (0x{Raw:X8})" : $"Error (0x{Raw:X8})";
    public override int GetHashCode() => Raw;
}