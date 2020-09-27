using Fnx.Core.Fn;
using Shouldly;
using Xunit;
using static Fnx.Core.Prelude;

namespace Fnx.Core.Tests.Fn
{
    public partial class CurryAndUncurryTests
    {
        [Fact]
        public void UncurryRestoresCurried2ArgFunc()
        {
            var f = Def((int arg1, int arg2) => arg1 + arg2);

            var fCurry = f.Curry();
            fCurry(1)(2).ShouldBe(3);

            var fUncurry = fCurry.Uncurry();
            fUncurry(1, 2).ShouldBe(f(1, 2));
        }

        [Fact]
        public void UncurryRestoresCurried3ArgFunc()
        {
            var f = Def((int arg1, int arg2, int arg3) => arg1 + arg2 + arg3);

            var fCurry = f.Curry();
            fCurry(1)(2)(3).ShouldBe(6);

            var fUncurry = fCurry.Uncurry();
            fUncurry(1, 2, 3).ShouldBe(f(1, 2, 3));
        }

        [Fact]
        public void UncurryRestoresCurried4ArgFunc()
        {
            var f = Def((int arg1, int arg2, int arg3, int arg4) => arg1 + arg2 + arg3 + arg4);

            var fCurry = f.Curry();
            fCurry(1)(2)(3)(4).ShouldBe(10);

            var fUncurry = fCurry.Uncurry();
            fUncurry(1, 2, 3, 4).ShouldBe(f(1, 2, 3, 4));
        }

        [Fact]
        public void UncurryRestoresCurried5ArgFunc()
        {
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5) => arg1 + arg2 + arg3 + arg4 + arg5);

            var fCurry = f.Curry();
            fCurry(1)(2)(3)(4)(5).ShouldBe(15);

            var fUncurry = fCurry.Uncurry();
            fUncurry(1, 2, 3, 4, 5).ShouldBe(f(1, 2, 3, 4, 5));
        }

        [Fact]
        public void UncurryRestoresCurried6ArgFunc()
        {
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6) =>
                arg1 + arg2 + arg3 + arg4 + arg5 + arg6);

            var fCurry = f.Curry();
            fCurry(1)(2)(3)(4)(5)(6).ShouldBe(21);

            var fUncurry = fCurry.Uncurry();
            fUncurry(1, 2, 3, 4, 5, 6).ShouldBe(f(1, 2, 3, 4, 5, 6));
        }

        [Fact]
        public void UncurryRestoresCurried7ArgFunc()
        {
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7) =>
                arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7);

            var fCurry = f.Curry();
            fCurry(1)(2)(3)(4)(5)(6)(7).ShouldBe(28);

            var fUncurry = fCurry.Uncurry();
            fUncurry(1, 2, 3, 4, 5, 6, 7).ShouldBe(f(1, 2, 3, 4, 5, 6, 7));
        }

        [Fact]
        public void UncurryRestoresCurried8ArgFunc()
        {
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8) =>
                arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8);

            var fCurry = f.Curry();
            fCurry(1)(2)(3)(4)(5)(6)(7)(8).ShouldBe(36);

            var fUncurry = fCurry.Uncurry();
            fUncurry(1, 2, 3, 4, 5, 6, 7, 8).ShouldBe(f(1, 2, 3, 4, 5, 6, 7, 8));
        }

        [Fact]
        public void UncurryRestoresCurried9ArgFunc()
        {
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9) =>
                arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9);

            var fCurry = f.Curry();
            fCurry(1)(2)(3)(4)(5)(6)(7)(8)(9).ShouldBe(45);

            var fUncurry = fCurry.Uncurry();
            fUncurry(1, 2, 3, 4, 5, 6, 7, 8, 9).ShouldBe(f(1, 2, 3, 4, 5, 6, 7, 8, 9));
        }

        [Fact]
        public void UncurryRestoresCurried10ArgFunc()
        {
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10);

            var fCurry = f.Curry();
            fCurry(1)(2)(3)(4)(5)(6)(7)(8)(9)(10).ShouldBe(55);

            var fUncurry = fCurry.Uncurry();
            fUncurry(1, 2, 3, 4, 5, 6, 7, 8, 9, 10).ShouldBe(f(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
        }

        [Fact]
        public void UncurryRestoresCurried11ArgFunc()
        {
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                    int arg11) => arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11);

            var fCurry = f.Curry();
            fCurry(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)(11).ShouldBe(66);

            var fUncurry = fCurry.Uncurry();
            fUncurry(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11).ShouldBe(f(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11));
        }

        [Fact]
        public void UncurryRestoresCurried12ArgFunc()
        {
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12) => arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 +
                                                 arg11 + arg12);

            var fCurry = f.Curry();
            fCurry(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)(11)(12).ShouldBe(78);

            var fUncurry = fCurry.Uncurry();
            fUncurry(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12).ShouldBe(f(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12));
        }

        [Fact]
        public void UncurryRestoresCurried13ArgFunc()
        {
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12, int arg13) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13);

            var fCurry = f.Curry();
            fCurry(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)(11)(12)(13).ShouldBe(91);

            var fUncurry = fCurry.Uncurry();
            fUncurry(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13).ShouldBe(f(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13));
        }

        [Fact]
        public void UncurryRestoresCurried14ArgFunc()
        {
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12, int arg13, int arg14) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13 +
                    arg14);

            var fCurry = f.Curry();
            fCurry(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)(11)(12)(13)(14).ShouldBe(105);

            var fUncurry = fCurry.Uncurry();
            fUncurry(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)
                .ShouldBe(f(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14));
        }

        [Fact]
        public void UncurryRestoresCurried15ArgFunc()
        {
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12, int arg13, int arg14, int arg15) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13 +
                    arg14 + arg15);

            var fCurry = f.Curry();
            fCurry(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)(11)(12)(13)(14)(15).ShouldBe(120);

            var fUncurry = fCurry.Uncurry();
            fUncurry(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)
                .ShouldBe(f(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15));
        }

        [Fact]
        public void UncurryRestoresCurried16ArgFunc()
        {
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12, int arg13, int arg14, int arg15, int arg16) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13 +
                    arg14 + arg15 + arg16);

            var fCurry = f.Curry();
            fCurry(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)(11)(12)(13)(14)(15)(16).ShouldBe(136);

            var fUncurry = fCurry.Uncurry();
            fUncurry(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)
                .ShouldBe(f(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16));
        }
    }
}