using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public readonly record struct HIcon(Handle Handle)
    : IEqualityOperators<HIcon, HIcon, bool>, IEquatable<HIcon>,
    IEqualityOperators<HIcon, Handle, bool>, IEquatable<Handle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Handle other) => Handle == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HIcon left, Handle right) => left.Handle == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HIcon left, Handle right) => left.Handle != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HIcon hicon) => hicon.Handle;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HIcon(Handle h) => new(h);
}