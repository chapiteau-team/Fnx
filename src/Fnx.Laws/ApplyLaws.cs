using System;
using Fnx.Core.Fn;
using Fnx.Core.TypeClasses;
using Fnx.Core.Types;
using static Fnx.Core.Prelude;

namespace Fnx.Laws
{
    public static class ApplyLaws<TApply, TF>
        where TApply : struct, IApply<TF>
    {
        public static IsEq<IKind<TF, TC>> ApplyComposition<TA, TB, TC>(
            IKind<TF, TA> fa, IKind<TF, Func<TA, TB>> fab, IKind<TF, Func<TB, TC>> fbc)
        {
            var apply = default(TApply);
            var compose = Def<Func<TB, TC>, Func<Func<TA, TB>, Func<TA, TC>>>(bc => bc.Compose);

            return IsEq.EqualUnderLaw(
                apply.Ap(fbc, apply.Ap(fab, fa)),
                apply.Ap(apply.Ap(apply.Map(fbc, compose), fab), fa));
        }

        public static IsEq<IKind<TF, TC>> Map2ProductConsistency<TA, TB, TC>(
            IKind<TF, TA> fa, IKind<TF, TB> fb, Func<TA, TB, TC> f)
        {
            var apply = default(TApply);

            return IsEq.EqualUnderLaw(
                apply.Map2(fa, fb, f),
                apply.Map(apply.Product(fa, fb), ((TA a, TB b) ab) => f(ab.a, ab.b)));
        }

        public static IsEq<IKind<TF, TA>> ProductLConsistency<TA, TB>(IKind<TF, TA> fa, IKind<TF, TB> fb)
        {
            var apply = default(TApply);
            return IsEq.EqualUnderLaw(apply.ProductL(fa, fb), apply.Map2(fa, fb, (a, _) => a));
        }

        public static IsEq<IKind<TF, TB>> ProductRConsistency<TA, TB>(IKind<TF, TA> fa, IKind<TF, TB> fb)
        {
            var apply = default(TApply);
            return IsEq.EqualUnderLaw(apply.ProductR(fa, fb), apply.Map2(fa, fb, (_, b) => b));
        }
    }
}