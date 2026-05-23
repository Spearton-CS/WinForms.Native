using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public readonly record struct GdiHPalette(GdiHObj HObj)
    : IEqualityOperators<GdiHPalette, GdiHPalette, bool>, IEquatable<GdiHPalette>,
    IEqualityOperators<GdiHPalette, GdiHObj, bool>, IEquatable<GdiHObj>,
    IEqualityOperators<GdiHPalette, Handle, bool>, IEquatable<Handle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(GdiHObj other) => HObj == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Handle other) => HObj == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdiHPalette left, GdiHObj right) => left.HObj == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdiHPalette left, GdiHObj right) => left.HObj != right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdiHPalette left, Handle right) => left.HObj == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdiHPalette left, Handle right) => left.HObj != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator GdiHObj(GdiHPalette hpal) => hpal.HObj;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(GdiHPalette hpal) => hpal.HObj;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdiHPalette(GdiHObj hobj) => new(hobj);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdiHPalette(Handle h) => new((GdiHObj)h);
}