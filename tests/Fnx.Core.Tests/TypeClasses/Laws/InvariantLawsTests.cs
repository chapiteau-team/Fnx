using Fnx.Core.TypeClasses;
using Fnx.Laws;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class InvariantLawsTests<TInvariant, TF, TEqK, TA, TB, TC> : LawTests<TestArgs<TF, TA, TB, TC>>
        where TInvariant : struct, IInvariant<TF>
        where TEqK : struct, IEqK<TF>
    {
        public InvariantLawsTests()
        {
            Add("Invariant Identity", args =>
                InvariantLaws<TInvariant, TF>.InvariantIdentity(args.LiftedA)
                    .Holds<TF, TA, TEqK>());
            
            Add("Invariant Composition", args =>
                InvariantLaws<TInvariant, TF>.InvariantComposition(args.LiftedA, args.FuncAtoB, args.FuncBtoA,
                        args.FuncBtoC, args.FuncCtoB)
                    .Holds<TF, TC, TEqK>());
        }
    }
}