using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WinForms.Native.PInvoke;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public readonly record struct HMonitor(Handle Handle)
    : IEqualityOperators<HMonitor, HMonitor, bool>, IEquatable<HMonitor>,
    IEqualityOperators<HMonitor, Handle, bool>, IEquatable<Handle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Handle other) => Handle == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HMonitor left, Handle right) => left.Handle == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HMonitor left, Handle right) => left.Handle != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HMonitor hmon) => hmon.Handle;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HMonitor(Handle h) => new(h);
}