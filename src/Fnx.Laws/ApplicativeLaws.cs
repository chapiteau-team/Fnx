using System;
using Fnx.Core;
using Fnx.Core.TypeClasses;
using Fnx.Core.Types;

namespace Fnx.Laws
{
    public static class ApplicativeLaws<TApplicative, TF>
        where TApplicative : struct, IApplicative<TF>
    {
        public static IsEq<IKind<TF, TA>> ApplicativeIdentity<TA>(IKind<TF, TA> fa)
        {
            var ap = default(TApplicative);
            return IsEq.EqualUnderLaw(
                ap.Ap(ap.Pure<Func<TA, TA>>(Combinators.I), fa),
                fa);
        }

        public static IsEq<IKind<TF, TB>> ApplicativeHomomorphism<TA, TB>(TA a, Func<TA, TB> f)
        {
            var ap = default(TApplicative);
            return IsEq.EqualUnderLaw(
                ap.Ap(ap.Pure(f), ap.Pure(a)),
                ap.Pure(f(a)));
        }

        public static IsEq<IKind<TF, TB>> ApplicativeInterchange<TA, TB>(TA a, IKind<TF, Func<TA, TB>> ff)
        {
            var ap = default(TApplicative);
            return IsEq.EqualUnderLaw(
                ap.Ap(ff, ap.Pure(a)),
                ap.Ap(ap.Pure<Func<Func<TA, TB>, TB>>(f => f(a)), ff));
        }

        public static IsEq<IKind<TF, TB>> ApplicativeMap<TA, TB>(IKind<TF, TA> fa, Func<TA, TB> f)
        {
            var ap = default(TApplicative);
            return IsEq.EqualUnderLaw(
                ap.Map(fa, f),
                ap.Ap(ap.Pure(f), fa));
        }

        public static IsEq<IKind<TF, TB>> ApProductConsistent<TA, TB>(IKind<TF, TA> fa, IKind<TF, Func<TA, TB>> ff)
        {
            var ap = default(TApplicative);
            return IsEq.EqualUnderLaw(
                ap.Ap(ff, fa),
                ap.Map(ap.Product(fa, ff), ((TA a, Func<TA, TB> f) x) => x.f(x.a)));
        }
    }
}