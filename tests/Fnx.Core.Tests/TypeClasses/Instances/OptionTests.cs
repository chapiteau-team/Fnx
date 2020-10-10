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
    public class OptionTests
    {
        public static IEnumerable<object[]> EqLaws() =>
            new EqLawsTests<Option<string>>(OptionK.Eq(Default<string>.Eq())).Wrap();

        [Theory]
        [MemberData(nameof(EqLaws))]
        public void EqLaw(Law<Option<string>> law)
        {
            law.TestLaw(None).ShouldBe(true);
            law.TestLaw(Some("1")).ShouldBe(true);
        }

        public static IEnumerable<object[]> InvariantLaws() =>
            new InvariantLawsTests<OptionF, string, int, long>(OptionK.Invariant(), OptionK.EqK()).Wrap();

        [Theory]
        [MemberData(nameof(InvariantLaws))]
        public void NoneInvariantLaw(Law<TestArgs<OptionF, string, int, long>> law)
        {
            var args = TestArgs.Default<OptionF>();
            args.LiftedA = None.K<string>();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(InvariantLaws))]
        public void SomeInvariantLaw(Law<TestArgs<OptionF, string, int, long>> law)
        {
            var args = TestArgs.Default<OptionF>();
            args.LiftedA = Some(args.A);

            law.TestLaw(args).ShouldBe(true);
        }

        public static IEnumerable<object[]> FunctorLaws() =>
            new FunctorLawsTests<OptionF, string, int, long>(OptionK.Functor(), OptionK.EqK()).Wrap();

        [Theory]
        [MemberData(nameof(FunctorLaws))]
        public void NoneFunctorLaw(Law<TestArgs<OptionF, string, int, long>> law)
        {
            var args = TestArgs.Default<OptionF>();
            args.LiftedA = None.K<string>();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(FunctorLaws))]
        public void SomeFunctorLaw(Law<TestArgs<OptionF, string, int, long>> law)
        {
            var args = TestArgs.Default<OptionF>();
            args.LiftedA = Some(args.A);

            law.TestLaw(args).ShouldBe(true);
        }

        public static IEnumerable<object[]> ApplyLaws() =>
            new ApplyLawsTests<OptionF, string, int, long>(OptionK.Apply(), OptionK.EqK()).Wrap();

        [Theory]
        [MemberData(nameof(ApplyLaws))]
        public void NoneApplyLaw(Law<TestArgs<OptionF, string, int, long>> law)
        {
            var args = TestArgs.Default<OptionF>();
            args.LiftedA = None.K<string>();
            args.LiftedB = None.K<int>();
            args.LiftedFuncAtoB = None.K<Func<string, int>>();
            args.LiftedFuncBtoC = None.K<Func<int, long>>();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(ApplyLaws))]
        public void SomeApplyLaw(Law<TestArgs<OptionF, string, int, long>> law)
        {
            var args = TestArgs.Default<OptionF>();
            args.LiftedA = Some(args.A);
            args.LiftedB = Some(args.B);
            args.LiftedFuncAtoB = Some(args.FuncAtoB);
            args.LiftedFuncBtoC = Some(args.FuncBtoC);

            law.TestLaw(args).ShouldBe(true);
        }

        public static IEnumerable<object[]> ApplicativeLaws() =>
            new ApplicativeLawsTests<OptionF, string, int, long>(OptionK.Applicative(), OptionK.EqK()).Wrap();

        [Theory]
        [MemberData(nameof(ApplicativeLaws))]
        public void NoneApplicativeLaw(Law<TestArgs<OptionF, string, int, long>> law)
        {
            var args = TestArgs.Default<OptionF>();
            args.LiftedA = None.K<string>();
            args.LiftedB = None.K<int>();
            args.LiftedFuncAtoB = None.K<Func<string, int>>();
            args.LiftedFuncBtoC = None.K<Func<int, long>>();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(ApplicativeLaws))]
        public void SomeApplicativeLaw(Law<TestArgs<OptionF, string, int, long>> law)
        {
            var args = TestArgs.Default<OptionF>();
            args.LiftedA = Some(args.A);
            args.LiftedB = Some(args.B);
            args.LiftedFuncAtoB = Some(args.FuncAtoB);
            args.LiftedFuncBtoC = Some(args.FuncBtoC);

            law.TestLaw(args).ShouldBe(true);
        }

        public static IEnumerable<object[]> FlatMapLaws() =>
            new FlatMapLawsTests<OptionF, string, int, long>(OptionK.FlatMap(), OptionK.EqK()).Wrap();

        [Theory]
        [MemberData(nameof(FlatMapLaws))]
        public void NoneFlatMapLaw(Law<TestArgs<OptionF, string, int, long>> law)
        {
            var args = TestArgs.Default<OptionF>();
            args.LiftedA = None.K<string>();
            args.LiftedB = None.K<int>();
            args.LiftedFuncAtoB = None.K<Func<string, int>>();
            args.LiftedFuncBtoC = None.K<Func<int, long>>();
            args.FuncAtoLiftedB = _ => None.K<int>();
            args.FuncBtoLiftedC = _ => None.K<long>();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(FlatMapLaws))]
        public void SomeFlatMapLaw(Law<TestArgs<OptionF, string, int, long>> law)
        {
            var args = TestArgs.Default<OptionF>();
            args.LiftedA = Some(args.A);
            args.LiftedB = Some(args.B);
            args.LiftedFuncAtoB = Some(args.FuncAtoB);
            args.LiftedFuncBtoC = Some(args.FuncBtoC);
            args.FuncAtoLiftedB = a => Some(args.FuncAtoB(a));
            args.FuncBtoLiftedC = b => Some(args.FuncBtoC(b));

            law.TestLaw(args).ShouldBe(true);
        }
        
        public static IEnumerable<object[]> MonadLaws() =>
            new MonadLawsTests<OptionF, string, int, long>(OptionK.Monad(), OptionK.EqK()).Wrap();

        [Theory]
        [MemberData(nameof(MonadLaws))]
        public void NoneMonadLaw(Law<TestArgs<OptionF, string, int, long>> law)
        {
            var args = TestArgs.Default<OptionF>();
            args.LiftedA = None.K<string>();
            args.LiftedB = None.K<int>();
            args.LiftedFuncAtoB = None.K<Func<string, int>>();
            args.LiftedFuncBtoC = None.K<Func<int, long>>();
            args.FuncAtoLiftedB = _ => None.K<int>();
            args.FuncBtoLiftedC = _ => None.K<long>();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(MonadLaws))]
        public void SomeMonadLaw(Law<TestArgs<OptionF, string, int, long>> law)
        {
            var args = TestArgs.Default<OptionF>();
            args.LiftedA = Some(args.A);
            args.LiftedB = Some(args.B);
            args.LiftedFuncAtoB = Some(args.FuncAtoB);
            args.LiftedFuncBtoC = Some(args.FuncBtoC);
            args.FuncAtoLiftedB = a => Some(args.FuncAtoB(a));
            args.FuncBtoLiftedC = b => Some(args.FuncBtoC(b));

            law.TestLaw(args).ShouldBe(true);
        }
    }
}