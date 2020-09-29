using System;
using System.Collections.Generic;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class LawTests<T> : List<object[]>
    {
        protected void Add(string name, Func<T, bool> test) =>
            Add(new object[] {new Law<T>(name, test)});
    }
}