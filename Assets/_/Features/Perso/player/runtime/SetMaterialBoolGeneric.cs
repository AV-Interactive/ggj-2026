using UnityEngine;

namespace Utils
{
    public class SetMaterialBoolGeneric : MonoBehaviour
    {

        #region Publics

        //

        #endregion


        #region Unity API

        //

        #endregion


        #region Main Methods

        public void SetOnOff(bool value)
        {
            if (value)
            {
                SetOnOff(1);
            }
            else
            {
                SetOnOff(0);
            }
        }
        
        public void SetOnOff(int onOff)
        {
            Debug.Log($"On Off: {onOff}");
            _materialTarget.SetInt(_propertyName, onOff);
        }
        
        [ContextMenu("SetOn")]
        public void SetOn()
        {
            SetOnOff(1);
        }

        [ContextMenu("SetOff")]
        public void SetOff()
        {
            SetOnOff(0);
        }

        #endregion


        #region Utils

        /* Fonctions privées utiles */

        #endregion


        #region Privates and Protected

        // Variables privées
        [SerializeField] Material _materialTarget;
        [SerializeField] string _propertyName;

        #endregion
    }
}

