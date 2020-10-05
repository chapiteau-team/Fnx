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
        [Theory]
        [ClassData(typeof(EqLawsTests<OptionEq<string, DefaultEq<string>>, Option<string>>))]
        public void EqLaw(Law<Option<string>> law)
        {
            law.TestLaw(None).ShouldBe(true);
            law.TestLaw(Some("1")).ShouldBe(true);
        }

        [Theory]
        [ClassData(typeof(InvariantLawsTests<OptionInvariant, OptionF, OptionEqK, string, int, long>))]
        public void NoneInvariantLaw(Law<TestArgs<OptionF, string, int, long>> law)
        {
            var args = TestArgs.Default<OptionF>();
            args.LiftedA = None.K<string>();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [ClassData(typeof(InvariantLawsTests<OptionInvariant, OptionF, OptionEqK, string, int, long>))]
        public void SomeInvariantLaw(Law<TestArgs<OptionF, string, int, long>> law)
        {
            var args = TestArgs.Default<OptionF>();
            args.LiftedA = Some(args.A);

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [ClassData(typeof(FunctorLawsTests<OptionFunctor, OptionF, OptionEqK, string, int, long>))]
        public void NoneFunctorLaw(Law<TestArgs<OptionF, string, int, long>> law)
        {
            var args = TestArgs.Default<OptionF>();
            args.LiftedA = None.K<string>();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [ClassData(typeof(FunctorLawsTests<OptionFunctor, OptionF, OptionEqK, string, int, long>))]
        public void SomeFunctorLaw(Law<TestArgs<OptionF, string, int, long>> law)
        {
            var args = TestArgs.Default<OptionF>();
            args.LiftedA = Some(args.A);

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [ClassData(typeof(ApplyLawsTests<OptionApply, OptionF, OptionEqK, string, int, long>))]
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
        [ClassData(typeof(ApplyLawsTests<OptionApply, OptionF, OptionEqK, string, int, long>))]
        public void SomeApplyLaw(Law<TestArgs<OptionF, string, int, long>> law)
        {
            var args = TestArgs.Default<OptionF>();
            args.LiftedA = Some(args.A);
            args.LiftedB = Some(args.B);
            args.LiftedFuncAtoB = Some(args.FuncAtoB);
            args.LiftedFuncBtoC = Some(args.FuncBtoC);

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [ClassData(typeof(ApplicativeLawsTests<OptionApplicative, OptionF, OptionEqK, string, int, long>))]
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
        [ClassData(typeof(ApplicativeLawsTests<OptionApplicative, OptionF, OptionEqK, string, int, long>))]
        public void SomeApplicativeLaw(Law<TestArgs<OptionF, string, int, long>> law)
        {
            var args = TestArgs.Default<OptionF>();
            args.LiftedA = Some(args.A);
            args.LiftedB = Some(args.B);
            args.LiftedFuncAtoB = Some(args.FuncAtoB);
            args.LiftedFuncBtoC = Some(args.FuncBtoC);

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [ClassData(typeof(FlatMapLawsTests<OptionFlatMap, OptionF, OptionEqK, string, int, long>))]
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
        [ClassData(typeof(FlatMapLawsTests<OptionFlatMap, OptionF, OptionEqK, string, int, long>))]
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
    }
}