using System;
using Enums;
using FractionInfoMVP.Model.Intrerfaces;
using FractionInfoMVP.View.Intrerfaces;

namespace FractionInfoMVP.Presenter
{
    public class FractionButtonsPresenter : IDisposable
    {
        private readonly IFractionProfileView _fractionProfileView;
        private readonly IAdvancedProfileView _advancedProfileView;
        
        private readonly IAdvancedProfileModel _advancedProfileModel;
        private readonly IFractionGeneratorModel _fractionGeneratorModel;

        private readonly FractionGeneratorPresenter _fractionGeneratorPresenter;

        public FractionButtonsPresenter(IFractionProfileView fractionProfileView,
            IAdvancedProfileView advancedProfileView, IAdvancedProfileModel advancedProfileModel,
            IFractionGeneratorModel fractionGeneratorModel, FractionGeneratorPresenter fractionGeneratorPresenter)
        {
            _fractionProfileView = fractionProfileView;
            _advancedProfileView = advancedProfileView;

            _advancedProfileModel = advancedProfileModel;
            _fractionGeneratorModel = fractionGeneratorModel;

            _fractionGeneratorPresenter = fractionGeneratorPresenter;

            Init();
        }

        private void Init()
        {
            _fractionProfileView.OnButtonClick += ShowProfile;
            _advancedProfileView.OnAddReputation += ChangeReputation;
            _advancedProfileView.OnMakePact += MakePact;
            _advancedProfileView.OnMakeWar += MakeWarPact;
        }

        public void Dispose()
        {
            _fractionProfileView.OnButtonClick -= ShowProfile;
            _advancedProfileView.OnAddReputation -= ChangeReputation;
            _advancedProfileView.OnMakePact -= MakePact;
            _advancedProfileView.OnMakeWar -= MakeWarPact;
        }
        
        
        
        private void ShowProfile(int index)
        {
            var fraction = _fractionGeneratorModel.GetFractionByIndex(index);
            _advancedProfileModel.SetCurrentFraction(fraction);

            _fractionProfileView.SetFractionInfo(fraction.Avatar, fraction.Icon, fraction.Name,
                fraction.GetReputationColor());

            _advancedProfileView.UpdateReputationText(fraction.Reputation, fraction.GetReputationColor());
            _advancedProfileView.SetProfileInfo(fraction.Avatar, fraction.Icon, fraction.TradePactSprite,
                fraction.SciencePactSprite,fraction.WarPactSprite, fraction.Name, fraction.Reputation);
            
            _advancedProfileView.SetPactActive(_advancedProfileModel.CurrentFraction.UnionTypes.HasFlag(UnionTypes.War),
                UnionTypes.War);
            
            UpdatePacts();
        }


        private void UpdatePacts()
        {
            var fraction = _advancedProfileModel.CurrentFraction;
            var reputation = fraction.Reputation;
            
            var tradeAvailable = reputation >= 50 && !fraction.UnionTypes.HasFlag(UnionTypes.War);
            var scienceAvailable = reputation >= 100 && !fraction.UnionTypes.HasFlag(UnionTypes.War); 
    

            SetPactButtonInteractable(tradeAvailable, UnionTypes.Trade);
            SetPactButtonInteractable(scienceAvailable, UnionTypes.Science);
            
            if (!tradeAvailable && fraction.UnionTypes.HasFlag(UnionTypes.Trade))
            {
                DeterminantePact(UnionTypes.Trade);
            }

            if (!scienceAvailable && fraction.UnionTypes.HasFlag(UnionTypes.Science))
            {
                DeterminantePact(UnionTypes.Science);
            }
        }


        private void MakePact(UnionTypes unionType)
        {
            var fraction = _advancedProfileModel.CurrentFraction;
            
            if (fraction.UnionTypes.HasFlag(UnionTypes.War))
            { 
                return;
            }
            
            fraction.AddPact(unionType);
            _fractionGeneratorPresenter.SetPactActive(fraction.Id, unionType, true);
        }

        private void DeterminantePact(UnionTypes unionType)
        {
            var fraction = _advancedProfileModel.CurrentFraction;
            fraction.DeterminantePact(unionType);
            _fractionGeneratorPresenter.SetPactActive(fraction.Id, unionType, false);
        }
        
        private bool MakeWarPact(UnionTypes unionType)
        {
            var reputation = _advancedProfileModel.CurrentFraction.Reputation;
            var isWarAvailable = reputation < 0;
            _advancedProfileView.UpdateWarOrPeaceText(isWarAvailable);
            if (isWarAvailable)
            {
                MakePact(unionType);
                return true;
            }
            DeterminantePact(unionType);
            return false;
        }


        private void SetPactButtonInteractable(bool isInteractable,
            UnionTypes unionType)
        {
            _advancedProfileView.SetPactButtonInteractable(isInteractable, unionType);
            _advancedProfileView.SetPactActive(_advancedProfileModel.CurrentFraction.UnionTypes.HasFlag(unionType),
                unionType);
        }

        private void ChangeReputation(int value)
        {
            _advancedProfileModel.AddReputation(value);
            _advancedProfileView.UpdateReputationText(_advancedProfileModel.ReputationValue,
                _advancedProfileModel.CurrentFraction.GetReputationColor());
            UpdatePacts();
            UpdateFractionInfo();
        }

        private void UpdateFractionInfo()
        {
            _fractionGeneratorPresenter.UpdateFractionInfo(_advancedProfileModel.CurrentFraction);
        }
    }
}
