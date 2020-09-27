using System;
using Fnx.Core.DataTypes;
using Fnx.Core.Types;

namespace Fnx.Core
{
    public static class Prelude
    {
        /// <summary>
        /// Instance of the Nothing class.
        /// Used in Partial Application to o indicate that the parameter is bypassed. 
        /// </summary>
        public static Nothing __ => new Nothing();

        /// <summary>
        /// Instantiates Some representing an existing value of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Some<T> Some<T>(T value) => new Some<T>(value);

        /// <summary>
        /// Instantiates None representing no value.
        /// </summary>
        public static None<Nothing> None => new None<Nothing>();

        /// <summary>
        /// Instantiates Ok with the value of <typeparamref name="TOk"/>
        /// </summary>
        /// <param name="ok"></param>
        /// <typeparam name="TOk"></typeparam>
        /// <returns></returns>
        public static Ok<TOk, Nothing> Ok<TOk>(TOk ok) => new Ok<TOk, Nothing>(ok);

        /// <summary>
        /// Instantiates Result with state Ok with the value of <typeparamref name="TOk"/>
        /// </summary>
        /// <param name="ok"></param>
        /// <typeparam name="TOk"></typeparam>
        /// <typeparam name="TError"></typeparam>
        /// <returns></returns>
        public static Ok<TOk, TError> Ok<TOk, TError>(TOk ok) => new Ok<TOk, TError>(ok);

        /// <summary>
        /// Instantiates Error with the value of <typeparamref name="TError"/>
        /// </summary>
        /// <param name="error"></param>
        /// <typeparam name="TError"></typeparam>
        /// <returns></returns>
        public static Error<Nothing, TError> Error<TError>(TError error) => new Error<Nothing, TError>(error);

        /// <summary>
        /// Instantiates Result with state Error with the value of <typeparamref name="TError"/>
        /// </summary>
        /// <param name="error"></param>
        /// <typeparam name="TOk"></typeparam>
        /// <typeparam name="TError"></typeparam>
        /// <returns></returns>
        public static Error<TOk, TError> Error<TOk, TError>(TError error) => new Error<TOk, TError>(error);

        // @formatter:off
        public static Func<TResult> Def<TResult>(Func<TResult> f) => f;
        public static Func<T1, TResult> Def<T1, TResult>(Func<T1, TResult> f) => f;
        public static Func<T1, T2, TResult> Def<T1, T2, TResult>(Func<T1, T2, TResult> f) => f;
        public static Func<T1, T2, T3, TResult> Def<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> f) => f;
        public static Func<T1, T2, T3, T4, TResult> Def<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> f) => f;
        public static Func<T1, T2, T3, T4, T5, TResult> Def<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> f) => f;
        public static Func<T1, T2, T3, T4, T5, T6, TResult> Def<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> f) => f;
        public static Func<T1, T2, T3, T4, T5, T6, T7, TResult> Def<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> f) => f;
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Def<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> f) => f;
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Def<T1, T2, T3, T4, T5, T6, T7, T8, T9,TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> f) => f;
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Def<T1, T2, T3, T4, T5, T6, T7, T8, T9,T10, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> f) => f;
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> Def<T1, T2, T3, T4, T5, T6, T7, T8,T9, T10, T11, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> f) => f;
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> Def<T1, T2, T3, T4, T5, T6, T7,T8, T9, T10, T11, T12, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> f) =>f;
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> Def<T1, T2, T3, T4, T5, T6,T7, T8, T9, T10, T11, T12, T13, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> f) => f;
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> Def<T1, T2, T3, T4,T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> f) => f;
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> Def<T1, T2, T3,T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> f) => f;
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> Def<T1, T2,T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> f) => f;
        // @formatter:on

        // @formatter:off
        public static Action Def(Action a) => a;
        public static Action<T1> Def<T1>(Action<T1> a) => a;
        public static Action<T1, T2> Def<T1, T2>(Action<T1, T2> a) => a;
        public static Action<T1, T2, T3> Def<T1, T2, T3>(Action<T1, T2, T3> a) => a;
        public static Action<T1, T2, T3, T4> Def<T1, T2, T3, T4>(Action<T1, T2, T3, T4> a) => a;
        public static Action<T1, T2, T3, T4, T5> Def<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> a) => a;
        public static Action<T1, T2, T3, T4, T5, T6> Def<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> a) => a;
        public static Action<T1, T2, T3, T4, T5, T6, T7> Def<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> a) => a;
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Def<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> a) => a;
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Def<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> a) => a;
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Def<T1, T2, T3, T4, T5, T6, T7, T8, T9,T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> a) => a;
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Def<T1, T2, T3, T4, T5, T6, T7, T8,T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> a) => a;
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Def<T1, T2, T3, T4, T5, T6, T7,T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> a) =>a;
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Def<T1, T2, T3, T4, T5, T6,T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> a) => a;
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Def<T1, T2, T3, T4,T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> a) => a;
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Def<T1, T2, T3,T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> a) => a;
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Def<T1, T2,T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> a) => a;
        // @formatter:on
    }
}