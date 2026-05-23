using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public readonly record struct GdiHRegion(GdiHObj HObj)
    : IEqualityOperators<GdiHRegion, GdiHRegion, bool>, IEquatable<GdiHRegion>,
    IEqualityOperators<GdiHRegion, GdiHObj, bool>, IEquatable<GdiHObj>,
    IEqualityOperators<GdiHRegion, Handle, bool>, IEquatable<Handle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(GdiHObj other) => HObj == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdiHRegion left, GdiHObj right) => left.HObj == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdiHRegion left, GdiHObj right) => left.HObj != right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Handle other) => HObj == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdiHRegion left, Handle right) => left.HObj == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdiHRegion left, Handle right) => left.HObj != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator GdiHObj(GdiHRegion hbrush) => hbrush.HObj;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdiHRegion(GdiHObj hobj) => new(hobj);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(GdiHRegion hbrush) => hbrush.HObj;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdiHRegion(Handle h) => (GdiHRegion)(GdiHObj)h;
}