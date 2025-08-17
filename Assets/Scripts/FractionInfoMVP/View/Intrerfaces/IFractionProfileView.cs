using System;
using UnityEngine;

namespace FractionInfoMVP.View.Intrerfaces
{
   public interface IFractionProfileView
   {
      event Action<int> OnButtonClick;
      void SetFractionInfo(Sprite avatar, Sprite icon, string name, Color color);
   }
}