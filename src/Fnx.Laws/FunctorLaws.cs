using System;
using Fnx.Core;
using Fnx.Core.Fn;
using Fnx.Core.TypeClasses;
using Fnx.Core.Types;

namespace Fnx.Laws
{
    public class FunctorLaws<TF>
    {
        private readonly IFunctor<TF> _functor;

        public FunctorLaws(IFunctor<TF> functor) => _functor = functor;

        public IsEq<IKind<TF, TA>> CovariantIdentity<TA>(IKind<TF, TA> fa) =>
            IsEq.EqualUnderLaw(fa, _functor.Map(fa, Combinators.I));

        public IsEq<IKind<TF, TC>> CovariantComposition<TA, TB, TC>(
            IKind<TF, TA> fa, Func<TA, TB> f, Func<TB, TC> g)
        {
            var x = _functor.Map(_functor.Map(fa, f), g);
            var y = _functor.Map(fa, g.Compose(f));

            return IsEq.EqualUnderLaw(x, y);
        }

        public IsEq<IKind<TF, TA>> LiftIdentity<TA>(IKind<TF, TA> fa)
        {
            var f = _functor.Lift<TA, TA>(Combinators.I);
            return IsEq.EqualUnderLaw(f(fa), fa);
        }

        public IsEq<IKind<TF, TC>> LiftComposition<TA, TB, TC>(IKind<TF, TA> fa, Func<TA, TB> f, Func<TB, TC> g)
        {
            var lf = _functor.Lift(f);
            var lg = _functor.Lift(g);
            var lgf = _functor.Lift(g.Compose(f));

            return IsEq.EqualUnderLaw(lg(lf(fa)), lgf(fa));
        }

        public IsEq<IKind<TF, Nothing>> VoidIdentity<TA>(IKind<TF, TA> fa) =>
            IsEq.EqualUnderLaw(_functor.Void(fa), _functor.Map(fa, _ => new Nothing()));

        public IsEq<IKind<TF, Nothing>> VoidComposition<TA>(IKind<TF, TA> fa) =>
            IsEq.EqualUnderLaw(_functor.Void(_functor.Void(fa)), _functor.Map(fa, _ => new Nothing()));

        public IsEq<IKind<TF, (TA, TB)>> FProductIdentity<TA, TB>(IKind<TF, TA> fa, TB b) =>
            IsEq.EqualUnderLaw(_functor.FProduct(fa, _ => b), _functor.Map(fa, a => (a, b)));

        public IsEq<IKind<TF, ((TA, TB), TC)>> FProductComposition<TA, TB, TC>(
            IKind<TF, TA> fa, Func<TA, TB> f, Func<(TA, TB), TC> g)
        {
            var x = _functor.FProduct(_functor.FProduct(fa, f), g);
            var y = _functor.Map(_functor.Map(fa, a => (a, f(a))), ab => (ab, g(ab)));
            return IsEq.EqualUnderLaw(x, y);
        }

        public IsEq<IKind<TF, (TB, TA)>> FProductLeftIdentity<TA, TB>(IKind<TF, TA> fa, TB b) =>
            IsEq.EqualUnderLaw(_functor.FProductLeft(fa, _ => b), _functor.Map(fa, a => (b, a)));

        public IsEq<IKind<TF, (TC, (TB, TA))>> FProductLeftComposition<TA, TB, TC>(
            IKind<TF, TA> fa, Func<TA, TB> f, Func<(TB, TA), TC> g)
        {
            var x = _functor.FProductLeft(_functor.FProductLeft(fa, f), g);
            var y = _functor.Map(_functor.Map(fa, a => (f(a), a)), ba => (g(ba), ba));
            return IsEq.EqualUnderLaw(x, y);
        }

        public IsEq<IKind<TF, TB>> AsIdentity<TA, TB>(IKind<TF, TA> fa, TB b) =>
            IsEq.EqualUnderLaw(_functor.As(fa, b), _functor.Map(fa, _ => b));

        public IsEq<IKind<TF, TC>> AsComposition<TA, TB, TC>(IKind<TF, TA> fa, TB b, TC c)
        {
            var x = _functor.As(_functor.As(fa, b), c);
            var y = _functor.Map(fa, _ => c);
            return IsEq.EqualUnderLaw(x, y);
        }

        public IsEq<IKind<TF, (TB, TA)>> TupleLeftIdentity<TA, TB>(IKind<TF, TA> fa, TB b)
        {
            var x = _functor.TupleLeft(fa, b);
            var y = _functor.Map(fa, a => (b, a));
            return IsEq.EqualUnderLaw(x, y);
        }

        public IsEq<IKind<TF, (TC, (TB, TA))>> TupleLeftComposition<TA, TB, TC>(IKind<TF, TA> fa, TB b, TC c)
        {
            var x = _functor.TupleLeft(_functor.TupleLeft(fa, b), c);
            var y = _functor.Map(fa, a => (c, (b, a)));
            return IsEq.EqualUnderLaw(x, y);
        }

        public IsEq<IKind<TF, (TA, TB)>> TupleRightIdentity<TA, TB>(IKind<TF, TA> fa, TB b)
        {
            var x = _functor.TupleRight(fa, b);
            var y = _functor.Map(fa, a => (a, b));
            return IsEq.EqualUnderLaw(x, y);
        }

        public IsEq<IKind<TF, ((TA, TB), TC)>> TupleRightComposition<TA, TB, TC>(IKind<TF, TA> fa, TB b, TC c)
        {
            var x = _functor.TupleRight(_functor.TupleRight(fa, b), c);
            var y = _functor.Map(fa, a => ((a, b), c));
            return IsEq.EqualUnderLaw(x, y);
        }

        public (IsEq<IKind<TF, TA>>, IsEq<IKind<TF, TB>>) UnzipIdentity<TA, TB>(IKind<TF, TA> fa, Func<TA, TB> f)
        {
            var fab = _functor.FProduct(fa, f);

            var (x, y) = _functor.UnZip(fab);
            return (IsEq.EqualUnderLaw(x, fa), IsEq.EqualUnderLaw(y, _functor.Map(fa, f)));
        }

        public bool Widen<TA, TB>(IKind<TF, TA> fa) where TA : TB =>
            _functor.Widen<TA, TB>(fa) is object;
    }
}