using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public readonly record struct HCursor(Handle Handle)
    : IEqualityOperators<HCursor, HCursor, bool>, IEquatable<HCursor>,
    IEqualityOperators<HCursor, Handle, bool>, IEquatable<Handle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Handle other) => Handle == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HCursor left, Handle right) => left.Handle == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HCursor left, Handle right) => left.Handle != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HCursor hcur) => hcur.Handle;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HCursor(Handle h) => new(h);
}