using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public readonly record struct GdiHFont(GdiHObj HObj)
    : IEqualityOperators<GdiHFont, GdiHFont, bool>, IEquatable<GdiHFont>,
    IEqualityOperators<GdiHFont, GdiHObj, bool>, IEquatable<GdiHObj>,
    IEqualityOperators<GdiHFont, Handle, bool>, IEquatable<Handle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(GdiHObj other) => HObj == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdiHFont left, GdiHObj right) => left.HObj == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdiHFont left, GdiHObj right) => left.HObj != right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Handle other) => HObj == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdiHFont left, Handle right) => left.HObj == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdiHFont left, Handle right) => left.HObj != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator GdiHObj(GdiHFont hfont) => hfont.HObj;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdiHFont(GdiHObj hobj) => new(hobj);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(GdiHFont hfont) => hfont.HObj;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdiHFont(Handle h) => (GdiHFont)(GdiHObj)h;
}