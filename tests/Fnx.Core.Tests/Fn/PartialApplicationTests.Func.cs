using Fnx.Core.Fn;
using Shouldly;
using Xunit;
using static Fnx.Core.Prelude;

namespace Fnx.Core.Tests.Fn
{
    public partial class PartialApplicationTests
    {
        [Fact]
        public void PartialApplication2ArgFunc()
        {
            var f = Def((int arg1, int arg2) => arg1 + arg2);

            f.Partial(1)(2).ShouldBe(3);
            f.Partial(__, 2)(1).ShouldBe(3);
        }

        [Fact]
        public void PartialApplication3ArgFunc()
        {
            var f = Def((int x, int y, int z) => x + y + z);

            f.Partial(1)(2, 3).ShouldBe(6);
            f.Partial(1, 2)(3).ShouldBe(6);
            f.Partial(__, 2)(1, 3).ShouldBe(6);
            f.Partial(__, __, 3)(1, 2).ShouldBe(6);
            f.Partial(__, 2, 3)(1).ShouldBe(6);
            f.Partial(1, __, 3)(2).ShouldBe(6);
        }

        [Fact]
        public void PartialApplication4ArgFunc()
        {
            var f = Def((int arg1, int arg2, int arg3, int arg4) => arg1 + arg2 + arg3 + arg4);

            f.Partial(1)(2, 3, 4).ShouldBe(10);
            f.Partial(__, 2)(1, 3, 4).ShouldBe(10);
            f.Partial(1, 2)(3, 4).ShouldBe(10);
            f.Partial(__, __, 3)(1, 2, 4).ShouldBe(10);
            f.Partial(1, __, 3)(2, 4).ShouldBe(10);
            f.Partial(__, 2, 3)(1, 4).ShouldBe(10);
            f.Partial(1, 2, 3)(4).ShouldBe(10);
            f.Partial(__, __, __, 4)(1, 2, 3).ShouldBe(10);
            f.Partial(1, __, __, 4)(2, 3).ShouldBe(10);
            f.Partial(__, 2, __, 4)(1, 3).ShouldBe(10);
            f.Partial(1, 2, __, 4)(3).ShouldBe(10);
            f.Partial(__, __, 3, 4)(1, 2).ShouldBe(10);
            f.Partial(1, __, 3, 4)(2).ShouldBe(10);
            f.Partial(__, 2, 3, 4)(1).ShouldBe(10);
        }

        [Fact]
        public void PartialApplication5ArgFunc()
        {
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5) => arg1 + arg2 + arg3 + arg4 + arg5);

            f.Partial(1)(2, 3, 4, 5).ShouldBe(15);
            f.Partial(__, 2)(1, 3, 4, 5).ShouldBe(15);
            f.Partial(1, 2)(3, 4, 5).ShouldBe(15);
            f.Partial(__, __, 3)(1, 2, 4, 5).ShouldBe(15);
            f.Partial(1, __, 3)(2, 4, 5).ShouldBe(15);
            f.Partial(__, 2, 3)(1, 4, 5).ShouldBe(15);
            f.Partial(1, 2, 3)(4, 5).ShouldBe(15);
            f.Partial(__, __, __, 4)(1, 2, 3, 5).ShouldBe(15);
            f.Partial(1, __, __, 4)(2, 3, 5).ShouldBe(15);
            f.Partial(__, 2, __, 4)(1, 3, 5).ShouldBe(15);
            f.Partial(1, 2, __, 4)(3, 5).ShouldBe(15);
            f.Partial(__, __, 3, 4)(1, 2, 5).ShouldBe(15);
            f.Partial(1, __, 3, 4)(2, 5).ShouldBe(15);
            f.Partial(__, 2, 3, 4)(1, 5).ShouldBe(15);
            f.Partial(1, 2, 3, 4)(5).ShouldBe(15);
            f.Partial(__, __, __, __, 5)(1, 2, 3, 4).ShouldBe(15);
            f.Partial(1, __, __, __, 5)(2, 3, 4).ShouldBe(15);
            f.Partial(__, 2, __, __, 5)(1, 3, 4).ShouldBe(15);
            f.Partial(1, 2, __, __, 5)(3, 4).ShouldBe(15);
            f.Partial(__, __, 3, __, 5)(1, 2, 4).ShouldBe(15);
            f.Partial(1, __, 3, __, 5)(2, 4).ShouldBe(15);
            f.Partial(__, 2, 3, __, 5)(1, 4).ShouldBe(15);
            f.Partial(1, 2, 3, __, 5)(4).ShouldBe(15);
            f.Partial(__, __, __, 4, 5)(1, 2, 3).ShouldBe(15);
            f.Partial(1, __, __, 4, 5)(2, 3).ShouldBe(15);
            f.Partial(__, 2, __, 4, 5)(1, 3).ShouldBe(15);
            f.Partial(1, 2, __, 4, 5)(3).ShouldBe(15);
            f.Partial(__, __, 3, 4, 5)(1, 2).ShouldBe(15);
            f.Partial(1, __, 3, 4, 5)(2).ShouldBe(15);
            f.Partial(__, 2, 3, 4, 5)(1).ShouldBe(15);
        }

        [Fact]
        public void PartialApplication6ArgFunc()
        {
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6) =>
                arg1 + arg2 + arg3 + arg4 + arg5 + arg6);

            f.Partial(1)(2, 3, 4, 5, 6).ShouldBe(21);
            f.Partial(__, 2)(1, 3, 4, 5, 6).ShouldBe(21);
            f.Partial(1, 2)(3, 4, 5, 6).ShouldBe(21);
            f.Partial(__, __, 3)(1, 2, 4, 5, 6).ShouldBe(21);
            f.Partial(1, __, 3)(2, 4, 5, 6).ShouldBe(21);
            f.Partial(__, 2, 3)(1, 4, 5, 6).ShouldBe(21);
            f.Partial(1, 2, 3)(4, 5, 6).ShouldBe(21);
            f.Partial(__, __, __, 4)(1, 2, 3, 5, 6).ShouldBe(21);
            f.Partial(1, __, __, 4)(2, 3, 5, 6).ShouldBe(21);
            f.Partial(__, 2, __, 4)(1, 3, 5, 6).ShouldBe(21);
            f.Partial(1, 2, __, 4)(3, 5, 6).ShouldBe(21);
            f.Partial(__, __, 3, 4)(1, 2, 5, 6).ShouldBe(21);
            f.Partial(1, __, 3, 4)(2, 5, 6).ShouldBe(21);
            f.Partial(__, 2, 3, 4)(1, 5, 6).ShouldBe(21);
            f.Partial(1, 2, 3, 4)(5, 6).ShouldBe(21);
            f.Partial(__, __, __, __, 5)(1, 2, 3, 4, 6).ShouldBe(21);
            f.Partial(1, __, __, __, 5)(2, 3, 4, 6).ShouldBe(21);
            f.Partial(__, 2, __, __, 5)(1, 3, 4, 6).ShouldBe(21);
            f.Partial(1, 2, __, __, 5)(3, 4, 6).ShouldBe(21);
            f.Partial(__, __, 3, __, 5)(1, 2, 4, 6).ShouldBe(21);
            f.Partial(1, __, 3, __, 5)(2, 4, 6).ShouldBe(21);
            f.Partial(__, 2, 3, __, 5)(1, 4, 6).ShouldBe(21);
            f.Partial(1, 2, 3, __, 5)(4, 6).ShouldBe(21);
            f.Partial(__, __, __, 4, 5)(1, 2, 3, 6).ShouldBe(21);
            f.Partial(1, __, __, 4, 5)(2, 3, 6).ShouldBe(21);
            f.Partial(__, 2, __, 4, 5)(1, 3, 6).ShouldBe(21);
            f.Partial(1, 2, __, 4, 5)(3, 6).ShouldBe(21);
            f.Partial(__, __, 3, 4, 5)(1, 2, 6).ShouldBe(21);
            f.Partial(1, __, 3, 4, 5)(2, 6).ShouldBe(21);
            f.Partial(__, 2, 3, 4, 5)(1, 6).ShouldBe(21);
            f.Partial(1, 2, 3, 4, 5)(6).ShouldBe(21);
            f.Partial(__, __, __, __, __, 6)(1, 2, 3, 4, 5).ShouldBe(21);
            f.Partial(1, __, __, __, __, 6)(2, 3, 4, 5).ShouldBe(21);
            f.Partial(__, 2, __, __, __, 6)(1, 3, 4, 5).ShouldBe(21);
            f.Partial(1, 2, __, __, __, 6)(3, 4, 5).ShouldBe(21);
            f.Partial(__, __, 3, __, __, 6)(1, 2, 4, 5).ShouldBe(21);
            f.Partial(1, __, 3, __, __, 6)(2, 4, 5).ShouldBe(21);
            f.Partial(__, 2, 3, __, __, 6)(1, 4, 5).ShouldBe(21);
            f.Partial(1, 2, 3, __, __, 6)(4, 5).ShouldBe(21);
            f.Partial(__, __, __, 4, __, 6)(1, 2, 3, 5).ShouldBe(21);
            f.Partial(1, __, __, 4, __, 6)(2, 3, 5).ShouldBe(21);
            f.Partial(__, 2, __, 4, __, 6)(1, 3, 5).ShouldBe(21);
            f.Partial(1, 2, __, 4, __, 6)(3, 5).ShouldBe(21);
            f.Partial(__, __, 3, 4, __, 6)(1, 2, 5).ShouldBe(21);
            f.Partial(1, __, 3, 4, __, 6)(2, 5).ShouldBe(21);
            f.Partial(__, 2, 3, 4, __, 6)(1, 5).ShouldBe(21);
            f.Partial(1, 2, 3, 4, __, 6)(5).ShouldBe(21);
            f.Partial(__, __, __, __, 5, 6)(1, 2, 3, 4).ShouldBe(21);
            f.Partial(1, __, __, __, 5, 6)(2, 3, 4).ShouldBe(21);
            f.Partial(__, 2, __, __, 5, 6)(1, 3, 4).ShouldBe(21);
            f.Partial(1, 2, __, __, 5, 6)(3, 4).ShouldBe(21);
            f.Partial(__, __, 3, __, 5, 6)(1, 2, 4).ShouldBe(21);
            f.Partial(1, __, 3, __, 5, 6)(2, 4).ShouldBe(21);
            f.Partial(__, 2, 3, __, 5, 6)(1, 4).ShouldBe(21);
            f.Partial(1, 2, 3, __, 5, 6)(4).ShouldBe(21);
            f.Partial(__, __, __, 4, 5, 6)(1, 2, 3).ShouldBe(21);
            f.Partial(1, __, __, 4, 5, 6)(2, 3).ShouldBe(21);
            f.Partial(__, 2, __, 4, 5, 6)(1, 3).ShouldBe(21);
            f.Partial(1, 2, __, 4, 5, 6)(3).ShouldBe(21);
            f.Partial(__, __, 3, 4, 5, 6)(1, 2).ShouldBe(21);
            f.Partial(1, __, 3, 4, 5, 6)(2).ShouldBe(21);
            f.Partial(__, 2, 3, 4, 5, 6)(1).ShouldBe(21);
        }

        [Fact]
        public void PartialApplication7ArgFunc()
        {
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7) =>
                arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7);

            f.Partial(1)(2, 3, 4, 5, 6, 7).ShouldBe(28);
            f.Partial(1, 2)(3, 4, 5, 6, 7).ShouldBe(28);
            f.Partial(1, 2, 3)(4, 5, 6, 7).ShouldBe(28);
            f.Partial(1, 2, 3, 4)(5, 6, 7).ShouldBe(28);
            f.Partial(1, 2, 3, 4, 5)(6, 7).ShouldBe(28);
            f.Partial(1, 2, 3, 4, 5, 6)(7).ShouldBe(28);
        }

        [Fact]
        public void PartialApplication8ArgFunc()
        {
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8) =>
                arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8);

            f.Partial(1)(2, 3, 4, 5, 6, 7, 8).ShouldBe(36);
            f.Partial(1, 2)(3, 4, 5, 6, 7, 8).ShouldBe(36);
            f.Partial(1, 2, 3)(4, 5, 6, 7, 8).ShouldBe(36);
            f.Partial(1, 2, 3, 4)(5, 6, 7, 8).ShouldBe(36);
            f.Partial(1, 2, 3, 4, 5)(6, 7, 8).ShouldBe(36);
            f.Partial(1, 2, 3, 4, 5, 6)(7, 8).ShouldBe(36);
            f.Partial(1, 2, 3, 4, 5, 6, 7)(8).ShouldBe(36);
        }

        [Fact]
        public void PartialApplication9ArgFunc()
        {
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9) =>
                arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9);

            f.Partial(1)(2, 3, 4, 5, 6, 7, 8, 9).ShouldBe(45);
            f.Partial(1, 2)(3, 4, 5, 6, 7, 8, 9).ShouldBe(45);
            f.Partial(1, 2, 3)(4, 5, 6, 7, 8, 9).ShouldBe(45);
            f.Partial(1, 2, 3, 4)(5, 6, 7, 8, 9).ShouldBe(45);
            f.Partial(1, 2, 3, 4, 5)(6, 7, 8, 9).ShouldBe(45);
            f.Partial(1, 2, 3, 4, 5, 6)(7, 8, 9).ShouldBe(45);
            f.Partial(1, 2, 3, 4, 5, 6, 7)(8, 9).ShouldBe(45);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8)(9).ShouldBe(45);
        }

        [Fact]
        public void PartialApplication10ArgFunc()
        {
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10);

            f.Partial(1)(2, 3, 4, 5, 6, 7, 8, 9, 10).ShouldBe(55);
            f.Partial(1, 2)(3, 4, 5, 6, 7, 8, 9, 10).ShouldBe(55);
            f.Partial(1, 2, 3)(4, 5, 6, 7, 8, 9, 10).ShouldBe(55);
            f.Partial(1, 2, 3, 4)(5, 6, 7, 8, 9, 10).ShouldBe(55);
            f.Partial(1, 2, 3, 4, 5)(6, 7, 8, 9, 10).ShouldBe(55);
            f.Partial(1, 2, 3, 4, 5, 6)(7, 8, 9, 10).ShouldBe(55);
            f.Partial(1, 2, 3, 4, 5, 6, 7)(8, 9, 10).ShouldBe(55);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8)(9, 10).ShouldBe(55);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9)(10).ShouldBe(55);
        }

        [Fact]
        public void PartialApplication11ArgFunc()
        {
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                    int arg11) => arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11);

            f.Partial(1)(2, 3, 4, 5, 6, 7, 8, 9, 10, 11).ShouldBe(66);
            f.Partial(1, 2)(3, 4, 5, 6, 7, 8, 9, 10, 11).ShouldBe(66);
            f.Partial(1, 2, 3)(4, 5, 6, 7, 8, 9, 10, 11).ShouldBe(66);
            f.Partial(1, 2, 3, 4)(5, 6, 7, 8, 9, 10, 11).ShouldBe(66);
            f.Partial(1, 2, 3, 4, 5)(6, 7, 8, 9, 10, 11).ShouldBe(66);
            f.Partial(1, 2, 3, 4, 5, 6)(7, 8, 9, 10, 11).ShouldBe(66);
            f.Partial(1, 2, 3, 4, 5, 6, 7)(8, 9, 10, 11).ShouldBe(66);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8)(9, 10, 11).ShouldBe(66);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9)(10, 11).ShouldBe(66);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)(11).ShouldBe(66);
        }

        [Fact]
        public void PartialApplication12ArgFunc()
        {
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12) => arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 +
                                                 arg11 + arg12);

            f.Partial(1)(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12).ShouldBe(78);
            f.Partial(1, 2)(3, 4, 5, 6, 7, 8, 9, 10, 11, 12).ShouldBe(78);
            f.Partial(1, 2, 3)(4, 5, 6, 7, 8, 9, 10, 11, 12).ShouldBe(78);
            f.Partial(1, 2, 3, 4)(5, 6, 7, 8, 9, 10, 11, 12).ShouldBe(78);
            f.Partial(1, 2, 3, 4, 5)(6, 7, 8, 9, 10, 11, 12).ShouldBe(78);
            f.Partial(1, 2, 3, 4, 5, 6)(7, 8, 9, 10, 11, 12).ShouldBe(78);
            f.Partial(1, 2, 3, 4, 5, 6, 7)(8, 9, 10, 11, 12).ShouldBe(78);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8)(9, 10, 11, 12).ShouldBe(78);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9)(10, 11, 12).ShouldBe(78);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)(11, 12).ShouldBe(78);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11)(12).ShouldBe(78);
        }

        [Fact]
        public void PartialApplication13ArgFunc()
        {
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12, int arg13) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13);

            f.Partial(1)(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13).ShouldBe(91);
            f.Partial(1, 2)(3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13).ShouldBe(91);
            f.Partial(1, 2, 3)(4, 5, 6, 7, 8, 9, 10, 11, 12, 13).ShouldBe(91);
            f.Partial(1, 2, 3, 4)(5, 6, 7, 8, 9, 10, 11, 12, 13).ShouldBe(91);
            f.Partial(1, 2, 3, 4, 5)(6, 7, 8, 9, 10, 11, 12, 13).ShouldBe(91);
            f.Partial(1, 2, 3, 4, 5, 6)(7, 8, 9, 10, 11, 12, 13).ShouldBe(91);
            f.Partial(1, 2, 3, 4, 5, 6, 7)(8, 9, 10, 11, 12, 13).ShouldBe(91);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8)(9, 10, 11, 12, 13).ShouldBe(91);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9)(10, 11, 12, 13).ShouldBe(91);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)(11, 12, 13).ShouldBe(91);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11)(12, 13).ShouldBe(91);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)(13).ShouldBe(91);
        }

        [Fact]
        public void PartialApplication14ArgFunc()
        {
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12, int arg13, int arg14) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13 +
                    arg14);

            f.Partial(1)(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14).ShouldBe(105);
            f.Partial(1, 2)(3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14).ShouldBe(105);
            f.Partial(1, 2, 3)(4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14).ShouldBe(105);
            f.Partial(1, 2, 3, 4)(5, 6, 7, 8, 9, 10, 11, 12, 13, 14).ShouldBe(105);
            f.Partial(1, 2, 3, 4, 5)(6, 7, 8, 9, 10, 11, 12, 13, 14).ShouldBe(105);
            f.Partial(1, 2, 3, 4, 5, 6)(7, 8, 9, 10, 11, 12, 13, 14).ShouldBe(105);
            f.Partial(1, 2, 3, 4, 5, 6, 7)(8, 9, 10, 11, 12, 13, 14).ShouldBe(105);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8)(9, 10, 11, 12, 13, 14).ShouldBe(105);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9)(10, 11, 12, 13, 14).ShouldBe(105);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)(11, 12, 13, 14).ShouldBe(105);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11)(12, 13, 14).ShouldBe(105);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)(13, 14).ShouldBe(105);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13)(14).ShouldBe(105);
        }

        [Fact]
        public void PartialApplication15ArgFunc()
        {
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12, int arg13, int arg14, int arg15) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13 +
                    arg14 + arg15);

            f.Partial(1)(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15).ShouldBe(120);
            f.Partial(1, 2)(3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15).ShouldBe(120);
            f.Partial(1, 2, 3)(4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15).ShouldBe(120);
            f.Partial(1, 2, 3, 4)(5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15).ShouldBe(120);
            f.Partial(1, 2, 3, 4, 5)(6, 7, 8, 9, 10, 11, 12, 13, 14, 15).ShouldBe(120);
            f.Partial(1, 2, 3, 4, 5, 6)(7, 8, 9, 10, 11, 12, 13, 14, 15).ShouldBe(120);
            f.Partial(1, 2, 3, 4, 5, 6, 7)(8, 9, 10, 11, 12, 13, 14, 15).ShouldBe(120);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8)(9, 10, 11, 12, 13, 14, 15).ShouldBe(120);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9)(10, 11, 12, 13, 14, 15).ShouldBe(120);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)(11, 12, 13, 14, 15).ShouldBe(120);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11)(12, 13, 14, 15).ShouldBe(120);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)(13, 14, 15).ShouldBe(120);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13)(14, 15).ShouldBe(120);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)(15).ShouldBe(120);
        }

        [Fact]
        public void PartialApplication16ArgFunc()
        {
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12, int arg13, int arg14, int arg15, int arg16) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13 +
                    arg14 + arg15 + arg16);

            f.Partial(1)(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16).ShouldBe(136);
            f.Partial(1, 2)(3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16).ShouldBe(136);
            f.Partial(1, 2, 3)(4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16).ShouldBe(136);
            f.Partial(1, 2, 3, 4)(5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16).ShouldBe(136);
            f.Partial(1, 2, 3, 4, 5)(6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16).ShouldBe(136);
            f.Partial(1, 2, 3, 4, 5, 6)(7, 8, 9, 10, 11, 12, 13, 14, 15, 16).ShouldBe(136);
            f.Partial(1, 2, 3, 4, 5, 6, 7)(8, 9, 10, 11, 12, 13, 14, 15, 16).ShouldBe(136);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8)(9, 10, 11, 12, 13, 14, 15, 16).ShouldBe(136);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9)(10, 11, 12, 13, 14, 15, 16).ShouldBe(136);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)(11, 12, 13, 14, 15, 16).ShouldBe(136);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11)(12, 13, 14, 15, 16).ShouldBe(136);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)(13, 14, 15, 16).ShouldBe(136);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13)(14, 15, 16).ShouldBe(136);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)(15, 16).ShouldBe(136);
            f.Partial(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)(16).ShouldBe(136);
        }
    }
}