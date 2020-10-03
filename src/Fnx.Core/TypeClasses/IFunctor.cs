using System;
using Fnx.Core.Types;

namespace Fnx.Core.TypeClasses
{
    /// <summary>
    /// Covariant functor.
    /// </summary>
    /// <typeparam name="TF"></typeparam>
    public interface IFunctor<TF> : IInvariant<TF>
    {
        /// <summary>
        /// Transform an F&lt;<typeparamref name="TA"/>&gt; into an F&lt;<typeparamref name="TB"/>&gt;
        /// by providing a transformation from <typeparamref name="TA"/> to <typeparamref name="TB"/>.
        /// </summary>
        /// <param name="fa"></param>
        /// <param name="f"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        IKind<TF, TB> Map<TA, TB>(IKind<TF, TA> fa, Func<TA, TB> f);

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <param name="fa"></param>
        /// <param name="f"></param>
        /// <param name="g"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        IKind<TF, TB> IInvariant<TF>.XMap<TA, TB>(IKind<TF, TA> fa, Func<TA, TB> f, Func<TB, TA> g) =>
            Map(fa, f);

        /// <summary>
        /// Lifts natural subtyping covariance of covariant Functors.
        /// </summary>
        /// <param name="fa"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        IKind<TF, TB> Widen<TA, TB>(IKind<TF, TA> fa) where TA : TB => (IKind<TF, TB>) fa;

        /// <summary>
        /// Lift a function f to operate on Functors.
        /// </summary>
        /// <param name="f"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        Func<IKind<TF, TA>, IKind<TF, TB>> Lift<TA, TB>(Func<TA, TB> f) =>
            fa => Map(fa, f);

        /// <summary>
        /// Empty the <paramref name="fa"/> of the values, preserving the structure.
        /// </summary>
        /// <param name="fa"></param>
        /// <typeparam name="TA"></typeparam>
        /// <returns></returns>
        IKind<TF, Nothing> Void<TA>(IKind<TF, TA> fa) =>
            Map(fa, _ => new Nothing());

        /// <summary>
        /// Tuple the values in <paramref name="fa"/> with the result of applying a function with the value.
        /// </summary>
        /// <param name="fa"></param>
        /// <param name="f"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        IKind<TF, (TA, TB)> FProduct<TA, TB>(IKind<TF, TA> fa, Func<TA, TB> f) =>
            Map(fa, a => (a, f(a)));

        /// <summary>
        /// Pair the result of function application with the values in <paramref name="fa"/>.
        /// </summary>
        /// <param name="fa"></param>
        /// <param name="f"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        IKind<TF, (TB, TA)> FProductLeft<TA, TB>(IKind<TF, TA> fa, Func<TA, TB> f) =>
            Map(fa, a => (f(a), a));

        /// <summary>
        /// Replaces the values in <paramref name="fa"/> with the supplied value.
        /// </summary>
        /// <param name="fa"></param>
        /// <param name="b"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        IKind<TF, TB> As<TA, TB>(IKind<TF, TA> fa, TB b) =>
            Map(fa, _ => b);

        /// <summary>
        /// Tuples the values in <paramref name="fa"/> with the supplied `B` value, with the `B` value on the left.
        /// </summary>
        /// <param name="fa"></param>
        /// <param name="b"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        IKind<TF, (TB, TA)> TupleLeft<TA, TB>(IKind<TF, TA> fa, TB b) =>
            Map(fa, a => (b, a));

        /// <summary>
        /// Tuples the values in <paramref name="fa"/> with the supplied `B` value, with the `B` value on the right.
        /// </summary>
        /// <param name="fa"></param>
        /// <param name="b"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        IKind<TF, (TA, TB)> TupleRight<TA, TB>(IKind<TF, TA> fa, TB b) =>
            Map(fa, a => (a, b));

        /// <summary>
        /// Un-zips an F&lt;(<typeparamref name="TA"/>, <typeparamref name="TB"/>)&gt; into two separate F's tupled.
        /// </summary>
        /// <param name="fab"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        (IKind<TF, TA>, IKind<TF, TB>) UnZip<TA, TB>(IKind<TF, (TA, TB)> fab) =>
            (Map(fab, x => x.Item1), Map(fab, x => x.Item2));
    }
}