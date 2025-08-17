using System;
using AYellowpaper.SerializedCollections;
using Enums;
using FractionInfoMVP.View.Intrerfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

namespace FractionInfoMVP.View
{
    
    public class AdvancedProfileView : FractionProfileView,IAdvancedProfileView
    {
        public event Action<int> OnAddReputation;
        public event Action<UnionTypes> OnMakePact;
        public event Func<UnionTypes,bool> OnMakeWar;
        
        [SerializedDictionary("UnionTypes","GameObject")] 
        [SerializeField] private SerializedDictionary<UnionTypes, GameObject> _pacts;
        
        [SerializedDictionary("UnionTypes","Button")] 
        [SerializeField] private SerializedDictionary<UnionTypes, Button> _pactsButtons;
        
        [SerializeField] private TMP_Text _reputationText;
        
        [SerializeField] private Button _tradePactButton;
        
        [SerializeField] private Button _sciencePactButton;
        
        [SerializeField] private GameObject _warPact;
        
        [SerializeField] private GameObject _tradePact;
        
        [SerializeField] private GameObject _sciencePact;

        
        //todo dictionary for pacts
        
        private void Start()
        {
            if (_pactsButtons.TryGetValue(UnionTypes.Science, out var scienceButton))
            {
                scienceButton.interactable = false;
            }
            if (_pactsButtons.TryGetValue(UnionTypes.Trade, out var tradeButton))
            {
                tradeButton.interactable = true;
            }
            
            _sciencePactButton.interactable = false;
            _warPact.SetActive(false);
        }

        
        public void SetProfileInfo(Sprite avatar,Sprite icon,Sprite tradePact,Sprite sciencePact,Sprite warPact, string name, int reputationValue)
        {
            _avatarImage.sprite = avatar;
            _iconImage.sprite = icon;
            _nameText.text = name;
            _reputationText.text = reputationValue.ToString();
            _tradePact.GetComponent<Image>().sprite = tradePact;
            _sciencePact.GetComponent<Image>().sprite = sciencePact;
            _warPact.GetComponent<Image>().sprite = warPact;
        }

        
        public void AddReputation(int value)
        {
            OnAddReputation?.Invoke(value);
        }

        
        public void UpdateReputationText(int value , Color textColor)
        {
            _reputationText.color = textColor;
            _reputationText.text = value.ToString();
        }
        
        public void UpdateWarOrPeaceText(bool isWar)
        {
            if (_pactsButtons.TryGetValue(UnionTypes.War, out var warButton))
            {
                warButton.GetComponentInChildren<TMP_Text>().text = isWar ? "War" : "Peace";
            }
        }
        
        
        public void SetPactButtonInteractable(bool isInteractable, UnionTypes unionType)
        {
            if (_pactsButtons.TryGetValue(unionType, out var button))
            {
                button.interactable = isInteractable;
            }
        }


       public void SetPactActive(bool isActive, UnionTypes unionType)
        {
            if (_pacts.TryGetValue(unionType, out var pact))
            {
                pact.SetActive(isActive);
            }
        }
        
        
        public void SetTradePactActive()
        {
            _tradePact.SetActive(true);
            OnMakePact?.Invoke(UnionTypes.Trade);
        }
        
        
        public void SetSciencePactActive()
        {
            _sciencePact.SetActive(true);
            OnMakePact?.Invoke(UnionTypes.Science);
        }
        
        
        public void SetWarPactActive()
        {
            _warPact.SetActive(OnMakeWar!.Invoke(UnionTypes.War));
        }
    }
}
