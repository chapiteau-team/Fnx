using System;
using Fnx.Core.TypeClasses;
using Fnx.Core.Types;

namespace Fnx.Laws
{
    public static class ApplyLaws<TApply, TF>
        where TApply : struct, IApply<TF>
    {
        public static IsEq<IKind<TF, TC>> Map2ProductConsistency<TA, TB, TC>(
            IKind<TF, TA> fa, IKind<TF, TB> fb, Func<TA, TB, TC> f)
        {
            var apply = default(TApply);

            return IsEq.EqualUnderLaw(
                apply.Map2(fa, fb, f),
                apply.Map(apply.Product(fa, fb), ((TA a, TB b) ab) => f(ab.a, ab.b))
            );
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