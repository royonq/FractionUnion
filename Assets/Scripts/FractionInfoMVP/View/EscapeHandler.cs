using System;
using SwichPannelsMVP.Buttons;
using SwichPannelsMVP.PannelsView.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SwichPannelsMVP.PannelsView.View
{
   public class EscapeHandler : MonoBehaviour ,IEscapeHandler
   {
      public event Action<GameObject> OnButtonClick;
      public event Action OnHidePannel;

      
      [SerializeField] private GameObject _showPannelButton;
      public GameObject GetShowPannelButton => _showPannelButton;

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
         OnButtonClick?.Invoke(pannel);
      }
      
      public void OnHideFractionPannel(InputAction.CallbackContext context)
      {
         if (context.performed)
         {
            OnHidePannel?.Invoke();
         }
      }
   }
}
