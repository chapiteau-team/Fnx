using System;
using Fnx.Core.Fn;
using Fnx.Core.TypeClasses;
using Fnx.Core.TypeClasses.Instances;
using Fnx.Core.Types;
using static Fnx.Core.Prelude;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public static class FunctorLaws<TFunctor, TF>
        where TFunctor : struct, IFunctor<TF>
    {
        public static bool CovariantIdentity<TEqK, TA, TEq>(IKind<TF, TA> fa)
            where TEqK : struct, IEqK<TF>
            where TEq : struct, IEq<TA> =>
            default(TEqK).EqK<TA, TEq>(default(TFunctor).Map(fa, Combinators.I), fa);

        public static bool CovariantComposition<TA, TB, TC, TEqK, TEq>(IKind<TF, TA> fa, Func<TA, TB> f, Func<TB, TC> g)
            where TEqK : struct, IEqK<TF>
            where TEq : struct, IEq<TC>
        {
            var functor = default(TFunctor);
            var x = functor.Map(functor.Map(fa, f), g);
            var y = functor.Map(fa, g.Compose(f));

            return default(TEqK).EqK<TC, TEq>(x, y);
        }

        public static bool LiftIdentity<TEqK, TA, TEq>(IKind<TF, TA> fa)
            where TEqK : struct, IEqK<TF>
            where TEq : struct, IEq<TA>
        {
            var f = default(TFunctor).Lift<TA, TA>(Combinators.I);
            return default(TEqK).EqK<TA, TEq>(f(fa), fa);
        }

        public static bool LiftComposition<TA, TB, TC, TEqK, TEq>(IKind<TF, TA> fa, Func<TA, TB> f, Func<TB, TC> g)
            where TEqK : struct, IEqK<TF>
            where TEq : struct, IEq<TC>
        {
            var functor = default(TFunctor);
            var lf = functor.Lift(f);
            var lg = functor.Lift(g);
            var lgf = functor.Lift(g.Compose(f));

            return default(TEqK).EqK<TC, TEq>(lg(lf(fa)), lgf(fa));
        }

        public static bool Widen<TA, TB>(IKind<TF, TA> fa)
            where TA : TB
        {
            var fb = default(TFunctor).Widen<TA, TB>(fa);
            return fb != null;
        }

        public static bool VoidIdentity<TA, TEqK, TEq>(IKind<TF, TA> fa)
            where TEqK : struct, IEqK<TF>
            where TEq : struct, IEq<Nothing>
        {
            var functor = default(TFunctor);
            return default(TEqK).EqK<Nothing, TEq>(functor.Void(fa), functor.Map(fa, _ => new Nothing()));
        }

        public static bool VoidComposition<TA, TEqK, TEq>(IKind<TF, TA> fa)
            where TEqK : struct, IEqK<TF>
            where TEq : struct, IEq<Nothing>
        {
            var functor = default(TFunctor);
            return default(TEqK).EqK<Nothing, TEq>(functor.Void(functor.Void(fa)), functor.Map(fa, _ => new Nothing()));
        }

        public static bool FProductIdentity<TA, TB, TEqK, TEq>(IKind<TF, TA> fa, TB b)
            where TEqK : struct, IEqK<TF>
            where TEq : struct, IEq<(TA, TB)>
        {
            var functor = default(TFunctor);
            return default(TEqK).EqK<(TA, TB), TEq>(functor.FProduct(fa, _ => b), functor.Map(fa, a => (a, b)));
        }

        public static bool FProductComposition<TA, TB, TC, TEqK, TEq>(
            IKind<TF, TA> fa, Func<TA, TB> f, Func<(TA, TB), TC> g)
            where TEqK : struct, IEqK<TF>
            where TEq : struct, IEq<((TA, TB), TC)>
        {
            var functor = default(TFunctor);
            var x = functor.FProduct(functor.FProduct(fa, f), g);
            var y = functor.Map(functor.Map(fa, a => (a, f(a))), ab => (ab, g(ab)));
            return default(TEqK).EqK<((TA, TB), TC), TEq>(x, y);
        }

        public static bool FProductLeftIdentity<TA, TB, TEqK, TEq>(IKind<TF, TA> fa, TB b)
            where TEqK : struct, IEqK<TF>
            where TEq : struct, IEq<(TB, TA)>
        {
            var functor = default(TFunctor);
            return default(TEqK).EqK<(TB, TA), TEq>(functor.FProductLeft(fa, _ => b), functor.Map(fa, a => (b, a)));
        }

        public static bool FProductLeftComposition<TA, TB, TC, TEqK, TEq>(
            IKind<TF, TA> fa, Func<TA, TB> f, Func<(TB, TA), TC> g)
            where TEqK : struct, IEqK<TF>
            where TEq : struct, IEq<(TC, (TB, TA))>
        {
            var functor = default(TFunctor);
            var x = functor.FProductLeft(functor.FProductLeft(fa, f), g);
            var y = functor.Map(functor.Map(fa, a => (f(a), a)), ba => (g(ba), ba));
            return default(TEqK).EqK<(TC, (TB, TA)), TEq>(x, y);
        }

        public static bool AsIdentity<TA, TB, TEqK, TEq>(IKind<TF, TA> fa, TB b)
            where TEqK : struct, IEqK<TF>
            where TEq : struct, IEq<TB>
        {
            var functor = default(TFunctor);
            return default(TEqK).EqK<TB, TEq>(functor.As(fa, b), functor.Map(fa, _ => b));
        }

        public static bool AsComposition<TA, TB, TC, TEqK, TEq>(IKind<TF, TA> fa, TB b, TC c)
            where TEqK : struct, IEqK<TF>
            where TEq : struct, IEq<TC>
        {
            var functor = default(TFunctor);
            var x = functor.As(functor.As(fa, b), c);
            var y = functor.Map(fa, _ => c);
            return default(TEqK).EqK<TC, TEq>(x, y);
        }

        public static bool TupleLeftIdentity<TA, TB, TEqK, TEq>(IKind<TF, TA> fa, TB b)
            where TEqK : struct, IEqK<TF>
            where TEq : struct, IEq<(TB, TA)>
        {
            var functor = default(TFunctor);
            var x = functor.TupleLeft(fa, b);
            var y = functor.Map(fa, a => (b, a));
            return default(TEqK).EqK<(TB, TA), TEq>(x, y);
        }

        public static bool TupleLeftComposition<TA, TB, TC, TEqK, TEq>(IKind<TF, TA> fa, TB b, TC c)
            where TEqK : struct, IEqK<TF>
            where TEq : struct, IEq<(TC, (TB, TA))>
        {
            var functor = default(TFunctor);
            var x = functor.TupleLeft(functor.TupleLeft(fa, b), c);
            var y = functor.Map(fa, a => (c, (b, a)));
            return default(TEqK).EqK<(TC, (TB, TA)), TEq>(x, y);
        }

        public static bool TupleRightIdentity<TA, TB, TEqK, TEq>(IKind<TF, TA> fa, TB b)
            where TEqK : struct, IEqK<TF>
            where TEq : struct, IEq<(TA, TB)>
        {
            var functor = default(TFunctor);
            var x = functor.TupleRight(fa, b);
            var y = functor.Map(fa, a => (a, b));
            return default(TEqK).EqK<(TA, TB), TEq>(x, y);
        }

        public static bool TupleRightComposition<TA, TB, TC, TEqK, TEq>(IKind<TF, TA> fa, TB b, TC c)
            where TEqK : struct, IEqK<TF>
            where TEq : struct, IEq<((TA, TB), TC)>
        {
            var functor = default(TFunctor);
            var x = functor.TupleRight(functor.TupleRight(fa, b), c);
            var y = functor.Map(fa, a => ((a, b), c));
            return default(TEqK).EqK<((TA, TB), TC), TEq>(x, y);
        }

        public static bool UnzipIdentity<TA, TB, TEqK, TEqA, TEqB>(IKind<TF, TA> fa, Func<TA, TB> f)
            where TEqK : struct, IEqK<TF>
            where TEqA : struct, IEq<TA>
            where TEqB : struct, IEq<TB>
        {
            var functor = default(TFunctor);
            var fab = functor.FProduct(fa, f);

            var (x, y) = functor.UnZip(fab);

            var eqk = default(TEqK);
            return eqk.EqK<TA, TEqA>(x, fa) && eqk.EqK<TB, TEqB>(y, functor.Map(fa, f));
        }
    }

    public class FunctorLawTests<TFunctor, TF, TEqK> : InvariantLawTests<TFunctor, TF, TEqK>
        where TFunctor : struct, IFunctor<TF>
        where TEqK : struct, IEqK<TF>
    {
        public FunctorLawTests()
        {
            var covariantComposition =
                Def<IKind<TF, string>, Func<string, int>, Func<int, long>, bool>(FunctorLaws<TFunctor, TF>
                    .CovariantComposition<string, int, long, TEqK, DefaultEq<long>>);

            var liftComposition =
                Def<IKind<TF, string>, Func<string, int>, Func<int, long>, bool>(FunctorLaws<TFunctor, TF>
                    .LiftComposition<string, int, long, TEqK, DefaultEq<long>>);

            var fProductIdentity =
                Def<IKind<TF, string>, int, bool>(FunctorLaws<TFunctor, TF>
                    .FProductIdentity<string, int, TEqK, DefaultEq<(string, int)>>);

            var fProductComposition =
                Def<IKind<TF, string>, Func<string, int>, Func<(string, int), long>, bool>(FunctorLaws<TFunctor, TF>
                    .FProductComposition<string, int, long, TEqK, DefaultEq<((string, int), long)>>);

            var fProductLeftIdentity =
                Def<IKind<TF, string>, int, bool>(FunctorLaws<TFunctor, TF>
                    .FProductLeftIdentity<string, int, TEqK, DefaultEq<(int, string)>>);

            var fProductLeftComposition =
                Def<IKind<TF, string>, Func<string, int>, Func<(int, string), long>, bool>(FunctorLaws<TFunctor, TF>
                    .FProductLeftComposition<string, int, long, TEqK, DefaultEq<(long, (int, string))>>);

            var asIdentity =
                Def<IKind<TF, string>, int, bool>(FunctorLaws<TFunctor, TF>
                    .AsIdentity<string, int, TEqK, DefaultEq<int>>);

            var asComposition =
                Def<IKind<TF, string>, int, long, bool>(FunctorLaws<TFunctor, TF>
                    .AsComposition<string, int, long, TEqK, DefaultEq<long>>);

            var tupleLeftIdentity =
                Def<IKind<TF, string>, int, bool>(FunctorLaws<TFunctor, TF>
                    .TupleLeftIdentity<string, int, TEqK, DefaultEq<(int, string)>>);

            var tupleLeftComposition =
                Def<IKind<TF, string>, int, long, bool>(FunctorLaws<TFunctor, TF>
                    .TupleLeftComposition<string, int, long, TEqK, DefaultEq<(long, (int, string))>>);

            var tupleRightIdentity =
                Def<IKind<TF, string>, int, bool>(FunctorLaws<TFunctor, TF>
                    .TupleRightIdentity<string, int, TEqK, DefaultEq<(string, int)>>);

            var tupleRightComposition =
                Def<IKind<TF, string>, int, long, bool>(FunctorLaws<TFunctor, TF>
                    .TupleRightComposition<string, int, long, TEqK, DefaultEq<((string, int), long)>>);

            var unzipIdentity =
                Def<IKind<TF, string>, Func<string, int>, bool>(FunctorLaws<TFunctor, TF>
                    .UnzipIdentity<string, int, TEqK, DefaultEq<string>, DefaultEq<int>>);

            var f = Def<string, int>(int.Parse);
            var g = Def<int, long>(x => x);

            Add("Covariant Identity", FunctorLaws<TFunctor, TF>.CovariantIdentity<TEqK, string, DefaultEq<string>>);
            Add("CovariantComposition", covariantComposition.Partial(__, f, g));
            Add("Lift Identity", FunctorLaws<TFunctor, TF>.LiftIdentity<TEqK, string, DefaultEq<string>>);
            Add("Lift Composition", liftComposition.Partial(__, f, g));
            Add("Void Identity", FunctorLaws<TFunctor, TF>.VoidIdentity<string, TEqK, DefaultEq<Nothing>>);
            Add("Void Composition", FunctorLaws<TFunctor, TF>.VoidComposition<string, TEqK, DefaultEq<Nothing>>);
            Add("FProduct Identity", fProductIdentity.Partial(__, 1));
            Add("FProduct Composition", fProductComposition.Partial(__, f, ((string a, int b) ab) => g(ab.b)));
            Add("FProductLeft Identity", fProductLeftIdentity.Partial(__, 1));
            Add("FProductLeft Composition", fProductLeftComposition.Partial(__, f, ((int b, string a) ba) => g(ba.b)));
            Add("As Identity", asIdentity.Partial(__, 1));
            Add("As Composition", asComposition.Partial(__, 1, 2));
            Add("TupleLeft Identity", tupleLeftIdentity.Partial(__, 1));
            Add("TupleLeft Composition", tupleLeftComposition.Partial(__, 1, 2));
            Add("TupleRight Identity", tupleRightIdentity.Partial(__, 1));
            Add("TupleRight Composition", tupleRightComposition.Partial(__, 1, 2));
            Add("Unzip Identity", unzipIdentity.Partial(__, f));
            Add("Widen", FunctorLaws<TFunctor, TF>.Widen<string, object>);
        }
    }
}