using UnityEngine;

namespace PlayerRunTime
{
    public class ResetMask : MonoBehaviour
    {

        #region Publics

        //

        #endregion


        #region Unity API

        private void Awake()
        {
            SkillFilter.Instance.DeactivateAllMasks();
        }

        #endregion


        #region Main Methods

        // 

        #endregion


        #region Utils

        /* Fonctions privées utiles */

        #endregion


        #region Privates and Protected

        // Variables privées

        #endregion
    }
}

