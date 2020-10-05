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
        [Theory]
        [ClassData(typeof(EqLawsTests<ListEq<string, DefaultEq<string>>, List<string>>))]
        public void EqLaw(Law<List<string>> law)
        {
            law.TestLaw(new List<string>()).ShouldBe(true);
            law.TestLaw(new List<string> {"1"}).ShouldBe(true);
        }

        [Theory]
        [ClassData(typeof(InvariantLawsTests<ListInvariant, ListF, ListEqK, string, int, long>))]
        public void EmptyListInvariantLaw(Law<TestArgs<ListF, string, int, long>> law)
        {
            var args = TestArgs.Default<ListF>();
            args.LiftedA = new List<string>().K();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [ClassData(typeof(InvariantLawsTests<ListInvariant, ListF, ListEqK, string, int, long>))]
        public void PopulatedListInvariantLaw(Law<TestArgs<ListF, string, int, long>> law)
        {
            var args = TestArgs.Default<ListF>();
            args.LiftedA = new List<string> {args.A}.K();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [ClassData(typeof(FunctorLawsTests<ListFunctor, ListF, ListEqK, string, int, long>))]
        public void EmptyListFunctorLaw(Law<TestArgs<ListF, string, int, long>> law)
        {
            var args = TestArgs.Default<ListF>();
            args.LiftedA = new List<string>().K();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [ClassData(typeof(FunctorLawsTests<ListFunctor, ListF, ListEqK, string, int, long>))]
        public void PopulatedListFunctorLaw(Law<TestArgs<ListF, string, int, long>> law)
        {
            var args = TestArgs.Default<ListF>();
            args.LiftedA = new List<string> {args.A}.K();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [ClassData(typeof(ApplyLawsTests<ListApply, ListF, ListEqK, string, int, long>))]
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
        [ClassData(typeof(ApplyLawsTests<ListApply, ListF, ListEqK, string, int, long>))]
        public void PopulatedListApplyLaw(Law<TestArgs<ListF, string, int, long>> law)
        {
            var args = TestArgs.Default<ListF>();
            args.LiftedA = new List<string> {args.A}.K();
            args.LiftedB = new List<int> {args.B}.K();
            args.LiftedFuncAtoB = new List<Func<string, int>> {args.FuncAtoB}.K();
            args.LiftedFuncBtoC = new List<Func<int, long>> {args.FuncBtoC}.K();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [ClassData(typeof(ApplicativeLawsTests<ListApplicative, ListF, ListEqK, string, int, long>))]
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
        [ClassData(typeof(ApplicativeLawsTests<ListApplicative, ListF, ListEqK, string, int, long>))]
        public void PopulatedListApplicativeLaw(Law<TestArgs<ListF, string, int, long>> law)
        {
            var args = TestArgs.Default<ListF>();
            args.LiftedA = new List<string> {args.A}.K();
            args.LiftedB = new List<int> {args.B}.K();
            args.LiftedFuncAtoB = new List<Func<string, int>> {args.FuncAtoB}.K();
            args.LiftedFuncBtoC = new List<Func<int, long>> {args.FuncBtoC}.K();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [ClassData(typeof(FlatMapLawsTests<ListFlatMap, ListF, ListEqK, string, int, long>))]
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
        [ClassData(typeof(FlatMapLawsTests<ListFlatMap, ListF, ListEqK, string, int, long>))]
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
    }
}