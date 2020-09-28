using Fnx.Core.TypeClasses;
using Fnx.Core.Types;
using Fnx.Laws;
using static Fnx.Core.Prelude;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class FunctorLawTests<TFunctor, TF, TEqK> : InvariantLawTests<TFunctor, TF, TEqK>
        where TFunctor : struct, IFunctor<TF>
        where TEqK : struct, IEqK<TF>
    {
        public FunctorLawTests()
        {
            var covariantIdentity = Def((IKind<TF, string> fa) =>
                FunctorLaws<TFunctor, TF>.CovariantIdentity<string>(fa).Holds<TF, string, TEqK>());

            var f = Def<string, int>(int.Parse);
            var g = Def<int, long>(x => x);

            var covariantComposition = Def((IKind<TF, string> fa) =>
                FunctorLaws<TFunctor, TF>.CovariantComposition(fa, f, g).Holds<TF, long, TEqK>());

            var liftIdentity = Def((IKind<TF, string> fa) =>
                FunctorLaws<TFunctor, TF>.LiftIdentity(fa).Holds<TF, string, TEqK>());

            var liftComposition = Def((IKind<TF, string> fa) =>
                FunctorLaws<TFunctor, TF>.LiftComposition(fa, f, g).Holds<TF, long, TEqK>());

            var voidIdentity = Def((IKind<TF, string> fa) =>
                FunctorLaws<TFunctor, TF>.VoidIdentity(fa).Holds<TF, Nothing, TEqK>());

            var voidComposition = Def((IKind<TF, string> fa) =>
                FunctorLaws<TFunctor, TF>.VoidComposition(fa).Holds<TF, Nothing, TEqK>());

            var fProductIdentity = Def((IKind<TF, string> fa) =>
                FunctorLaws<TFunctor, TF>.FProductIdentity(fa, 1).Holds<TF, (string, int), TEqK>());

            var fProductComposition = Def((IKind<TF, string> fa) =>
                FunctorLaws<TFunctor, TF>.FProductComposition(fa, f, ((string a, int b) ab) => g(ab.b))
                    .Holds<TF, ((string, int), long), TEqK>());

            var fProductLeftIdentity = Def((IKind<TF, string> fa) =>
                FunctorLaws<TFunctor, TF>.FProductLeftIdentity(fa, 1).Holds<TF, (int, string), TEqK>());

            var fProductLeftComposition = Def((IKind<TF, string> fa) =>
                FunctorLaws<TFunctor, TF>.FProductLeftComposition(fa, f, ((int b, string a) ba) => g(ba.b))
                    .Holds<TF, (long, (int, string)), TEqK>());

            var asIdentity = Def((IKind<TF, string> fa) =>
                FunctorLaws<TFunctor, TF>.AsIdentity(fa, 1).Holds<TF, int, TEqK>());

            var asComposition = Def((IKind<TF, string> fa) =>
                FunctorLaws<TFunctor, TF>.AsComposition(fa, 1, 2).Holds<TF, int, TEqK>());

            var tupleLeftIdentity = Def((IKind<TF, string> fa) =>
                FunctorLaws<TFunctor, TF>.TupleLeftIdentity(fa, 1).Holds<TF, (int, string), TEqK>());

            var tupleLeftComposition = Def((IKind<TF, string> fa) =>
                FunctorLaws<TFunctor, TF>.TupleLeftComposition(fa, 1, 2L).Holds<TF, (long, (int, string)), TEqK>());

            var tupleRightIdentity = Def((IKind<TF, string> fa) =>
                FunctorLaws<TFunctor, TF>.TupleRightIdentity(fa, 1).Holds<TF, (string, int), TEqK>());

            var tupleRightComposition = Def((IKind<TF, string> fa) =>
                FunctorLaws<TFunctor, TF>.TupleRightComposition(fa, 1, 2L).Holds<TF, ((string, int), long), TEqK>());

            var unzipIdentity = Def((IKind<TF, string> fa) =>
                FunctorLaws<TFunctor, TF>.UnzipIdentity(fa, f) switch
                {
                    var (a, b) => a.Holds<TF, string, TEqK>() && b.Holds<TF, int, TEqK>()
                }
            );

            Add("Covariant Identity", covariantIdentity);
            Add("CovariantComposition", covariantComposition);
            Add("Lift Identity", liftIdentity);
            Add("Lift Composition", liftComposition);
            Add("Void Identity", voidIdentity);
            Add("Void Composition", voidComposition);
            Add("FProduct Identity", fProductIdentity);
            Add("FProduct Composition", fProductComposition);
            Add("FProductLeft Identity", fProductLeftIdentity);
            Add("FProductLeft Composition", fProductLeftComposition);
            Add("As Identity", asIdentity);
            Add("As Composition", asComposition);
            Add("TupleLeft Identity", tupleLeftIdentity);
            Add("TupleLeft Composition", tupleLeftComposition);
            Add("TupleRight Identity", tupleRightIdentity);
            Add("TupleRight Composition", tupleRightComposition);
            Add("Unzip Identity", unzipIdentity);
            Add("Widen", FunctorLaws<TFunctor, TF>.Widen<string, object>);
        }
    }
}