using System;
using Fnx.Core.Fn;
using Shouldly;
using Xunit;

namespace Fnx.Core.Tests.Fn
{
    public class ApplyTests
    {
        [Fact]
        public void ApplyChaining()
        {
            (-5)
                .Apply(Math.Abs)
                .Apply(x => Math.Pow(x, 2))
                .Apply(x => Math.Min(x, 30))
                .ShouldBe(25);
        }

        private struct PersonVal
        {
            public string Name { get; set; }
            public uint Age { get; set; }
        }

        private class PersonRef
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        [Fact]
        public void ApplyByRefChangesReceiver()
        {
            var sam = new PersonVal {Name = "Sam", Age = 20};

            sam
                .Apply((ref PersonVal x) => { x.Age++; })
                .ShouldBe(new PersonVal {Name = "Sam", Age = 21});

            var bob = new PersonRef {Name = "Bob", Age = 20};
            var rob = bob.Apply((ref PersonRef x) => { x = new PersonRef {Name = "Rob", Age = x.Age + 1}; });
            rob.ShouldNotBe(bob);
            rob.Name.ShouldBe("Rob");
            rob.Age.ShouldBe(21);
        }

        [Fact]
        public void ApplyByValDoesNotChangeReceiver()
        {
            var sam = new PersonVal {Name = "Sam", Age = 20};

            sam
                .Apply(x => { x.Age++; })
                .ShouldBe(new PersonVal {Name = "Sam", Age = 20});

            var bob = new PersonRef {Name = "Bob", Age = 20};
            bob.Apply(x =>
                {
                    x.Name = "Rob";
                    x.Age += 1;
                })
                .ShouldBe(bob);
            bob.Name.ShouldBe("Rob");
            bob.Age.ShouldBe(21);
        }
    }
}