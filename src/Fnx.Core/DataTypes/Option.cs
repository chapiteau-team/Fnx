using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Fnx.Core.DataTypes.Interfaces;
using Fnx.Core.Exceptions;
using Fnx.Core.Types;

namespace Fnx.Core.DataTypes
{
    public readonly struct OptionF
    {
    }

    /// <summary>
    /// Represents optional values. Instances of Option are either Some or None.
    /// The most idiomatic way to use an Option instance is to treat it as a monad and use Map(), FlatMap(), Filter().
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public abstract class Option<T> : IEquatable<Option<T>>, IKind<OptionF, T>, IGettable<T>, IToResult<T>
    {
        private protected Option()
        {
        }

        /// <summary>
        /// Returns true if the option is Some, false otherwise.
        /// </summary>
        public abstract bool IsSome { get; }

        /// <summary>
        /// Returns true if the option is None, false otherwise.
        /// </summary>
        public bool IsNone => !IsSome;

        /// <summary>
        /// Returns the option's value.
        /// </summary>
        /// <returns></returns>
        public abstract T Get();

        /// <summary>
        /// Returns the option's value if the option is Some, otherwise returns <paramref name="or"/>.
        /// </summary>
        /// <param name="or"></param>
        /// <returns></returns>
        [return: MaybeNull]
        public abstract T GetOrElse([AllowNull] T or);

        /// <summary>
        /// Returns the option's value if the option is Some, otherwise returns the result of evaluating <paramref name="or"/>.
        /// </summary>
        /// <param name="or"></param>
        /// <returns></returns>
        public abstract T GetOrElse(Func<T> or);

        /// <summary>
        /// Returns the option's value if the option is Some, otherwise returns default value of <typeparamref name="T"/>.
        /// </summary>
        /// <returns></returns>
        [return: MaybeNull]
        public T GetOrDefault() => GetOrElse(default(T));

        /// <summary>
        /// Applies a function on the optional value.
        /// Returns a Some containing the result of applying <paramref name="map"/> to this Option's value
        /// if this Option is Some. Otherwise return None.
        /// </summary>
        /// <param name="map"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public abstract Option<TResult> Map<TResult>(Func<T, TResult> map);

        /// <summary>
        /// Returns the result of applying <paramref name="map"/> to this Option's value
        /// if this Option is Some. Returns None if this Option is None.
        /// Slightly different from Map() in that <paramref name="map"/> is expected to return an Option (which could be None).
        /// </summary>
        /// <param name="map"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public abstract Option<TResult> FlatMap<TResult>(Func<T, Option<TResult>> map);

        /// <summary>
        /// Returns this Option if it is Some and applying the predicate <paramref name="condition"/> to this Option's value returns true.
        /// Otherwise, return None.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public abstract Option<T> Filter(Func<T, bool> condition);

        /// <summary>
        /// Returns this Option if it is Some and <paramref name="condition"/> is true. Otherwise, return None.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public abstract Option<T> Filter(bool condition);

        /// <summary>
        /// Returns true if this option is Some and the predicate <paramref name="condition"/> returns true
        /// when applied to this Option's value. Otherwise, returns false.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public abstract bool Contains(Func<T, bool> condition);

        /// <summary>
        /// Returns the result of applying <paramref name="some"/> to this Option's value if the Option is Some.
        /// Otherwise, returns <paramref name="none"/>.
        /// </summary>
        /// <param name="some"></param>
        /// <param name="none"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public abstract TResult Fold<TResult>(Func<T, TResult> some, TResult none);

        /// <summary>
        /// Returns the result of applying <paramref name="some"/> to this Option's value if the Option is Some.
        /// Otherwise, evaluates <paramref name="none"/>.
        /// </summary>
        /// <param name="some"></param>
        /// <param name="none"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public abstract TResult Fold<TResult>(Func<T, TResult> some, Func<TResult> none);

        /// <summary>
        /// Executes <paramref name="some"/> to this Option's value if the Option is Some.
        /// Otherwise, executes <paramref name="none"/>.
        /// </summary>
        /// <param name="some"></param>
        /// <param name="none"></param>
        /// <returns></returns>
        public abstract void Match(Action<T> some, Action none);

        public static implicit operator Option<T>(Option<Nothing> _) => new None<T>();

        public static implicit operator Option<T>(T value) =>
            value is null ? (Option<T>) new None<T>() : new Some<T>(value);

        public static explicit operator T(Option<T> option) =>
            option.IsSome
                ? option.Get()
                : throw new InvalidCastException(ExceptionsMessages.OptionIsNone);

        public static Option<T> operator &(Option<T> left, Option<T> right) => left ? right : left;

        public static Option<T> operator |(Option<T> left, Option<T> right) => left ? left : right;

        public static bool operator true(Option<T> option) => option.IsSome;

        public static bool operator false(Option<T> option) => option.IsNone;

        public abstract bool Equals(Option<T>? other);

        public override bool Equals(object? obj) =>
            ReferenceEquals(this, obj) || obj is Option<T> other && Equals(other);

        public abstract override int GetHashCode();

        public static bool operator ==(Option<T>? left, Option<T>? right) => Equals(left, right);

        public static bool operator !=(Option<T>? left, Option<T>? right) => !Equals(left, right);

        /// <summary>
        /// Instantiates Some representing an existing value of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Option<T> Some(T value) => new Some<T>(value);

        /// <summary>
        /// Instantiates None representing no value.
        /// </summary>
        public static Option<T> None => new None<T>();

        public abstract Result<T, TError> ToResult<TError>(TError error);

        public abstract Result<T, TError> ToResult<TError>(Func<TError> error);
    }


    /// <inheritdoc />
    public class Some<TSome> : Option<TSome>
    {
        private readonly TSome _value;

        /// <summary>
        /// Instantiates Some representing an existing value of type <typeparamref name="TSome"/>.
        /// </summary>
        /// <param name="value"></param>
        public Some(TSome value) => _value = value;


        /// <inheritdoc />
        public override bool IsSome => true;

        /// <inheritdoc />
        public override TSome Get() => _value;

        /// <inheritdoc />
        public override TSome GetOrElse([AllowNull] TSome or) => _value;

        /// <inheritdoc />
        public override TSome GetOrElse(Func<TSome> or) => _value;

        /// <inheritdoc />
        public override Option<TResult> Map<TResult>(Func<TSome, TResult> map) =>
            map is null ? throw new ArgumentNullException(nameof(map)) : new Some<TResult>(map(_value));

        /// <inheritdoc />
        public override Option<TResult> FlatMap<TResult>(Func<TSome, Option<TResult>> map) =>
            map is null ? throw new ArgumentNullException(nameof(map)) : map(_value);

        /// <inheritdoc />
        public override Option<TSome> Filter(Func<TSome, bool> condition)
        {
            _ = condition ?? throw new ArgumentNullException(nameof(condition));
            return condition(_value) ? (Option<TSome>) this : new None<TSome>();
        }

        /// <inheritdoc />
        public override Option<TSome> Filter(bool condition) =>
            condition ? (Option<TSome>) this : new None<TSome>();

        /// <inheritdoc />
        public override bool Contains(Func<TSome, bool> condition)
        {
            _ = condition ?? throw new ArgumentNullException(nameof(condition));

            return condition(_value);
        }

        /// <inheritdoc />
        public override TResult Fold<TResult>(Func<TSome, TResult> some, TResult none)
        {
            _ = some ?? throw new ArgumentNullException(nameof(some));

            return some(_value);
        }

        /// <inheritdoc />
        public override TResult Fold<TResult>(Func<TSome, TResult> some, Func<TResult> none)
        {
            _ = some ?? throw new ArgumentNullException(nameof(some));

            return some(_value);
        }

        /// <inheritdoc />
        public override void Match(Action<TSome> some, Action none)
        {
            _ = some ?? throw new ArgumentNullException(nameof(some));

            some(_value);
        }

        public override bool Equals(Option<TSome>? other) =>
            (other?.IsSome ?? false) && EqualityComparer<TSome>.Default.Equals(_value, other.Get());

        public override int GetHashCode() => EqualityComparer<TSome>.Default.GetHashCode(_value);

        public override string ToString() => $"Some({_value})";

        public void Deconstruct(out TSome value) => value = _value;

        public override Result<TSome, TError> ToResult<TError>(TError error) => new Ok<TSome, TError>(_value);

        public override Result<TSome, TError> ToResult<TError>(Func<TError> error) => new Ok<TSome, TError>(_value);
    }

    /// <inheritdoc />
    public class None<TSome> : Option<TSome>
    {
        /// <inheritdoc />

        public override bool IsSome => false;

        /// <inheritdoc />
        public override TSome Get() => throw new InvalidOperationException(ExceptionsMessages.OptionIsNone);

        /// <inheritdoc />
        [return: MaybeNull]
        public override TSome GetOrElse([AllowNull] TSome or) => or;

        /// <inheritdoc />
        public override TSome GetOrElse(Func<TSome> or) =>
            or is null ? throw new ArgumentNullException(nameof(or)) : or();

        /// <inheritdoc />
        public override Option<TResult> Map<TResult>(Func<TSome, TResult> map) =>
            new None<TResult>();

        /// <inheritdoc />
        public override Option<TResult> FlatMap<TResult>(Func<TSome, Option<TResult>> map) =>
            new None<TResult>();

        /// <inheritdoc />
        public override Option<TSome> Filter(Func<TSome, bool> condition) =>
            new None<TSome>();

        /// <inheritdoc />
        public override Option<TSome> Filter(bool condition) =>
            new None<TSome>();

        /// <inheritdoc />
        public override bool Contains(Func<TSome, bool> condition) => false;

        /// <inheritdoc />
        public override TResult Fold<TResult>(Func<TSome, TResult> some, TResult none) => none;

        /// <inheritdoc />
        public override TResult Fold<TResult>(Func<TSome, TResult> some, Func<TResult> none)
        {
            _ = none ?? throw new ArgumentNullException(nameof(none));

            return none();
        }

        /// <inheritdoc />
        public override void Match(Action<TSome> some, Action none)
        {
            _ = none ?? throw new ArgumentNullException(nameof(none));

            none();
        }

        public override bool Equals(Option<TSome>? other) => other?.IsNone ?? false;

        public override int GetHashCode() => int.MinValue;

        public override string ToString() => "None";

        public void Deconstruct()
        {
        }

        public override Result<TSome, TError> ToResult<TError>(TError error) => new Error<TSome, TError>(error);

        public override Result<TSome, TError> ToResult<TError>(Func<TError> error) => new Error<TSome, TError>(error());
    }

    public static class Option
    {
        /// <summary>
        /// Instantiates Some representing an existing value of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Some<T> Some<T>(T value) => new Some<T>(value);

        /// <summary>
        /// Instantiates None representing no value.
        /// </summary>
        public static None<Nothing> None => new None<Nothing>();

        /// <summary>
        /// Converts caller to Some if caller is not null. Otherwise, to None.
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Option<T> ToOption<T>(this T value) => value;

        /// <summary>
        /// Converts caller to Some, even if it is null.
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Some<T> ToSome<T>(this T value) => Some(value);

        public static Option<TB> Select<TA, TB>(this Option<TA> self, Func<TA, TB> map) => self.Map(map);

        public static Option<TB> SelectMany<TA, TB>(this Option<TA> self, Func<TA, Option<TB>> map) =>
            self.FlatMap(map);

        public static Option<TC> SelectMany<TA, TB, TC>(this Option<TA> self, Func<TA, Option<TB>> map,
            Func<TA, TB, TC> project)
        {
            _ = project ?? throw new ArgumentNullException(nameof(project));

            return self.FlatMap(a => map(a).Map(b => project(a, b)));
        }

        public static Option<T> Where<T>(this Option<T> self, Func<T, bool> condition) => self.Filter(condition);

        public static Option<T> Fix<T>(this IKind<OptionF, T> self) => (Option<T>) self;

        public static IKind<OptionF, T> ToKind<T>(this Option<T> self) => self;

        public static IKind<OptionF, T> ToKind<T>(this Option<Nothing> self) => (Option<T>) self;
    }
}