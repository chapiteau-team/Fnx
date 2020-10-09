using Fnx.Core.Types;

namespace Fnx.Core.TypeClasses
{
    /// <summary>
    /// A typeclass abstracts the ability to lift the Eq typeclass to binary type constructors.
    /// </summary>
    /// <typeparam name="TF"></typeparam>
    public interface IEqK2<in TF>
    {
        /// <summary>
        /// Lifts the equality check provided by a given <see cref="IEq{T}"/> instance of type <typeparamref name="TA"/>
        /// and <see cref="IEq{T}"/> instance of type <typeparamref name="TB"/>
        /// to <see cref="IEq{T}"/> of type <see cref="IKind2{TF,TA,TB}"/>.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="eqOk"></param>
        /// <param name="eqB"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        bool EqK<TA, TB>(IKind2<TF, TA, TB> x, IKind2<TF, TA, TB> y, IEq<TA> eqOk, IEq<TB> eqB);
    }
}