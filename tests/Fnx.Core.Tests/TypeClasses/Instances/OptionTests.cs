using Fnx.Core.DataTypes;
using Fnx.Core.Tests.TypeClasses.Laws;
using Fnx.Core.TypeClasses.Instances;
using Fnx.Core.Types;
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
            law.Test(None).ShouldBe(true);
            law.Test(Some("1")).ShouldBe(true);
        }

        [Theory]
        [ClassData(typeof(InvariantLawsTests<OptionInvariant, OptionF, OptionEqK>))]
        public void InvariantLaw(Law<IKind<OptionF, string>> law)
        {
            Option<string> none = None;
            law.Test(none).ShouldBe(true);

            law.Test(Some("1")).ShouldBe(true);
        }

        [Theory]
        [ClassData(typeof(FunctorLawsTests<OptionFunctor, OptionF, OptionEqK>))]
        public void FunctorLaw(Law<IKind<OptionF, string>> law)
        {
            Option<string> none = None;
            law.Test(none).ShouldBe(true);

            law.Test(Some("1")).ShouldBe(true);
        }

        [Theory]
        [ClassData(typeof(ApplyLawsTests<OptionApply, OptionF, OptionEqK>))]
        public void ApplyLaw(Law<IKind<OptionF, string>> law)
        {
            Option<string> none = None;
            law.Test(none).ShouldBe(true);

            law.Test(Some("1")).ShouldBe(true);
        }
    }
}