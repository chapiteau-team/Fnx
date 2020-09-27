using System;
using Fnx.Core.Fn;
using Fnx.Core.TypeClasses;
using Fnx.Core.TypeClasses.Instances;
using Fnx.Core.Types;
using static Fnx.Core.Prelude;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public static class InvariantLaws<TInvariant, TF>
        where TInvariant : struct, IInvariant<TF>
    {
        public static bool InvariantIdentity<TEqK, TA, TEq>(IKind<TF, TA> fa)
            where TEqK : struct, IEqK<TF>
            where TEq : struct, IEq<TA>
        {
            var actual = default(TInvariant).XMap(fa, Combinators.I, Combinators.I);
            return default(TEqK).EqK<TA, TEq>(fa, actual);
        }

        public static bool InvariantComposition<TA, TB, TC, TEqK, TEq>(
            IKind<TF, TA> fa, Func<TA, TB> f1, Func<TB, TA> f2, Func<TB, TC> g1, Func<TC, TB> g2)
            where TEqK : struct, IEqK<TF>
            where TEq : struct, IEq<TC>
        {
            var invariant = default(TInvariant);
            var a = invariant.XMap(invariant.XMap(fa, f1, f2), g1, g2);
            var b = invariant.XMap(fa, g1.Compose(f1), f2.Compose(g2));
            return default(TEqK).EqK<TC, TEq>(a, b);
        }
    }

    public class InvariantLawTests<TInvariant, TF, TEqK> : LawTests
        where TInvariant : struct, IInvariant<TF>
        where TEqK : struct, IEqK<TF>
    {
        public InvariantLawTests()
        {
            var invariantComposition =
                Def<IKind<TF, string>, Func<string, int>, Func<int, string>, Func<int, long>, Func<long, int>, bool>(
                    InvariantLaws<TInvariant, TF>.InvariantComposition<string, int, long, TEqK, DefaultEq<long>>);

            var f1 = Def<string, int>(int.Parse);
            var f2 = Def<int, string>(b => b.ToString());
            var g1 = Def<int, long>(x => x);
            var g2 = Def<long, int>(x => (int) x);

            Add("Invariant Identity", InvariantLaws<TInvariant, TF>.InvariantIdentity<TEqK, string, DefaultEq<string>>);
            Add("Invariant Composition", invariantComposition.Partial(__, f1, f2, g1, g2));
        }

        public void Add(string name, Func<IKind<TF, string>, bool> test) =>
            Add(new object[] {new Law<TF, string>(name, test)});
    }
}