using UnityEngine;

namespace PlayerRunTime
{
    public class Autorun : MonoBehaviour
    {
        #region Publics
        [SerializeField] private float _speed;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _gravity = -9.81f;
        [SerializeField] private float _jumpForce = 5f;
        #endregion

        #region Privates and Protected
        private Vector3 _velocity;
        #endregion

        #region Unity API
        private void Reset()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Awake()
        {
            if (_characterController == null)
            {
                _characterController = GetComponent<CharacterController>();
            }
        }

        private void Update()
        {
            ApplyMovement();
            ApplyGravity();
        }
        #endregion

        #region Main Methods
        private void ApplyMovement()
        {
            // Déplacement avant
            Vector3 movement = transform.forward * _speed;
            _characterController.Move(movement * Time.deltaTime);
        }

        private void ApplyGravity()
        {
            // Vérifier si on est au sol
            if (_characterController.isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f; // Petite valeur pour rester collé au sol
            }

            // Appliquer la gravité
            _velocity.y += _gravity * Time.deltaTime;

            // Appliquer la vélocité verticale
            _characterController.Move(_velocity * Time.deltaTime);
        }

        public void Jump()
        {
            if (_characterController.isGrounded)
            {
                _velocity.y = _jumpForce;
            }
        }
        #endregion

        #region Utils
        /* Fonctions privées utiles */
        #endregion
    }
}