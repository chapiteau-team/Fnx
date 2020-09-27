using System;
using Fnx.Core.DataTypes;
using Shouldly;
using Xunit;
using static Fnx.Core.Prelude;

namespace Fnx.Core.Tests.DataTypes
{
    public class OptionTests
    {
        [Fact]
        public void NoneToStringReturnsNone() =>
            Option<int>.None.ToString().ShouldBe("None");

        [Fact]
        public void NoneGetThrows() =>
            Should.Throw<InvalidOperationException>(() => None.Get());

        [Fact]
        public void NoneGetOrElseExecutesElse()
        {
            GetNone("none").GetOrElse("error").ShouldBe("error");
            Should.Throw<Exception>(
                () => GetNone("ok").GetOrElse(() => throw new Exception("error"))
            ).Message.ShouldBe("error");
        }

        [Fact]
        public void NoneGetOrDefaultReturnsDefaultValue() =>
            GetNone("none").GetOrDefault().ShouldBe(null);

        [Fact]
        public void SomeToStringReturnsSomeWithValue() =>
            Option<string>.Some(null).ToString().ShouldBe("Some()");

        [Fact]
        public void SomeGetReturnsValue()
        {
            var value = new {Foo = "Bar"};
            var some = Some(value);

            some.Get().ShouldBe(value);
        }

        [Fact]
        public void SomeGetOrElseReturnsValue()
        {
            Some("ok").GetOrElse("error").ShouldBe("ok");
            Some("ok").GetOrElse(() => throw new Exception("error")).ShouldBe("ok");
        }

        [Fact]
        public void SomeGetOrDefaultReturnsValue()
        {
            Some("ok").GetOrDefault().ShouldBe("ok");
        }

        [Fact]
        public void ToOptionReturnsNoneForNull() =>
            ((string) null).ToOption().ShouldBe(None);

        [Fact]
        public void ToSomeReturnsSomeForNull() =>
            ((int?) null).ToSome().ShouldBe(Some<int?>(null));

        [Fact]
        public void FilterReturnsNoneWhenConditionDoesNotHold()
        {
            Some(10).Filter(x => x < 1).ShouldBe(None);
            Some(10).Filter(10 < 1).ShouldBe(None);
        }

        [Fact]
        public void TestFold()
        {
            Option.Some(true).Fold(x => 10, () => -10).ShouldBe(10);
            Option.Some(true).Fold(x => 10, -10).ShouldBe(10);
            Option.None.Fold(x => 10, () => -10).ShouldBe(-10);
            Option.None.Fold(x => 10, -10).ShouldBe(-10);
        }

        [Fact]
        public void TestMatch()
        {
            Should.NotThrow(() =>
                Some(true).Match(x => x.ShouldBe(true), () => throw new Exception()));

            Should.Throw<Exception>(
                    () => ((Option<bool>) None).Match(x => x.ShouldBe(true),
                        () => throw new Exception("error")))
                .Message.ShouldBe("error");
        }

        [Fact]
        public void TestContains()
        {
            None.Contains(_ => true).ShouldBe(false);
            Some(12).Contains(x => x > 10).ShouldBe(true);
            Some(12).Contains(x => x < 10).ShouldBe(false);
        }

        [Fact]
        public void TestOperators()
        {
            (None == None).ShouldBe(true);
            (Some(true) == Some(true)).ShouldBe(true);
            (Some(false) == Some(true)).ShouldBe(false);
            (Some(true) == None).ShouldBe(false);

            (None != None).ShouldBe(false);
            (Some(true) != Some(true)).ShouldBe(false);
            (Some(false) != Some(true)).ShouldBe(true);
            (Some(true) != None).ShouldBe(true);

            Some(true).Equals((object) Some(true)).ShouldBe(true);
            Some(true).Equals((object) None).ShouldBe(false);

            (None || Some("some") || None ? true : false).ShouldBe(true);
            (Some(1) && Some(2) ? true : false).ShouldBe(true);

            ((int) Some(1)).ShouldBe(1);
        }

        [Fact]
        public void TestGetHashCode()
        {
            Some(1).GetHashCode().ShouldBe(Some(1).GetHashCode());
            Some(1).GetHashCode().ShouldNotBe(Some(2).GetHashCode());
            Some(1).GetHashCode().ShouldNotBe(None.GetHashCode());
            None.GetHashCode().ShouldBe(Option<int>.None.GetHashCode());
        }

        [Fact]
        public void TestFromComprehension()
        {
            (from x in Some(0) select x).ShouldBe(Some(0));

            (
                from x in Some(0)
                from y in Some(x.ToString())
                select y).ShouldBe(Some("0"));

            (
                from x in Some(0)
                from y in None
                from z in Some("str")
                select "foo").ShouldBe(None);

            (
                from a in Some("123")
                from b in Some("456")
                from c in Some(789)
                select a + b + c).ShouldBe("123456789");

            (
                from x in
                    from a in Some(10)
                    from b in Some(20)
                    select Math.Max(a, b)
                let bound = 100
                where x > bound
                select x).ShouldBe(None);
        }

        [Fact]
        public void TestPatternMatching()
        {
            (Some("some") switch {Some<string>(var value) => value, _ => "none"}).ShouldBe("some");
            (GetNone("some") switch {Some<string>(var value) => value, _ => "none"}).ShouldBe("none");
        }

        private static Option<T> GetNone<T>(T _) => None;
    }
}