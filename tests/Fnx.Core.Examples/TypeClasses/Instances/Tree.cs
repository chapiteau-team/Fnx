using System;
using Fnx.Core.TypeClasses;
using Fnx.Core.Types;

namespace Fnx.Core.Examples.TypeClasses.Instances
{
    public class TreeFunctor : IFunctor<TreeF>
    {
        public IKind<TreeF, TB> Map<TA, TB>(IKind<TreeF, TA> fa, Func<TA, TB> f) =>
            fa.Fix() switch
            {
                Branch<TA> (var left, var right) =>
                    new Branch<TB>(Map(left, f).Fix(), Map(right, f).Fix()),
                Leaf<TA> (var value) =>
                    new Leaf<TB>(f(value))
            };
    }

    public static class TreeK
    {
        private static readonly IFunctor<TreeF> FunctorSingleton = new TreeFunctor();

        public static IFunctor<TreeF> Functor() => FunctorSingleton;
    }
}