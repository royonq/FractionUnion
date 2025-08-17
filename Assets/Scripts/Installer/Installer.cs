using System;
using System.Collections.Generic;
using FractionInfoMVP.Model;
using FractionInfoMVP.Presenter;
using FractionInfoMVP.View;
using Scriptables.ScriptableScripts;
using UnityEngine;

namespace Installer
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private FractionData _fractionData;

        [SerializeField] private FractionBlockView _fractionBlockView;
        [SerializeField] private FractionProfileView _fractionProfileView;
        [SerializeField] private AdvancedProfileView _advancedProfileView;

        private FractionButtonsPresenter fractionButtonsPresenter;

        private readonly List<IDisposable> _disposables = new();
    
        private void Awake()
        {
            var fractionGeneratorModel = new FractionGeneratorModel(_fractionData);
            var advancedProfileModel = new AdvancedProfileModel();
        
            var fractionGeneratorPresenter = new FractionGeneratorPresenter(_fractionBlockView, fractionGeneratorModel);
            fractionButtonsPresenter = new FractionButtonsPresenter(_fractionProfileView,_advancedProfileView, advancedProfileModel,fractionGeneratorModel,
                fractionGeneratorPresenter);
       
            
            _disposables.Add(fractionButtonsPresenter);
        }
    
        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}
