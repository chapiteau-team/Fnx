using Fnx.Core.TypeClasses;
using Fnx.Laws;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class FlatMapLawsTests<TF, TA, TB, TC> : ApplyLawsTests<TF, TA, TB, TC>
    {
        public FlatMapLawsTests(IFlatMap<TF> flatMap, IEqK<TF> eqK) : base(flatMap, eqK)
        {
            var flatMapLaws = new FlatMapLaws<TF>(flatMap);

            Add("FlatMap Associativity", args =>
                flatMapLaws.FlatMapAssociativity(args.LiftedA, args.FuncAtoLiftedB, args.FuncBtoLiftedC).Holds(eqK));

            Add("FlatMap Consistent Apply", args =>
                flatMapLaws.FlatMapConsistentApply(args.LiftedA, args.LiftedFuncAtoB).Holds(eqK));

            Add("MProduct Consistency", args =>
                flatMapLaws.MProductConsistency(args.LiftedA, args.FuncAtoLiftedB).Holds(eqK));
        }
    }
}