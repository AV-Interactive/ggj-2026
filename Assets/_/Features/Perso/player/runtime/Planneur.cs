using UnityEngine;
using UnityEngine.UIElements;

namespace PlayerRunTime
{
    public class Planneur : MonoBehaviour
    {

        #region Publics

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private bool _isGliderActive = false;
        [SerializeField] private float _normalGravityScale = 1f;
        [SerializeField] private float _fallingGravityScale = 2f;
        [SerializeField] private float _glidingGravityScale = 0.3f;
        [SerializeField] private float _fallThreshold = -0.1f;

        #endregion


        #region Unity API

        private void Awake()
        {
            if (_rigidbody == null)
            {
                _rigidbody = GetComponent<Rigidbody>();
            }
        }

        private void FixedUpdate()
        {
            ApplyGravityModifier();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                _isGliderActive = false;
            }
        }

        #endregion


        #region Main Methods

        private void ApplyGravityModifier()
        {
            if (_isGliderActive && IsFalling())
            {
                // Mode planeur : gravité réduite
                float gravityReduction = 1f - _glidingGravityScale;
                _rigidbody.AddForce(Physics.gravity * -gravityReduction, ForceMode.Acceleration);
            }
            else if (IsFalling())
            {
                // Chute normale : gravité augmentée
                _rigidbody.AddForce(Physics.gravity * (_fallingGravityScale - 1f), ForceMode.Acceleration);
            }
        }

        public void SetGliderActive(bool isActive)
        {
            _isGliderActive = isActive;
        }

        #endregion


        #region Utils

        private bool IsFalling()
        {
            return _rigidbody.linearVelocity.y < _fallThreshold;
        }

        #endregion


        #region Privates and Protected

        // Variables privées

        #endregion
    }
}

