using System;

namespace Fnx.Core.Fn
{
    public delegate void ActionRef<T>(ref T obj);

    public static class ApplyIdiom
    {
        /// <summary>
        /// Executes the specified action with its caller as an argument and returns the caller.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="a"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Apply<T>(this T self, Action<T> a)
        {
            a(self);
            return self;
        }

        /// <summary>
        /// Executes the specified action with a reference to its caller as an argument and returns the caller.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="a"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Apply<T>(this T self, ActionRef<T> a)
        {
            a(ref self);
            return self;
        }

        /// <summary>
        /// Evaluates the specified function with its caller as an argument and returns the result.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="f"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static TResult Apply<T, TResult>(this T self, Func<T, TResult> f) =>
            f(self);
    }
}