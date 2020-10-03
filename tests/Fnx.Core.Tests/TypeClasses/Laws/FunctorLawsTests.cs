using Fnx.Core.TypeClasses;
using Fnx.Core.Types;
using Fnx.Laws;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class FunctorLawsTests<TFunctor, TF, TEqK, TA, TB, TC> : InvariantLawsTests<TFunctor, TF, TEqK, TA, TB, TC>
        where TFunctor : struct, IFunctor<TF>
        where TEqK : struct, IEqK<TF>
    {
        public FunctorLawsTests()
        {
            Add("Covariant Identity", args =>
                FunctorLaws<TFunctor, TF>.CovariantIdentity(args.LiftedA).Holds<TF, TA, TEqK>());

            Add("CovariantComposition", args =>
                FunctorLaws<TFunctor, TF>.CovariantComposition(args.LiftedA, args.FuncAtoB, args.FuncBtoC)
                    .Holds<TF, TC, TEqK>());

            Add("Lift Identity", args =>
                FunctorLaws<TFunctor, TF>.LiftIdentity(args.LiftedA).Holds<TF, TA, TEqK>());

            Add("Lift Composition", args =>
                FunctorLaws<TFunctor, TF>.LiftComposition(args.LiftedA, args.FuncAtoB, args.FuncBtoC)
                    .Holds<TF, TC, TEqK>());

            Add("Void Identity", args =>
                FunctorLaws<TFunctor, TF>.VoidIdentity(args.LiftedA).Holds<TF, Nothing, TEqK>());

            Add("Void Composition", args =>
                FunctorLaws<TFunctor, TF>.VoidComposition(args.LiftedA).Holds<TF, Nothing, TEqK>());

            Add("FProduct Identity", args =>
                FunctorLaws<TFunctor, TF>.FProductIdentity(args.LiftedA, args.B).Holds<TF, (TA, TB), TEqK>());

            Add("FProduct Composition", args =>
                FunctorLaws<TFunctor, TF>
                    .FProductComposition(args.LiftedA, args.FuncAtoB, ((TA a, TB b) ab) => args.FuncBtoC(ab.b))
                    .Holds<TF, ((TA, TB), TC), TEqK>());

            Add("FProductLeft Identity", args =>
                FunctorLaws<TFunctor, TF>.FProductLeftIdentity(args.LiftedA, args.B).Holds<TF, (TB, TA), TEqK>());

            Add("FProductLeft Composition", args =>
                FunctorLaws<TFunctor, TF>
                    .FProductLeftComposition(args.LiftedA, args.FuncAtoB, ((TB b, TA a) ba) => args.FuncBtoC(ba.b))
                    .Holds<TF, (TC, (TB, TA)), TEqK>());

            Add("As Identity", args =>
                FunctorLaws<TFunctor, TF>.AsIdentity(args.LiftedA, args.B).Holds<TF, TB, TEqK>());

            Add("As Composition", args =>
                FunctorLaws<TFunctor, TF>.AsComposition(args.LiftedA, args.B, args.C).Holds<TF, TC, TEqK>());

            Add("TupleLeft Identity", args =>
                FunctorLaws<TFunctor, TF>.TupleLeftIdentity(args.LiftedA, args.B).Holds<TF, (TB, TA), TEqK>());

            Add("TupleLeft Composition", args =>
                FunctorLaws<TFunctor, TF>.TupleLeftComposition(args.LiftedA, args.B, args.C)
                    .Holds<TF, (TC, (TB, TA)), TEqK>());

            Add("TupleRight Identity", args =>
                FunctorLaws<TFunctor, TF>.TupleRightIdentity(args.LiftedA, args.B).Holds<TF, (TA, TB), TEqK>());

            Add("TupleRight Composition", args =>
                FunctorLaws<TFunctor, TF>.TupleRightComposition(args.LiftedA, args.B, args.C)
                    .Holds<TF, ((TA, TB), TC), TEqK>());

            Add("Unzip Identity", args =>
                FunctorLaws<TFunctor, TF>.UnzipIdentity(args.LiftedA, args.FuncAtoB) switch
                {
                    var (a, b) => a.Holds<TF, TA, TEqK>() && b.Holds<TF, TB, TEqK>()
                }
            );

            Add("Widen", args => FunctorLaws<TFunctor, TF>.Widen<TA, object>(args.LiftedA));
        }
    }
}