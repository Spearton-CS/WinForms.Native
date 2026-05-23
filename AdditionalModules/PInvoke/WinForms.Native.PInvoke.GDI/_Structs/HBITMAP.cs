using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public readonly record struct HBITMAP(HGDIOBJ Handle)
    : IEqualityOperators<HBITMAP, HBITMAP, bool>, IEquatable<HBITMAP>,
    IEqualityOperators<HBITMAP, HGDIOBJ, bool>, IEquatable<HGDIOBJ>,
    IEqualityOperators<HBITMAP, Handle, bool>, IEquatable<Handle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(HGDIOBJ other) => Handle == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Handle other) => Handle == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HBITMAP left, HGDIOBJ right) => left.Handle == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HBITMAP left, HGDIOBJ right) => left.Handle != right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HBITMAP left, Handle right) => left.Handle == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HBITMAP left, Handle right) => left.Handle != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator HGDIOBJ(HBITMAP HBITMAP) => HBITMAP.Handle;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HBITMAP HBITMAP) => HBITMAP.Handle;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBITMAP(HGDIOBJ hGdiObj) => new(hGdiObj);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HBITMAP(Handle handle) => new((HGDIOBJ)handle);
}