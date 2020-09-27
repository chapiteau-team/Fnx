using System;

namespace Fnx.Core.Fn
{
    public static partial class Composition
    {
        // @formatter:off
        public static Func<TResult> Compose<T1, TResult>(this Func<T1, TResult> f, Func<T1> g) => () => f(g());
        /// <summary>
        /// (g ∘ f )(x) = g(f(x))
        /// </summary>
        public static Func<T1, TResult> Compose<T1, T2, TResult>(this Func<T2, TResult> f, Func<T1, T2> g) => arg1 => f(g(arg1));
        public static Func<T1, T2, TResult> Compose<T1, T2, T3, TResult>(this Func<T3, TResult> f, Func<T1, T2, T3> g) => (arg1, arg2) => f(g(arg1, arg2));
        public static Func<T1, T2, T3, TResult> Compose<T1, T2, T3, T4, TResult>(this Func<T4, TResult> f, Func<T1, T2, T3, T4> g) => (arg1, arg2, arg3) => f(g(arg1, arg2, arg3));
        public static Func<T1, T2, T3, T4, TResult> Compose<T1, T2, T3, T4, T5, TResult>(this Func<T5, TResult> f, Func<T1, T2, T3, T4, T5> g) => (arg1, arg2, arg3,arg4) => f(g(arg1, arg2, arg3, arg4));
        public static Func<T1, T2, T3, T4, T5, TResult> Compose<T1, T2, T3, T4, T5, T6, TResult>(this Func<T6, TResult> f, Func<T1, T2, T3, T4, T5, T6> g) => (arg1, arg2, arg3, arg4, arg5) => f(g(arg1, arg2, arg3, arg4, arg5));
        public static Func<T1, T2, T3, T4, T5, T6, TResult> Compose<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T7, TResult> f, Func<T1, T2, T3, T4, T5, T6, T7> g) => (arg1, arg2, arg3, arg4, arg5, arg6) => f(g(arg1, arg2, arg3, arg4, arg5, arg6));
        public static Func<T1, T2, T3, T4, T5, T6, T7, TResult> Compose<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T8, TResult> f, Func<T1, T2, T3, T4, T5, T6, T7, T8> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7));
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Func<T9, TResult> f, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this Func<T10, TResult> f, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(this Func<T11, TResult> f, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(this Func<T12, TResult> f, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(this Func<T13, TResult> f, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12));
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(this Func<T14, TResult> f, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(this Func<T15, TResult> f, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14));
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(this Func<T16, TResult> f, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15));
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TResult>(this Func<T17, TResult> f, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16));
        // @formatter:on
    }
}