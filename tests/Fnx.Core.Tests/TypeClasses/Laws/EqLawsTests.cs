using Fnx.Core.TypeClasses;
using Fnx.Laws;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class EqLawsTests<TEq, T> : LawTests<T>
        where TEq : struct, IEq<T>
    {
        public EqLawsTests()
        {
            Add("Reflexivity", EqLaws<TEq, T>.Reflexivity);
            Add("Symmetry", x => EqLaws<TEq, T>.Symmetry(x, x));
            Add("Substitution", x => EqLaws<TEq, T>.Substitution(x, x, Combinators.I));
            Add("Transitivity", x => EqLaws<TEq, T>.Transitivity(x, x, x));
        }
    }
}