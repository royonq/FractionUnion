using System;
using FractionInfoMVP.View.Intrerfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FractionInfoMVP.View
{
    public class FractionProfileView : MonoBehaviour , IFractionProfileView
    {
        public event Action<int> OnButtonClick;
    
        [SerializeField] protected Image _avatarImage;
    
        [SerializeField] protected Image _iconImage;
    
        [SerializeField] protected TMP_Text _nameText;
    
        public void OnClick(int index)
        {
            OnButtonClick?.Invoke(index);
        }
    
        public void SetFractionInfo(Sprite avatar, Sprite icon, string name, Color color)
        {
            _avatarImage.sprite = avatar;
            _iconImage.sprite = icon;
            _nameText.text = name;
            _nameText.color = color;
        }
    }
}
