using Fnx.Core.TypeClasses;
using Fnx.Core.TypeClasses.Instances;
using Fnx.Core.Types;
using Fnx.Laws;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public static class IsEq
    {
        public static bool Holds<TF, T>(this IsEq<IKind<TF, T>> self, IEqK<TF> eqK) =>
            self switch
            {
                var (x, y) => eqK.EqK(x, y, Default<T>.Eq())
            };
    }
}