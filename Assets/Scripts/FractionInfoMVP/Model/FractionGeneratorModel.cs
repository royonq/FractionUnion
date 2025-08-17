using System.Collections.Generic;
using System.Linq;
using Data.NewFraction;
using Scriptables.ScriptableScripts;
using UnityEngine;

namespace FractionInfoMVP.Model
{
    public class FractionGeneratorModel : IFractionGeneratorModel
    {
        private readonly FractionData _fractionData;

        private readonly List<Fraction> _fractions = new();
        
        private Sprite[] _randomAvatar;
        private Sprite[] _randomIcon; 
        private string[] _randomName;

        public FractionGeneratorModel(FractionData fractionData)
        {
            _fractionData = fractionData;  
        
            RandomizeData();
        }

        public Fraction GetFractionByIndex(int index)
        {
            return _fractions[index];
        }
    
        private void RandomizeData()
        {
            _randomAvatar = RandomizeArray(_fractionData.GetAvatars);
            _randomIcon = RandomizeArray(_fractionData.GetIcons);
            _randomName = RandomizeArray(_fractionData.GetNames);
        }
    
        public void GenerateFractions()
        {
            for (var i = 0; i < 6; i++)
            {
                var fraction = new Fraction(_randomAvatar[i], _randomIcon[i],_fractionData.GetTradePacts[i],_fractionData.GetSciencePacts[i],_fractionData.GetWarPacts[i], _randomName[i],i);
                _fractions.Add(fraction);
            }
        }
    
        private T[] RandomizeArray<T>(T[] array)
        {
            var randomIndex = Enumerable.Range(0, array.Length)
                .OrderBy(_ => Random.value)
                .ToArray();

            var randomized = new T[array.Length];
            for (var i = 0; i < array.Length; i++)
            {
                randomized[i] = array[randomIndex[i]];
            }
            return randomized;
        }
    }
}
