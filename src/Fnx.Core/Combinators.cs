using System;
using Fnx.Core.Fn;

namespace Fnx.Core
{
    public static class Combinators
    {
        /// <summary>
        /// I = λx.x
        /// </summary>
        public static T I<T>(T x) => x;

        /// <summary>
        /// B = λx.λy.λz.x (y z)
        /// </summary>
        public static Func<Func<T1, T2>, Func<T1, TResult>> B<T1, T2, TResult>(Func<T2, TResult> x) =>
            y => z => x.Compose(y)(z);

        /// <summary>
        /// C = λx.λy.λz.x z y
        /// </summary>
        public static Func<T2, Func<T1, TResult>> C<T1, T2, TResult>(Func<T1, Func<T2, TResult>> x) =>
            y => z => x(z)(y);

        /// <summary>
        /// K = λx.λy.x
        /// </summary>
        public static Func<T2, T1> K<T1, T2>(T1 x) => _ => x;

        /// <summary>
        /// W = λx.λy.x y y
        /// </summary>
        public static Func<T, TResult> W<T, TResult>(Func<T, Func<T, TResult>> x) => y => x(y)(y);

        /// <summary>
        /// S = λx.λy.λz.x z (y z)
        /// </summary>
        public static Func<Func<T1, T2>, Func<T1, TResult>> S<T1, T2, TResult>(Func<T1, Func<T2, TResult>> x) =>
            y => z => x(z)(y(z));

        /// <summary>
        /// Y = λf. (λx.f(x x) (λx.f(x x))
        /// </summary>
        public static Func<T1, T2> Y<T1, T2>(Func<Func<T1, T2>, Func<T1, T2>> f) => x => f(Y(f))(x);
    }
}