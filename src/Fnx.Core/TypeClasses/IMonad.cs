namespace Fnx.Core.TypeClasses
{
    /// <summary>
    /// Monad. Allows composition of dependent effectful functions.
    /// </summary>
    /// <typeparam name="TF"></typeparam>
    public interface IMonad<TF> : IFlatMap<TF>, IApplicative<TF>
    {
    }
}