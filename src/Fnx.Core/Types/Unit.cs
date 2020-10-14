using System;
using Fnx.Core.Exceptions;

namespace Fnx.Core.Types
{
    /// <summary>
    /// The type with only one value. It corresponds to the <see langword="void"/> in C#.
    /// </summary>
    public readonly struct Unit : IEquatable<Unit>, IComparable, IComparable<Unit>
    {
        public override string ToString() => nameof(Unit);


        public bool Equals(Unit other) => true;

        public override bool Equals(object? obj) => obj is Unit;

        public override int GetHashCode() => 1;

        public static bool operator ==(Unit left, Unit right) => left.Equals(right);

        public static bool operator !=(Unit left, Unit right) => !left.Equals(right);

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            return obj is Unit
                ? 0
                : throw new ArgumentException(ExceptionsMessages.WrongType, nameof(obj));
        }

        public int CompareTo(Unit other) => 0;
    }
}