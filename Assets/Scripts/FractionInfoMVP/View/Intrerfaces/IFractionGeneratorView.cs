using Enums;
using UnityEngine;

public interface IFractionBlockView
{
    void SetFractionInfo(int index, Sprite icon, Sprite tradePactSprite, Sprite sciencePactSprite, string name,
        int value, Color color);
    void SetPactActive(int index,UnionTypes unionType, bool isActive);
}
