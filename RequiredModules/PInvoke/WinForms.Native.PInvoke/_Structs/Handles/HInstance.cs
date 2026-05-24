using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public readonly record struct HInstance(Handle Handle)
    : IEqualityOperators<HInstance, HInstance, bool>, IEquatable<HInstance>,
    IEqualityOperators<HInstance, Handle, bool>, IEquatable<Handle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Handle other) => Handle == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HInstance left, Handle right) => left.Handle == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HInstance left, Handle right) => left.Handle != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HInstance hinstance) => hinstance.Handle;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HInstance(Handle h) => new(h);
}