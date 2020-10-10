using System;
using Fnx.Core.TypeClasses;
using Fnx.Core.Types;

namespace Fnx.Laws
{
    public class MonadLaws<TF>
    {
        private readonly IMonad<TF> _monad;

        public MonadLaws(IMonad<TF> monad) => _monad = monad;

        public IsEq<IKind<TF, TB>> MonadLeftIdentity<TA, TB>(TA a, Func<TA, IKind<TF, TB>> f) =>
            IsEq.EqualUnderLaw(_monad.FlatMap(_monad.Pure(a), f), f(a));

        public IsEq<IKind<TF, TA>> MonadRightIdentity<TA>(IKind<TF, TA> fa) =>
            IsEq.EqualUnderLaw(_monad.FlatMap(fa, _monad.Pure), fa);

        public IsEq<IKind<TF, TB>> MapFlatMapCoherence<TA, TB>(IKind<TF, TA> fa, Func<TA, TB> f) =>
            IsEq.EqualUnderLaw(
                _monad.FlatMap(fa, a => _monad.Pure(f(a))),
                _monad.Map(fa, f));
    }
}