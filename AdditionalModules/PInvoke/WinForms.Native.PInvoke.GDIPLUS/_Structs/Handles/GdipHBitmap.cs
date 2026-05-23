using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public readonly record struct GdipHBitmap(GdipHImage HImage)
    : IEqualityOperators<GdipHBitmap, GdipHBitmap, bool>, IEquatable<GdipHBitmap>,
    IEqualityOperators<GdipHBitmap, GdipHImage, bool>, IEquatable<GdipHImage>,
    IEqualityOperators<GdipHBitmap, Handle, bool>, IEquatable<Handle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(GdipHImage other) => HImage == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdipHBitmap left, GdipHImage right) => left.HImage == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdipHBitmap left, GdipHImage right) => left.HImage != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Handle other) => HImage == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdipHBitmap left, Handle right) => left.HImage == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdipHBitmap left, Handle right) => left.HImage != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator GdipHImage(GdipHBitmap hbmp) => hbmp.HImage;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdipHBitmap(GdipHImage himg) => new(himg);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(GdipHBitmap hbmp) => hbmp.HImage;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GdipHBitmap(Handle h) => (GdipHBitmap)(GdipHImage)h;
}