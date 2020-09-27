using Fnx.Core.Fn;
using Shouldly;
using Xunit;
using static Fnx.Core.Prelude;

namespace Fnx.Core.Tests.Fn
{
    public partial class CurryAndUncurryTests
    {
        [Fact]
        public void UncurryRestoresCurried2ArgAction()
        {
            var result = 0;
            var a = Def((int arg1, int arg2) => { result = arg1 + arg2; });
            a(1, 2);
            result.ShouldBe(3);

            result = 0;
            var aCurry = a.Curry();
            aCurry(1)(2);
            result.ShouldBe(3);

            result = 0;
            var aUncurry = aCurry.Uncurry();
            aUncurry(1, 2);
            result.ShouldBe(3);
        }

        [Fact]
        public void UncurryRestoresCurried3ArgAction()
        {
            var result = 0;
            var a = Def((int arg1, int arg2, int arg3) => { result = arg1 + arg2 + arg3; });
            a(1, 2, 3);
            result.ShouldBe(6);

            result = 0;
            var aCurry = a.Curry();
            aCurry(1)(2)(3);
            result.ShouldBe(6);

            result = 0;
            var aUncurry = aCurry.Uncurry();
            aUncurry(1, 2, 3);
            result.ShouldBe(6);
        }

        [Fact]
        public void UncurryRestoresCurried4ArgAction()
        {
            var result = 0;
            var a = Def((int arg1, int arg2, int arg3, int arg4) => { result = arg1 + arg2 + arg3 + arg4; });
            a(1, 2, 3, 4);
            result.ShouldBe(10);

            result = 0;
            var aCurry = a.Curry();
            aCurry(1)(2)(3)(4);
            result.ShouldBe(10);

            result = 0;
            var aUncurry = aCurry.Uncurry();
            aUncurry(1, 2, 3, 4);
            result.ShouldBe(10);
        }

        [Fact]
        public void UncurryRestoresCurried5ArgAction()
        {
            var result = 0;
            var a = Def((int arg1, int arg2, int arg3, int arg4, int arg5) =>
            {
                result = arg1 + arg2 + arg3 + arg4 + arg5;
            });
            a(1, 2, 3, 4, 5);
            result.ShouldBe(15);

            result = 0;
            var aCurry = a.Curry();
            aCurry(1)(2)(3)(4)(5);
            result.ShouldBe(15);

            result = 0;
            var aUncurry = aCurry.Uncurry();
            aUncurry(1, 2, 3, 4, 5);
            result.ShouldBe(15);
        }

        [Fact]
        public void UncurryRestoresCurried6ArgAction()
        {
            var result = 0;
            var a = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6) =>
            {
                result = arg1 + arg2 + arg3 + arg4 + arg5 + arg6;
            });
            a(1, 2, 3, 4, 5, 6);
            result.ShouldBe(21);

            result = 0;
            var aCurry = a.Curry();
            aCurry(1)(2)(3)(4)(5)(6);
            result.ShouldBe(21);

            result = 0;
            var aUncurry = aCurry.Uncurry();
            aUncurry(1, 2, 3, 4, 5, 6);
            result.ShouldBe(21);
        }

        [Fact]
        public void UncurryRestoresCurried7ArgAction()
        {
            var result = 0;
            var a = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7) =>
            {
                result = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7;
            });
            a(1, 2, 3, 4, 5, 6, 7);
            result.ShouldBe(28);

            result = 0;
            var aCurry = a.Curry();
            aCurry(1)(2)(3)(4)(5)(6)(7);
            result.ShouldBe(28);

            result = 0;
            var aUncurry = aCurry.Uncurry();
            aUncurry(1, 2, 3, 4, 5, 6, 7);
            result.ShouldBe(28);
        }

        [Fact]
        public void UncurryRestoresCurried8ArgAction()
        {
            var result = 0;
            var a = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8) =>
            {
                result = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8;
            });
            a(1, 2, 3, 4, 5, 6, 7, 8);
            result.ShouldBe(36);

            result = 0;
            var aCurry = a.Curry();
            aCurry(1)(2)(3)(4)(5)(6)(7)(8);
            result.ShouldBe(36);

            result = 0;
            var aUncurry = aCurry.Uncurry();
            aUncurry(1, 2, 3, 4, 5, 6, 7, 8);
            result.ShouldBe(36);
        }

        [Fact]
        public void UncurryRestoresCurried9ArgAction()
        {
            var result = 0;
            var a = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9) =>
            {
                result = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9;
            });
            a(1, 2, 3, 4, 5, 6, 7, 8, 9);
            result.ShouldBe(45);

            result = 0;
            var aCurry = a.Curry();
            aCurry(1)(2)(3)(4)(5)(6)(7)(8)(9);
            result.ShouldBe(45);

            result = 0;
            var aUncurry = aCurry.Uncurry();
            aUncurry(1, 2, 3, 4, 5, 6, 7, 8, 9);
            result.ShouldBe(45);
        }

        [Fact]
        public void UncurryRestoresCurried10ArgAction()
        {
            var result = 0;
            var a = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10) =>
                {
                    result = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10;
                });
            a(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            result.ShouldBe(55);

            result = 0;
            var aCurry = a.Curry();
            aCurry(1)(2)(3)(4)(5)(6)(7)(8)(9)(10);
            result.ShouldBe(55);

            result = 0;
            var aUncurry = aCurry.Uncurry();
            aUncurry(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            result.ShouldBe(55);
        }

        [Fact]
        public void UncurryRestoresCurried11ArgAction()
        {
            var result = 0;
            var a = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                    int arg11) =>
                {
                    result = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11;
                });
            a(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
            result.ShouldBe(66);

            result = 0;
            var aCurry = a.Curry();
            aCurry(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)(11);
            result.ShouldBe(66);

            result = 0;
            var aUncurry = aCurry.Uncurry();
            aUncurry(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
            result.ShouldBe(66);
        }

        [Fact]
        public void UncurryRestoresCurried12ArgAction()
        {
            var result = 0;
            var a = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                    int arg11, int arg12) =>
                {
                    result = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12;
                });
            a(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
            result.ShouldBe(78);

            result = 0;
            var aCurry = a.Curry();
            aCurry(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)(11)(12);
            result.ShouldBe(78);

            result = 0;
            var aUncurry = aCurry.Uncurry();
            aUncurry(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
            result.ShouldBe(78);
        }

        [Fact]
        public void UncurryRestoresCurried13ArgAction()
        {
            var result = 0;
            var a = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                    int arg11, int arg12, int arg13) =>
                {
                    result = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 +
                             arg13;
                });
            a(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
            result.ShouldBe(91);

            result = 0;
            var aCurry = a.Curry();
            aCurry(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)(11)(12)(13);
            result.ShouldBe(91);

            result = 0;
            var aUncurry = aCurry.Uncurry();
            aUncurry(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
            result.ShouldBe(91);
        }

        [Fact]
        public void UncurryRestoresCurried14ArgAction()
        {
            var result = 0;
            var a = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                    int arg11, int arg12, int arg13, int arg14) =>
                {
                    result = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 +
                             arg13 + arg14;
                });
            a(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
            result.ShouldBe(105);

            result = 0;
            var aCurry = a.Curry();
            aCurry(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)(11)(12)(13)(14);
            result.ShouldBe(105);

            result = 0;
            var aUncurry = aCurry.Uncurry();
            aUncurry(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
            result.ShouldBe(105);
        }

        [Fact]
        public void UncurryRestoresCurried15ArgAction()
        {
            var result = 0;
            var a = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                    int arg11, int arg12, int arg13, int arg14, int arg15) =>
                {
                    result = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 +
                             arg13 + arg14 + arg15;
                });
            a(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            result.ShouldBe(120);

            result = 0;
            var aCurry = a.Curry();
            aCurry(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)(11)(12)(13)(14)(15);
            result.ShouldBe(120);

            result = 0;
            var aUncurry = aCurry.Uncurry();
            aUncurry(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            result.ShouldBe(120);
        }

        [Fact]
        public void UncurryRestoresCurried16ArgAction()
        {
            var result = 0;
            var a = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                    int arg11, int arg12, int arg13, int arg14, int arg15, int arg16) =>
                {
                    result = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 +
                             arg13 + arg14 + arg15 + arg16;
                });
            a(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            result.ShouldBe(136);

            result = 0;
            var aCurry = a.Curry();
            aCurry(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)(11)(12)(13)(14)(15)(16);
            result.ShouldBe(136);

            result = 0;
            var aUncurry = aCurry.Uncurry();
            aUncurry(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            result.ShouldBe(136);
        }
    }
}