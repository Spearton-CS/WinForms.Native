using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Explicit, Size = 32)]
public unsafe struct GdiBitmap
    : IEqualityOperators<GdiBitmap, GdiBitmap, bool>, IEquatable<GdiBitmap>
{
    [FieldOffset(0)] public int bmType;
    [FieldOffset(4)] public int bmWidth;
    [FieldOffset(8)] public int bmHeight;
    [FieldOffset(12)] public int bmWidthBytes;
    [FieldOffset(16)] public ushort bmPlanes;
    [FieldOffset(18)] public ushort bmBitsPixel;
    [FieldOffset(24)] public void* bmBits;

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly Span<byte> AsSpan()
        => MemoryMarshal.CreateSpan(ref Unsafe
                        .As<int, byte>(ref Unsafe
                        .AsRef(in bmType)), sizeof(GdiBitmap));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly bool Equals([NotNullWhen(true)] object? obj)
        => obj is GdiBitmap bmp && this == bmp;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(GdiBitmap other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(GdiBitmap left, GdiBitmap right) => left.AsSpan().SequenceEqual(right.AsSpan());
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(GdiBitmap left, GdiBitmap right) => !(left == right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly int GetHashCode() => -1;
}