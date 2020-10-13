using System.Collections.Generic;
using Shouldly;
using Xunit;
using static Fnx.Core.Prelude;

namespace Fnx.Core.Tests
{
    public class PreludeTests
    {
        [Fact]
        public void ListOfReturnsEmptyListIfNoArguments() =>
            ListOf<int>().Count.ShouldBe(0);

        [Fact]
        public void ListOfReturnsPopulatedListIfElementsPresent() =>
            ListOf(1, 2, 3).ShouldBe(new List<int> {1, 2, 3});

        [Fact]
        public void ArrayOfReturnsEmptyArrayIfNoArguments() =>
            ArrayOf<int>().Length.ShouldBe(0);

        [Fact]
        public void ArrayOfReturnsPopulatedArrayIfElementsPresent() =>
            ArrayOf(1, 2, 3).ShouldBe(new[] {1, 2, 3});
    }
}