using System.Text;
using Fnx.Core.DataTypes;
using Fnx.Core.Examples.TypeClasses;
using Fnx.Core.Examples.TypeClasses.Instances;
using Fnx.Core.TypeClasses.Instances;
using Shouldly;
using Xunit;
using static Fnx.Core.Prelude;
using ResultK = Fnx.Core.Examples.TypeClasses.Instances.ResultK;
using StringK = Fnx.Core.Examples.TypeClasses.Instances.StringK;

namespace Fnx.Core.Examples
{
    public class TypeClassesExamples
    {
        [Fact]
        public void Map3Example()
        {
            var userId = 1;

            OptionK.Applicative().Map3(
                    UserRepository.GetUserDetails(userId),
                    OrderRepository.GetOrders(),
                    ShipmentRepository.GetShipments(),
                    ReportManager.MakeReport)
                .Fix()
                .IsSome
                .ShouldBe(true);


            // The same with monadic bind
            var report =
                from user in UserRepository.GetUserDetails(userId)
                from orders in OrderRepository.GetOrders()
                from shipments in ShipmentRepository.GetShipments()
                select ReportManager.MakeReport(user, orders, shipments);

            report.IsSome.ShouldBe(true);
        }

        [Fact]
        public void CustomDataTypeExample()
        {
            var tree = new Branch<int>(new Leaf<int>(1), new Leaf<int>(2));

            TreeK.Functor().Map(tree, x => x * 10).Fix().ToString()
                .ShouldBe("Branch(Leaf(10), Leaf(20))");

            TreeK.Functor().FProduct(tree, x => x.ToString()).Fix().ToString()
                .ShouldBe("Branch(Leaf((1, 1)), Leaf((2, 2)))");

            TreeK.Functor().As(tree, true).Fix().ToString()
                .ShouldBe("Branch(Leaf(True), Leaf(True))");

            TreeK.Functor().Void(tree).Fix().ToString()
                .ShouldBe("Branch(Leaf(Unit), Leaf(Unit))");
        }

        public class Writer<T>
        {
            private readonly IDisplay<T> _display;
            internal StringBuilder StdOut = new StringBuilder();

            public Writer(IDisplay<T> display) => _display = display;

            public string Format(T value) => _display.Output(value);

            public void PrintLn(T value) => StdOut.AppendLine(_display.Output(value));
        }

        [Fact]
        public void CustomTypeClassExample()
        {
            var myLocation = new Location(15, 20);
            var writer = new Writer<Location>(LocationK.Display());
            writer.PrintLn(myLocation);
            writer.StdOut.ToString()
                .ShouldBe("Location where X=15 and Y=20\n");

            var resultDisplay = ResultK.Display(LocationK.Display(), StringK.Display());
            new Writer<Result<Location, string>>(resultDisplay)
                .Format(Ok(myLocation))
                .ShouldBe("Got a value of Location where X=15 and Y=20");

            new Writer<Result<Location, string>>(resultDisplay)
                .Format(Error("error"))
                .ShouldBe("Sorry, error");
        }
    }
}