using System;
using Fnx.Core.Fn;
using Shouldly;
using Xunit;
using static Fnx.Core.Prelude;

namespace Fnx.Core.Examples
{
    public class FnExamples
    {
        [Fact]
        public void DefExample()
        {
            // Doesn't compile
            // [CS0815] Cannot assign lambda expression to an implicitly-typed variable
            // var id = (int x) => x;

            var id = Def((int x) => x);

            // Doesn't compile
            // [CS0815] Cannot assign method group to an implicitly-typed variable
            // var readLine = Console.ReadLine;

            var readLine = Def(Console.ReadLine);

            id(1).ShouldBe(1);
            readLine.ShouldNotBeNull();
        }

        [Fact]
        public void PartialExample()
        {
            var version =
                Def((string text, int major, int min, char rev) => $"{text}: {major}.{min}{rev}");

            var withMin = version.Partial(__, __, 0);
            var versioned = withMin.Partial(__, 2);
            var withTextAndVersion = versioned.Partial("Version");
            var result = withTextAndVersion('b');

            result.ShouldBe("Version: 2.0b");
        }

        [Fact]
        public void ComposeExample()
        {
            var readInt = Def<string, int>(int.Parse).Compose(Console.ReadLine);

            readInt.ShouldNotBeNull();
        }

        [Fact]
        public void CurryAndUncurry()
        {
            var min = Def<int, int, int>(Math.Min);

            var minCurry = min.Curry();
            minCurry(1)(2).ShouldBe(1);

            var minUncurry = minCurry.Uncurry();
            minUncurry(1, 2).ShouldBe(Math.Min(1, 2));
        }

        private struct Location
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        [Fact]
        public void PartialApplicationExample()
        {
            var location = new Location {X = 50, Y = 23};
            var time = "13:57:59";

            Def<string, object[], string>(string.Format)
                .Partial(__, new object[] {location.X, location.Y, time})
                .Apply(LogLocation);

            void LogLocation(Func<string, string> log)
            {
                log("{2}: {0},{1}").ShouldBe($"{time}: {location.X},{location.Y}");
                log("({0}, {1})").ShouldBe($"({location.X}, {location.Y})");
            }
        }

        [Fact]
        public void PartialAndCompositionExample()
        {
            var substring = Def((int start, int length, string str) => str.Substring(start, length));
            var firstChars = substring.Partial(0);
            var firstChar = firstChars.Partial(1);
            var toLower = Def((string str) => str.ToLower());
            var lowerFirstChar = toLower.Compose(firstChar);

            lowerFirstChar("String").ShouldBe("s");
        }
    }
}