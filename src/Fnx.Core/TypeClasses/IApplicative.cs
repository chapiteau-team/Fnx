using System.Collections.Generic;
using Fnx.Core.DataTypes;
using Fnx.Core.Types;

namespace Fnx.Core.TypeClasses
{
    /// <summary>
    /// Applicative functor.
    /// </summary>
    /// <typeparam name="TF"></typeparam>
    public interface IApplicative<TF> : IApply<TF>
    {
        /// <summary>
        /// Lifts any value into the Applicative Functor.
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IKind<TF, T> Pure<T>(T value);

        /// <summary>
        /// Apply <paramref name="fa"/> <paramref name="n"/> times.
        /// </summary>
        /// <param name="fa"></param>
        /// <param name="n"></param>
        /// <typeparam name="TA"></typeparam>
        /// <returns></returns>
        IKind<TF, List<TA>> Replicate<TA>(IKind<TF, TA> fa, int n)
        {
            if (n <= 0)
            {
                return Pure(new List<TA>());
            }

            return Map(fa, a =>
            {
                var result = new List<TA>(n);
                for (var i = 0; i < n; i++)
                {
                    result.Add(a);
                }

                return result;
            });
        }
    }
}