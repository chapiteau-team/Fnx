namespace Fnx.Core.Examples.TypeClasses
{
    public interface IDisplay<in T>
    {
        string Output(T value);
    }
}