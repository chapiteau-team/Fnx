// ReSharper disable UnusedTypeParameter

namespace Fnx.Core.Types
{
    public interface IKind<out TF, out T>
    {
    }

    public interface IKind2<out TF, out TA, out TB> : IKind<IKind<TF, TA>, TB>
    {
    }
}