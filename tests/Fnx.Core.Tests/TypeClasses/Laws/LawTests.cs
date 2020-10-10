using System;
using System.Collections.Generic;
using System.Linq;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class LawTests<T> : List<Law<T>>
    {
        protected void Add(string name, Func<T, bool> test)
        {
            if (!Exists(x => x.Name == name))
            {
                Add(new Law<T>(name, test));
            }
        }

        public IEnumerable<object[]> Wrap() =>
            this.Select(x => new object[] {x});
    }
}