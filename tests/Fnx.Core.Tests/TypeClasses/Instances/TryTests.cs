using System;
using System.Collections.Generic;
using Fnx.Core.DataTypes;
using Fnx.Core.Tests.TypeClasses.Laws;
using Fnx.Core.TypeClasses;
using Fnx.Core.TypeClasses.Instances;
using Shouldly;
using Xunit;

namespace Fnx.Core.Tests.TypeClasses.Instances
{
    public class ExceptionEq : IEq<Exception>
    {
        public bool Eqv(Exception a, Exception b)
        {
            return a.Message == b.Message;
        }
    }

    public class TryTests
    {
        private static Failure<T> GetFailure<T>() => new Failure<T>(new Exception("fail"));

        public static IEnumerable<object[]> EqLaws() =>
            new EqLawsTests<Try<string>>(TryK.Eq(StringK.Eq(), new ExceptionEq())).Wrap();

        [Theory]
        [MemberData(nameof(EqLaws))]
        public void EqLaw(Law<Try<string>> law)
        {
            law.TestLaw(GetFailure<string>()).ShouldBe(true);
            law.TestLaw(new Success<string>("1")).ShouldBe(true);
        }

        public static IEnumerable<object[]> InvariantLaws() =>
            new InvariantLawsTests<TryF, string, int, long>(TryK.Invariant(), TryK.EqK(new ExceptionEq())).Wrap();

        [Theory]
        [MemberData(nameof(InvariantLaws))]
        public void FailureInvariantLaw(Law<TestArgs<TryF, string, int, long>> law)
        {
            var args = TestArgs.Default<TryF>();
            args.LiftedA = GetFailure<string>().K();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(InvariantLaws))]
        public void SuccessInvariantLaw(Law<TestArgs<TryF, string, int, long>> law)
        {
            var args = TestArgs.Default<TryF>();
            args.LiftedA = new Success<string>(args.A);

            law.TestLaw(args).ShouldBe(true);
        }

        public static IEnumerable<object[]> FunctorLaws() =>
            new FunctorLawsTests<TryF, string, int, long>(TryK.Functor(), TryK.EqK(new ExceptionEq())).Wrap();

        [Theory]
        [MemberData(nameof(FunctorLaws))]
        public void FailureFunctorLaw(Law<TestArgs<TryF, string, int, long>> law)
        {
            var args = TestArgs.Default<TryF>();
            args.LiftedA = GetFailure<string>().K();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(FunctorLaws))]
        public void SuccessFunctorLaw(Law<TestArgs<TryF, string, int, long>> law)
        {
            var args = TestArgs.Default<TryF>();
            args.LiftedA = new Success<string>(args.A);

            law.TestLaw(args).ShouldBe(true);
        }

        public static IEnumerable<object[]> ApplyLaws() =>
            new ApplyLawsTests<TryF, string, int, long>(TryK.Apply(), TryK.EqK(new ExceptionEq())).Wrap();

        [Theory]
        [MemberData(nameof(ApplyLaws))]
        public void FailureApplyLaw(Law<TestArgs<TryF, string, int, long>> law)
        {
            var args = TestArgs.Default<TryF>();
            args.LiftedA = GetFailure<string>().K();
            args.LiftedB = GetFailure<int>().K();
            args.LiftedFuncAtoB = GetFailure<Func<string, int>>().K();
            args.LiftedFuncBtoC = GetFailure<Func<int, long>>().K();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(ApplyLaws))]
        public void SuccessApplyLaw(Law<TestArgs<TryF, string, int, long>> law)
        {
            var args = TestArgs.Default<TryF>();
            args.LiftedA = new Success<string>(args.A);
            args.LiftedB = new Success<int>(args.B);
            args.LiftedFuncAtoB = new Success<Func<string, int>>(args.FuncAtoB);
            args.LiftedFuncBtoC = new Success<Func<int, long>>(args.FuncBtoC);

            law.TestLaw(args).ShouldBe(true);
        }

        public static IEnumerable<object[]> ApplicativeLaws() =>
            new ApplicativeLawsTests<TryF, string, int, long>(TryK.Applicative(), TryK.EqK(new ExceptionEq())).Wrap();

        [Theory]
        [MemberData(nameof(ApplicativeLaws))]
        public void FailureApplicativeLaw(Law<TestArgs<TryF, string, int, long>> law)
        {
            var args = TestArgs.Default<TryF>();
            args.LiftedA = GetFailure<string>().K();
            args.LiftedB = GetFailure<int>().K();
            args.LiftedFuncAtoB = GetFailure<Func<string, int>>().K();
            args.LiftedFuncBtoC = GetFailure<Func<int, long>>().K();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(ApplicativeLaws))]
        public void SuccessApplicativeLaw(Law<TestArgs<TryF, string, int, long>> law)
        {
            var args = TestArgs.Default<TryF>();
            args.LiftedA = new Success<string>(args.A);
            args.LiftedB = new Success<int>(args.B);
            args.LiftedFuncAtoB = new Success<Func<string, int>>(args.FuncAtoB);
            args.LiftedFuncBtoC = new Success<Func<int, long>>(args.FuncBtoC);

            law.TestLaw(args).ShouldBe(true);
        }

        public static IEnumerable<object[]> FlatMapLaws() =>
            new FlatMapLawsTests<TryF, string, int, long>(TryK.FlatMap(), TryK.EqK(new ExceptionEq())).Wrap();

        [Theory]
        [MemberData(nameof(FlatMapLaws))]
        public void FailureFlatMapLaw(Law<TestArgs<TryF, string, int, long>> law)
        {
            var args = TestArgs.Default<TryF>();
            args.LiftedA = GetFailure<string>().K();
            args.LiftedB = GetFailure<int>().K();
            args.LiftedFuncAtoB = GetFailure<Func<string, int>>().K();
            args.LiftedFuncBtoC = GetFailure<Func<int, long>>().K();
            args.FuncAtoLiftedB = _ => GetFailure<int>().K();
            args.FuncBtoLiftedC = _ => GetFailure<long>().K();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(FlatMapLaws))]
        public void SuccessFlatMapLaw(Law<TestArgs<TryF, string, int, long>> law)
        {
            var args = TestArgs.Default<TryF>();
            args.LiftedA = new Success<string>(args.A);
            args.LiftedB = new Success<int>(args.B);
            args.LiftedFuncAtoB = new Success<Func<string, int>>(args.FuncAtoB);
            args.LiftedFuncBtoC = new Success<Func<int, long>>(args.FuncBtoC);
            args.FuncAtoLiftedB = a => new Success<int>(args.FuncAtoB(a));
            args.FuncBtoLiftedC = b => new Success<long>(args.FuncBtoC(b));

            law.TestLaw(args).ShouldBe(true);
        }

        public static IEnumerable<object[]> MonadLaws() =>
            new MonadLawsTests<TryF, string, int, long>(TryK.Monad(), TryK.EqK(new ExceptionEq())).Wrap();

        [Theory]
        [MemberData(nameof(MonadLaws))]
        public void FailureMonadLaw(Law<TestArgs<TryF, string, int, long>> law)
        {
            var args = TestArgs.Default<TryF>();
            args.LiftedA = GetFailure<string>().K();
            args.LiftedB = GetFailure<int>().K();
            args.LiftedFuncAtoB = GetFailure<Func<string, int>>().K();
            args.LiftedFuncBtoC = GetFailure<Func<int, long>>().K();
            args.FuncAtoLiftedB = _ => GetFailure<int>().K();
            args.FuncBtoLiftedC = _ => GetFailure<long>().K();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(MonadLaws))]
        public void SuccessMonadLaw(Law<TestArgs<TryF, string, int, long>> law)
        {
            var args = TestArgs.Default<TryF>();
            args.LiftedA = new Success<string>(args.A);
            args.LiftedB = new Success<int>(args.B);
            args.LiftedFuncAtoB = new Success<Func<string, int>>(args.FuncAtoB);
            args.LiftedFuncBtoC = new Success<Func<int, long>>(args.FuncBtoC);
            args.FuncAtoLiftedB = a => new Success<int>(args.FuncAtoB(a));
            args.FuncBtoLiftedC = b => new Success<long>(args.FuncBtoC(b));

            law.TestLaw(args).ShouldBe(true);
        }
    }
}