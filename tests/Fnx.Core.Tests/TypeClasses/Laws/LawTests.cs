using System;
using System.Collections.Generic;
using Fnx.Core.Types;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class LawTests<TF, T> : List<object[]>
    {
        protected void Add(string name, Func<IKind<TF, T>, bool> test) =>
            Add(new object[]
            {
                new Law<TF, T>(name, test)
            });
    }
}