using Fnx.Core.TypeClasses;
using Fnx.Laws;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class InvariantLawsTests<TF, TA, TB, TC> : LawTests<TestArgs<TF, TA, TB, TC>>
    {
        public InvariantLawsTests(IInvariant<TF> invariant, IEqK<TF> eqK)
        {
            var invariantLaws = new InvariantLaws<TF>(invariant);

            Add("Invariant Identity", args =>
                invariantLaws.InvariantIdentity(args.LiftedA).Holds(eqK));

            Add("Invariant Composition", args =>
                invariantLaws
                    .InvariantComposition(args.LiftedA, args.FuncAtoB, args.FuncBtoA, args.FuncBtoC, args.FuncCtoB)
                    .Holds(eqK));
        }
    }
}