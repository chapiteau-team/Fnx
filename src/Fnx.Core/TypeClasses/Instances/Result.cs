using System;
using Fnx.Core.DataTypes;
using Fnx.Core.Types;

namespace Fnx.Core.TypeClasses.Instances
{
    public struct ResultEq<TOk, TError, TEqOk, TEqError> : IEq<Result<TOk, TError>>
        where TEqOk : struct, IEq<TOk>
        where TEqError : struct, IEq<TError>
    {
        public bool Eqv(Result<TOk, TError> a, Result<TOk, TError> b) =>
            a.IsOk
                ? b.IsOk && default(TEqOk).Eqv(a.Get(), b.Get())
                : b.IsError && default(TEqError).Eqv(a.GetError(), b.GetError());
    }

    public struct ResultEqK<TError, TEqError> : IEqK<ResultOkF<TError>>
        where TEqError : struct, IEq<TError>
    {
        public bool EqK<TOk, TEqOk>(IKind<ResultOkF<TError>, TOk> x, IKind<ResultOkF<TError>, TOk> y)
            where TEqOk : struct, IEq<TOk> =>
            default(ResultEq<TOk, TError, TEqOk, TEqError>).Eqv(x.Fix(), y.Fix());
    }

    public struct ResultEqK2 : IEqK2<ResultF>
    {
        public bool EqK<TOk, TError, TEqOk, TEqError>(IKind2<ResultF, TOk, TError> x, IKind2<ResultF, TOk, TError> y)
            where TEqOk : struct, IEq<TOk>
            where TEqError : struct, IEq<TError> =>
            default(ResultEq<TOk, TError, TEqOk, TEqError>).Eqv(x.Fix(), y.Fix());
    }

    public struct ResultInvariant<TError> : IInvariant<ResultOkF<TError>>
    {
        public IKind<ResultOkF<TError>, TB> XMap<TA, TB>(
            IKind<ResultOkF<TError>, TA> fa, Func<TA, TB> f, Func<TB, TA> g) =>
            fa.Fix().Map(f);
    }

    public struct ResultFunctor<TError> : IFunctor<ResultOkF<TError>>
    {
        public IKind<ResultOkF<TError>, TB> Map<TA, TB>(IKind<ResultOkF<TError>, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f);
    }
}