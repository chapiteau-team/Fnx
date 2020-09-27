using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Fnx.Core.DataTypes.Interfaces;
using Fnx.Core.Exceptions;
using Fnx.Core.Types;

namespace Fnx.Core.DataTypes
{
    public readonly struct ResultOkF<TError>
    {
    }

    public readonly struct ResultF
    {
    }

    /// <summary>
    /// The Result type represents Ok value of <typeparamref name="TOk"/>  or Error value of <typeparamref name="TError"/>.
    /// An instance of Result is either Ok or Error.
    /// </summary>
    /// <typeparam name="TOk"></typeparam>
    /// <typeparam name="TError"></typeparam>
    public abstract class Result<TOk, TError>
        : IEquatable<Result<TOk, TError>>,
            IKind<ResultOkF<TError>, TOk>, IKind2<ResultF, TOk, TError>,
            IGettable<TOk>, IToOption<TOk>
    {
        private protected Result()
        {
        }

        /// <summary>
        /// Returns true if this is Ok, false otherwise.
        /// </summary>
        public abstract bool IsOk { get; }

        /// <summary>
        /// Returns true if this is Error, false otherwise.
        /// </summary>
        public bool IsError => !IsOk;

        /// <summary>
        /// Returns the value from this Ok or throws the exception if this is an Error.
        /// </summary>
        /// <returns></returns>
        public abstract TOk Get();

        /// <summary>
        /// Returns the value from this Ok or the given value of <paramref name="or"/> if this is an Error.
        /// </summary>
        /// <returns></returns>
        [return: MaybeNull]
        public abstract TOk GetOrElse([AllowNull] TOk or);

        /// <summary>
        /// Returns the value from this Ok, or the result of evaluating <paramref name="or"/> if this is an Error.
        /// </summary>
        /// <param name="or"></param>
        /// <returns></returns>
        public abstract TOk GetOrElse(Func<TOk> or);

        /// <summary>
        /// Returns the value from this Ok, or default value of Ok type.
        /// </summary>
        /// <returns></returns>
        [return: MaybeNull]
        public TOk GetOrDefault() => GetOrElse(default(TOk));

        /// <summary>
        /// Returns the error from this Error or throws an exception if this is Ok.
        /// </summary>
        public abstract TError GetError();

        /// <summary>
        /// Applies a function on the Ok value.
        /// Returns an Ok containing the result of applying <paramref name="map"/> to this Ok value
        /// if this Result is Ok. Otherwise, return Error.
        /// </summary>
        /// <param name="map"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public abstract Result<T, TError> Map<T>(Func<TOk, T> map);

        /// <summary>
        /// Applies a function to the Ok or Error
        /// to the Error value. Returns Result containing the result of applying <paramref name="ok"/> to the Ok value
        /// or <paramref name="error"/> to the Error value
        /// </summary>
        /// <param name="ok"></param>
        /// <param name="error"></param>
        /// <typeparam name="TOkReturn"></typeparam>
        /// <typeparam name="TErrorReturn"></typeparam>
        /// <returns></returns>
        public abstract Result<TOkReturn, TErrorReturn> BiMap<TOkReturn, TErrorReturn>(
            Func<TOk, TOkReturn> ok,
            Func<TError, TErrorReturn> error);

        /// <summary>
        /// Applies a function to the Error value.
        /// Returns an Error containing the result of applying <paramref name="map"/> to this Errors value
        /// if this Result is Ok. Otherwise, return Error.
        /// </summary>
        /// <param name="map"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public abstract Result<TOk, T> ErrorMap<T>(Func<TError, T> map);

        /// <summary>
        /// Returns the Result of applying <paramref name="map"/> to Result's Ok value,
        /// otherwise, returns Error.
        /// Slightly different from Map() in that <paramref name="map"/>
        /// is expected to return a Result (which could be Error).
        /// </summary>
        /// <param name="map"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public abstract Result<T, TError> FlatMap<T>(Func<TOk, Result<T, TError>> map);

        /// <summary>
        /// Applies the given function <paramref name="recover"/> if this is an Error,
        /// otherwise, returns this if this is an Ok.
        /// </summary>
        /// <param name="recover"></param>
        /// <returns></returns>
        public abstract Result<TOk, TError> Recover(Func<TError, TOk> recover);

        /// <summary>
        /// Applies the given function <paramref name="recover"/> if this is Error, otherwise returns this if this is an Ok.
        /// This is like flatMap for the Error.
        /// </summary>
        /// <param name="recover"></param>
        /// <typeparam name="TErrorReturn"></typeparam>
        /// <returns></returns>
        public abstract Result<TOk, TErrorReturn> RecoverWith<TErrorReturn>(
            Func<TError, Result<TOk, TErrorReturn>> recover);

        /// <summary>
        /// Returns an Ok if applying the predicate <paramref name="condition"/> to this Result's Ok value returns true.
        /// Otherwise, return Error containing the given <paramref name="error"/>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public abstract Result<TOk, TError> Filter(Func<TOk, bool> condition, TError error = default);

        /// <summary>
        /// Returns this Result if applying the predicate <paramref name="condition"/> to this Result's Ok value returns true.
        /// Otherwise, return Error containing the result of applying <paramref name="error"/>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public abstract Result<TOk, TError> Filter(Func<TOk, bool> condition, Func<TError> error);

        /// <summary>
        /// Returns this Result if <paramref name="condition"/> is true and Result state is Ok.
        /// Otherwise, return Error containing the given <paramref name="error"/>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public abstract Result<TOk, TError> Filter(bool condition, TError error = default);

        /// <summary>
        /// Returns this Result if <paramref name="condition"/> is true and Result state is Ok.
        /// Otherwise, return Error containing the result of applying <paramref name="error"/>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public abstract Result<TOk, TError> Filter(bool condition, Func<TError> error);

        /// <summary>
        /// Returns false if Error or returns the result of the application
        /// of the given <paramref name="condition"/> to the Ok value.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public abstract bool Contains(Func<TOk, bool> condition);

        /// <summary>
        /// Returns the result of applying <paramref name="ok"/> to this Result's value if the Result is Ok.
        /// Otherwise, returns result of applying <paramref name="error"/> to the Error.
        /// </summary>
        /// <param name="ok"></param>
        /// <param name="error"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public abstract TResult Fold<TResult>(Func<TOk, TResult> ok, Func<TError, TResult> error);

        /// <summary>
        /// Executes <paramref name="ok"/> if this is an Ok  or <paramref name="error"/> if this is an Error.
        /// </summary>
        /// <param name="ok"></param>
        /// <param name="error"></param>
        public abstract void Match(Action<TOk> ok, Action<TError> error);

        public static implicit operator Result<TOk, TError>(TOk ok) => new Ok<TOk, TError>(ok);

        public static implicit operator Result<TOk, TError>(TError error) => new Error<TOk, TError>(error);

        public static implicit operator Result<TOk, TError>(Result<TOk, Nothing> ok) =>
            new Ok<TOk, TError>(ok.Get());

        public static implicit operator Result<TOk, TError>(Result<Nothing, TError> error) =>
            new Error<TOk, TError>(error.GetError());

        public static explicit operator TOk(Result<TOk, TError> result) =>
            result.IsOk
                ? result.Get()
                : throw new InvalidCastException(ExceptionsMessages.ResultIsError);

        public static explicit operator TError(Result<TOk, TError> result) =>
            result.IsOk
                ? throw new InvalidCastException(ExceptionsMessages.ResultIsOk)
                : result.GetError();

        public static Result<TOk, TError> operator &(Result<TOk, TError> left, Result<TOk, TError> right) =>
            left ? right : left;

        public static Result<TOk, TError> operator |(Result<TOk, TError> left, Result<TOk, TError> right) =>
            left ? left : right;

        public static bool operator true(Result<TOk, TError> result) => result.IsOk;

        public static bool operator false(Result<TOk, TError> result) => result.IsError;

        public abstract bool Equals(Result<TOk, TError>? other);

        public override bool Equals(object? obj) =>
            ReferenceEquals(this, obj) || obj is Result<TOk, TError> other && Equals(other);

        public abstract override int GetHashCode();

        public static bool operator ==(Result<TOk, TError>? left, Result<TOk, TError>? right) => Equals(left, right);

        public static bool operator !=(Result<TOk, TError>? left, Result<TOk, TError>? right) => !Equals(left, right);

        public abstract Option<TOk> ToOption();
    }

    /// <inheritdoc />
    public class Ok<TOk, TError> : Result<TOk, TError>
    {
        private readonly TOk _ok;

        public Ok(TOk ok)
        {
            _ok = ok;
        }

        /// <inheritdoc />
        public override bool IsOk => true;

        /// <inheritdoc />
        public override TOk Get() => _ok;

        /// <inheritdoc />
        public override TOk GetOrElse([AllowNull] TOk or) => _ok;

        /// <inheritdoc />
        public override TOk GetOrElse(Func<TOk> or) => _ok;

        /// <inheritdoc />
        public override TError GetError() => throw new InvalidOperationException(ExceptionsMessages.ResultIsOk);

        /// <inheritdoc />
        public override Result<T, TError> Map<T>(Func<TOk, T> map)
        {
            _ = map ?? throw new ArgumentNullException(nameof(map));

            return new Ok<T, TError>(map(_ok));
        }

        /// <inheritdoc />
        public override Result<TOkReturn, TErrorReturn> BiMap<TOkReturn, TErrorReturn>(
            Func<TOk, TOkReturn> ok,
            Func<TError, TErrorReturn> error)
        {
            _ = ok ?? throw new ArgumentNullException(nameof(ok));

            return new Ok<TOkReturn, TErrorReturn>(ok(_ok));
        }

        /// <inheritdoc />
        public override Result<TOk, T> ErrorMap<T>(Func<TError, T> map) => new Ok<TOk, T>(_ok);

        /// <inheritdoc />
        public override Result<T, TError> FlatMap<T>(Func<TOk, Result<T, TError>> map)
        {
            _ = map ?? throw new ArgumentNullException(nameof(map));

            return map(_ok);
        }

        /// <inheritdoc />
        public override Result<TOk, TError> Recover(Func<TError, TOk> recover) => this;

        /// <inheritdoc />
        public override Result<TOk, TErrorReturn> RecoverWith<TErrorReturn>(
            Func<TError, Result<TOk, TErrorReturn>> recover) =>
            new Ok<TOk, TErrorReturn>(_ok);

        /// <inheritdoc />
        public override Result<TOk, TError> Filter(Func<TOk, bool> condition, TError error = default)
        {
            _ = condition ?? throw new ArgumentNullException(nameof(condition));

            return condition(_ok) ? (Result<TOk, TError>) this : new Error<TOk, TError>(error);
        }

        /// <inheritdoc />
        public override Result<TOk, TError> Filter(Func<TOk, bool> condition, Func<TError> error)
        {
            _ = condition ?? throw new ArgumentNullException(nameof(condition));
            _ = error ?? throw new ArgumentNullException(nameof(error));

            return condition(_ok) ? (Result<TOk, TError>) this : new Error<TOk, TError>(error());
        }

        /// <inheritdoc />
        public override Result<TOk, TError> Filter(bool condition, TError error = default) =>
            condition ? (Result<TOk, TError>) this : new Error<TOk, TError>(error);

        /// <inheritdoc />
        public override Result<TOk, TError> Filter(bool condition, Func<TError> error)
        {
            _ = error ?? throw new ArgumentNullException(nameof(error));

            return condition ? (Result<TOk, TError>) this : new Error<TOk, TError>(error());
        }

        /// <inheritdoc />
        public override bool Contains(Func<TOk, bool> condition)
        {
            _ = condition ?? throw new ArgumentNullException(nameof(condition));

            return condition(_ok);
        }

        /// <inheritdoc />
        public override TResult Fold<TResult>(Func<TOk, TResult> ok, Func<TError, TResult> error)
        {
            _ = ok ?? throw new ArgumentNullException(nameof(ok));

            return ok(_ok);
        }

        /// <inheritdoc />
        public override void Match(Action<TOk> ok, Action<TError> error)
        {
            _ = ok ?? throw new ArgumentNullException(nameof(ok));

            ok(_ok);
        }

        public override bool Equals(Result<TOk, TError>? other) =>
            (other?.IsOk ?? false) && EqualityComparer<TOk>.Default.Equals(_ok, other.Get());

        public override int GetHashCode() => EqualityComparer<TOk>.Default.GetHashCode(_ok);

        public static implicit operator Ok<TOk, TError>(TOk ok) => new Ok<TOk, TError>(ok);

        public static implicit operator Ok<TOk, TError>(Ok<TOk, Nothing> ok) => new Ok<TOk, TError>(ok.Get());

        public static explicit operator TOk(Ok<TOk, TError> ok) => ok._ok;

        public override string ToString() => $"Ok({_ok})";

        public void Deconstruct(out TOk ok) => ok = _ok;

        public override Option<TOk> ToOption() => new Some<TOk>(_ok);
    }

    /// <inheritdoc />
    public class Error<TOk, TError> : Result<TOk, TError>
    {
        private readonly TError _error;

        public Error(TError error)
        {
            _error = error;
        }

        /// <inheritdoc />
        public override bool IsOk => false;

        /// <inheritdoc />
        public override TOk Get() => throw new InvalidOperationException(ExceptionsMessages.ResultIsError);

        /// <inheritdoc />
        [return: MaybeNull]
        public override TOk GetOrElse([AllowNull] TOk or) => or;

        /// <inheritdoc />
        public override TOk GetOrElse(Func<TOk> or)
        {
            _ = or ?? throw new ArgumentNullException(nameof(or));

            return or();
        }

        /// <inheritdoc />
        public override TError GetError() => _error;

        /// <inheritdoc />
        public override Result<T, TError> Map<T>(Func<TOk, T> map) => new Error<T, TError>(_error);

        /// <inheritdoc />
        public override Result<TOkReturn, TErrorReturn> BiMap<TOkReturn, TErrorReturn>(
            Func<TOk, TOkReturn> ok,
            Func<TError, TErrorReturn> error)
        {
            _ = error ?? throw new ArgumentNullException(nameof(error));

            return new Error<TOkReturn, TErrorReturn>(error(_error));
        }

        /// <inheritdoc />
        public override Result<TOk, T> ErrorMap<T>(Func<TError, T> map)
        {
            _ = map ?? throw new ArgumentNullException(nameof(map));

            return new Error<TOk, T>(map(_error));
        }

        /// <inheritdoc />
        public override Result<T, TError> FlatMap<T>(Func<TOk, Result<T, TError>> map) => new Error<T, TError>(_error);

        /// <inheritdoc />
        public override Result<TOk, TError> Recover(Func<TError, TOk> recover)
        {
            _ = recover ?? throw new ArgumentNullException(nameof(recover));

            return new Ok<TOk, TError>(recover(_error));
        }

        /// <inheritdoc />
        public override Result<TOk, TErrorReturn> RecoverWith<TErrorReturn>(
            Func<TError, Result<TOk, TErrorReturn>> recover)
        {
            _ = recover ?? throw new ArgumentNullException(nameof(recover));

            return recover(_error);
        }

        /// <inheritdoc />
        public override Result<TOk, TError> Filter(Func<TOk, bool> condition, TError error = default) => this;

        /// <inheritdoc />
        public override Result<TOk, TError> Filter(Func<TOk, bool> condition, Func<TError> error) => this;


        /// <inheritdoc />
        public override Result<TOk, TError> Filter(bool condition, TError error = default) => this;

        /// <inheritdoc />
        public override Result<TOk, TError> Filter(bool condition, Func<TError> error) => this;

        /// <inheritdoc />
        public override bool Contains(Func<TOk, bool> condition) => false;

        /// <inheritdoc />
        public override TResult Fold<TResult>(Func<TOk, TResult> ok, Func<TError, TResult> error)
        {
            _ = error ?? throw new ArgumentNullException(nameof(error));

            return error(_error);
        }

        /// <inheritdoc />
        public override void Match(Action<TOk> ok, Action<TError> error)
        {
            _ = error ?? throw new ArgumentNullException(nameof(error));

            error(_error);
        }

        public override bool Equals(Result<TOk, TError>? other) =>
            (other?.IsError ?? false) && EqualityComparer<TError>.Default.Equals(_error, other.GetError());

        public override int GetHashCode() => EqualityComparer<TError>.Default.GetHashCode(_error);

        public static implicit operator Error<TOk, TError>(TError error) => new Error<TOk, TError>(error);

        public static implicit operator Error<TOk, TError>(Error<Nothing, TError> error) =>
            new Error<TOk, TError>(error.GetError());

        public static explicit operator TError(Error<TOk, TError> error) => error._error;

        public override string ToString() => $"Error({_error})";

        public void Deconstruct(out TError error) => error = _error;

        public override Option<TOk> ToOption() => new None<TOk>();
    }

    public static class Result
    {
        /// <summary>
        /// Returns an Ok if applying the predicate <paramref name="condition"/> to this Result's Ok value returns true.
        /// Otherwise, return Error containing the given <paramref name="error"/>.
        /// </summary>
        /// <param name="ok"></param>
        /// <param name="condition"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static Result<TOk, TError> Filter<TOk, TError>(
            this Result<TOk, Nothing> ok, Func<TOk, bool> condition, TError error = default)
        {
            _ = condition ?? throw new ArgumentNullException(nameof(condition));

            return condition(ok.Get())
                ? (Result<TOk, TError>) new Ok<TOk, TError>(ok.Get())
                : new Error<TOk, TError>(error);
        }

        /// <summary>
        /// Returns this Result if applying the predicate <paramref name="condition"/> to this Result's Ok value returns true.
        /// Otherwise, return Error containing the result of applying <paramref name="error"/>.
        /// </summary>
        /// <param name="ok"></param>
        /// <param name="condition"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static Result<TOk, TError> Filter<TOk, TError>(
            this Result<TOk, Nothing> ok, Func<TOk, bool> condition, Func<TError> error)
        {
            _ = condition ?? throw new ArgumentNullException(nameof(condition));
            _ = error ?? throw new ArgumentNullException(nameof(error));

            return condition(ok.Get())
                ? (Result<TOk, TError>) new Ok<TOk, TError>(ok.Get())
                : new Error<TOk, TError>(error());
        }

        /// <summary>
        /// Returns this Result if <paramref name="condition"/> is true and Result state is Ok.
        /// Otherwise, return Error containing the given <paramref name="error"/>.
        /// </summary>
        /// <param name="ok"></param>
        /// <param name="condition"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static Result<TOk, TError> Filter<TOk, TError>(
            this Result<TOk, Nothing> ok, bool condition, TError error = default) =>
            condition
                ? (Result<TOk, TError>) new Ok<TOk, TError>(ok.Get())
                : new Error<TOk, TError>(error);

        /// <summary>
        /// Returns this Result if <paramref name="condition"/> is true and Result state is Ok.
        /// Otherwise, return Error containing the result of applying <paramref name="error"/>.
        /// </summary>
        /// <param name="ok"></param>
        /// <param name="condition"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static Result<TOk, TError> Filter<TOk, TError>(
            this Result<TOk, Nothing> ok, bool condition, Func<TError> error)
        {
            _ = error ?? throw new ArgumentNullException(nameof(error));

            return condition
                ? (Result<TOk, TError>) new Ok<TOk, TError>(ok.Get())
                : new Error<TOk, TError>(error());
        }

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

        public static Result<TTOk, TError> Select<TOk, TError, TTOk>(this Result<TOk, TError> self, Func<TOk, TTOk> map)
            => self.Map(map);

        public static Result<TB, TError> SelectMany<TA, TError, TB>(this Result<TA, TError> self,
            Func<TA, Result<TB, TError>> map) => self.FlatMap(map);

        public static Result<TC, TError> SelectMany<TA, TError, TB, TC>(this Result<TA, TError> self,
            Func<TA, Result<TB, TError>> map, Func<TA, TB, TC> project)
        {
            _ = project ?? throw new ArgumentNullException(nameof(project));

            return self.FlatMap(a => map(a).Map(b => project(a, b)));
        }

        public static Result<TOk, TError> Where<TOk, TError>(this Result<TOk, TError> self, Func<TOk, bool> condition)
            => self.Filter(condition);

        public static Result<TOk, TError> Fix<TOk, TError>(this IKind<ResultOkF<TError>, TOk> self) =>
            (Result<TOk, TError>) self;

        public static IKind<ResultOkF<TError>, TOk> ToKind<TOk, TError>(this Result<TOk, TError> self) => self;
    }
}