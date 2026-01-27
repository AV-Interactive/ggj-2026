using UnityEngine;
using UnityEngine.UIElements;

namespace PlayerRunTime
{
    public class Planneur : MonoBehaviour
    {

        #region Publics

        [SerializeField] private Rigidbody _rigibody;
        [SerializeField] private float _normalGravityScale = 1f;
        [SerializeField] private float _fallingGravityScale = 2f;
        [SerializeField] private float _fallThreshold = -0.1f; // Vitesse Y en dessous de laquelle on considère être en chute

        #endregion


        #region Unity API

        private void Awake()
        {
            if (_rigibody == null)
            {
                _rigibody = GetComponent<Rigidbody>();
            }
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

