using System;
using System.Collections.Generic;
using SwichPannelsMVP.Buttons;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SwichPannelsMVP.PannelsView.View
{
   public class EscapeHandler : MonoBehaviour
   {
      
      private readonly Stack<GameObject> _pannelStack = new();
      
      
      [SerializeField] private GameObject _showPannelButton;

      private void OnEnable()
      {
         ChosePannelType.OnButtonClick += OnClick;
      }

      private void OnDisable()
      {
         ChosePannelType.OnButtonClick -= OnClick;
      }
      
      private void OnClick(GameObject pannel)
      {
         OpenFractionPannel(pannel);
      }
      
      public void OnHideFractionPannel(InputAction.CallbackContext context)
      {
         if (context.performed)
         {
            CloseFractionPannels();
         }
      }
      

      private void OpenFractionPannel(GameObject pannel)
      {
         pannel.SetActive(true);
         _pannelStack.Push(pannel);
      }

      private void CloseFractionPannels()
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
