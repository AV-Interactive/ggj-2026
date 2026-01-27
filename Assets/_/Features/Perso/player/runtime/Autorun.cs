using UnityEngine;

namespace PlayerRunTime
{
    public class Autorun : MonoBehaviour
    {

        #region Publics

        [SerializeField] public float _speed;
        [SerializeField] public Rigidbody _rigidbody;
        [SerializeField] public Transform _whatToMove;
        [SerializeField] public float _forceAmount;
        [SerializeField] public ForceMode _force;

        #endregion


        #region Unity API

        private void Reset()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _whatToMove = this.transform;
        }

        private void Update()
        {
            _whatToMove.Translate(Vector3.forward * _speed * Time.deltaTime);
            // _rigidbody.AddForce(Vector3.right * _forceAmount, _force);
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

