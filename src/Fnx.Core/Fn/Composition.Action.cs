using System;

namespace Fnx.Core.Fn
{
    public static partial class Composition
    {
        // @formatter:off
        public static Action Compose<T1>(this Action<T1> f, Func<T1> g) => () => f(g());
        public static Action<T1> Compose<T1, T2>(this Action<T2> f, Func<T1, T2> g) => arg1 => f(g(arg1));
        public static Action<T1, T2> Compose<T1, T2, T3>(this Action<T3> f, Func<T1, T2, T3> g) => (arg1, arg2) => f(g(arg1, arg2));
        public static Action<T1, T2, T3> Compose<T1, T2, T3, T4>(this Action<T4> f, Func<T1, T2, T3, T4> g) => (arg1, arg2, arg3) => f(g(arg1, arg2, arg3));
        public static Action<T1, T2, T3, T4> Compose<T1, T2, T3, T4, T5>(this Action<T5> f, Func<T1, T2, T3, T4, T5> g) => (arg1, arg2, arg3,arg4) => f(g(arg1, arg2, arg3, arg4));
        public static Action<T1, T2, T3, T4, T5> Compose<T1, T2, T3, T4, T5, T6>(this Action<T6> f, Func<T1, T2, T3, T4, T5, T6> g) => (arg1, arg2, arg3, arg4, arg5) => f(g(arg1, arg2, arg3, arg4, arg5));
        public static Action<T1, T2, T3, T4, T5, T6> Compose<T1, T2, T3, T4, T5, T6, T7>(this Action<T7> f, Func<T1, T2, T3, T4, T5, T6, T7> g) => (arg1, arg2, arg3, arg4, arg5, arg6) => f(g(arg1, arg2, arg3, arg4, arg5, arg6));
        public static Action<T1, T2, T3, T4, T5, T6, T7> Compose<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T8> f, Func<T1, T2, T3, T4, T5, T6, T7, T8> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7));
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T9> f, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T10> f, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T11> f, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T12> f, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T13> f, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12));
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T14> f, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T15> f, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14));
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T16> f, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15));
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(this Action<T17> f, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> g) => (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16) => f(g(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16));
        // @formatter:on
    }
}