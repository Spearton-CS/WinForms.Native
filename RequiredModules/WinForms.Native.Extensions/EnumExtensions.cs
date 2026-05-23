using System.Runtime.CompilerServices;

namespace WinForms.Native.Extensions;

public unsafe static class EnumExtensions64
{
    extension<T>(ulong value)
        where T : unmanaged, Enum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool HasFlag(T flag) => (value & flag) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong RawWithFlag(T flag) => value | flag;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T WithFlag(T flag)
        {
            ulong raw = value.RawWithFlag(flag);
            return Unsafe.As<ulong, T>(ref raw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong RawWithoutFlag(T flag) => value & (sizeof(T) switch
        {
            1 => (ulong)~Unsafe.As<T, byte>(ref flag),
            2 => (ulong)~Unsafe.As<T, ushort>(ref flag),
            4 => (ulong)~Unsafe.As<T, uint>(ref flag),
            _ => ~Unsafe.As<T, ulong>(ref flag)
        });
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T WithoutFlag(T flag)
        {
            ulong raw = value.RawWithoutFlag(flag);
            return Unsafe.As<ulong, T>(ref raw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong RawReverseFlag(T flag) => value ^ flag;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T ReverseFlag(T flag)
        {
            ulong raw = value.RawReverseFlag(flag);
            return Unsafe.As<ulong, T>(ref raw);
        }

        #region ulong with T as ulong

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong operator |(ulong a, T b) => sizeof(T) switch
        {
            1 => a | Unsafe.As<T, byte>(ref b),
            2 => a | Unsafe.As<T, ushort>(ref b),
            4 => a | Unsafe.As<T, uint>(ref b),
            _ => a | Unsafe.As<T, ulong>(ref b)
        };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong operator &(ulong a, T b) => sizeof(T) switch
        {
            1 => a & Unsafe.As<T, byte>(ref b),
            2 => a & Unsafe.As<T, ushort>(ref b),
            4 => a & Unsafe.As<T, uint>(ref b),
            _ => a & Unsafe.As<T, ulong>(ref b)
        };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong operator ^(ulong a, T b) => sizeof(T) switch
        {
            1 => a ^ Unsafe.As<T, byte>(ref b),
            2 => a ^ Unsafe.As<T, ushort>(ref b),
            4 => a ^ Unsafe.As<T, uint>(ref b),
            _ => a ^ Unsafe.As<T, ulong>(ref b)
        };

        #endregion

        #region T with ulong as T

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator |(T a, ulong b)
        {
            ulong raw = b | a;
            return Unsafe.As<ulong, T>(ref raw);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator &(T a, ulong b)
        {
            ulong raw = b & a;
            return Unsafe.As<ulong, T>(ref raw);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator ^(T a, ulong b)
        {
            ulong raw = b ^ a;
            return Unsafe.As<ulong, T>(ref raw);
        }

        #endregion
    }
}

public unsafe static class EnumExtensions32
{
    extension<T>(uint value)
        where T : unmanaged, Enum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool HasFlag(T flag) => (value & flag) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint RawWithFlag(T flag) => value | flag;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T WithFlag(T flag)
        {
            ulong raw = value.RawWithFlag(flag);
            return Unsafe.As<ulong, T>(ref raw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint RawWithoutFlag(T flag) => value & (sizeof(T) switch
        {
            1 => (uint)~Unsafe.As<T, byte>(ref flag),
            2 => (uint)~Unsafe.As<T, ushort>(ref flag),
            _ => ~Unsafe.As<T, uint>(ref flag)
        });
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T WithoutFlag(T flag)
        {
            ulong raw = value.RawWithoutFlag(flag);
            return Unsafe.As<ulong, T>(ref raw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint RawReverseFlag(T flag) => value ^ flag;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T ReverseFlag(T flag)
        {
            ulong raw = value.RawReverseFlag(flag);
            return Unsafe.As<ulong, T>(ref raw);
        }

        #region uint with T as uint

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint operator |(uint a, T b) => sizeof(T) switch
        {
            1 => a | Unsafe.As<T, byte>(ref b),
            2 => a | Unsafe.As<T, ushort>(ref b),
            _ => a | Unsafe.As<T, uint>(ref b)
        };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint operator &(uint a, T b) => sizeof(T) switch
        {
            1 => a & Unsafe.As<T, byte>(ref b),
            2 => a & Unsafe.As<T, ushort>(ref b),
            _ => a & Unsafe.As<T, uint>(ref b)
        };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint operator ^(uint a, T b) => sizeof(T) switch
        {
            1 => a ^ Unsafe.As<T, byte>(ref b),
            2 => a ^ Unsafe.As<T, ushort>(ref b),
            _ => a ^ Unsafe.As<T, uint>(ref b)
        };

        #endregion

        #region T with uint as T

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator |(T a, uint b)
        {
            ulong raw = b | a;
            return Unsafe.As<ulong, T>(ref raw);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator &(T a, uint b)
        {
            ulong raw = b & a;
            return Unsafe.As<ulong, T>(ref raw);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator ^(T a, uint b)
        {
            ulong raw = b ^ a;
            return Unsafe.As<ulong, T>(ref raw);
        }

        #endregion
    }
}

public unsafe static class EnumExtensions16
{
    extension<T>(ushort value)
        where T : unmanaged, Enum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool HasFlag(T flag) => (value & flag) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort RawWithFlag(T flag) => value | flag;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T WithFlag(T flag)
        {
            ulong raw = value.RawWithFlag(flag);
            return Unsafe.As<ulong, T>(ref raw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort RawWithoutFlag(T flag) => (ushort)(value & (sizeof(T) == 1
            ? (ushort)~Unsafe.As<T, byte>(ref flag)
            : ~Unsafe.As<T, ushort>(ref flag)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T WithoutFlag(T flag)
        {
            ulong raw = value.RawWithoutFlag(flag);
            return Unsafe.As<ulong, T>(ref raw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort RawReverseFlag(T flag) => value ^ flag;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T ReverseFlag(T flag)
        {
            ulong raw = value.RawReverseFlag(flag);
            return Unsafe.As<ulong, T>(ref raw);
        }

        #region ushort with T as ushort

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort operator |(ushort a, T b) => (ushort)(sizeof(T) == 1
            ? a | Unsafe.As<T, byte>(ref b)
            : a | Unsafe.As<T, ushort>(ref b));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort operator &(ushort a, T b) => (ushort)(sizeof(T) == 1
            ? a & Unsafe.As<T, byte>(ref b)
            : a & Unsafe.As<T, ushort>(ref b));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort operator ^(ushort a, T b) => (ushort)(sizeof(T) == 1
            ? a ^ Unsafe.As<T, byte>(ref b)
            : a ^ Unsafe.As<T, ushort>(ref b));

        #endregion

        #region T with ushort as T

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator |(T a, ushort b)
        {
            ulong raw = b | a;
            return Unsafe.As<ulong, T>(ref raw);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator &(T a, ushort b)
        {
            ulong raw = b & a;
            return Unsafe.As<ulong, T>(ref raw);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator ^(T a, ushort b)
        {
            ulong raw = b ^ a;
            return Unsafe.As<ulong, T>(ref raw);
        }

        #endregion
    }
}

public static class EnumExtensions8
{
    extension<T>(byte value)
        where T : unmanaged, Enum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool HasFlag(T flag) => (value & flag) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte RawWithFlag(T flag) => value | flag;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T WithFlag(T flag)
        {
            ulong raw = value.RawWithFlag(flag);
            return Unsafe.As<ulong, T>(ref raw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte RawWithoutFlag(T flag) => (byte)(value & (~Unsafe.As<T, byte>(ref flag)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T WithoutFlag(T flag)
        {
            ulong raw = value.RawWithoutFlag(flag);
            return Unsafe.As<ulong, T>(ref raw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte RawReverseFlag(T flag) => value ^ flag;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T ReverseFlag(T flag)
        {
            ulong raw = value.RawReverseFlag(flag);
            return Unsafe.As<ulong, T>(ref raw);
        }

        #region byte with T as byte

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte operator |(byte a, T b) => (byte)(a | Unsafe.As<T, byte>(ref b));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte operator &(byte a, T b) => (byte)(a & Unsafe.As<T, byte>(ref b));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte operator ^(byte a, T b) => (byte)(a ^ Unsafe.As<T, byte>(ref b));

        #endregion

        #region T with byte as T

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator |(T a, byte b)
        {
            ulong raw = b | a;
            return Unsafe.As<ulong, T>(ref raw);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator &(T a, byte b)
        {
            ulong raw = b & a;
            return Unsafe.As<ulong, T>(ref raw);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator ^(T a, byte b)
        {
            ulong raw = b ^ a;
            return Unsafe.As<ulong, T>(ref raw);
        }

        #endregion
    }
}