using Fnx.Core.DataTypes;
using Fnx.Core.Tests.TypeClasses.Laws;
using Fnx.Core.TypeClasses.Instances;
using Fnx.Core.Types;
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
            law.Test(Ok(1)).ShouldBe(true);
            law.Test(Error("error")).ShouldBe(true);
        }

        [Theory]
        [ClassData(typeof(
            InvariantLawsTests<ResultInvariant<string>, ResultOkF<string>, ResultEqK<string, DefaultEq<string>>>))]
        public void InvariantLaw(Law<IKind<ResultOkF<string>, string>> law)
        {
            Result<string, string> error = Error("err");
            law.Test(error).ShouldBe(true);

            Result<string, string> ok = Ok("1");
            law.Test(ok).ShouldBe(true);
        }

        [Theory]
        [ClassData(
            typeof(FunctorLawsTests<ResultFunctor<string>, ResultOkF<string>, ResultEqK<string, DefaultEq<string>>>))]
        public void FunctorLaw(Law<IKind<ResultOkF<string>, string>> law)
        {
            Result<string, string> error = Error("err");
            law.Test(error).ShouldBe(true);

            Result<string, string> ok = Ok("1");
            law.Test(ok).ShouldBe(true);
        }

        [Theory]
        [ClassData(
            typeof(ApplyLawsTests<ResultApply<string>, ResultOkF<string>, ResultEqK<string, DefaultEq<string>>>))]
        public void ApplyLaw(Law<IKind<ResultOkF<string>, string>> law)
        {
            Result<string, string> error = Error("err");
            law.Test(error).ShouldBe(true);

            Result<string, string> ok = Ok("1");
            law.Test(ok).ShouldBe(true);
        }
    }
}