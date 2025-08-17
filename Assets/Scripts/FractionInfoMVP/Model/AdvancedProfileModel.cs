using Data.NewFraction;
using FractionInfoMVP.Model.Intrerfaces;
using UnityEngine;

namespace FractionInfoMVP.Model
{
    public class  AdvancedProfileModel : IAdvancedProfileModel
    {
        private Fraction _currentFraction;
        public Fraction CurrentFraction => _currentFraction;

        private int _reputationValue;
        public int ReputationValue => _reputationValue;

        private Color _color;


        public void SetCurrentFraction(Fraction fraction)
        {
            _currentFraction = fraction;
        }
        
        
        public void AddReputation(int value)
        {
            _reputationValue = _currentFraction.Reputation + value;
            _currentFraction.SetReputation(_reputationValue);
        }
    }
}
