using Enums;
using UnityEngine;

namespace Data.NewFraction
{
    public class Fraction 
    {
        public int Id { get; }

        public Sprite Avatar { get; }

        public Sprite Icon { get; }

        public Sprite TradePactSprite { get; }

        public Sprite SciencePactSprite { get; }
        
        public Sprite WarPactSprite { get; }

        public string Name { get; }

        public UnionTypes UnionTypes { get; private set; }

        public int Reputation { get; private set; }

        public void SetReputation(int value)
        {
            Reputation = value;
        }
        
        
        public Fraction(Sprite avatar, Sprite icon,Sprite tradePactSprite, Sprite sciencePactSprite,Sprite warPactSprite, string name, int id)
        {
            Avatar = avatar;
            Icon = icon;
            Name = name;
            Id = id;
            WarPactSprite = warPactSprite;
            TradePactSprite = tradePactSprite;
            SciencePactSprite = sciencePactSprite;
        }

        public void AddPact(UnionTypes unionType)
        {
           UnionTypes |= unionType;
        }
  
        
        public void DeterminantePact(UnionTypes unionType)
        {
            UnionTypes &= ~unionType;
        }
        
        public Color GetReputationColor()
        {
           var  _color = Reputation switch
            {
                0 => Color.white,
                > 0 => Color.green,
                < 0 => Color.red
            };

            return _color;
        }
    }
}
