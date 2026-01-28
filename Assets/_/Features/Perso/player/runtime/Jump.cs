using UnityEngine;

namespace PlayerRunTime
{
    public class Jumps : MonoBehaviour
    {
        #region Publics
        [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Autorun _autorun;
        #endregion

        #region Unity API
        private void Reset()
        {
            _characterController = GetComponent<CharacterController>();
            _autorun = GetComponent<Autorun>();
        }

        private void Awake()
        {
            if (_characterController == null)
            {
                _characterController = GetComponent<CharacterController>();
            }

            if (_autorun == null)
            {
                _autorun = GetComponent<Autorun>();
            }
        }

        #endregion

        #region Main Methods
        private void OnJump(bool isJumping)
        {
            Jump();
        }

        public void Jump()
        {
            if (_characterController.isGrounded)
            {
                _autorun.SetVelocityY(_jumpForce);
            }
        }
        #endregion

        #region Utils
        /* Fonctions privées utiles */
        #endregion

        #region Privates and Protected
        // Variables privées
        #endregion
    }
}