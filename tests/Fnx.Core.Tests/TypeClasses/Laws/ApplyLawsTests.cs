using Fnx.Core.TypeClasses;
using Fnx.Core.Types;
using Fnx.Laws;
using static Fnx.Core.Prelude;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class ApplyLawsTests<TApply, TF, TEqK> : FunctorLawsTests<TApply, TF, TEqK>
        where TApply : struct, IApply<TF>
        where TEqK : struct, IEqK<TF>
    {
        public ApplyLawsTests()
        {
            var apply = default(TApply);
            var f = Def<string, int>(int.Parse);
            var g = Def<int, long>(x => x);

            var map2ProductConsistency = Def((IKind<TF, string> fa) =>
                ApplyLaws<TApply, TF>.Map2ProductConsistency(fa, apply.Map(fa, f), (a, b) => f(a) == b)
                    .Holds<TF, bool, TEqK>());

            var productLConsistency = Def((IKind<TF, string> fa) =>
                ApplyLaws<TApply, TF>.ProductLConsistency(fa, apply.Map(fa, f)).Holds<TF, string, TEqK>());

            var productRConsistency = Def((IKind<TF, string> fa) =>
                ApplyLaws<TApply, TF>.ProductRConsistency(fa, apply.Map(fa, f)).Holds<TF, int, TEqK>());

            Add("Map2 Product Consistency", map2ProductConsistency);
            Add("ProductL Consistency", productLConsistency);
            Add("ProductR Consistency", productRConsistency);
        }
    }
}