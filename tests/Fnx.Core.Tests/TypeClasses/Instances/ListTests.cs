using System;
using System.Collections.Generic;
using Fnx.Core.DataTypes;
using Fnx.Core.Tests.TypeClasses.Laws;
using Fnx.Core.TypeClasses.Instances;
using Shouldly;
using Xunit;

namespace Fnx.Core.Tests.TypeClasses.Instances
{
    public class ListTests
    {
        public static IEnumerable<object[]> EqLaws() =>
            new EqLawsTests<List<string>>(ListK.Eq(StringK.Eq())).Wrap();

        [Theory]
        [MemberData(nameof(EqLaws))]
        public void EqLaw(Law<List<string>> law)
        {
            law.TestLaw(new List<string>()).ShouldBe(true);
            law.TestLaw(new List<string> {"1"}).ShouldBe(true);
        }

        public static IEnumerable<object[]> InvariantLaws() =>
            new InvariantLawsTests<ListF, string, int, long>(ListK.Invariant(), ListK.EqK()).Wrap();

        [Theory]
        [MemberData(nameof(InvariantLaws))]
        public void EmptyListInvariantLaw(Law<TestArgs<ListF, string, int, long>> law)
        {
            var args = TestArgs.Default<ListF>();
            args.LiftedA = new List<string>().K();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(InvariantLaws))]
        public void PopulatedListInvariantLaw(Law<TestArgs<ListF, string, int, long>> law)
        {
            var args = TestArgs.Default<ListF>();
            args.LiftedA = new List<string> {args.A}.K();

            law.TestLaw(args).ShouldBe(true);
        }

        public static IEnumerable<object[]> FunctorLaws() =>
            new FunctorLawsTests<ListF, string, int, long>(ListK.Functor(), ListK.EqK()).Wrap();

        [Theory]
        [MemberData(nameof(FunctorLaws))]
        public void EmptyListFunctorLaw(Law<TestArgs<ListF, string, int, long>> law)
        {
            var args = TestArgs.Default<ListF>();
            args.LiftedA = new List<string>().K();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(FunctorLaws))]
        public void PopulatedListFunctorLaw(Law<TestArgs<ListF, string, int, long>> law)
        {
            var args = TestArgs.Default<ListF>();
            args.LiftedA = new List<string> {args.A}.K();

            law.TestLaw(args).ShouldBe(true);
        }

        public static IEnumerable<object[]> ApplyLaws() =>
            new ApplyLawsTests<ListF, string, int, long>(ListK.Apply(), ListK.EqK()).Wrap();

        [Theory]
        [MemberData(nameof(ApplyLaws))]
        public void EmptyListApplyLaw(Law<TestArgs<ListF, string, int, long>> law)
        {
            var args = TestArgs.Default<ListF>();
            args.LiftedA = new List<string>().K();
            args.LiftedB = new List<int>().K();
            args.LiftedFuncAtoB = new List<Func<string, int>>().K();
            args.LiftedFuncBtoC = new List<Func<int, long>>().K();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(ApplyLaws))]
        public void PopulatedListApplyLaw(Law<TestArgs<ListF, string, int, long>> law)
        {
            var args = TestArgs.Default<ListF>();
            args.LiftedA = new List<string> {args.A}.K();
            args.LiftedB = new List<int> {args.B}.K();
            args.LiftedFuncAtoB = new List<Func<string, int>> {args.FuncAtoB}.K();
            args.LiftedFuncBtoC = new List<Func<int, long>> {args.FuncBtoC}.K();

            law.TestLaw(args).ShouldBe(true);
        }

        public static IEnumerable<object[]> ApplicativeLaws() =>
            new ApplicativeLawsTests<ListF, string, int, long>(ListK.Applicative(), ListK.EqK()).Wrap();

        [Theory]
        [MemberData(nameof(ApplicativeLaws))]
        public void EmptyListApplicativeLaw(Law<TestArgs<ListF, string, int, long>> law)
        {
            var args = TestArgs.Default<ListF>();
            args.LiftedA = new List<string>().K();
            args.LiftedB = new List<int>().K();
            args.LiftedFuncAtoB = new List<Func<string, int>>().K();
            args.LiftedFuncBtoC = new List<Func<int, long>>().K();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(ApplicativeLaws))]
        public void PopulatedListApplicativeLaw(Law<TestArgs<ListF, string, int, long>> law)
        {
            var args = TestArgs.Default<ListF>();
            args.LiftedA = new List<string> {args.A}.K();
            args.LiftedB = new List<int> {args.B}.K();
            args.LiftedFuncAtoB = new List<Func<string, int>> {args.FuncAtoB}.K();
            args.LiftedFuncBtoC = new List<Func<int, long>> {args.FuncBtoC}.K();

            law.TestLaw(args).ShouldBe(true);
        }

        public static IEnumerable<object[]> FlatMapLaws() =>
            new FlatMapLawsTests<ListF, string, int, long>(ListK.FlatMap(), ListK.EqK()).Wrap();

        [Theory]
        [MemberData(nameof(FlatMapLaws))]
        public void EmptyListFlatMapLaw(Law<TestArgs<ListF, string, int, long>> law)
        {
            var args = TestArgs.Default<ListF>();
            args.LiftedA = new List<string>().K();
            args.LiftedB = new List<int>().K();
            args.LiftedFuncAtoB = new List<Func<string, int>>().K();
            args.LiftedFuncBtoC = new List<Func<int, long>>().K();
            args.FuncAtoLiftedB = _ => new List<int>().K();
            args.FuncBtoLiftedC = _ => new List<long>().K();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(FlatMapLaws))]
        public void PopulatedListFlatMapLaw(Law<TestArgs<ListF, string, int, long>> law)
        {
            var args = TestArgs.Default<ListF>();
            args.LiftedA = new List<string> {args.A}.K();
            args.LiftedB = new List<int> {args.B}.K();
            args.LiftedFuncAtoB = new List<Func<string, int>> {args.FuncAtoB}.K();
            args.LiftedFuncBtoC = new List<Func<int, long>> {args.FuncBtoC}.K();
            args.FuncAtoLiftedB = a => new List<int> {args.FuncAtoB(a)}.K();
            args.FuncBtoLiftedC = b => new List<long> {args.FuncBtoC(b)}.K();

            law.TestLaw(args).ShouldBe(true);
        }

        public static IEnumerable<object[]> MonadLaws() =>
            new MonadLawsTests<ListF, string, int, long>(ListK.Monad(), ListK.EqK()).Wrap();

        [Theory]
        [MemberData(nameof(MonadLaws))]
        public void EmptyListMonadLaw(Law<TestArgs<ListF, string, int, long>> law)
        {
            var args = TestArgs.Default<ListF>();
            args.LiftedA = new List<string>().K();
            args.LiftedB = new List<int>().K();
            args.LiftedFuncAtoB = new List<Func<string, int>>().K();
            args.LiftedFuncBtoC = new List<Func<int, long>>().K();
            args.FuncAtoLiftedB = _ => new List<int>().K();
            args.FuncBtoLiftedC = _ => new List<long>().K();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [MemberData(nameof(MonadLaws))]
        public void PopulatedListMonadLaw(Law<TestArgs<ListF, string, int, long>> law)
        {
            var args = TestArgs.Default<ListF>();
            args.LiftedA = new List<string> {args.A}.K();
            args.LiftedB = new List<int> {args.B}.K();
            args.LiftedFuncAtoB = new List<Func<string, int>> {args.FuncAtoB}.K();
            args.LiftedFuncBtoC = new List<Func<int, long>> {args.FuncBtoC}.K();
            args.FuncAtoLiftedB = a => new List<int> {args.FuncAtoB(a)}.K();
            args.FuncBtoLiftedC = b => new List<long> {args.FuncBtoC(b)}.K();

            law.TestLaw(args).ShouldBe(true);
        }
    }
}