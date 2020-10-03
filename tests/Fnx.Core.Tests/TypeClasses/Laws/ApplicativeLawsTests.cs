using Fnx.Core.TypeClasses;
using Fnx.Laws;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class ApplicativeLawsTests<TApplicative, TF, TEqK, TA, TB, TC>
        : ApplyLawsTests<TApplicative, TF, TEqK, TA, TB, TC>
        where TApplicative : struct, IApplicative<TF>
        where TEqK : struct, IEqK<TF>
    {
        public ApplicativeLawsTests()
        {
            Add("Applicative Identity", args =>
                ApplicativeLaws<TApplicative, TF>.ApplicativeIdentity(args.LiftedA).Holds<TF, TA, TEqK>());

            Add("Applicative Homomorphism", args =>
                ApplicativeLaws<TApplicative, TF>.ApplicativeHomomorphism(args.A, args.FuncAtoB).Holds<TF, TB, TEqK>());

            Add("Applicative Interchange", args =>
                ApplicativeLaws<TApplicative, TF>.ApplicativeInterchange(args.A, args.LiftedFuncAtoB)
                    .Holds<TF, TB, TEqK>());

            Add("Applicative Map", args =>
                ApplicativeLaws<TApplicative, TF>.ApplicativeMap(args.LiftedA, args.FuncAtoB).Holds<TF, TB, TEqK>());

            Add("Ap Product Consistent", args =>
                ApplicativeLaws<TApplicative, TF>.ApProductConsistent(args.LiftedA, args.LiftedFuncAtoB)
                    .Holds<TF, TB, TEqK>());
        }
    }
}