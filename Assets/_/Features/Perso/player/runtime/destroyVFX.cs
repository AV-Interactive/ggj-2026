using UnityEngine;

namespace PlayerRunTime
{
    public class destroyVFX : MonoBehaviour
    {
        #region Publics

        [SerializeField] private float _lifeTime = 5f;

        #endregion

        #region Unity API

        private void Start()
        {
            Destroy(gameObject, _lifeTime); 
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

