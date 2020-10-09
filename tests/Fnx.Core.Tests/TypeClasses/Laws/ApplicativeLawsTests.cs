using Fnx.Core.TypeClasses;
using Fnx.Laws;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class ApplicativeLawsTests<TF, TA, TB, TC> : ApplyLawsTests<TF, TA, TB, TC>
    {
        public ApplicativeLawsTests(IApplicative<TF> applicative, IEqK<TF> eqK) : base(applicative, eqK)
        {
            var applicativeLaws = new ApplicativeLaws<TF>(applicative);

            Add("Applicative Identity", args =>
                applicativeLaws.ApplicativeIdentity(args.LiftedA).Holds(eqK));

            Add("Applicative Homomorphism", args =>
                applicativeLaws.ApplicativeHomomorphism(args.A, args.FuncAtoB).Holds(eqK));

            Add("Applicative Interchange", args =>
                applicativeLaws.ApplicativeInterchange(args.A, args.LiftedFuncAtoB).Holds(eqK));

            Add("Applicative Map", args =>
                applicativeLaws.ApplicativeMap(args.LiftedA, args.FuncAtoB).Holds(eqK));

            Add("Ap Product Consistent", args =>
                applicativeLaws.ApProductConsistent(args.LiftedA, args.LiftedFuncAtoB).Holds(eqK));
        }
    }
}