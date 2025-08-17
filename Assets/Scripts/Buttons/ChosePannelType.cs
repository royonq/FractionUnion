using System;
using UnityEngine;

namespace SwichPannelsMVP.Buttons
{
    public class ChosePannelType : MonoBehaviour
    {
        public static event Action<GameObject> OnButtonClick;
        [SerializeField] private GameObject _type;

        public void OnClick()
        {
            OnButtonClick?.Invoke(_type);
        }
    }
}
