
using Data.NewFraction;

namespace FractionInfoMVP.Model.Intrerfaces
{
    public interface IAdvancedProfileModel

    {
        Fraction CurrentFraction { get; }
        int ReputationValue { get; }
        void AddReputation(int value);
        void SetCurrentFraction(Fraction fraction);
    }
}
