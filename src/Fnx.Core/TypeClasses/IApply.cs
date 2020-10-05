using System;
using Fnx.Core.Types;

namespace Fnx.Core.TypeClasses
{
    /// <summary>
    /// Weaker version of Applicative; Doesn't have Pure.
    /// </summary>
    /// <typeparam name="TF"></typeparam>
    public partial interface IApply<TF> : IFunctor<TF>
    {
        /// <summary>
        /// Given a value and a function in the Apply context, applies the function to the value.
        /// </summary>
        /// <param name="ff"></param>
        /// <param name="fa"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        IKind<TF, TB> Ap<TA, TB>(IKind<TF, Func<TA, TB>> ff, IKind<TF, TA> fa);

        /// <summary>
        /// Is a binary version of <see cref="Ap{TA,TB}"/>.
        /// </summary>
        /// <param name="ff"></param>
        /// <param name="fa"></param>
        /// <param name="fb"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <typeparam name="TZ"></typeparam>
        /// <returns></returns>
        IKind<TF, TZ> Ap2<TA, TB, TZ>(IKind<TF, Func<TA, TB, TZ>> ff, IKind<TF, TA> fa, IKind<TF, TB> fb) =>
            Ap(Ap(Map<Func<TA, TB, TZ>, Func<TA, Func<TB, TZ>>>(ff, f => a => b => f(a, b)), fa), fb);

        /// <summary>
        /// Compose two actions, discarding any value produced by the second. 
        /// This is equivalent to &lt;* in Haskell.
        /// </summary>
        /// <param name="fa"></param>
        /// <param name="fb"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        IKind<TF, TA> ProductL<TA, TB>(IKind<TF, TA> fa, IKind<TF, TB> fb) =>
            Map2(fa, fb, (a, _) => a);

        /// <summary>
        /// Compose two actions, discarding any value produced by the first.
        /// This is equivalent to *&gt; in Haskell.
        /// </summary>
        /// <param name="fa"></param>
        /// <param name="fb"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        IKind<TF, TB> ProductR<TA, TB>(IKind<TF, TA> fa, IKind<TF, TB> fb) =>
            Ap(Map<TA, Func<TB, TB>>(fa, _ => b => b), fb);

        /// <summary>
        /// Combine an <see cref="IKind{TF,T}"/> of <typeparamref name="TA"/>
        /// and an <see cref="IKind{TF,T}"/> of <typeparamref name="TB"/>
        /// into an <see cref="IKind{TF,T}"/> of (<typeparamref name="TA"/>, <typeparamref name="TB"/>)
        /// that maintains the effects of both <paramref name="fa"/> and <paramref name="fb"/>.
        /// </summary>
        /// <param name="fa"></param>
        /// <param name="fb"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        IKind<TF, (TA, TB)> Product<TA, TB>(IKind<TF, TA> fa, IKind<TF, TB> fb) =>
            Ap(Map<TA, Func<TB, (TA, TB)>>(fa, a => b => (a, b)), fb);

        /// <summary>
        /// Applies the pure (binary) function <paramref name="f"/>
        /// to the effectful values <paramref name="fa"/> and <paramref name="fb"/>.
        /// Can be seen as a binary version of <see cref="IFunctor{TF}.Map{TA, TB}"/>
        /// </summary>
        /// <param name="fa"></param>
        /// <param name="fb"></param>
        /// <param name="f"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <typeparam name="TZ"></typeparam>
        /// <returns></returns>
        IKind<TF, TZ> Map2<TA, TB, TZ>(IKind<TF, TA> fa, IKind<TF, TB> fb, Func<TA, TB, TZ> f) =>
            Map(Product(fa, fb), ((TA a, TB b) x) => f(x.a, x.b));
    }
}