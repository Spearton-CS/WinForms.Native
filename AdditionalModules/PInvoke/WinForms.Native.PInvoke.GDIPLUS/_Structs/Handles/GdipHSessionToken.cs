using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public readonly record struct GdipHSessionToken(Handle Handle)
    : IEqualityOperators<GdipHSessionToken, GdipHSessionToken, bool>, IEquatable<GdipHSessionToken>,
    IEqualityOperators<GdipHSessionToken, Handle, bool>, IEquatable<Handle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Handle other) => Handle == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdipHSessionToken left, Handle right) => left.Handle == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdipHSessionToken left, Handle right) => left.Handle != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(GdipHSessionToken htoken) => htoken.Handle;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdipHSessionToken(Handle h) => new(h);
}