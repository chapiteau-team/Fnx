namespace Fnx.Core.Examples.TypeClasses.Instances
{
    public class LocationDisplay : IDisplay<Location>
    {
        public string Output(Location value) => $"Location where X={value.X} and Y={value.Y}";
    }

    public static class LocationK
    {
        private static readonly IDisplay<Location> DisplaySingleton = new LocationDisplay();

        public static IDisplay<Location> Display() => DisplaySingleton;
    }
}