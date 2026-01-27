using UnityEngine;

namespace PlayerRunTime
{
    public class Autorun : MonoBehaviour
    {

        #region Publics

        [SerializeField] public float Speed;

        #endregion


        #region Unity API

        private void Update()
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
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

