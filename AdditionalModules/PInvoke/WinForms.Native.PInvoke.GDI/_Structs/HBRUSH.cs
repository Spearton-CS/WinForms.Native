using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public readonly record struct HBRUSH(Handle Handle)
    : IEqualityOperators<HBRUSH, HBRUSH, bool>, IEquatable<HBRUSH>,
    IEqualityOperators<HBRUSH, Handle, bool>, IEquatable<Handle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Handle other) => this.Handle == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HBRUSH left, Handle right) => left.Handle == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HBRUSH left, Handle right) => left.Handle != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HBRUSH HBRUSH) => HBRUSH.Handle;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBRUSH(Handle handle) => new(handle);
}