using Data.NewFraction;
using Enums;
using UnityEngine;

namespace FractionInfoMVP.Presenter
{
    public class FractionGeneratorPresenter
    {
        private readonly IFractionBlockView _fractionBlockView;
        private readonly IFractionGeneratorModel _fractionGeneratorModel;

        public FractionGeneratorPresenter(IFractionBlockView fractionBlockView,
            IFractionGeneratorModel fractionGeneratorModel)
        {
            _fractionBlockView = fractionBlockView;
            _fractionGeneratorModel = fractionGeneratorModel;

            fractionGeneratorModel.GenerateFractions();

            GenerateInfo();
        }


        private void GenerateInfo()
        {
            for (var i = 0; i < 6; i++)
            {
                var fraction = _fractionGeneratorModel.GetFractionByIndex(i);

                _fractionBlockView.SetFractionInfo(i, fraction.Icon,fraction.TradePactSprite,fraction.SciencePactSprite
                    ,fraction.Name, fraction.Reputation,fraction.GetReputationColor());
            }
        }

        public void UpdateFractionInfo(Fraction fraction)
        {
            _fractionBlockView.SetFractionInfo(fraction.Id, fraction.Icon,fraction.TradePactSprite,fraction.SciencePactSprite
                ,fraction.Name, fraction.Reputation,fraction.GetReputationColor());
        }
        
        
        public void SetPactActive(int index, UnionTypes unionType, bool isActive)
        {
            _fractionBlockView.SetPactActive(index, unionType, isActive);
        }
    }
}
