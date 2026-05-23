using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public readonly record struct GdiHBitmap(GdiHObj HObj)
    : IEqualityOperators<GdiHBitmap, GdiHBitmap, bool>, IEquatable<GdiHBitmap>,
    IEqualityOperators<GdiHBitmap, GdiHObj, bool>, IEquatable<GdiHObj>,
    IEqualityOperators<GdiHBitmap, Handle, bool>, IEquatable<Handle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(GdiHObj other) => HObj == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Handle other) => HObj == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdiHBitmap left, GdiHObj right) => left.HObj == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdiHBitmap left, GdiHObj right) => left.HObj != right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdiHBitmap left, Handle right) => left.HObj == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdiHBitmap left, Handle right) => left.HObj != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator GdiHObj(GdiHBitmap hbmp) => hbmp.HObj;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(GdiHBitmap hbmp) => hbmp.HObj;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdiHBitmap(GdiHObj hobj) => new(hobj);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdiHBitmap(Handle h) => new((GdiHObj)h);
}