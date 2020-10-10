using System.Collections.Generic;

namespace Fnx.Core.TypeClasses.Instances
{
    public class DefaultEq<T> : IEq<T>
    {
        public bool Eqv(T a, T b) =>
            EqualityComparer<T>.Default.Equals(a, b);
    }

    public static class Default<T>
    {
        private static readonly IEq<T> EqSingleton = new DefaultEq<T>();

        public static IEq<T> Eq() => EqSingleton;
    }

    public class StringEq : IEq<string>
    {
        public bool Eqv(string a, string b) => a == b;
    }

    public static class StringK
    {
        private static readonly IEq<string> EqSingleton = new StringEq();
        public static IEq<string> Eq() => EqSingleton;
    }

    public class BooleanEq : IEq<bool>
    {
        public bool Eqv(bool a, bool b) => a == b;
    }

    public static class BooleanK
    {
        private static readonly IEq<bool> EqSingleton = new BooleanEq();
        public static IEq<bool> Eq() => EqSingleton;
    }

    public class ByteEq : IEq<byte>
    {
        public bool Eqv(byte a, byte b) => a == b;
    }

    public static class ByteK
    {
        private static readonly IEq<byte> EqSingleton = new ByteEq();
        public static IEq<byte> Eq() => EqSingleton;
    }

    public class SByteEq : IEq<sbyte>
    {
        public bool Eqv(sbyte a, sbyte b) => a == b;
    }

    public static class SByteK
    {
        private static readonly IEq<sbyte> EqSingleton = new SByteEq();
        public static IEq<sbyte> Eq() => EqSingleton;
    }

    public class CharEq : IEq<char>
    {
        public bool Eqv(char a, char b) => a == b;
    }

    public static class CharK
    {
        private static readonly IEq<char> EqSingleton = new CharEq();
        public static IEq<char> Eq() => EqSingleton;
    }

    public class DecimalEq : IEq<decimal>
    {
        public bool Eqv(decimal a, decimal b) => a == b;
    }

    public static class DecimalK
    {
        private static readonly IEq<decimal> EqSingleton = new DecimalEq();
        public static IEq<decimal> Eq() => EqSingleton;
    }

    public class DoubleEq : IEq<double>
    {
        public bool Eqv(double a, double b) => a == b;
    }

    public static class DoubleK
    {
        private static readonly IEq<double> EqSingleton = new DoubleEq();
        public static IEq<double> Eq() => EqSingleton;
    }

    public class SingleEq : IEq<float>
    {
        public bool Eqv(float a, float b) => a == b;
    }

    public static class SingleK
    {
        private static readonly IEq<float> EqSingleton = new SingleEq();
        public static IEq<float> Eq() => EqSingleton;
    }

    public class Int32Eq : IEq<int>
    {
        public bool Eqv(int a, int b) => a == b;
    }

    public static class Int32K
    {
        private static readonly IEq<int> EqSingleton = new Int32Eq();
        public static IEq<int> Eq() => EqSingleton;
    }

    public class UInt32Eq : IEq<uint>
    {
        public bool Eqv(uint a, uint b) => a == b;
    }

    public static class UInt32K
    {
        private static readonly IEq<uint> EqSingleton = new UInt32Eq();
        public static IEq<uint> Eq() => EqSingleton;
    }

    public class Int64Eq : IEq<long>
    {
        public bool Eqv(long a, long b) => a == b;
    }

    public static class Int64K
    {
        private static readonly IEq<long> EqSingleton = new Int64Eq();
        public static IEq<long> Eq() => EqSingleton;
    }

    public class UInt64Eq : IEq<ulong>
    {
        public bool Eqv(ulong a, ulong b) => a == b;
    }

    public static class UInt64K
    {
        private static readonly IEq<ulong> EqSingleton = new UInt64Eq();
        public static IEq<ulong> Eq() => EqSingleton;
    }

    public class Int16Eq : IEq<short>
    {
        public bool Eqv(short a, short b) => a == b;
    }

    public static class Int16K
    {
        private static readonly IEq<short> EqSingleton = new Int16Eq();
        public static IEq<short> Eq() => EqSingleton;
    }

    public class UInt16Eq : IEq<ushort>
    {
        public bool Eqv(ushort a, ushort b) => a == b;
    }

    public static class UInt16K
    {
        private static readonly IEq<ushort> EqSingleton = new UInt16Eq();
        public static IEq<ushort> Eq() => EqSingleton;
    }
}