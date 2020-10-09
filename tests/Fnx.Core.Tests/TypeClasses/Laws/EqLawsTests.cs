using Fnx.Core.TypeClasses;
using Fnx.Laws;

namespace Fnx.Core.Tests.TypeClasses.Laws
{
    public class EqLawsTests<T> : LawTests<T>
    {
        public EqLawsTests(IEq<T> eq)
        {
            var eqLaws = new EqLaws<T>(eq);

            Add("Reflexivity", eqLaws.Reflexivity);
            Add("Symmetry", x => eqLaws.Symmetry(x, x));
            Add("Substitution", x => eqLaws.Substitution(x, x, Combinators.I));
            Add("Transitivity", x => eqLaws.Transitivity(x, x, x));
        }
    }
}