using Fnx.Core.Fn;
using Shouldly;
using Xunit;
using static Fnx.Core.Prelude;

namespace Fnx.Core.Tests.Fn
{
    public partial class ComposeTests
    {
        [Fact]
        public void ComposeActionWith0ArgFunc()
        {
            var result = 0;
            var g = Def((int x) => { result = x * 2; });
            var f = Def(() => 0);

            var h = g.Compose(f);
            h();
            result.ShouldBe(0);
        }

        [Fact]
        public void ComposeActionWith1ArgFunc()
        {
            var result = 0;
            var g = Def((int x) => { result = x * 2; });
            var f = Def((int arg1) => arg1);

            var h = g.Compose(f);
            h(1);
            result.ShouldBe(2);
        }

        [Fact]
        public void ComposeActionWith2ArgFunc()
        {
            var result = 0;
            var g = Def((int x) => { result = x * 2; });
            var f = Def((int arg1, int arg2) => arg1 + arg2);

            var h = g.Compose(f);
            h(1, 2);
            result.ShouldBe(6);
        }

        [Fact]
        public void ComposeActionWith3ArgFunc()
        {
            var result = 0;
            var g = Def((int x) => { result = x * 2; });
            var f = Def((int arg1, int arg2, int arg3) => arg1 + arg2 + arg3);

            var h = g.Compose(f);
            h(1, 2, 3);
            result.ShouldBe(12);
        }

        [Fact]
        public void ComposeActionWith4ArgFunc()
        {
            var result = 0;
            var g = Def((int x) => { result = x * 2; });
            var f = Def((int arg1, int arg2, int arg3, int arg4) => arg1 + arg2 + arg3 + arg4);

            var h = g.Compose(f);
            h(1, 2, 3, 4);
            result.ShouldBe(20);
        }

        [Fact]
        public void ComposeActionWith5ArgFunc()
        {
            var result = 0;
            var g = Def((int x) => { result = x * 2; });
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5) => arg1 + arg2 + arg3 + arg4 + arg5);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5);
            result.ShouldBe(30);
        }

        [Fact]
        public void ComposeActionWith6ArgFunc()
        {
            var result = 0;
            var g = Def((int x) => { result = x * 2; });
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6) =>
                arg1 + arg2 + arg3 + arg4 + arg5 + arg6);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6);
            result.ShouldBe(42);
        }

        [Fact]
        public void ComposeActionWith7ArgFunc()
        {
            var result = 0;
            var g = Def((int x) => { result = x * 2; });
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7) =>
                arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7);
            result.ShouldBe(56);
        }

        [Fact]
        public void ComposeActionWith8ArgFunc()
        {
            var result = 0;
            var g = Def((int x) => { result = x * 2; });
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8) =>
                arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7, 8);
            result.ShouldBe(72);
        }

        [Fact]
        public void ComposeActionWith9ArgFunc()
        {
            var result = 0;
            var g = Def((int x) => { result = x * 2; });
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9) =>
                arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7, 8, 9);
            result.ShouldBe(90);
        }

        [Fact]
        public void ComposeActionWith10ArgFunc()
        {
            var result = 0;
            var g = Def((int x) => { result = x * 2; });
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            result.ShouldBe(110);
        }

        [Fact]
        public void ComposeActionWith11ArgFunc()
        {
            var result = 0;
            var g = Def((int x) => { result = x * 2; });
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                    int arg11) => arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
            result.ShouldBe(132);
        }

        [Fact]
        public void ComposeActionWith12ArgFunc()
        {
            var result = 0;
            var g = Def((int x) => { result = x * 2; });
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12) => arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 +
                                                 arg11 + arg12);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
            result.ShouldBe(156);
        }

        [Fact]
        public void ComposeActionWith13ArgFunc()
        {
            var result = 0;
            var g = Def((int x) => { result = x * 2; });
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12, int arg13) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
            result.ShouldBe(182);
        }

        [Fact]
        public void ComposeActionWith14ArgFunc()
        {
            var result = 0;
            var g = Def((int x) => { result = x * 2; });
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12, int arg13, int arg14) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13 +
                    arg14);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
            result.ShouldBe(210);
        }

        [Fact]
        public void ComposeActionWith15ArgFunc()
        {
            var result = 0;
            var g = Def((int x) => { result = x * 2; });
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12, int arg13, int arg14, int arg15) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13 +
                    arg14 + arg15);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            result.ShouldBe(240);
        }

        [Fact]
        public void ComposeActionWith16ArgFunc()
        {
            var result = 0;
            var g = Def((int x) => { result = x * 2; });
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12, int arg13, int arg14, int arg15, int arg16) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13 +
                    arg14 + arg15 + arg16);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            result.ShouldBe(272);
        }
    }
}