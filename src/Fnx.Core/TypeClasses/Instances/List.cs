using System;
using System.Collections.Generic;
using Fnx.Core.DataTypes;
using Fnx.Core.Types;

namespace Fnx.Core.TypeClasses.Instances
{
    public class ListEq<T> : IEq<List<T>>
    {
        private readonly IEq<T> _eq;

        public ListEq(IEq<T> eq) => _eq = eq;

        public bool Eqv(List<T> a, List<T> b)
        {
            if (a.Count != b.Count)
            {
                return false;
            }

            var count = a.Count;
            for (var i = 0; i < count; i++)
            {
                if (_eq.NEqv(a[i], b[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class ListEqK : IEqK<ListF>
    {
        public bool EqK<T>(IKind<ListF, T> x, IKind<ListF, T> y, IEq<T> eq) =>
            ListK.Eq(eq).Eqv(x.Fix(), y.Fix());
    }

    public class ListInvariant : IInvariant<ListF>
    {
        public IKind<ListF, TB> XMap<TA, TB>(IKind<ListF, TA> fa, Func<TA, TB> f, Func<TB, TA> g) =>
            fa.Fix().Map(f).K();
    }

    public class ListFunctor : IFunctor<ListF>
    {
        public IKind<ListF, TB> Map<TA, TB>(IKind<ListF, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f).K();
    }

    public class ListApply : IApply<ListF>
    {
        public IKind<ListF, TB> Map<TA, TB>(IKind<ListF, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f).K();

        public IKind<ListF, TB> Ap<TA, TB>(IKind<ListF, Func<TA, TB>> ff, IKind<ListF, TA> fa)
        {
            var a = fa.Fix();
            return ff.Fix().FlatMap(x => a.Map(x)).K();
        }
    }

    public class ListApplicative : IApplicative<ListF>
    {
        public IKind<ListF, TB> Map<TA, TB>(IKind<ListF, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f).K();

        public IKind<ListF, TB> Ap<TA, TB>(IKind<ListF, Func<TA, TB>> ff, IKind<ListF, TA> fa)
        {
            var a = fa.Fix();
            return ff.Fix().FlatMap(x => a.Map(x)).K();
        }

        public IKind<ListF, T> Pure<T>(T value) =>
            new List<T> {value}.K();
    }

    public class ListFlatMap : IFlatMap<ListF>
    {
        public IKind<ListF, TB> Map<TA, TB>(IKind<ListF, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f).K();

        public IKind<ListF, TB> FlatMap<TA, TB>(IKind<ListF, TA> fa, Func<TA, IKind<ListF, TB>> f) =>
            fa.Fix().FlatMap(x => f(x).Fix()).K();

        public IKind<ListF, T> Pure<T>(T value) =>
            new List<T> {value}.K();
    }

    public class ListMonad : IMonad<ListF>
    {
        public IKind<ListF, TB> Map<TA, TB>(IKind<ListF, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f).K();

        public IKind<ListF, TB> FlatMap<TA, TB>(IKind<ListF, TA> fa, Func<TA, IKind<ListF, TB>> f) =>
            fa.Fix().FlatMap(x => f(x).Fix()).K();

        public IKind<ListF, T> Pure<T>(T value) =>
            new List<T> {value}.K();
    }

    public static class ListK
    {
        public static IEq<List<T>> Eq<T>(IEq<T> eq) => new ListEq<T>(eq);

        private static readonly IEqK<ListF> EqkSingleton = new ListEqK();
        public static IEqK<ListF> EqK() => EqkSingleton;

        private static readonly IInvariant<ListF> InvariantSingleton = new ListInvariant();
        public static IInvariant<ListF> Invariant() => InvariantSingleton;

        private static readonly IFunctor<ListF> FunctorSingleton = new ListFunctor();
        public static IFunctor<ListF> Functor() => FunctorSingleton;

        private static readonly IApply<ListF> ApplySingleton = new ListApply();
        public static IApply<ListF> Apply() => ApplySingleton;

        private static readonly IApplicative<ListF> ApplicativeSingleton = new ListApplicative();
        public static IApplicative<ListF> Applicative() => ApplicativeSingleton;

        private static readonly IFlatMap<ListF> FlatMapSingleton = new ListFlatMap();
        public static IFlatMap<ListF> FlatMap() => FlatMapSingleton;

        private static readonly IMonad<ListF> MonadSingleton = new ListMonad();
        public static IMonad<ListF> Monad() => MonadSingleton;
    }
}