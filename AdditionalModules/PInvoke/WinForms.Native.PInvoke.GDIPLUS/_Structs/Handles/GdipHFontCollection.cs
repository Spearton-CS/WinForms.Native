using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public readonly record struct GdipHFontCollection(Handle Handle)
    : IEqualityOperators<GdipHFontCollection, GdipHFontCollection, bool>, IEquatable<GdipHFontCollection>,
    IEqualityOperators<GdipHFontCollection, Handle, bool>, IEquatable<Handle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Handle other) => Handle == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdipHFontCollection left, Handle right) => left.Handle == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdipHFontCollection left, Handle right) => left.Handle != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(GdipHFontCollection hfontcol) => hfontcol.Handle;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdipHFontCollection(Handle h) => new(h);
}