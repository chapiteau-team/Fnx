using System;
using Fnx.Core;
using Fnx.Core.Fn;
using Fnx.Core.TypeClasses;
using Fnx.Core.Types;

namespace Fnx.Laws
{
    public static class FunctorLaws<TFunctor, TF>
        where TFunctor : struct, IFunctor<TF>
    {
        public static IsEq<IKind<TF, TA>> CovariantIdentity<TA>(IKind<TF, TA> fa) =>
            IsEq.EqualUnderLaw(fa, default(TFunctor).Map(fa, Combinators.I));

        public static IsEq<IKind<TF, TC>> CovariantComposition<TA, TB, TC>(
            IKind<TF, TA> fa, Func<TA, TB> f, Func<TB, TC> g)
        {
            var functor = default(TFunctor);
            var x = functor.Map(functor.Map(fa, f), g);
            var y = functor.Map(fa, g.Compose(f));

            return IsEq.EqualUnderLaw(x, y);
        }

        public static IsEq<IKind<TF, TA>> LiftIdentity<TA>(IKind<TF, TA> fa)
        {
            var f = default(TFunctor).Lift<TA, TA>(Combinators.I);
            return IsEq.EqualUnderLaw(f(fa), fa);
        }

        public static IsEq<IKind<TF, TC>> LiftComposition<TA, TB, TC>(IKind<TF, TA> fa, Func<TA, TB> f, Func<TB, TC> g)
        {
            var functor = default(TFunctor);
            var lf = functor.Lift(f);
            var lg = functor.Lift(g);
            var lgf = functor.Lift(g.Compose(f));

            return IsEq.EqualUnderLaw(lg(lf(fa)), lgf(fa));
        }

        public static IsEq<IKind<TF, Nothing>> VoidIdentity<TA>(IKind<TF, TA> fa)
        {
            var functor = default(TFunctor);
            return IsEq.EqualUnderLaw(functor.Void(fa), functor.Map(fa, _ => new Nothing()));
        }

        public static IsEq<IKind<TF, Nothing>> VoidComposition<TA>(IKind<TF, TA> fa)
        {
            var functor = default(TFunctor);
            return IsEq.EqualUnderLaw(functor.Void(functor.Void(fa)), functor.Map(fa, _ => new Nothing()));
        }

        public static IsEq<IKind<TF, (TA, TB)>> FProductIdentity<TA, TB>(IKind<TF, TA> fa, TB b)
        {
            var functor = default(TFunctor);
            return IsEq.EqualUnderLaw(functor.FProduct(fa, _ => b), functor.Map(fa, a => (a, b)));
        }

        public static IsEq<IKind<TF, ((TA, TB), TC)>> FProductComposition<TA, TB, TC>(
            IKind<TF, TA> fa, Func<TA, TB> f, Func<(TA, TB), TC> g)
        {
            var functor = default(TFunctor);
            var x = functor.FProduct(functor.FProduct(fa, f), g);
            var y = functor.Map(functor.Map(fa, a => (a, f(a))), ab => (ab, g(ab)));
            return IsEq.EqualUnderLaw(x, y);
        }

        public static IsEq<IKind<TF, (TB, TA)>> FProductLeftIdentity<TA, TB>(IKind<TF, TA> fa, TB b)
        {
            var functor = default(TFunctor);
            return IsEq.EqualUnderLaw(functor.FProductLeft(fa, _ => b), functor.Map(fa, a => (b, a)));
        }

        public static IsEq<IKind<TF, (TC, (TB, TA))>> FProductLeftComposition<TA, TB, TC>(
            IKind<TF, TA> fa, Func<TA, TB> f, Func<(TB, TA), TC> g)
        {
            var functor = default(TFunctor);
            var x = functor.FProductLeft(functor.FProductLeft(fa, f), g);
            var y = functor.Map(functor.Map(fa, a => (f(a), a)), ba => (g(ba), ba));
            return IsEq.EqualUnderLaw(x, y);
        }

        public static IsEq<IKind<TF, TB>> AsIdentity<TA, TB>(IKind<TF, TA> fa, TB b)
        {
            var functor = default(TFunctor);
            return IsEq.EqualUnderLaw(functor.As(fa, b), functor.Map(fa, _ => b));
        }

        public static IsEq<IKind<TF, TC>> AsComposition<TA, TB, TC>(IKind<TF, TA> fa, TB b, TC c)
        {
            var functor = default(TFunctor);
            var x = functor.As(functor.As(fa, b), c);
            var y = functor.Map(fa, _ => c);
            return IsEq.EqualUnderLaw(x, y);
        }

        public static IsEq<IKind<TF, (TB, TA)>> TupleLeftIdentity<TA, TB>(IKind<TF, TA> fa, TB b)
        {
            var functor = default(TFunctor);
            var x = functor.TupleLeft(fa, b);
            var y = functor.Map(fa, a => (b, a));
            return IsEq.EqualUnderLaw(x, y);
        }

        public static IsEq<IKind<TF, (TC, (TB, TA))>> TupleLeftComposition<TA, TB, TC>(IKind<TF, TA> fa, TB b, TC c)
        {
            var functor = default(TFunctor);
            var x = functor.TupleLeft(functor.TupleLeft(fa, b), c);
            var y = functor.Map(fa, a => (c, (b, a)));
            return IsEq.EqualUnderLaw(x, y);
        }

        public static IsEq<IKind<TF, (TA, TB)>> TupleRightIdentity<TA, TB>(IKind<TF, TA> fa, TB b)
        {
            var functor = default(TFunctor);
            var x = functor.TupleRight(fa, b);
            var y = functor.Map(fa, a => (a, b));
            return IsEq.EqualUnderLaw(x, y);
        }

        public static IsEq<IKind<TF, ((TA, TB), TC)>> TupleRightComposition<TA, TB, TC>(IKind<TF, TA> fa, TB b, TC c)
        {
            var functor = default(TFunctor);
            var x = functor.TupleRight(functor.TupleRight(fa, b), c);
            var y = functor.Map(fa, a => ((a, b), c));
            return IsEq.EqualUnderLaw(x, y);
        }

        public static (IsEq<IKind<TF, TA>>, IsEq<IKind<TF, TB>>) UnzipIdentity<TA, TB>(IKind<TF, TA> fa, Func<TA, TB> f)
        {
            var functor = default(TFunctor);
            var fab = functor.FProduct(fa, f);

            var (x, y) = functor.UnZip(fab);
            return (IsEq.EqualUnderLaw(x, fa), IsEq.EqualUnderLaw(y, functor.Map(fa, f)));
        }

        public static bool Widen<TA, TB>(IKind<TF, TA> fa) where TA : TB
        {
            var fb = default(TFunctor).Widen<TA, TB>(fa);
            return fb is object;
        }
    }
}