using UnityEngine;

namespace Scriptables.ScriptableScripts
{
    [CreateAssetMenu(fileName = "FractionData", menuName = "Data/FractionData")]
    public class FractionData : ScriptableObject
    { 
         [SerializeField] private Sprite[] _icons;

        public Sprite[] GetIcons => _icons;
        
        [SerializeField] private Sprite[] _avatars;
        public Sprite[] GetAvatars => _avatars;
        
        [SerializeField] private Sprite[] _tradePacts;
        public Sprite[] GetTradePacts => _tradePacts;
        
        [SerializeField] private Sprite[] _sciencePacts;
        public Sprite[] GetSciencePacts => _sciencePacts;
        
        [SerializeField] private Sprite[] _warPacts;
        public Sprite[] GetWarPacts => _warPacts;
        
        [SerializeField] private string[] _names;
        public string[] GetNames => _names;
    }
}

