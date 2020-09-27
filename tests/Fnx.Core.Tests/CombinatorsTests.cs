using System;
using System.Linq;
using Shouldly;
using Xunit;

namespace Fnx.Core.Tests
{
    public class CombinatorsTests
    {
        [Fact]
        public void TestI() =>
            Combinators.I("id").ShouldBe("id");

        [Fact]
        public void TestB() =>
            Combinators.B<int, string, int>(int.Parse)(x => x.ToString())(10).ShouldBe(10);

        [Fact]
        public void TestC()
        {
            Combinators.C<string, int, string[]>(x => y => Enumerable.Repeat(x, y).ToArray())(3)(null)
                .ShouldBe(new string[] {null, null, null});
        }

        [Fact]
        public void TestK() =>
            Combinators.K<string, int>("x")(0).ShouldBe("x");

        [Fact]
        public void TestW() =>
            Combinators.W<int, int>(x => y => x * y)(6).ShouldBe(36);

        [Fact]
        public void TestS() =>
            Combinators.S<int, int, int>(x => y => x + y)(x => x * x)(10).ShouldBe(110);

        [Fact]
        public void TestY() =>
            Enumerable.Range(0, 5)
                .Select(x => (int) Math.Pow(2, x))
                .Select(Combinators.Y<int, int>(factorial => n => n == 0 ? 1 : n * factorial(n - 1)))
                .ShouldBe(new[] {1, 2, 24, 40320, 2004189184});
    }
}