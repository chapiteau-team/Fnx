using System;
using Fnx.Core.Exceptions;

namespace Fnx.Core.Types
{
    /// <summary>
    /// Nothing is the return type for methods while the final type is not known.
    /// Another usage of Nothing is to indicate that the parameter is bypassed in Partial Application.
    /// </summary>
    public readonly struct Nothing : IEquatable<Nothing>, IComparable, IComparable<Nothing>
    {
        public override string ToString() => nameof(Nothing);

        public bool Equals(Nothing other) => true;

        public override bool Equals(object? obj) => obj is Nothing;

        public override int GetHashCode() => 0;

        public static bool operator ==(Nothing left, Nothing right) => true;

        public static bool operator !=(Nothing left, Nothing right) => false;

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            return obj is Nothing
                ? 0
                : throw new ArgumentException(ExceptionsMessages.WrongType, nameof(obj));
        }

        public int CompareTo(Nothing other) => 0;
    }
}