using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public readonly record struct HGDIOBJ(Handle Handle)
    : IEqualityOperators<HGDIOBJ, HGDIOBJ, bool>, IEquatable<HGDIOBJ>,
    IEqualityOperators<HGDIOBJ, Handle, bool>, IEquatable<Handle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Handle other) => this.Handle == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HGDIOBJ left, Handle right) => left.Handle == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HGDIOBJ left, Handle right) => left.Handle != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HGDIOBJ HGDIOBJ) => HGDIOBJ.Handle;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HGDIOBJ(Handle handle) => new(handle);
}