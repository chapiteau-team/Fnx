using System;
using Fnx.Core.Types;

namespace Fnx.Core.TypeClasses
{
    /// <summary>
    /// Invariant.
    /// </summary>
    /// <typeparam name="TF"></typeparam>
    public interface IInvariant<TF>
    {
        /// <summary>
        /// Transform an F&lt;TA&gt; into an F&lt;TB&gt; by providing a transformation from
        /// <typeparamref name="TA"/> to <typeparamref name="TB"/>
        /// and one from <typeparamref name="TB"/> to <typeparamref name="TA"/>.
        /// </summary>
        /// <param name="fa"></param>
        /// <param name="f"></param>
        /// <param name="g"></param>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <returns></returns>
        IKind<TF, TB> XMap<TA, TB>(IKind<TF, TA> fa, Func<TA, TB> f, Func<TB, TA> g);
    }
}