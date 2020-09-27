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
        [ClassData(
            typeof(FunctorLawTests<ResultFunctor<string>, ResultOkF<string>, ResultEqK<string, DefaultEq<string>>>))]
        public void CorrectFunctor(Law<ResultOkF<string>, string> law)
        {
            Result<string, string> error = Error("err");
            law.Test(error).ShouldBe(true);

            Result<string, string> ok = Ok("1");
            law.Test(ok).ShouldBe(true);
        }
    }
}