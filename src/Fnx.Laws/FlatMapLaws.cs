using System;
using Fnx.Core.TypeClasses;
using Fnx.Core.Types;

namespace Fnx.Laws
{
    public class FlatMapLaws<TF>
    {
        private readonly IFlatMap<TF> _flatMap;

        public FlatMapLaws(IFlatMap<TF> flatMap) => _flatMap = flatMap;

        public IsEq<IKind<TF, TC>> FlatMapAssociativity<TA, TB, TC>(
            IKind<TF, TA> fa, Func<TA, IKind<TF, TB>> f, Func<TB, IKind<TF, TC>> g) =>
            IsEq.EqualUnderLaw(
                _flatMap.FlatMap(_flatMap.FlatMap(fa, f), g),
                _flatMap.FlatMap(fa, a => _flatMap.FlatMap(f(a), g)));

        public IsEq<IKind<TF, TB>> FlatMapConsistentApply<TA, TB>(IKind<TF, TA> fa, IKind<TF, Func<TA, TB>> ff) =>
            IsEq.EqualUnderLaw(
                _flatMap.Ap(ff, fa),
                _flatMap.FlatMap(ff, f => _flatMap.Map(fa, f)));

        public IsEq<IKind<TF, (TA, TB)>> MProductConsistency<TA, TB>(IKind<TF, TA> fa, Func<TA, IKind<TF, TB>> f) =>
            IsEq.EqualUnderLaw(
                _flatMap.MProduct(fa, f),
                _flatMap.FlatMap(fa, a => _flatMap.Map(f(a), b => (a, b))));
    }
}