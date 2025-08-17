using System;
using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FractionInfoMVP.View
{
    public class FractionBlockView : MonoBehaviour, IFractionBlockView
    {
        [SerializeField] private Image[] _icons;
        [SerializeField] private TMP_Text[] _names;
        [SerializeField] private TMP_Text[] _reputationTexts;
        [SerializeField] private GameObject[] _tradePacts;
        [SerializeField] private GameObject[] _sciencePacts;
        [SerializeField] private GameObject[] _warPacts;

        public void SetFractionInfo(int index,Sprite icon,Sprite tradePactSprite,Sprite sciencePactSprite,string name,int value,Color color)
        {
            _icons[index].sprite = icon;
            _names[index].text = name;
            _tradePacts[index].GetComponent<Image>().sprite = tradePactSprite;
            _sciencePacts[index].GetComponent<Image>().sprite = sciencePactSprite;
            _reputationTexts[index].text = value.ToString();
            _reputationTexts[index].color = color;
        }
    

        public void SetPactActive(int index,UnionTypes unionType, bool isActive)
        {

            switch (unionType)
            {
                case UnionTypes.Trade:
                    _tradePacts[index].SetActive(isActive);
                    break;
                case UnionTypes.Science:
                    _sciencePacts[index].SetActive(isActive);
                    break;
                case UnionTypes.War:
                    _warPacts[index].SetActive(isActive);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(unionType), unionType, null);
            }
        }
    }
}
