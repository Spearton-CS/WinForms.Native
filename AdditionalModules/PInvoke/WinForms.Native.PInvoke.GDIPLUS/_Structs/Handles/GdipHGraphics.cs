using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public readonly record struct GdipHGraphics(Handle Handle)
    : IEqualityOperators<GdipHGraphics, GdipHGraphics, bool>, IEquatable<GdipHGraphics>,
    IEqualityOperators<GdipHGraphics, Handle, bool>, IEquatable<Handle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Handle other) => Handle == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdipHGraphics left, Handle right) => left.Handle == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdipHGraphics left, Handle right) => left.Handle != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(GdipHGraphics hg) => hg.Handle;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdipHGraphics(Handle h) => new(h);
}