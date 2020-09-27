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
        [ClassData(typeof(FunctorLawTests<OptionFunctor, OptionF, OptionEqK>))]
        public void CorrectFunctor(Law<OptionF, string> law)
        {
            Option<string> none = None;
            law.Test(none).ShouldBe(true);

            law.Test(Some("1")).ShouldBe(true);
        }
    }
}