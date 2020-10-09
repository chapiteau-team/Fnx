using Fnx.Core.DataTypes;

namespace Fnx.Core.Examples.TypeClasses.Instances
{
    public class OptionDisplay<T> : IDisplay<Option<T>>
    {
        private readonly IDisplay<T> _display;

        public OptionDisplay(IDisplay<T> display)
        {
            _display = display;
        }

        public string Output(Option<T> value) =>
            value switch
            {
                Some<T> (var some) => $"Got a value of {_display.Output(some)}",
                _ => "Nothing, sorry",
            };
    }

    public static class OptionK
    {
        public static IDisplay<Option<T>> Display<T>(IDisplay<T> display) =>
            new OptionDisplay<T>(display);
    }
}