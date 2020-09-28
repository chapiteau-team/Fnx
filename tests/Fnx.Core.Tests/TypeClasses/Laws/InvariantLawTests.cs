using Fnx.Core.TypeClasses;
using Fnx.Core.Types;
using Fnx.Laws;
using static Fnx.Core.Prelude;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class InvariantLawTests<TInvariant, TF, TEqK> : LawTests<TF, string>
        where TInvariant : struct, IInvariant<TF>
        where TEqK : struct, IEqK<TF>
    {
        public InvariantLawTests()
        {
            var invariantIdentity = Def((IKind<TF, string> fa) =>
                InvariantLaws<TInvariant, TF>.InvariantIdentity(fa).Holds<TF, string, TEqK>());

            var f1 = Def<string, int>(int.Parse);
            var f2 = Def<int, string>(b => b.ToString());
            var g1 = Def<int, long>(x => x);
            var g2 = Def<long, int>(x => (int) x);

            var invariantComposition = Def((IKind<TF, string> fa) =>
                InvariantLaws<TInvariant, TF>.InvariantComposition(fa, f1, f2, g1, g2).Holds<TF, long, TEqK>());

            Add("Invariant Identity", invariantIdentity);
            Add("Invariant Composition", invariantComposition);
        }
    }
}