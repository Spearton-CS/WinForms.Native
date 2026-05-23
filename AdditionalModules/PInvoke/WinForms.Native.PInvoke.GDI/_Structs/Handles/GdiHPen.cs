using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public readonly record struct GdiHPen(GdiHObj HObj)
    : IEqualityOperators<GdiHPen, GdiHPen, bool>, IEquatable<GdiHPen>,
    IEqualityOperators<GdiHPen, GdiHObj, bool>, IEquatable<GdiHObj>,
    IEqualityOperators<GdiHPen, Handle, bool>, IEquatable<Handle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(GdiHObj other) => HObj == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdiHPen left, GdiHObj right) => left.HObj == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdiHPen left, GdiHObj right) => left.HObj != right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Handle other) => HObj == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdiHPen left, Handle right) => left.HObj == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdiHPen left, Handle right) => left.HObj != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator GdiHObj(GdiHPen hpen) => hpen.HObj;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdiHPen(GdiHObj hobj) => new(hobj);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(GdiHPen hpen) => hpen.HObj;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdiHPen(Handle h) => (GdiHPen)(GdiHObj)h;
}