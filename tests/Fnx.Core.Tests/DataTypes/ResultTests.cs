using System;
using Fnx.Core.DataTypes;
using Fnx.Core.Fn;
using Fnx.Core.Types;
using Shouldly;
using Xunit;
using static Fnx.Core.Prelude;

namespace Fnx.Core.Tests.DataTypes
{
    public class ResultTests
    {
        [Fact]
        public void TestError()
        {
            Should.Throw<InvalidOperationException>(() => Ok(1).GetError());
            Error("error").GetError().ShouldBe("error");
        }

        [Fact]
        public void TestContains()
        {
            Should.Throw<ArgumentNullException>(() => Ok(1).Contains(null!));

            Ok(1).Contains(x => x == 1).ShouldBeTrue();
            Error<int, string>("some error").Contains(x => x == 1).ShouldBeFalse();
        }

        [Fact]
        public void TestMap()
        {
            Should.Throw<ArgumentNullException>(() => Ok(1).Map<int>(null!));

            Ok(1).Map(x => x.ToString()).ShouldBe(Ok("1"));
            Ok<int, string>(1).Map(ok => ok.ToString()).ShouldBe(Ok<string, string>("1"));
            Error<int, string>("some error").Map(ok => ok + 1).ShouldBe(Error<int, string>("some error"));
        }

        [Fact]
        public void TestBiMap()
        {
            Should.Throw<ArgumentNullException>(() => Ok(1).BiMap<int, int>(null!, null!));
            Should.Throw<ArgumentNullException>(() => Ok(1).BiMap<int, int>(null!, _ => 1));

            Should.Throw<ArgumentNullException>(() => Error(1).BiMap<int, int>(null!, null!));
            Should.Throw<ArgumentNullException>(() => Error(1).BiMap<int, int>(_ => 1, null!));

            var map = Def<int, decimal>(x => x + 0.1m);
            var mapError = Def<string, int>(x => x.Length);

            Ok<int, string>(1).BiMap(map, mapError).ShouldBe(new Ok<decimal, int>(1.1m));
            Error<int, string>("some error").BiMap(map, mapError).ShouldBe(new Error<decimal, int>(10));
        }

        [Fact]
        public void TestErrorMap()
        {
            const string error = "some";

            Error(error).ErrorMap(x => x.Length).ShouldBe(Error(error.Length));
            Ok(1).ErrorMap(_ => "some").ShouldBe(Ok(1));

            Should.Throw<ArgumentNullException>(() => Error(1).ErrorMap<int>(null!));
        }

        [Fact]
        public void TestFlatMap()
        {
            const string error = "error";

            Ok(1).FlatMap(x => Ok(x + 1)).ShouldBe(Ok(2));
            Ok<int, string>(1).FlatMap(x => Error(error)).ShouldBe(Error(error));
            Error(error).FlatMap(x => Ok(1)).ShouldBe(Error(error));

            Should.Throw<ArgumentNullException>(() => Ok(1).FlatMap<int>(null!));
        }

        [Fact]
        public void TestRecover()
        {
            const string error = "Some";

            Error<int, string>(error).Recover(x => x.Length).ShouldBe(Ok<int, string>(error.Length));
            Ok(1).Recover(_ => 2).ShouldBe(Ok(1));

            Should.Throw<ArgumentNullException>(() => Error(1).Recover(null!));
        }

        [Fact]
        public void TestRecoverWith()
        {
            const string error = "Some";

            Error<int, string>(error).RecoverWith(x => Ok<int, string>(x.Length))
                .ShouldBe(Ok<int, string>(error.Length));
            Error<int, string>(error).RecoverWith(x => Error<int, string>(x + " error")).ShouldBe("Some error");
            Ok(1).RecoverWith<string>(_ => 2).ShouldBe(Ok(1));

            Should.Throw<ArgumentNullException>(() => Error(1).RecoverWith<string>(null!));
        }

        [Fact]
        public void TestGet()
        {
            Ok(1).Get().ShouldBe(1);

            Should.Throw<InvalidOperationException>(() => Error(1).Get());
        }

        [Fact]
        public void TestGetOrElse()
        {
            Ok(1).GetOrElse(2).ShouldBe(1);
            Error<int, string>("error").GetOrElse(1).ShouldBe(1);

            Ok(1).GetOrElse(() => 2).ShouldBe(1);
            Error<int, string>("error").GetOrElse(() => 2).ShouldBe(2);

            Should.Throw<ArgumentNullException>(() => Error(1).GetOrElse(null!));
        }

        [Fact]
        public void TestGetOrDefault()
        {
            Ok(1).GetOrDefault().ShouldBe(1);
            Error<int, string>("error").GetOrDefault().ShouldBe(default);
        }

        [Fact]
        public void TestOrElse()
        {
            Error<int, bool>(false).OrElse(Ok(1)).ShouldBe(Ok(1));
            Error<int, bool>(false).OrElse(() => Ok(1)).ShouldBe(Ok(1));
            Error<int, bool>(false).OrElse(() => Error(true)).ShouldBe(Error(true));
            Ok<int, bool>(1).OrElse(Ok(2)).ShouldBe(Ok(1));
            Ok<int, bool>(1).OrElse(() => Error(false)).ShouldBe(Ok(1));
        }

        [Fact]
        public void TestMatch()
        {
            Ok("ok").Match(ok => ok.ShouldBe("ok"), error => error.ShouldNotBe(new Nothing()));
            Error("error").Match(ok => ok.ShouldNotBe(new Nothing()), error => error.ShouldBe("error"));

            Should.Throw<ArgumentNullException>(() => Ok(1).Match(null!, null!));
            Should.Throw<ArgumentNullException>(() => Ok(1).Match(null!, _ => { }));
            Should.Throw<ArgumentNullException>(() => Error(1).Match(null!, null!));
            Should.Throw<ArgumentNullException>(() => Error(1).Match(_ => { }, null!));
        }

        [Fact]
        public void TestFold()
        {
            Ok(1).Fold(ok => ok + 10, _ => 10).ShouldBe(11);
            Error<int, string>("error").Fold(ok => ok + 1, error => error.Length + 10).ShouldBe(15);

            Should.Throw<ArgumentNullException>(() => Ok(1).Fold<int>(null!, null!));
            Should.Throw<ArgumentNullException>(() => Ok(1).Fold(null!, _ => 1));
            Should.Throw<ArgumentNullException>(() => Error(1).Fold<int>(null!, null!));
            Should.Throw<ArgumentNullException>(() => Error(1).Fold(_ => 1, null!));
        }

        [Fact]
        public void TestFilter()
        {
            Ok(10).Filter(false).ShouldBe(Error(default(Nothing)));
            Ok<int, int>(10).Filter(false).ShouldBe(Error(default(int)));
            Ok<int, string>(10).Filter(false, "error").ShouldBe(Error("error"));
            Ok(10).Filter(true).ShouldBe(Ok(10));
            Ok<int, int>(10).Filter(true, 12).ShouldBe(Ok(10));

            Error("error").Filter(true).ShouldBe(Error("error"));
            Error("error").Filter(false).ShouldBe(Error("error"));
            Error("error").Filter(false, "exception").ShouldBe(Error("error"));
            Error("error").Filter(true, "exception").ShouldBe(Error("error"));

            Ok(10).Filter(x => x == 10).ShouldBe(Ok(10));
            Ok<int, string>(10).Filter(x => x == 10, "error").ShouldBe(Ok(10));
            Ok<int, string>(10).Filter(x => x == 10, () => "error").ShouldBe(Ok(10));

            Ok(10).Filter(x => x < 5).ShouldBe(Error(default(Nothing)));
            Ok<int, string>(10).Filter(x => x < 5, "error").ShouldBe(Error("error"));
            Ok<int, int>(10).Filter(x => x < 5).ShouldBe(Error(default(int)));
            Ok<int, int>(10).Filter(x => x < 5, () => 13).ShouldBe(Error(13));
            Error("error").Filter(_ => false).ShouldBe(Error("error"));
            Error("error").Filter(_ => true).ShouldBe(Error("error"));

            Ok<int, string>(10).Filter(x => x == 10, "error").ShouldBe(Ok(10));
            Ok<int, string>(10).Filter(x => x < 10, "error").ShouldBe(Error("error"));
            Error("error").Filter(true).ShouldBe(Error("error"));
            Error("error").Filter(false).ShouldBe(Error("error"));

            Ok<int, string>(1).Filter(true, () => "error").ShouldBe(Ok(1));
            Ok<int, string>(1).Filter(false, () => "error").ShouldBe(Error("error"));
            Error<int, string>("error").Filter(true, () => "another error").ShouldBe(Error("error"));
            Error<int, string>("error").Filter(false, () => "another error").ShouldBe(Error("error"));

            Should.Throw<ArgumentNullException>(() => Ok(10).Filter(null!));
            Should.Throw<ArgumentNullException>(() => Ok(10).Filter(false, null!));

            Ok(true).Filter(x => !x, "error").ShouldBe("error");
            Ok(true).Filter(x => !x, () => "error").ShouldBe("error");
            Ok(true).Filter(false, "error").ShouldBe("error");
            Ok(true).Filter(false, () => "error").ShouldBe("error");
        }

        [Fact]
        public void TestToOption()
        {
            Ok(10).ToOption().ShouldBe(Some(10));
            Error("error").ToOption().ShouldBe(None);
        }

        [Fact]
        public void TestToString()
        {
            Ok(1).ToString().ShouldBe("Ok(1)");
            Error("some error").ToString().ShouldBe("Error(some error)");
        }

        [Fact]
        public void TestImplicitOperator()
        {
            static Result<int, string> Func() => 200;
            Func().ShouldBe(Ok(200));
            Func().ShouldBe(Ok<int, string>(200));

            static Result<int, string> ErrorFunc() => "error";
            ErrorFunc().ShouldBe(Error("error"));
            ErrorFunc().ShouldBe(Error<int, string>("error"));
        }

        [Fact]
        public void TestExplicitOperator()
        {
            ((Result<int, string>) 1).ShouldBe(Ok<int, string>(1));
            ((Result<int, string>) "error").ShouldBe(Error<int, string>("error"));

            ((int) Ok(1)).ShouldBe(1);
            ((string) Error("error")).ShouldBe("error");
            Should.Throw<InvalidCastException>(() => (int) Error<int, string>("error"));
            Should.Throw<InvalidCastException>(() => (int) Error<int, string>("error"));
        }

        [Fact]
        public void TestBoolean()
        {
            (Ok<int, string>(1) & Error<int, string>("error")).ShouldBe(Error("error"));
            (Ok<int, string>(1) | Error<int, string>("error")).ShouldBe(Ok(1));
            (Ok(1) == Ok(0 + 1)).ShouldBeTrue();
            (Ok<int, string>(1) != Error<int, string>("error")).ShouldBeTrue();
            (Ok(1) ? true : false).ShouldBeTrue();
            (Error("error") ? false : true).ShouldBeTrue();
            (Ok<int, string>(1) && Error<int, string>("error") ? true : false).ShouldBeFalse();
            (Ok<int, string>(1) || Error<int, string>("error") ? true : false).ShouldBeTrue();
        }

        [Fact]
        public void TestEquals()
        {
            Ok(1).Equals((object) Ok(1)).ShouldBeTrue();
            Ok(1).Equals((object) Ok("ok")).ShouldBeFalse();
            Ok(1).Equals((object) Error("error")).ShouldBeFalse();
            Error("error").Equals((object) Error("error")).ShouldBeTrue();
            Error("error").Equals((object) Error("some error")).ShouldBeFalse();
            Error("error").Equals((object) Ok(1)).ShouldBeFalse();
        }

        [Fact]
        public void TestGetHashCode()
        {
            Ok(1).GetHashCode().ShouldBe(Ok(1).GetHashCode());
            Error(1).GetHashCode().ShouldBe(Error(1).GetHashCode());
            Error(1).GetHashCode().ShouldNotBe(Error(2).GetHashCode());
        }

        [Fact]
        public void TestSelect()
        {
            Ok("ping").Select(x => x + " pong").ShouldBe(Ok("ping pong"));
            Error("error").Select(_ => 1).ShouldBe(Error("error"));
        }

        [Fact]
        public void TestSelectMany()
        {
            Ok("ping").SelectMany(ok => Ok(ok + " pong")).ShouldBe(Ok("ping pong"));
            Ok("ping").SelectMany(ok => Error(new Nothing())).ShouldBe(Error(new Nothing()));
            Error("error").SelectMany(_ => Ok<int, string>(1)).ShouldBe(Error("error"));
            Error("error").SelectMany(_ => Error<int, string>("some error")).ShouldBe(Error("error"));
        }

        [Fact]
        public void TestSelectManyWithProjection()
        {
            Ok("ping").SelectMany(ok => Ok(ok + " pong"), (x, y) => x + " " + y).ShouldBe(Ok("ping ping pong"));
            Ok("ping").SelectMany(ok => Error(new Nothing()), (x, y) => x.Length).ShouldBe(Error(new Nothing()));
            Error("error").SelectMany(_ => Ok<int, string>(1), (x, y) => x + " " + y).ShouldBe(Error("error"));
            Error("error").SelectMany(_ => Error<int, string>("some error"), (x, y) => y + 1).ShouldBe(Error("error"));
        }

        [Fact]
        public void TestWhere()
        {
            Ok(10).Where(x => x == 10).ShouldBe(Ok(10));
            Ok(10).Where(x => x < 5).ShouldBe(Error(new Nothing()));
            Error("error").Where(_ => false).ShouldBe(Error("error"));
            Error("error").Where(_ => true).ShouldBe(Error("error"));

            Should.Throw<ArgumentNullException>(() => Ok(10).Where(null!));
        }

        [Fact]
        public void TestWhenOkAndErrorSameTypes()
        {
            Ok<string, string>("ок").Apply(x =>
            {
                x.IsOk.ShouldBeTrue();
                x.IsError.ShouldBeFalse();
            });

            Error<string, string>("error").Apply(x =>
            {
                x.IsOk.ShouldBeFalse();
                x.IsError.ShouldBeTrue();
            });
        }
    }
}