using System.Collections.Generic;
using System.Linq;
using Fnx.Core.DataTypes;
using Fnx.Core.Tests.TypeClasses.Laws;
using Fnx.Core.TypeClasses.Instances;
using Shouldly;
using Xunit;

namespace Fnx.Core.Tests.TypeClasses.Instances
{
    public class ListTests
    {
        [Theory, ClassData(typeof(FunctorLawTests<ListFunctor, ListF, ListEqK>))]
        public void CorrectFunctor(Law<ListF, string> law)
        {
            var empty = Enumerable.Empty<string>().ToList();
            law.Test(empty.ToKind()).ShouldBe(true);

            var list = new List<string> {"1", "2", "3"};
            law.Test(list.ToKind()).ShouldBe(true);
        }
    }
}