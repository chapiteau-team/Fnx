using System;
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
        [Theory]
        [ClassData(typeof(EqLawsTests<ResultEq<int, string, DefaultEq<int>, DefaultEq<string>>, Result<int, string>>))]
        public void EqLaw(Law<Result<int, string>> law)
        {
            law.TestLaw(Ok(1)).ShouldBe(true);
            law.TestLaw(Error("error")).ShouldBe(true);
        }

        [Theory]
        [ClassData(
            typeof(InvariantLawsTests<ResultInvariant<bool>, ResultOkF<bool>, ResultEqK<bool, DefaultEq<bool>>,
                string, int, long>))]
        public void ErrorInvariantLaw(Law<TestArgs<ResultOkF<bool>, string, int, long>> law)
        {
            var args = TestArgs.Default<ResultOkF<bool>>();
            args.LiftedA = Error(false).K<string, bool>();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [ClassData(
            typeof(InvariantLawsTests<ResultInvariant<bool>, ResultOkF<bool>, ResultEqK<bool, DefaultEq<bool>>,
                string, int, long>))]
        public void OkInvariantLaw(Law<TestArgs<ResultOkF<bool>, string, int, long>> law)
        {
            var args = TestArgs.Default<ResultOkF<bool>>();
            args.LiftedA = Ok(args.A).K<string, bool>();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [ClassData(
            typeof(FunctorLawsTests<ResultFunctor<bool>, ResultOkF<bool>, ResultEqK<bool, DefaultEq<bool>>,
                string, int, long>))]
        public void ErrorFunctorLaw(Law<TestArgs<ResultOkF<bool>, string, int, long>> law)
        {
            var args = TestArgs.Default<ResultOkF<bool>>();
            args.LiftedA = Error(false).K<string, bool>();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [ClassData(
            typeof(FunctorLawsTests<ResultFunctor<bool>, ResultOkF<bool>, ResultEqK<bool, DefaultEq<bool>>,
                string, int, long>))]
        public void OkFunctorLaw(Law<TestArgs<ResultOkF<bool>, string, int, long>> law)
        {
            var args = TestArgs.Default<ResultOkF<bool>>();
            args.LiftedA = Ok(args.A).K<string, bool>();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [ClassData(
            typeof(ApplyLawsTests<ResultApply<bool>, ResultOkF<bool>, ResultEqK<bool, DefaultEq<bool>>,
                string, int, long>))]
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
        [ClassData(
            typeof(ApplyLawsTests<ResultApply<bool>, ResultOkF<bool>, ResultEqK<bool, DefaultEq<bool>>,
                string, int, long>))]
        public void OkApplyLaw(Law<TestArgs<ResultOkF<bool>, string, int, long>> law)
        {
            var args = TestArgs.Default<ResultOkF<bool>>();
            args.LiftedA = Ok(args.A).K<string, bool>();
            args.LiftedB = Ok(args.B).K<int, bool>();
            args.LiftedFuncAtoB = Ok(args.FuncAtoB).K<Func<string, int>, bool>();
            args.LiftedFuncBtoC = Ok(args.FuncBtoC).K<Func<int, long>, bool>();

            law.TestLaw(args).ShouldBe(true);
        }

        [Theory]
        [ClassData(
            typeof(ApplicativeLawsTests<ResultApplicative<bool>, ResultOkF<bool>, ResultEqK<bool, DefaultEq<bool>>,
                string, int, long>))]
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
        [ClassData(
            typeof(ApplicativeLawsTests<ResultApplicative<bool>, ResultOkF<bool>, ResultEqK<bool, DefaultEq<bool>>,
                string, int, long>))]
        public void OkApplicativeLaw(Law<TestArgs<ResultOkF<bool>, string, int, long>> law)
        {
            var args = TestArgs.Default<ResultOkF<bool>>();
            args.LiftedA = Ok(args.A).K<string, bool>();
            args.LiftedB = Ok(args.B).K<int, bool>();
            args.LiftedFuncAtoB = Ok(args.FuncAtoB).K<Func<string, int>, bool>();
            args.LiftedFuncBtoC = Ok(args.FuncBtoC).K<Func<int, long>, bool>();

            law.TestLaw(args).ShouldBe(true);
        }
    }
}