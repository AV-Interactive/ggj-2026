using Unity.Cinemachine;
using UnityEngine;

namespace UtilsRuntime._.Features.Utils
{
    public class CheckScreenResolution : MonoBehaviour
    {

        #region Publics

        //

        #endregion


        #region Unity API

        void Awake()
        {
            _vcam = GetComponent<CinemachineCamera>();
            _initialOrthoSize = _vcam.Lens.OrthographicSize;
            
            AdjustCamera();
        }

        #endregion


        #region Main Methods

        // 

        #endregion


        #region Utils

        /* Fonctions privées utiles */
        void AdjustCamera()
        {
            float currentAspect = (float)Screen.width / Screen.height;
            
            Debug.Log($"Aspect actuel : {currentAspect}");
            Debug.Log($"Aspect Cible : {_targetAspect}");

            if (currentAspect < _targetAspect)
            {
                float differenceInSize = _targetAspect / currentAspect;
                LensSettings lens = _vcam.Lens;
                lens.OrthographicSize = _initialOrthoSize * differenceInSize;
                _vcam.Lens = lens;
            }
            else
            {
                LensSettings lens = _vcam.Lens;
                lens.OrthographicSize = _initialOrthoSize;
                _vcam.Lens = lens;
            }
        }

        #endregion


        #region Privates and Protected
        
        CinemachineCamera _vcam;
        float _initialOrthoSize;
        float _targetAspect = 1920f / 1080f;

        #endregion
    }
}

