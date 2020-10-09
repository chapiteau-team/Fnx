using Fnx.Core.Types;

namespace Fnx.Core.TypeClasses
{
    /// <summary>
    /// A typeclass abstracts the ability to lift the Eq typeclass to unary type constructors.
    /// </summary>
    /// <typeparam name="TF"></typeparam>
    public interface IEqK<in TF>
    {
        /// <summary>
        /// Lifts the equality check provided by a given <see cref="IEq{T}"/> instance of type <typeparamref name="T"/>
        /// to <see cref="IEq{T}"/> of type <see cref="IKind{TF,T}"/>.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="eq"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        bool EqK<T>(IKind<TF, T> x, IKind<TF, T> y, IEq<T> eq);
    }
}