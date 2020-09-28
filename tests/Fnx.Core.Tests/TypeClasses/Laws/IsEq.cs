using Fnx.Core.TypeClasses;
using Fnx.Core.TypeClasses.Instances;
using Fnx.Core.Types;
using Fnx.Laws;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public static class IsEq
    {
        public static bool Holds<TF, T, TEqK>(this IsEq<IKind<TF, T>> self)
            where TEqK : struct, IEqK<TF> =>
            self switch
            {
                var (x, y) => default(TEqK).EqK<T, DefaultEq<T>>(x, y)
            };
    }
}