using System;
using Fnx.Core.Types;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class Law<T>
    {
        private string Name { get; }

        public Func<T, bool> Test { get; }

        public Law(string name, Func<T, bool> test)
        {
            Name = name;
            Test = test;
        }

        public override string ToString() => Name;
    }
}