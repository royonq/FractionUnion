using System.Collections.Generic;
using SwichPannelsMVP.PannelsModel.Interfaces;
using UnityEngine;

namespace SwichPannelsMVP.PannelsModel.Model
{
    public class FractionButtonsModel : IFractionButtonsModel
    {
        private readonly Stack<GameObject> _pannelStack = new();
        
        private GameObject _showPannelButton;
        
        public void SetFractionPannels(GameObject showPannelButton)
        {
            _showPannelButton = showPannelButton;
        }
        public void OpenFractionPannel(GameObject pannel)
        {
            pannel.SetActive(true);
            _pannelStack.Push(pannel);
        }

        public void CloseFractionPannels()
        {
            if (_pannelStack.Count <= 0)
            {
                return;
            }
            
            var lastPannel = _pannelStack.Pop();
            lastPannel.SetActive(false);

            if (_pannelStack.Count == 0)
            {
                _showPannelButton.SetActive(true);
            }
        }
    }
}
