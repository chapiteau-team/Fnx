using System;
using Fnx.Core.DataTypes;
using Fnx.Core.Types;

namespace Fnx.Core.TypeClasses.Instances
{
    public class TryEq<T> : IEq<Try<T>>
    {
        private readonly IEq<T> _eq;
        private readonly IEq<Exception> _eqException;

        public TryEq(IEq<T> eq, IEq<Exception> eqException)
        {
            _eq = eq;
            _eqException = eqException;
        }

        public bool Eqv(Try<T> a, Try<T> b) =>
            a.IsSuccess
                ? b.IsSuccess && _eq.Eqv(a.Get(), b.Get())
                : b.IsFailure && _eqException.Eqv(a.GetException(), b.GetException());
    }

    public class TryEqK : IEqK<TryF>
    {
        private readonly IEq<Exception> _eqException;

        public TryEqK(IEq<Exception> eqException) => _eqException = eqException;

        public bool EqK<T>(IKind<TryF, T> x, IKind<TryF, T> y, IEq<T> eq) =>
            TryK.Eq(eq, _eqException).Eqv(x.Fix(), y.Fix());
    }

    public class TryInvariant : IInvariant<TryF>
    {
        public IKind<TryF, TB> XMap<TA, TB>(IKind<TryF, TA> fa, Func<TA, TB> f, Func<TB, TA> g) =>
            fa.Fix().Map(f);
    }

    public class TryFunctor : IFunctor<TryF>
    {
        public IKind<TryF, TB> Map<TA, TB>(IKind<TryF, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f);
    }

    public class TryApply : IApply<TryF>
    {
        public IKind<TryF, TB> Map<TA, TB>(IKind<TryF, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f);

        public IKind<TryF, TB> Ap<TA, TB>(IKind<TryF, Func<TA, TB>> ff, IKind<TryF, TA> fa) =>
            ff.Fix().FlatMap(fa.Fix().Map);
    }

    public class TryApplicative : IApplicative<TryF>
    {
        public IKind<TryF, TB> Map<TA, TB>(IKind<TryF, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f);

        public IKind<TryF, TB> Ap<TA, TB>(IKind<TryF, Func<TA, TB>> ff, IKind<TryF, TA> fa) =>
            ff.Fix().FlatMap(fa.Fix().Map);

        public IKind<TryF, T> Pure<T>(T value) =>
            new Success<T>(value);
    }

    public class TryFlatMap : IFlatMap<TryF>
    {
        public IKind<TryF, TB> Map<TA, TB>(IKind<TryF, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f);

        public IKind<TryF, TB> FlatMap<TA, TB>(IKind<TryF, TA> fa, Func<TA, IKind<TryF, TB>> f) =>
            fa.Fix().FlatMap(x => f(x).Fix());
    }

    public class TryMonad : IMonad<TryF>
    {
        public IKind<TryF, TB> Map<TA, TB>(IKind<TryF, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f);

        public IKind<TryF, TB> FlatMap<TA, TB>(IKind<TryF, TA> fa, Func<TA, IKind<TryF, TB>> f) =>
            fa.Fix().FlatMap(x => f(x).Fix());

        public IKind<TryF, T> Pure<T>(T value) =>
            new Success<T>(value);
    }

    public static class TryK
    {
        public static IEq<Try<T>> Eq<T>(IEq<T> eq, IEq<Exception> eqException) => new TryEq<T>(eq, eqException);

        public static IEqK<TryF> EqK(IEq<Exception> eqException) => new TryEqK(eqException);

        private static readonly IInvariant<TryF> InvariantSingleton = new TryInvariant();
        public static IInvariant<TryF> Invariant() => InvariantSingleton;

        private static readonly IFunctor<TryF> FunctorSingleton = new TryFunctor();
        public static IFunctor<TryF> Functor() => FunctorSingleton;

        private static readonly IApply<TryF> ApplySingleton = new TryApply();
        public static IApply<TryF> Apply() => ApplySingleton;

        private static readonly IApplicative<TryF> ApplicativeSingleton = new TryApplicative();
        public static IApplicative<TryF> Applicative() => ApplicativeSingleton;

        private static readonly IFlatMap<TryF> FlatMapSingleton = new TryFlatMap();
        public static IFlatMap<TryF> FlatMap() => FlatMapSingleton;

        private static readonly IMonad<TryF> MonadSingleton = new TryMonad();
        public static IMonad<TryF> Monad() => MonadSingleton;
    }
}