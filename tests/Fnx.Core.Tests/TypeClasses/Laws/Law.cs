using System;
using Fnx.Core.Types;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class Law<T>
    {
        public string Name { get; }

        public Func<T, bool> TestLaw { get; }

        public Law(string name, Func<T, bool> testLaw)
        {
            Name = name;
            TestLaw = testLaw;
        }

        public override string ToString() => Name;
    }
}