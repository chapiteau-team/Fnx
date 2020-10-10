using Fnx.Core.TypeClasses;
using Fnx.Laws;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class MonadLawsTests<TF, TA, TB, TC> : FlatMapLawsTests<TF, TA, TB, TC>
    {
        public MonadLawsTests(IMonad<TF> monad, IEqK<TF> eqK) : base(monad, eqK)
        {
            AddRange(new ApplicativeLawsTests<TF, TA, TB, TC>(monad, eqK));

            var monadLaws = new MonadLaws<TF>(monad);

            Add("Monad Left Identity", args =>
                monadLaws.MonadLeftIdentity(args.A, args.FuncAtoLiftedB).Holds(eqK));

            Add("Monad Right Identity", args =>
                monadLaws.MonadRightIdentity(args.LiftedA).Holds(eqK));

            Add("Map and FlatMap Coherence", args =>
                monadLaws.MapFlatMapCoherence(args.LiftedA, args.FuncAtoB).Holds(eqK));
        }
    }
}