using UnityEngine;

namespace SwichPannelsMVP.PannelsModel.Interfaces
{
    public interface IFractionButtonsModel
    {
        void OpenFractionPannel(GameObject pannel);
        void CloseFractionPannels();
        void SetFractionPannels(
            GameObject showPannelButton);
    }
}
