namespace Fnx.Core.TypeClasses
{
    /// <summary>
    /// A type class used to determine equality between 2 instances of the same type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEq<in T>
    {
        /// <summary>
        /// Returns <see langword="true" /> if <paramref name="a"/> and <paramref name="b"/> are equivalent,
        /// <see langword="false" /> otherwise.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        bool Eqv(T a, T b);

        /// <summary>
        /// Returns <see langword="true" /> if <paramref name="a"/> and <paramref name="b"/> are equivalent,
        /// <see langword="true" /> otherwise.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        bool NEqv(T a, T b) => !Eqv(a, b);
    }
}