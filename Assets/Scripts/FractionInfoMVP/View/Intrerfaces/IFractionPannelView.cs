using System;
using UnityEngine;

namespace SwichPannelsMVP.PannelsView.Interfaces
{
    public interface IEscapeHandler
    {
        event Action<GameObject> OnButtonClick;
        event Action OnHidePannel;
        GameObject GetShowPannelButton { get;  }
    }
}
