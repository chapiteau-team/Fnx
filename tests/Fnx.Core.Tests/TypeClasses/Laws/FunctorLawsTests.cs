using Fnx.Core.TypeClasses;
using Fnx.Core.Types;
using Fnx.Laws;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class FunctorLawsTests<TF, TA, TB, TC> : InvariantLawsTests<TF, TA, TB, TC>
    {
        public FunctorLawsTests(IFunctor<TF> functor, IEqK<TF> eqK) : base(functor, eqK)
        {
            var functorLaws = new FunctorLaws<TF>(functor);

            Add("Covariant Identity", args =>
                functorLaws.CovariantIdentity(args.LiftedA).Holds(eqK));

            Add("CovariantComposition", args =>
                functorLaws.CovariantComposition(args.LiftedA, args.FuncAtoB, args.FuncBtoC).Holds(eqK));

            Add("Lift Identity", args =>
                functorLaws.LiftIdentity(args.LiftedA).Holds(eqK));

            Add("Lift Composition", args =>
                functorLaws.LiftComposition(args.LiftedA, args.FuncAtoB, args.FuncBtoC).Holds(eqK));

            Add("Void Identity", args =>
                functorLaws.VoidIdentity(args.LiftedA).Holds(eqK));

            Add("Void Composition", args =>
                functorLaws.VoidComposition(args.LiftedA).Holds(eqK));

            Add("FProduct Identity", args =>
                functorLaws.FProductIdentity(args.LiftedA, args.B).Holds(eqK));

            Add("FProduct Composition", args =>
                functorLaws
                    .FProductComposition(args.LiftedA, args.FuncAtoB, ((TA a, TB b) ab) => args.FuncBtoC(ab.b))
                    .Holds(eqK));

            Add("FProductLeft Identity", args =>
                functorLaws.FProductLeftIdentity(args.LiftedA, args.B).Holds(eqK));

            Add("FProductLeft Composition", args =>
                functorLaws
                    .FProductLeftComposition(args.LiftedA, args.FuncAtoB, ((TB b, TA a) ba) => args.FuncBtoC(ba.b))
                    .Holds(eqK));

            Add("As Identity", args =>
                functorLaws.AsIdentity(args.LiftedA, args.B).Holds(eqK));

            Add("As Composition", args =>
                functorLaws.AsComposition(args.LiftedA, args.B, args.C).Holds(eqK));

            Add("TupleLeft Identity", args =>
                functorLaws.TupleLeftIdentity(args.LiftedA, args.B).Holds(eqK));

            Add("TupleLeft Composition", args =>
                functorLaws.TupleLeftComposition(args.LiftedA, args.B, args.C).Holds(eqK));

            Add("TupleRight Identity", args =>
                functorLaws.TupleRightIdentity(args.LiftedA, args.B).Holds(eqK));

            Add("TupleRight Composition", args =>
                functorLaws.TupleRightComposition(args.LiftedA, args.B, args.C).Holds(eqK));

            Add("Unzip Identity", args =>
                functorLaws.UnzipIdentity(args.LiftedA, args.FuncAtoB) switch
                {
                    var (a, b) => a.Holds(eqK) && b.Holds(eqK)
                }
            );

            Add("Widen", args => functorLaws.Widen<TA, object>(args.LiftedA));
        }
    }
}