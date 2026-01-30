using UnityEngine;

namespace PlayerRunTime
{
    public class Planneur : MonoBehaviour
    {
        #region Publics
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Autorun _autorun;
        [SerializeField] private bool _isGliderActive = false;
        [SerializeField] private float _fallingGravityScale = 2f;
        [SerializeField] private float _glidingGravityScale = 0.1f;
        [SerializeField] private float _fallThreshold = -0.1f;
        [SerializeField] private AudioClip _planeSound;
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

        private void Update()
        {
            CheckGroundCollision();
        }
        #endregion

        #region Main Methods
        public float GetGravityMultiplier()
        {
            if (_isGliderActive && _autorun.GetVelocity().y < _fallThreshold)
            {
                return _glidingGravityScale;
            }
            else if (_autorun.GetVelocity().y < _fallThreshold)
            {
                return _fallingGravityScale;
            }

            return 1f;
        }

        private void CheckGroundCollision()
        {
            if (_characterController.isGrounded)
            {
                _isGliderActive = false;
            }
        }

        public void SetGliderActive(bool isActive)
        {
            AudioManager._Instance.PlaySFX(_planeSound);

            _isGliderActive = true;
        }

        public bool IsGliderActive()
        {
            return _isGliderActive;
        }
        #endregion

        #region Utils
        private bool IsFalling()
        {
            return _autorun.GetVelocity().y < _fallThreshold;
        }
        #endregion

        #region Privates and Protected

        #endregion
    }
}