using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 2)]
public readonly record struct ATOM(Handle16 Handle)
    : IEqualityOperators<ATOM, ATOM, bool>, IEquatable<ATOM>,
    IEqualityOperators<ATOM, Handle16, bool>, IEquatable<Handle16>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Handle16 other) => Handle == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(ATOM left, Handle16 right) => left.Handle == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(ATOM left, Handle16 right) => left.Handle != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle16(ATOM atom) => atom.Handle;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ATOM(Handle16 h) => new(h);
}