using System;
using System.Runtime.InteropServices;

namespace Fnx.Core.Types
{
    /// <summary>
    /// Nothing is the return type for methods while the final type is not known.
    /// Another usage of Nothing is to indicate that the parameter is bypassed in Partial Application.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct Nothing : IEquatable<Nothing>
    {
        public override string ToString() => nameof(Nothing);

        public bool Equals(Nothing other) => true;

        public override bool Equals(object? obj) =>
            obj is Nothing other && Equals(other);

        public override int GetHashCode() => 0;

        public static bool operator ==(Nothing left, Nothing right) => left.Equals(right);

        public static bool operator !=(Nothing left, Nothing right) => !left.Equals(right);
    }
}