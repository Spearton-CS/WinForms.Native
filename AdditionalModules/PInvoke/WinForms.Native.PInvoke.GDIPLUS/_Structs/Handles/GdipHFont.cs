using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public readonly record struct GdipHFont(Handle Handle)
    : IEqualityOperators<GdipHFont, GdipHFont, bool>, IEquatable<GdipHFont>,
    IEqualityOperators<GdipHFont, Handle, bool>, IEquatable<Handle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Handle other) => Handle == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdipHFont left, Handle right) => left.Handle == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdipHFont left, Handle right) => left.Handle != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(GdipHFont hfont) => hfont.Handle;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdipHFont(Handle h) => new(h);
}