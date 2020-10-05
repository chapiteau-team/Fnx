using System;
using Fnx.Core.Types;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public struct TestArgs<TF, TA, TB, TC>
    {
        public TA A;
        public IKind<TF, TA> LiftedA;
        public TB B;
        public IKind<TF, TB> LiftedB;
        public TC C;

        public Func<TA, TB> FuncAtoB;
        public IKind<TF, Func<TA, TB>> LiftedFuncAtoB;
        public Func<TA, IKind<TF, TB>> FuncAtoLiftedB;
        public Func<TB, TA> FuncBtoA;
        public Func<TB, TC> FuncBtoC;
        public IKind<TF, Func<TB, TC>> LiftedFuncBtoC;
        public Func<TB, IKind<TF, TC>> FuncBtoLiftedC;
        public Func<TC, TB> FuncCtoB;
    }

    public static class TestArgs
    {
        public static TestArgs<TF, string, int, long> Default<TF>() =>
            new TestArgs<TF, string, int, long>
            {
                A = "1",
                B = 2,
                C = 3,
                FuncAtoB = int.Parse,
                FuncBtoA = x => x.ToString(),
                FuncBtoC = x => x,
                FuncCtoB = x => (int) x
            };
    }
}