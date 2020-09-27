using Fnx.Core.Fn;
using Shouldly;
using Xunit;
using static Fnx.Core.Prelude;

namespace Fnx.Core.Tests.Fn
{
    public partial class ComposeFuncTests
    {
        [Fact]
        public void ComposeFuncWith0ArgFunc()
        {
            var g = Def((int x) => x * 2);
            var f = Def(() => 0);

            var h = g.Compose(f);
            h().ShouldBe(0);
        }

        [Fact]
        public void ComposeFuncWith1ArgFunc()
        {
            var g = Def((int x) => x * 2);
            var f = Def((int arg1) => arg1);

            var h = g.Compose(f);
            h(1).ShouldBe(2);
        }

        [Fact]
        public void ComposeFuncWith2ArgFunc()
        {
            var g = Def((int x) => x * 2);
            var f = Def((int arg1, int arg2) => arg1 + arg2);

            var h = g.Compose(f);
            h(1, 2).ShouldBe(6);
        }

        [Fact]
        public void ComposeFuncWith3ArgFunc()
        {
            var g = Def((int x) => x * 2);
            var f = Def((int arg1, int arg2, int arg3) => arg1 + arg2 + arg3);

            var h = g.Compose(f);
            h(1, 2, 3).ShouldBe(12);
        }

        [Fact]
        public void ComposeFuncWith4ArgFunc()
        {
            var g = Def((int x) => x * 2);
            var f = Def((int arg1, int arg2, int arg3, int arg4) => arg1 + arg2 + arg3 + arg4);

            var h = g.Compose(f);
            h(1, 2, 3, 4).ShouldBe(20);
        }

        [Fact]
        public void ComposeFuncWith5ArgFunc()
        {
            var g = Def((int x) => x * 2);
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5) => arg1 + arg2 + arg3 + arg4 + arg5);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5).ShouldBe(30);
        }

        [Fact]
        public void ComposeFuncWith6ArgFunc()
        {
            var g = Def((int x) => x * 2);
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6) =>
                arg1 + arg2 + arg3 + arg4 + arg5 + arg6);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6).ShouldBe(42);
        }

        [Fact]
        public void ComposeFuncWith7ArgFunc()
        {
            var g = Def((int x) => x * 2);
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7) =>
                arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7).ShouldBe(56);
        }

        [Fact]
        public void ComposeFuncWith8ArgFunc()
        {
            var g = Def((int x) => x * 2);
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8) =>
                arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7, 8).ShouldBe(72);
        }

        [Fact]
        public void ComposeFuncWith9ArgFunc()
        {
            var g = Def((int x) => x * 2);
            var f = Def((int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9) =>
                arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7, 8, 9).ShouldBe(90);
        }

        [Fact]
        public void ComposeFuncWith10ArgFunc()
        {
            var g = Def((int x) => x * 2);
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7, 8, 9, 10).ShouldBe(110);
        }

        [Fact]
        public void ComposeFuncWith11ArgFunc()
        {
            var g = Def((int x) => x * 2);
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                    int arg11) => arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11).ShouldBe(132);
        }

        [Fact]
        public void ComposeFuncWith12ArgFunc()
        {
            var g = Def((int x) => x * 2);
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12) => arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 +
                                                 arg11 + arg12);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12).ShouldBe(156);
        }

        [Fact]
        public void ComposeFuncWith13ArgFunc()
        {
            var g = Def((int x) => x * 2);
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12, int arg13) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13).ShouldBe(182);
        }

        [Fact]
        public void ComposeFuncWith14ArgFunc()
        {
            var g = Def((int x) => x * 2);
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12, int arg13, int arg14) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13 +
                    arg14);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14).ShouldBe(210);
        }

        [Fact]
        public void ComposeFuncWith15ArgFunc()
        {
            var g = Def((int x) => x * 2);
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12, int arg13, int arg14, int arg15) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13 +
                    arg14 + arg15);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15).ShouldBe(240);
        }

        [Fact]
        public void ComposeFuncWith16ArgFunc()
        {
            var g = Def((int x) => x * 2);
            var f = Def(
                (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10,
                        int arg11, int arg12, int arg13, int arg14, int arg15, int arg16) =>
                    arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13 +
                    arg14 + arg15 + arg16);

            var h = g.Compose(f);
            h(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16).ShouldBe(272);
        }
    }
}