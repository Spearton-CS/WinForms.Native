using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public readonly record struct HMenu(Handle Handle)
    : IEqualityOperators<HMenu, HMenu, bool>, IEquatable<HMenu>,
    IEqualityOperators<HMenu, Handle, bool>, IEquatable<Handle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Handle other) => Handle == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HMenu left, Handle right) => left.Handle == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HMenu left, Handle right) => left.Handle != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HMenu hmenu) => hmenu.Handle;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HMenu(Handle h) => new(h);
}