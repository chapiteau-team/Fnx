using System;
using Fnx.Core.TypeClasses;
using Fnx.Core.Types;

namespace Fnx.Laws
{
    public static class FlatMapLaws<TFlatMap, TF>
        where TFlatMap : struct, IFlatMap<TF>
    {
        public static IsEq<IKind<TF, TC>> FlatMapAssociativity<TA, TB, TC>(
            IKind<TF, TA> fa, Func<TA, IKind<TF, TB>> f, Func<TB, IKind<TF, TC>> g)
        {
            var fm = default(TFlatMap);
            return IsEq.EqualUnderLaw(
                fm.FlatMap(fm.FlatMap(fa, f), g),
                fm.FlatMap(fa, a => fm.FlatMap(f(a), g)));
        }

        public static IsEq<IKind<TF, TB>> FlatMapConsistentApply<TA, TB>(IKind<TF, TA> fa, IKind<TF, Func<TA, TB>> ff)
        {
            var fm = default(TFlatMap);
            return IsEq.EqualUnderLaw(
                fm.Ap(ff, fa),
                fm.FlatMap(ff, f => fm.Map(fa, f)));
        }

        public static IsEq<IKind<TF, (TA, TB)>> MProductConsistency<TA, TB>(IKind<TF, TA> fa, Func<TA, IKind<TF, TB>> f)
        {
            var fm = default(TFlatMap);
            return IsEq.EqualUnderLaw(
                fm.MProduct(fa, f),
                fm.FlatMap(fa, a => fm.Map(f(a), b => (a, b))));
        }
    }
}