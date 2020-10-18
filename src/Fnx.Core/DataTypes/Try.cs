using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Fnx.Core.DataTypes.Interfaces;
using Fnx.Core.Exceptions;
using Fnx.Core.Types;

namespace Fnx.Core.DataTypes
{
    public readonly struct TryF
    {
    }

    /// <summary>
    /// The <see cref="Try{T}"/> type represents a computation that may either result in an exception,
    /// or return a successfully computed value.
    /// Instances of <see cref="Try{T}"/> are either <see cref="Success{T}"/> or <see cref="Failure{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Try<T>
        : IEquatable<Try<T>>,
            IKind<TryF, T>,
            IGettable<T>, IToOption<T>, IToResult<T, Exception>
    {
        private protected Try()
        {
        }

        /// <summary>
        /// Returns <see langword="true"/> if the <see cref="Try{T}"/> is a <see cref="Success{T}"/>,
        /// <see langword="false"/> otherwise.
        /// </summary>
        public abstract bool IsSuccess { get; }

        /// <summary>
        /// Returns <see langword="true"/> if the <see cref="Try{T}"/> is a <see cref="Failure{T}"/>,
        /// <see langword="false"/> otherwise.
        /// </summary>
        public bool IsFailure => !IsSuccess;

        /// <summary>
        /// Returns the value from this <see cref="Success{T}"/>
        /// or throws the exception if this is a <see cref="Failure{T}"/>.
        /// </summary>
        /// <returns></returns>
        public abstract T Get();

        /// <summary>
        /// Returns the value from this <see cref="Success{T}"/>
        /// or the given value of <paramref name="or"/> if this is a <see cref="Failure{T}"/>.
        /// </summary>
        /// <param name="or"></param>
        /// <returns></returns>
        [return: MaybeNull]
        public abstract T GetOrElse([AllowNull] T or);

        /// <summary>
        /// Returns the value from this <see cref="Success{T}"/>
        /// or the result of evaluating <paramref name="or"/> if this is a <see cref="Failure{T}"/>.
        /// </summary>
        /// <param name="or"></param>
        /// <returns></returns>
        public abstract T GetOrElse(Func<T> or);

        /// <summary>
        /// Returns the value from this <see cref="Success{T}"/>
        /// or a default value of <typeparamref name="T"/> if this is a <see cref="Failure{T}"/>.
        /// </summary>
        /// <returns></returns>
        [return: MaybeNull]
        public T GetOrDefault() => GetOrElse(default(T));

        /// <summary>
        /// Returns the exception from this <see cref="Failure{T}"/>
        /// or throws an exception if this is <see cref="Success{T}"/>.
        /// </summary>
        /// <returns></returns>
        public abstract Exception GetException();

        /// <summary>
        /// Returns this <see cref="Try{T}"/> if it's a <see cref="Success{T}"/>
        /// or the given <paramref name="alternative"/> argument if this is a <see cref="Failure{T}"/>.
        /// </summary>
        /// <param name="alternative"></param>
        /// <returns></returns>
        public abstract Try<T> OrElse(Try<T> alternative);

        /// <summary>
        /// Returns this <see cref="Try{T}"/> if it's a <see cref="Success{T}"/>
        /// or the result of evaluating <paramref name="alternative"/> argument if this is a <see cref="Failure{T}"/>.
        /// </summary>
        /// <param name="alternative"></param>
        /// <returns></returns>
        public abstract Try<T> OrElse(Func<Try<T>> alternative);

        /// <summary>
        /// Maps the given function to the value from this <see cref="Success{T}"/>
        /// or returns this if this is a <see cref="Failure{T}"/>.
        /// </summary>
        /// <param name="map"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public abstract Try<TResult> Map<TResult>(Func<T, TResult> map);

        /// <summary>
        /// Returns the result of the given function applied to the value from this <see cref="Success{T}"/>
        /// or returns this if this is a <see cref="Failure{T}"/>.
        /// </summary>
        /// <param name="map"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public abstract Try<TResult> FlatMap<TResult>(Func<T, Try<TResult>> map);

        /// <summary>
        /// Converts this to a <see cref="Failure{T}"/> if the predicate <paramref name="condition"/> is not satisfied.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public abstract Try<T> Filter(Func<T, bool> condition);

        /// <summary>
        /// Converts this to a <see cref="Failure{T}"/> if <paramref name="condition"/> is false.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public abstract Try<T> Filter(bool condition);

        /// <summary>
        /// Returns true if this is <see cref="Success{T}"/> and the predicate <paramref name="condition"/> returns true
        /// when applied to this Success's value. Otherwise, returns false.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public abstract bool Contains(Func<T, bool> condition);

        /// <summary>
        /// Applies <paramref name="success"/> if this is a Success or <paramref name="failure"/> if this is a Failure.
        /// If <paramref name="success"/> is initially applied and throws an exception,
        /// then <paramref name="failure"/> is applied with this exception.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public abstract TResult Fold<TResult>(Func<T, TResult> success, Func<Exception, TResult> failure);

        /// <summary>
        /// Executes <paramref name="success"/> if this is a Success or <paramref name="failure"/> if this is a Failure.
        /// If <paramref name="success"/> is initially executed and throws an exception,
        /// then <paramref name="failure"/> is executed with this exception.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        public abstract void Match(Action<T> success, Action<Exception> failure);

        /// <summary>
        /// Applies the given function <paramref name="recover"/> if this is a <see cref="Failure{T}"/>,
        /// otherwise returns this if this is a <see cref="Success{T}"/>.
        /// </summary>
        /// <param name="recover"></param>
        /// <returns></returns>
        public abstract Try<T> Recover(Func<Exception, T> recover);

        /// <summary>
        /// Applies the given function <paramref name="recover"/> if this is a <see cref="Failure{T}"/>
        /// containing an exception of <typeparamref name="TException"/>.
        /// Otherwise returns this if this is a <see cref="Success{T}"/> or a <see cref="Failure{T}"/>
        /// containing an exception of different type.
        /// </summary>
        /// <param name="recover"></param>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public abstract Try<T> Recover<TException>(Func<TException, T> recover) where TException : Exception;

        /// <summary>
        /// Applies the given function <paramref name="recover"/> if this is a <see cref="Failure{T}"/>,
        /// otherwise returns this if this is a <see cref="Success{T}"/>.
        /// This is like <see cref="FlatMap{TResult}"/> for the exception.
        /// </summary>
        /// <param name="recover"></param>
        /// <returns></returns>
        public abstract Try<T> RecoverWith(Func<Exception, Try<T>> recover);

        /// <summary>
        /// Applies the given function <paramref name="recover"/> if this is a <see cref="Failure{T}"/>
        /// containing an exception of <typeparamref name="TException"/>.
        /// Otherwise returns this if this is a <see cref="Success{T}"/> or a <see cref="Failure{T}"/>
        /// containing an exception of different type.
        /// This is like <see cref="FlatMap{TResult}"/> for the exception.
        /// </summary>
        /// <param name="recover"></param>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public abstract Try<T> RecoverWith<TException>(Func<TException, Try<T>> recover) where TException : Exception;

        /// <summary>
        /// Throws contained exception if this is a <see cref="Failure{T}"/>.
        /// Otherwise, throws <see cref="InvalidOperationException"/>.
        /// </summary>
        public abstract void Rethrow();

        public static implicit operator Try<T>(T value) => new Success<T>(value);
        public static implicit operator Try<T>(Exception exception) => new Failure<T>(exception);

        public static explicit operator T(Try<T> @try) =>
            @try.IsSuccess
                ? @try.Get()
                : throw new InvalidCastException(ExceptionsMessages.TryIsNotSuccess);

        public static explicit operator Exception(Try<T> @try) =>
            @try.IsSuccess
                ? throw new InvalidCastException(ExceptionsMessages.TryIsNotFailure)
                : @try.GetException();

        public static Try<T> operator &(Try<T> left, Try<T> right) => left ? right : left;

        public static Try<T> operator |(Try<T> left, Try<T> right) => left ? left : right;

        public static bool operator true(Try<T> @try) => @try.IsSuccess;

        public static bool operator false(Try<T> @try) => !@try.IsSuccess;

        public abstract bool Equals(Try<T>? other);

        public override bool Equals(object? obj) =>
            ReferenceEquals(this, obj) || obj is Try<T> other && Equals(other);

        public abstract override int GetHashCode();

        public static bool operator ==(Try<T>? left, Try<T>? right) => Equals(left, right);

        public static bool operator !=(Try<T>? left, Try<T>? right) => !Equals(left, right);

        public abstract Option<T> ToOption();

        public abstract Result<T, Exception> ToResult();
    }

    public class Success<T> : Try<T>
    {
        private readonly T _value;

        public Success(T value) =>
            _value = value;

        /// <inheritdoc />
        public override bool IsSuccess => true;

        /// <inheritdoc />
        public override T Get() => _value;

        /// <inheritdoc />
        public override T GetOrElse([AllowNull] T or) => _value;

        /// <inheritdoc />
        public override T GetOrElse(Func<T> or) => _value;

        /// <inheritdoc />
        public override Exception GetException() =>
            throw new InvalidOperationException(ExceptionsMessages.TryIsNotSuccess);

        /// <inheritdoc />
        public override Try<T> OrElse(Try<T> alternative) => this;

        /// <inheritdoc />
        public override Try<T> OrElse(Func<Try<T>> alternative) => this;

        /// <inheritdoc />
        public override Try<TResult> Map<TResult>(Func<T, TResult> map)
        {
            try
            {
                return map(_value);
            }
            catch (Exception e)
            {
                return e;
            }
        }

        /// <inheritdoc />
        public override Try<TResult> FlatMap<TResult>(Func<T, Try<TResult>> map)
        {
            try
            {
                return map(_value);
            }
            catch (Exception e)
            {
                return new Failure<TResult>(e);
            }
        }

        /// <inheritdoc />
        public override Try<T> Filter(Func<T, bool> condition)
        {
            try
            {
                return condition(_value) ? (Try<T>) this : new NoSuchElementException();
            }
            catch (Exception e)
            {
                return e;
            }
        }

        /// <inheritdoc />
        public override Try<T> Filter(bool condition) =>
            condition ? (Try<T>) this : new NoSuchElementException();

        /// <inheritdoc />
        public override bool Contains(Func<T, bool> condition) => condition(_value);

        /// <inheritdoc />
        public override TResult Fold<TResult>(Func<T, TResult> success, Func<Exception, TResult> failure)
        {
            _ = success ?? throw new ArgumentNullException(nameof(success));
            _ = failure ?? throw new ArgumentNullException(nameof(failure));

            try
            {
                return success(_value);
            }
            catch (Exception e)
            {
                return failure(e);
            }
        }

        /// <inheritdoc />
        public override void Match(Action<T> success, Action<Exception> failure)
        {
            _ = success ?? throw new ArgumentNullException(nameof(success));
            _ = failure ?? throw new ArgumentNullException(nameof(failure));

            try
            {
                success(_value);
            }
            catch (Exception e)
            {
                failure(e);
            }
        }

        /// <inheritdoc />
        public override Try<T> Recover(Func<Exception, T> recover) => this;

        /// <inheritdoc />
        public override Try<T> Recover<TException>(Func<TException, T> recover) => this;

        /// <inheritdoc />
        public override Try<T> RecoverWith(Func<Exception, Try<T>> recover) => this;

        public override Try<T> RecoverWith<TException>(Func<TException, Try<T>> recover) => this;

        /// <inheritdoc />
        public override void Rethrow() =>
            throw new InvalidOperationException(ExceptionsMessages.TryIsNotFailure);

        public override bool Equals(Try<T>? other) =>
            (other?.IsSuccess ?? false) && EqualityComparer<T>.Default.Equals(_value, other.Get());

        public override int GetHashCode() => EqualityComparer<T>.Default.GetHashCode(_value);

        public override string ToString() => $"Success({_value})";

        public void Deconstruct(out T value) => value = _value;

        public override Option<T> ToOption() => _value;

        public override Result<T, Exception> ToResult() => _value;
    }

    public class Failure<T> : Try<T>
    {
        private readonly Exception _exception;

        public Failure(Exception exception) =>
            _exception = exception ?? throw new ArgumentNullException(nameof(exception));

        /// <inheritdoc />
        public override bool IsSuccess => false;

        /// <inheritdoc />
        public override T Get() => throw _exception;

        /// <inheritdoc />
        [return: MaybeNull]
        public override T GetOrElse([AllowNull] T or) => or;

        /// <inheritdoc />
        public override T GetOrElse(Func<T> or) =>
            or is null ? throw new ArgumentNullException(nameof(or)) : or();

        /// <inheritdoc />
        public override Exception GetException() => _exception;

        /// <inheritdoc />
        public override Try<T> OrElse(Try<T> alternative) => alternative;

        /// <inheritdoc />
        public override Try<T> OrElse(Func<Try<T>> alternative)
        {
            try
            {
                return alternative();
            }
            catch (Exception e)
            {
                return e;
            }
        }

        /// <inheritdoc />
        public override Try<TResult> Map<TResult>(Func<T, TResult> map) => new Failure<TResult>(_exception);

        /// <inheritdoc />
        public override Try<TResult> FlatMap<TResult>(Func<T, Try<TResult>> map) => new Failure<TResult>(_exception);

        /// <inheritdoc />
        public override Try<T> Filter(Func<T, bool> condition) => this;

        /// <inheritdoc />
        public override Try<T> Filter(bool condition) => this;

        /// <inheritdoc />
        public override bool Contains(Func<T, bool> condition) => false;

        /// <inheritdoc />
        public override TResult Fold<TResult>(Func<T, TResult> success, Func<Exception, TResult> failure)
        {
            _ = failure ?? throw new ArgumentNullException(nameof(failure));

            return failure(_exception);
        }

        /// <inheritdoc />
        public override void Match(Action<T> success, Action<Exception> failure)
        {
            _ = failure ?? throw new ArgumentNullException(nameof(failure));

            failure(_exception);
        }

        /// <inheritdoc />
        public override Try<T> Recover(Func<Exception, T> recover)
        {
            try
            {
                return recover(_exception);
            }
            catch (Exception e)
            {
                return e;
            }
        }

        /// <inheritdoc />
        public override Try<T> Recover<TException>(Func<TException, T> recover)
        {
            if (!(_exception is TException exception)) return this;

            try
            {
                return recover(exception);
            }
            catch (Exception e)
            {
                return e;
            }
        }

        /// <inheritdoc />
        public override Try<T> RecoverWith(Func<Exception, Try<T>> recover)
        {
            try
            {
                return recover(_exception);
            }
            catch (Exception e)
            {
                return e;
            }
        }

        /// <inheritdoc />
        public override Try<T> RecoverWith<TException>(Func<TException, Try<T>> recover)
        {
            if (!(_exception is TException exception)) return this;

            try
            {
                return recover(exception);
            }
            catch (Exception e)
            {
                return e;
            }
        }

        /// <inheritdoc />
        public override void Rethrow()
        {
            ExceptionDispatchInfo
                .Capture(_exception)
                .Throw();
        }

        public override bool Equals(Try<T>? other) =>
            (other?.IsFailure ?? false) && EqualityComparer<Exception>.Default.Equals(_exception, other.GetException());

        public override int GetHashCode() => _exception.GetHashCode();

        public override string ToString() => $"Failure({_exception})";

        public void Deconstruct(out Exception exception) => exception = _exception;

        public override Option<T> ToOption() => new None<T>();

        public override Result<T, Exception> ToResult() => _exception;
    }

    public static class Try
    {
        /// <summary>
        /// Constructs a Try using the function <paramref name="f"/>.
        /// This method will ensure any exception is caught and a Failure object is returned.
        /// </summary>
        /// <param name="f"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> From<T>(Func<T> f)
        {
            try
            {
                return f();
            }
            catch (Exception e)
            {
                return e;
            }
        }

        /// <summary>
        /// Constructs a Try using the function <paramref name="f"/> returning Task of <typeparamref name="T"/>.
        /// This method will ensure any non-fatal exception is caught and a Failure object is returned.
        /// </summary>
        /// <param name="f"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Try<T>> From<T>(Func<Task<T>> f)
        {
            try
            {
                return await f().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                return e;
            }
        }

        /// <summary>
        /// Constructs a <see cref="Success{T}"/> using the <paramref name="value"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Success<T> Success<T>(T value) => new Success<T>(value);
        
        /// <summary>
        /// Constructs a <see cref="Failure{T}"/> using the <paramref name="exception"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Failure<T> Failure<T>(Exception exception) => new Failure<T>(exception);

        public static Try<TB> Select<TA, TB>(this Try<TA> self, Func<TA, TB> map) => self.Map(map);

        public static Try<TB> SelectMany<TA, TB>(this Try<TA> self, Func<TA, Try<TB>> map) =>
            self.FlatMap(map);

        public static Try<TC> SelectMany<TA, TB, TC>(
            this Try<TA> self, Func<TA, Try<TB>> map, Func<TA, TB, TC> project)
        {
            _ = project ?? throw new ArgumentNullException(nameof(project));

            return self.FlatMap(a => map(a).Map(b => project(a, b)));
        }

        public static Try<T> Where<T>(this Try<T> self, Func<T, bool> condition) => self.Filter(condition);
    }
}