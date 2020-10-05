using Fnx.Core.TypeClasses;
using Fnx.Laws;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class FlatMapLawsTests<TFlatMap, TF, TEqK, TA, TB, TC> : ApplyLawsTests<TFlatMap, TF, TEqK, TA, TB, TC>
        where TFlatMap : struct, IFlatMap<TF>
        where TEqK : struct, IEqK<TF>
    {
        public FlatMapLawsTests()
        {
            Add("FlatMap Associativity", args =>
                FlatMapLaws<TFlatMap, TF>.FlatMapAssociativity(args.LiftedA, args.FuncAtoLiftedB, args.FuncBtoLiftedC)
                    .Holds<TF, TC, TEqK>());

            Add("FlatMap Consistent Apply", args =>
                FlatMapLaws<TFlatMap, TF>.FlatMapConsistentApply(args.LiftedA, args.LiftedFuncAtoB)
                    .Holds<TF, TB, TEqK>());

            Add("MProduct Consistency", args =>
                FlatMapLaws<TFlatMap, TF>.MProductConsistency(args.LiftedA, args.FuncAtoLiftedB)
                    .Holds<TF, (TA, TB), TEqK>());
        }
    }
}