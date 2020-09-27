using System;
using Fnx.Core.Types;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class Law<TF, TA>
    {
        public string Name { get; }

        public Func<IKind<TF, TA>, bool> Test { get; }

        public Law(string name, Func<IKind<TF, TA>, bool> test)
        {
            Name = name;
            Test = test;
        }

        public override string ToString() => Name;
    }
}