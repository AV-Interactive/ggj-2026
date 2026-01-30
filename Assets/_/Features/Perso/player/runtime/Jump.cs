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
        [SerializeField] private Animator _animator;
        [SerializeField] private LayerMask _groundLayer;
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
            _animator = GetComponent<Animator>();
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
            if (_animator == null)
            {
                _animator = GetComponent<Animator>();
            }
        }

        private void Update()
        {
            // Vérifie si le personnage touche le sol
            bool isGrounded = CheckGrounded();

            // Désactive l'animation de saut si au sol
            if (_animator != null && isGrounded)
            {
                _animator.SetBool("IsJumping", false);
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

                // Active l'animation de saut
                if (_animator != null)
                {
                    _animator.SetBool("IsJumping", true);
                }
            }
        }
        #endregion
        #region Utils
        private bool CheckGrounded()
        {
            // Utilise le CharacterController pour vérifier si au sol
            if (_characterController.isGrounded)
            {
                return true;
            }

            // Vérifie aussi avec un raycast vers le bas pour plus de précision
            float rayDistance = 0.3f;
            Vector3 origin = transform.position;

            return Physics.Raycast(origin, Vector3.down, rayDistance, _groundLayer);
        }
        #endregion
        #region Privates and Protected

        // Variables privées
        bool _canJump = false;
        #endregion
    }
}