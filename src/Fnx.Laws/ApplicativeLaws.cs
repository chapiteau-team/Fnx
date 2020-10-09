using System;
using Fnx.Core;
using Fnx.Core.TypeClasses;
using Fnx.Core.Types;

namespace Fnx.Laws
{
    public class ApplicativeLaws<TF>
    {
        private readonly IApplicative<TF> _applicative;

        public ApplicativeLaws(IApplicative<TF> applicative) => _applicative = applicative;

        public IsEq<IKind<TF, TA>> ApplicativeIdentity<TA>(IKind<TF, TA> fa) =>
            IsEq.EqualUnderLaw(
                _applicative.Ap(_applicative.Pure<Func<TA, TA>>(Combinators.I), fa),
                fa);

        public IsEq<IKind<TF, TB>> ApplicativeHomomorphism<TA, TB>(TA a, Func<TA, TB> f) =>
            IsEq.EqualUnderLaw(
                _applicative.Ap(_applicative.Pure(f), _applicative.Pure(a)),
                _applicative.Pure(f(a)));

        public IsEq<IKind<TF, TB>> ApplicativeInterchange<TA, TB>(TA a, IKind<TF, Func<TA, TB>> ff) =>
            IsEq.EqualUnderLaw(
                _applicative.Ap(ff, _applicative.Pure(a)),
                _applicative.Ap(_applicative.Pure<Func<Func<TA, TB>, TB>>(f => f(a)), ff));

        public IsEq<IKind<TF, TB>> ApplicativeMap<TA, TB>(IKind<TF, TA> fa, Func<TA, TB> f) =>
            IsEq.EqualUnderLaw(
                _applicative.Map(fa, f),
                _applicative.Ap(_applicative.Pure(f), fa));

        public IsEq<IKind<TF, TB>> ApProductConsistent<TA, TB>(IKind<TF, TA> fa, IKind<TF, Func<TA, TB>> ff) =>
            IsEq.EqualUnderLaw(
                _applicative.Ap(ff, fa),
                _applicative.Map(_applicative.Product(fa, ff), ((TA a, Func<TA, TB> f) x) => x.f(x.a)));
    }
}