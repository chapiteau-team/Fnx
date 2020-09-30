using System.Collections.Generic;
using System.Linq;
using Fnx.Core.DataTypes;
using Fnx.Core.Tests.TypeClasses.Laws;
using Fnx.Core.TypeClasses.Instances;
using Fnx.Core.Types;
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
            law.Test(Enumerable.Empty<string>().ToList()).ShouldBe(true);
            law.Test(new List<string> {"1", "2", "3"}).ShouldBe(true);
        }

        [Theory, ClassData(typeof(InvariantLawsTests<ListInvariant, ListF, ListEqK>))]
        public void InvariantLaw(Law<IKind<ListF, string>> law)
        {
            var empty = Enumerable.Empty<string>().ToList();
            law.Test(empty.ToKind()).ShouldBe(true);

            var list = new List<string> {"1", "2", "3"};
            law.Test(list.ToKind()).ShouldBe(true);
        }

        [Theory, ClassData(typeof(FunctorLawsTests<ListFunctor, ListF, ListEqK>))]
        public void FunctorLaw(Law<IKind<ListF, string>> law)
        {
            var empty = Enumerable.Empty<string>().ToList();
            law.Test(empty.ToKind()).ShouldBe(true);

            var list = new List<string> {"1", "2", "3"};
            law.Test(list.ToKind()).ShouldBe(true);
        }

        [Theory, ClassData(typeof(ApplyLawsTests<ListApply, ListF, ListEqK>))]
        public void ApplyLaw(Law<IKind<ListF, string>> law)
        {
            var empty = Enumerable.Empty<string>().ToList();
            law.Test(empty.ToKind()).ShouldBe(true);

            var list = new List<string> {"1", "2", "3"};
            law.Test(list.ToKind()).ShouldBe(true);
        }
    }
}