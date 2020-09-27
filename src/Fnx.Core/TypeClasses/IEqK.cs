using Fnx.Core.Types;

namespace Fnx.Core.TypeClasses
{
    public interface IEqK<in TF>
    {
        bool EqK<T, TEq>(IKind<TF, T> x, IKind<TF, T> y) where TEq : struct, IEq<T>;
    }
}