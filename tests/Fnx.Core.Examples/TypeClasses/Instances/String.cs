namespace Fnx.Core.Examples.TypeClasses.Instances
{
    public class StringDisplay : IDisplay<string>
    {
        public string Output(string value) => value;
    }

    public static class StringK
    {
        private static readonly IDisplay<string> DisplaySingleton = new StringDisplay();

        public static IDisplay<string> Display() => DisplaySingleton;
    }
}