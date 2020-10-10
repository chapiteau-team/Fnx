using System;
using Fnx.Core.DataTypes;
using Fnx.Core.Types;

namespace Fnx.Core.TypeClasses.Instances
{
    public class ResultEq<TOk, TError> : IEq<Result<TOk, TError>>
    {
        private readonly IEq<TOk> _eqOk;
        private readonly IEq<TError> _eqError;

        public ResultEq(IEq<TOk> eqOk, IEq<TError> eqError)
        {
            _eqOk = eqOk;
            _eqError = eqError;
        }

        public bool Eqv(Result<TOk, TError> a, Result<TOk, TError> b) =>
            a.IsOk
                ? b.IsOk && _eqOk.Eqv(a.Get(), b.Get())
                : b.IsError && _eqError.Eqv(a.GetError(), b.GetError());
    }

    public class ResultEqK<TError> : IEqK<ResultOkF<TError>>
    {
        private readonly IEq<TError> _eqError;

        public ResultEqK(IEq<TError> eqError) => _eqError = eqError;

        public bool EqK<TOk>(IKind<ResultOkF<TError>, TOk> x, IKind<ResultOkF<TError>, TOk> y, IEq<TOk> eqOk) =>
            ResultK.Eq(eqOk, _eqError).Eqv(x.Fix(), y.Fix());
    }

    public class ResultEqK2 : IEqK2<ResultF>
    {
        public bool EqK<TOk, TError>(
            IKind2<ResultF, TOk, TError> x, IKind2<ResultF, TOk, TError> y, IEq<TOk> eqOk, IEq<TError> eqError) =>
            ResultK.Eq(eqOk, eqError).Eqv(x.Fix(), y.Fix());
    }

    public class ResultInvariant<TError> : IInvariant<ResultOkF<TError>>
    {
        public IKind<ResultOkF<TError>, TB> XMap<TA, TB>(
            IKind<ResultOkF<TError>, TA> fa, Func<TA, TB> f, Func<TB, TA> g) =>
            fa.Fix().Map(f);
    }

    public class ResultFunctor<TError> : IFunctor<ResultOkF<TError>>
    {
        public IKind<ResultOkF<TError>, TB> Map<TA, TB>(IKind<ResultOkF<TError>, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f);
    }

    public class ResultApply<TError> : IApply<ResultOkF<TError>>
    {
        public IKind<ResultOkF<TError>, TB> Map<TA, TB>(IKind<ResultOkF<TError>, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f);

        public IKind<ResultOkF<TError>, TB> Ap<TA, TB>(
            IKind<ResultOkF<TError>, Func<TA, TB>> ff, IKind<ResultOkF<TError>, TA> fa) =>
            ff.Fix().FlatMap(fa.Fix().Map);
    }

    public class ResultApplicative<TError> : IApplicative<ResultOkF<TError>>
    {
        public IKind<ResultOkF<TError>, TB> Map<TA, TB>(IKind<ResultOkF<TError>, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f);

        public IKind<ResultOkF<TError>, TB> Ap<TA, TB>(IKind<ResultOkF<TError>, Func<TA, TB>> ff,
            IKind<ResultOkF<TError>, TA> fa) =>
            ff.Fix().FlatMap(fa.Fix().Map);

        public IKind<ResultOkF<TError>, T> Pure<T>(T value) =>
            new Ok<T, TError>(value);
    }

    public class ResultFlatMap<TError> : IFlatMap<ResultOkF<TError>>
    {
        public IKind<ResultOkF<TError>, TB> Map<TA, TB>(IKind<ResultOkF<TError>, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f);

        public IKind<ResultOkF<TError>, TB> FlatMap<TA, TB>(
            IKind<ResultOkF<TError>, TA> fa, Func<TA, IKind<ResultOkF<TError>, TB>> f) =>
            fa.Fix().FlatMap(x => f(x).Fix());
    }

    public class ResultMonad<TError> : IMonad<ResultOkF<TError>>
    {
        public IKind<ResultOkF<TError>, TB> Map<TA, TB>(IKind<ResultOkF<TError>, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f);

        public IKind<ResultOkF<TError>, TB> FlatMap<TA, TB>(
            IKind<ResultOkF<TError>, TA> fa, Func<TA, IKind<ResultOkF<TError>, TB>> f) =>
            fa.Fix().FlatMap(x => f(x).Fix());

        public IKind<ResultOkF<TError>, T> Pure<T>(T value) =>
            new Ok<T, TError>(value);
    }

    public static class ResultK
    {
        public static IEq<Result<TOk, TError>> Eq<TOk, TError>(IEq<TOk> eqOk, IEq<TError> eqError) =>
            new ResultEq<TOk, TError>(eqOk, eqError);

        public static IEqK<ResultOkF<TError>> EqK<TError>(IEq<TError> eqError) => new ResultEqK<TError>(eqError);

        private static readonly IEqK2<ResultF> Eq2Singleton = new ResultEqK2();
        public static IEqK2<ResultF> EqK2() => Eq2Singleton;
    }

    public static class ResultK<TError>
    {
        private static readonly IInvariant<ResultOkF<TError>> InvariantSingleton = new ResultInvariant<TError>();
        public static IInvariant<ResultOkF<TError>> Invariant() => InvariantSingleton;

        private static readonly IFunctor<ResultOkF<TError>> FunctorSingleton = new ResultFunctor<TError>();
        public static IFunctor<ResultOkF<TError>> Functor() => FunctorSingleton;

        private static readonly IApply<ResultOkF<TError>> ApplySingleton = new ResultApply<TError>();
        public static IApply<ResultOkF<TError>> Apply() => ApplySingleton;

        private static readonly IApplicative<ResultOkF<TError>> ApplicativeSingleton = new ResultApplicative<TError>();
        public static IApplicative<ResultOkF<TError>> Applicative() => ApplicativeSingleton;

        private static readonly IFlatMap<ResultOkF<TError>> FlatMapSingleton = new ResultFlatMap<TError>();
        public static IFlatMap<ResultOkF<TError>> FlatMap() => FlatMapSingleton;

        private static readonly IMonad<ResultOkF<TError>> MonadSingleton = new ResultMonad<TError>();
        public static IMonad<ResultOkF<TError>> Monad() => MonadSingleton;
    }
}