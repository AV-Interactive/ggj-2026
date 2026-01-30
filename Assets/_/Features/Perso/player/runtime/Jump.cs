using System;
using UnityEngine;

namespace PlayerRunTime
{
    public class Jumps : MonoBehaviour
    {
        #region Publics
        [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Autorun _autorun;

        [SerializeField] private AudioClip _jumpSound;
        #endregion

        #region Unity API

        void OnEnable()
        {
            _canJump = true;
        }

        void OnDisable()
        {
            _canJump = false;
        }

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
        public void OnJump(bool isJumping)
        {
            if (!_canJump) return;
            Jump();
        }

        public void Jump()
        {
            if (!_canJump) return;
            if (_characterController.isGrounded)
            {
                AudioManager._Instance.PlaySFX(_jumpSound);
                _autorun.SetVelocityY(_jumpForce);
            }
        }
        #endregion

        #region Utils
        /* Fonctions privées utiles */
        #endregion

        #region Privates and Protected
        
        // Variables privées
        bool _canJump = false;

        #endregion
    }
}