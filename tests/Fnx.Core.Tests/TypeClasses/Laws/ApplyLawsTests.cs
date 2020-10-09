using Fnx.Core.TypeClasses;
using Fnx.Laws;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class ApplyLawsTests<TF, TA, TB, TC> : FunctorLawsTests<TF, TA, TB, TC>
    {
        public ApplyLawsTests(IApply<TF> apply, IEqK<TF> eqK) : base(apply, eqK)
        {
            var applyLaws = new ApplyLaws<TF>(apply);

            Add("Apply Composition", args =>
                applyLaws.ApplyComposition(args.LiftedA, args.LiftedFuncAtoB, args.LiftedFuncBtoC).Holds(eqK));

            Add("Map2 Product Consistency", args =>
                applyLaws
                    .Map2ProductConsistency(args.LiftedA, args.LiftedB, (a, b) => a.GetHashCode() == b.GetHashCode())
                    .Holds(eqK));

            Add("ProductL Consistency", args =>
                applyLaws.ProductLConsistency(args.LiftedA, args.LiftedB).Holds(eqK));

            Add("ProductR Consistency", args =>
                applyLaws.ProductRConsistency(args.LiftedA, args.LiftedB).Holds(eqK));
        }
    }
}