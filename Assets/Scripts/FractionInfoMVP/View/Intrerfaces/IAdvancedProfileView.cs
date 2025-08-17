using System;
using Enums;
using UnityEngine;

namespace FractionInfoMVP.View.Intrerfaces
{
    public interface 
        IAdvancedProfileView
    {
        event Action<int> OnAddReputation;
        event Action<UnionTypes> OnMakePact; 
        event Func<UnionTypes,bool> OnMakeWar;
 
        void SetProfileInfo(Sprite avatar,Sprite icon,Sprite tradePact,Sprite sciencePact,Sprite warPact, string name, int reputationValue);
    
 
        void UpdateReputationText(int reputationValue, Color textColor);
        void UpdateWarOrPeaceText(bool isWar);

        void SetPactButtonInteractable(bool isInteractable, UnionTypes unionType);
        void SetPactActive(bool isActive, UnionTypes unionType);
    }
}