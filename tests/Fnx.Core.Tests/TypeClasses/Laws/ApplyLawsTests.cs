using Fnx.Core.TypeClasses;
using Fnx.Laws;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class ApplyLawsTests<TApply, TF, TEqK, TA, TB, TC> : FunctorLawsTests<TApply, TF, TEqK, TA, TB, TC>
        where TApply : struct, IApply<TF>
        where TEqK : struct, IEqK<TF>
    {
        public ApplyLawsTests()
        {
            Add("Apply Composition", args =>
                ApplyLaws<TApply, TF>.ApplyComposition(args.LiftedA, args.LiftedFuncAtoB, args.LiftedFuncBtoC)
                    .Holds<TF, TC, TEqK>());

            Add("Map2 Product Consistency", args =>
                ApplyLaws<TApply, TF>
                    .Map2ProductConsistency(args.LiftedA, args.LiftedB, (a, b) => a.GetHashCode() == b.GetHashCode())
                    .Holds<TF, bool, TEqK>());

            Add("ProductL Consistency", args =>
                ApplyLaws<TApply, TF>.ProductLConsistency(args.LiftedA, args.LiftedB).Holds<TF, TA, TEqK>());

            Add("ProductR Consistency", args =>
                ApplyLaws<TApply, TF>.ProductRConsistency(args.LiftedA, args.LiftedB).Holds<TF, TB, TEqK>());
        }
    }
}