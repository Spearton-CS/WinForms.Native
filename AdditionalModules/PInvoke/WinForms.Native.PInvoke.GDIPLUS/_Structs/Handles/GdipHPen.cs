using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public readonly record struct GdipHPen(Handle Handle)
    : IEqualityOperators<GdipHPen, GdipHPen, bool>, IEquatable<GdipHPen>,
    IEqualityOperators<GdipHPen, Handle, bool>, IEquatable<Handle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Handle other) => Handle == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdipHPen left, Handle right) => left.Handle == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdipHPen left, Handle right) => left.Handle != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(GdipHPen hpen) => hpen.Handle;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdipHPen(Handle h) => new(h);
}