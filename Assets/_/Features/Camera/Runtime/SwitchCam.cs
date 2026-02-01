using EventsRuntime;
using UnityEngine;

namespace CameraRuntime
{
    public class SwitchCam : MonoBehaviour
    {

        #region Publics

        //

        #endregion


        #region Unity API

        void OnEnable()
        {
            PlayerEvents.OnJump += ChangeCam;
        }

        void OnDisable()
        {
            PlayerEvents.OnJump -= ChangeCam;
        }

        #endregion


        #region Main Methods

        //

        #endregion


        #region Utils

        /* Fonctions privées utiles */
        void ChangeCam(bool isActive)
        {
            _cameraJump.SetActive(isActive);
        }

        #endregion


        #region Privates and Protected

        // Variables privées
        [SerializeField] GameObject _cameraJump;

        #endregion
    }
}

