using System;
using Fnx.Core.Types;

namespace Fnx.Core.TypeClasses
{
    /// <summary>
    /// Weaker version of Monad; Doesn't have Pure.
    /// </summary>
    /// <typeparam name="TF"></typeparam>
    public interface IFlatMap<TF> : IApply<TF>
    {
        /// <summary>
        /// Maps an <see cref="IKind{TF,T}"/> of <typeparamref name="TA"/> into
        /// an <see cref="IKind{TF,T}"/> of <typeparamref name="TB"/>
        /// and Flattens the result.
        /// </summary>
        /// <param name="fa"></param>
        /// <param name="f"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        IKind<TF, TB> FlatMap<TA, TB>(IKind<TF, TA> fa, Func<TA, IKind<TF, TB>> f);

        /// <summary>
        /// Flattens a nested <see cref="IKind{TF,T}"/> of <see cref="IKind{TF,T}"/> of <typeparamref name="TA"/>
        /// into a <see cref="IKind{TF,T}"/> of <typeparamref name="TA"/>.
        /// </summary>
        /// <param name="ffa"></param>
        /// <typeparam name="TA"></typeparam>
        /// <returns></returns>
        IKind<TF, TA> Flatten<TA>(IKind<TF, IKind<TF, TA>> ffa) =>
            FlatMap(ffa, Combinators.I);

        /// <summary>
        /// Apply a monadic function and discard the result while keeping the effect.
        /// </summary>
        /// <param name="fa"></param>
        /// <param name="f"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        IKind<TF, TA> FlatTap<TA, TB>(IKind<TF, TA> fa, Func<TA, IKind<TF, TB>> f) =>
            FlatMap(fa, a => Map(f(a), _ => a));

        /// <summary>
        /// Pair <typeparamref name="TA"/> with the result of function application.
        /// </summary>
        /// <param name="fa"></param>
        /// <param name="f"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        IKind<TF, (TA, TB)> MProduct<TA, TB>(IKind<TF, TA> fa, Func<TA, IKind<TF, TB>> f) =>
            FlatMap(fa, a => Map(f(a), b => (a, b)));

        /// <summary>
        /// <see langword="if" /> lifted into monad.
        /// </summary>
        /// <param name="fa"></param>
        /// <param name="ifTrue"></param>
        /// <param name="ifFalse"></param>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        IKind<TF, TB> IfM<TB>(IKind<TF, bool> fa, Func<IKind<TF, TB>> ifTrue, Func<IKind<TF, TB>> ifFalse) =>
            FlatMap<bool, TB>(fa, a => a ? ifTrue() : ifFalse());

        /// <inheritdoc />
        IKind<TF, TB> IApply<TF>.Ap<TA, TB>(IKind<TF, Func<TA, TB>> ff, IKind<TF, TA> fa) =>
            FlatMap(ff, f => Map(fa, f));

        /// <inheritdoc />
        IKind<TF, TZ> IApply<TF>.Ap2<TA, TB, TZ>(IKind<TF, Func<TA, TB, TZ>> ff, IKind<TF, TA> fa, IKind<TF, TB> fb) =>
            FlatMap(fa, a => FlatMap(fb, b => Map(ff, f => f(a, b))));

        /// <inheritdoc />
        IKind<TF, TA> IApply<TF>.ProductL<TA, TB>(IKind<TF, TA> fa, IKind<TF, TB> fb) =>
            Map2(fa, fb, (a, _) => a);

        /// <inheritdoc />
        IKind<TF, TB> IApply<TF>.ProductR<TA, TB>(IKind<TF, TA> fa, IKind<TF, TB> fb) =>
            FlatMap(fa, _ => fb);

        /// <inheritdoc />
        IKind<TF, (TA, TB)> IApply<TF>.Product<TA, TB>(IKind<TF, TA> fa, IKind<TF, TB> fb) =>
            FlatMap(fa, a => Map(fb, b => (a, b)));

        /// <inheritdoc />
        IKind<TF, TZ> IApply<TF>.Map2<TA, TB, TZ>(IKind<TF, TA> fa, IKind<TF, TB> fb, Func<TA, TB, TZ> f) =>
            FlatMap(fa, a => Map(fb, b => f(a, b)));
    }
}