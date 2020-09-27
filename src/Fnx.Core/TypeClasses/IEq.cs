namespace Fnx.Core.TypeClasses
{
    public interface IEq<in T>
    {
        bool Eqv(T a, T b);

        bool NEqv(T a, T b) => !Eqv(a, b);
    }
}