using System;
using System.Collections.Generic;
using Fnx.Core.DataTypes;
using Fnx.Core.Tests.TypeClasses.Laws;
using Fnx.Core.TypeClasses.Instances;
using Shouldly;
using Xunit;
using static Fnx.Core.Prelude;

namespace Fnx.Core.Tests.TypeClasses.Instances
{
    public class ResultTests
    {
        public static IEnumerable<object[]> EqLaws() =>
            new EqLawsTests<Result<int, string>>(ResultK.Eq(Default<int>.Eq(), Default<string>.Eq())).Wrap();

        [Theory]
        [MemberData(nameof(EqLaws))]
        public void EqLaw(Law<Result<int, string>> law)
        {
            law.TestLaw(Ok(1)).ShouldBe(true);
            law.TestLaw(Error("error")).ShouldBe(true);
        }

        public static IEnumerable<object[]> InvariantLaws() =>
            new InvariantLawsTests<ResultOkF<bool>, string, int, long>(
                ResultK<bool>.Invariant(), ResultK.EqK(Default<bool>.Eq())).Wrap();

        [Theory]
        [MemberData(nameof(InvariantLaws))]
        public void ErrorInvariantLaw(Law<TestArgs<ResultOkF<bool>, string, int, long>> law)
        {
            var args = TestArgs.Default<ResultOkF<bool>>();
            args.LiftedA = Error(false).K<string, bool>();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(InvariantLaws))]
        public void OkInvariantLaw(Law<TestArgs<ResultOkF<bool>, string, int, long>> law)
        {
            var args = TestArgs.Default<ResultOkF<bool>>();
            args.LiftedA = Ok(args.A).K<string, bool>();

            law.TestLaw(args).ShouldBe(true);
        }

        public static IEnumerable<object[]> FunctorLaws() =>
            new FunctorLawsTests<ResultOkF<bool>, string, int, long>(
                ResultK<bool>.Functor(), ResultK.EqK(Default<bool>.Eq())).Wrap();

        [Theory]
        [MemberData(nameof(FunctorLaws))]
        public void ErrorFunctorLaw(Law<TestArgs<ResultOkF<bool>, string, int, long>> law)
        {
            var args = TestArgs.Default<ResultOkF<bool>>();
            args.LiftedA = Error(false).K<string, bool>();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(FunctorLaws))]
        public void OkFunctorLaw(Law<TestArgs<ResultOkF<bool>, string, int, long>> law)
        {
            var args = TestArgs.Default<ResultOkF<bool>>();
            args.LiftedA = Ok(args.A).K<string, bool>();

            law.TestLaw(args).ShouldBe(true);
        }

        public static IEnumerable<object[]> ApplyLaws() =>
            new ApplyLawsTests<ResultOkF<bool>, string, int, long>(
                ResultK<bool>.Apply(), ResultK.EqK(Default<bool>.Eq())).Wrap();

        [Theory]
        [MemberData(nameof(ApplyLaws))]
        public void ErrorApplyLaw(Law<TestArgs<ResultOkF<bool>, string, int, long>> law)
        {
            var args = TestArgs.Default<ResultOkF<bool>>();
            args.LiftedA = Error(false).K<string, bool>();
            args.LiftedB = Error(false).K<int, bool>();
            args.LiftedFuncAtoB = Error(false).K<Func<string, int>, bool>();
            args.LiftedFuncBtoC = Error(false).K<Func<int, long>, bool>();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(ApplyLaws))]
        public void OkApplyLaw(Law<TestArgs<ResultOkF<bool>, string, int, long>> law)
        {
            var args = TestArgs.Default<ResultOkF<bool>>();
            args.LiftedA = Ok(args.A).K<string, bool>();
            args.LiftedB = Ok(args.B).K<int, bool>();
            args.LiftedFuncAtoB = Ok(args.FuncAtoB).K<Func<string, int>, bool>();
            args.LiftedFuncBtoC = Ok(args.FuncBtoC).K<Func<int, long>, bool>();

            law.TestLaw(args).ShouldBe(true);
        }

        public static IEnumerable<object[]> ApplicativeLaws() =>
            new ApplicativeLawsTests<ResultOkF<bool>, string, int, long>(
                ResultK<bool>.Applicative(), ResultK.EqK(Default<bool>.Eq())).Wrap();

        [Theory]
        [MemberData(nameof(ApplicativeLaws))]
        public void ErrorApplicativeLaw(Law<TestArgs<ResultOkF<bool>, string, int, long>> law)
        {
            var args = TestArgs.Default<ResultOkF<bool>>();
            args.LiftedA = Error(false).K<string, bool>();
            args.LiftedB = Error(false).K<int, bool>();
            args.LiftedFuncAtoB = Error(false).K<Func<string, int>, bool>();
            args.LiftedFuncBtoC = Error(false).K<Func<int, long>, bool>();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(ApplicativeLaws))]
        public void OkApplicativeLaw(Law<TestArgs<ResultOkF<bool>, string, int, long>> law)
        {
            var args = TestArgs.Default<ResultOkF<bool>>();
            args.LiftedA = Ok(args.A).K<string, bool>();
            args.LiftedB = Ok(args.B).K<int, bool>();
            args.LiftedFuncAtoB = Ok(args.FuncAtoB).K<Func<string, int>, bool>();
            args.LiftedFuncBtoC = Ok(args.FuncBtoC).K<Func<int, long>, bool>();

            law.TestLaw(args).ShouldBe(true);
        }

        public static IEnumerable<object[]> FlatMapLaws() =>
            new FlatMapLawsTests<ResultOkF<bool>, string, int, long>(
                ResultK<bool>.FlatMap(), ResultK.EqK(Default<bool>.Eq())).Wrap();

        [Theory]
        [MemberData(nameof(FlatMapLaws))]
        public void ErrorFlatMapLaw(Law<TestArgs<ResultOkF<bool>, string, int, long>> law)
        {
            var args = TestArgs.Default<ResultOkF<bool>>();
            args.LiftedA = Error(false).K<string, bool>();
            args.LiftedB = Error(false).K<int, bool>();
            args.LiftedFuncAtoB = Error(false).K<Func<string, int>, bool>();
            args.LiftedFuncBtoC = Error(false).K<Func<int, long>, bool>();
            args.FuncAtoLiftedB = _ => Error(false).K<int, bool>();
            args.FuncBtoLiftedC = _ => Error(false).K<long, bool>();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(FlatMapLaws))]
        public void OkFlatMapLaw(Law<TestArgs<ResultOkF<bool>, string, int, long>> law)
        {
            var args = TestArgs.Default<ResultOkF<bool>>();
            args.LiftedA = Ok(args.A).K<string, bool>();
            args.LiftedB = Ok(args.B).K<int, bool>();
            args.LiftedFuncAtoB = Ok(args.FuncAtoB).K<Func<string, int>, bool>();
            args.LiftedFuncBtoC = Ok(args.FuncBtoC).K<Func<int, long>, bool>();
            args.FuncAtoLiftedB = a => Ok(args.FuncAtoB(a)).K<int, bool>();
            args.FuncBtoLiftedC = b => Ok(args.FuncBtoC(b)).K<long, bool>();

            law.TestLaw(args).ShouldBe(true);
        }

        public static IEnumerable<object[]> MonadLaws() =>
            new MonadLawsTests<ResultOkF<bool>, string, int, long>(
                ResultK<bool>.Monad(), ResultK.EqK(Default<bool>.Eq())).Wrap();

        [Theory]
        [MemberData(nameof(MonadLaws))]
        public void ErrorMonadLaw(Law<TestArgs<ResultOkF<bool>, string, int, long>> law)
        {
            var args = TestArgs.Default<ResultOkF<bool>>();
            args.LiftedA = Error(false).K<string, bool>();
            args.LiftedB = Error(false).K<int, bool>();
            args.LiftedFuncAtoB = Error(false).K<Func<string, int>, bool>();
            args.LiftedFuncBtoC = Error(false).K<Func<int, long>, bool>();
            args.FuncAtoLiftedB = _ => Error(false).K<int, bool>();
            args.FuncBtoLiftedC = _ => Error(false).K<long, bool>();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(MonadLaws))]
        public void OkMonadLaw(Law<TestArgs<ResultOkF<bool>, string, int, long>> law)
        {
            var args = TestArgs.Default<ResultOkF<bool>>();
            args.LiftedA = Ok(args.A).K<string, bool>();
            args.LiftedB = Ok(args.B).K<int, bool>();
            args.LiftedFuncAtoB = Ok(args.FuncAtoB).K<Func<string, int>, bool>();
            args.LiftedFuncBtoC = Ok(args.FuncBtoC).K<Func<int, long>, bool>();
            args.FuncAtoLiftedB = a => Ok(args.FuncAtoB(a)).K<int, bool>();
            args.FuncBtoLiftedC = b => Ok(args.FuncBtoC(b)).K<long, bool>();

            law.TestLaw(args).ShouldBe(true);
        }
    }
}