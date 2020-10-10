using System;
using Fnx.Core.DataTypes;
using Fnx.Core.Types;

namespace Fnx.Core.TypeClasses.Instances
{
    public class OptionEq<T> : IEq<Option<T>>
    {
        private readonly IEq<T> _eq;

        public OptionEq(IEq<T> eq) => _eq = eq;

        public bool Eqv(Option<T> a, Option<T> b) =>
            a.IsSome
                ? b.IsSome && _eq.Eqv(a.Get(), b.Get())
                : !b.IsSome;
    }

    public class OptionEqK : IEqK<OptionF>
    {
        public bool EqK<T>(IKind<OptionF, T> x, IKind<OptionF, T> y, IEq<T> eq) =>
            OptionK.Eq(eq).Eqv(x.Fix(), y.Fix());
    }

    public class OptionInvariant : IInvariant<OptionF>
    {
        public IKind<OptionF, TB> XMap<TA, TB>(IKind<OptionF, TA> fa, Func<TA, TB> f, Func<TB, TA> g) =>
            fa.Fix().Map(f);
    }

    public class OptionFunctor : IFunctor<OptionF>
    {
        public IKind<OptionF, TB> Map<TA, TB>(IKind<OptionF, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f);
    }

    public class OptionApply : IApply<OptionF>
    {
        public IKind<OptionF, TB> Map<TA, TB>(IKind<OptionF, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f);

        public IKind<OptionF, TB> Ap<TA, TB>(IKind<OptionF, Func<TA, TB>> ff, IKind<OptionF, TA> fa)
        {
            var f = ff.Fix();
            var a = fa.Fix();

            return f.IsSome && a.IsSome
                ? (IKind<OptionF, TB>) new Some<TB>(f.Get()(a.Get()))
                : new None<TB>();
        }
    }

    public class OptionApplicative : IApplicative<OptionF>
    {
        public IKind<OptionF, TB> Map<TA, TB>(IKind<OptionF, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f);

        public IKind<OptionF, TB> Ap<TA, TB>(IKind<OptionF, Func<TA, TB>> ff, IKind<OptionF, TA> fa)
        {
            var f = ff.Fix();
            var a = fa.Fix();

            return f.IsSome && a.IsSome
                ? (IKind<OptionF, TB>) new Some<TB>(f.Get()(a.Get()))
                : new None<TB>();
        }

        public IKind<OptionF, T> Pure<T>(T value) =>
            new Some<T>(value);
    }

    public class OptionFlatMap : IFlatMap<OptionF>
    {
        public IKind<OptionF, TB> Map<TA, TB>(IKind<OptionF, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f);

        public IKind<OptionF, TB> FlatMap<TA, TB>(IKind<OptionF, TA> fa, Func<TA, IKind<OptionF, TB>> f) =>
            fa.Fix().FlatMap(x => f(x).Fix());
    }

    public class OptionMonad : IMonad<OptionF>
    {
        public IKind<OptionF, TB> Map<TA, TB>(IKind<OptionF, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f);

        public IKind<OptionF, TB> FlatMap<TA, TB>(IKind<OptionF, TA> fa, Func<TA, IKind<OptionF, TB>> f) =>
            fa.Fix().FlatMap(x => f(x).Fix());

        public IKind<OptionF, T> Pure<T>(T value) =>
            new Some<T>(value);
    }

    public static class OptionK
    {
        public static IEq<Option<T>> Eq<T>(IEq<T> eq) => new OptionEq<T>(eq);

        private static readonly IEqK<OptionF> EqkSingleton = new OptionEqK();
        public static IEqK<OptionF> EqK() => EqkSingleton;

        private static readonly IInvariant<OptionF> InvariantSingleton = new OptionInvariant();
        public static IInvariant<OptionF> Invariant() => InvariantSingleton;

        private static readonly IFunctor<OptionF> FunctorSingleton = new OptionFunctor();
        public static IFunctor<OptionF> Functor() => FunctorSingleton;

        private static readonly IApply<OptionF> ApplySingleton = new OptionApply();
        public static IApply<OptionF> Apply() => ApplySingleton;

        private static readonly IApplicative<OptionF> ApplicativeSingleton = new OptionApplicative();
        public static IApplicative<OptionF> Applicative() => ApplicativeSingleton;

        private static readonly IFlatMap<OptionF> FlatMapSingleton = new OptionFlatMap();
        public static IFlatMap<OptionF> FlatMap() => FlatMapSingleton;

        private static readonly IMonad<OptionF> MonadSingleton = new OptionMonad();
        public static IMonad<OptionF> Monad() => MonadSingleton;
    }
}