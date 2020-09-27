using System;
using System.Diagnostics.CodeAnalysis;

namespace Fnx.Core.DataTypes.Interfaces
{
    public interface IGettable<T>
    {
        T Get();

        [return: MaybeNull]
        T GetOrElse([AllowNull] T or);

        T GetOrElse(Func<T> or);

        [return: MaybeNull]
        T GetOrDefault();
    }
}