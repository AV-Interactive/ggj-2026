using UnityEngine;
using UnityEngine.Events;

namespace PlayerRunTime
{
    public class Jump : MonoBehaviour
    {

        #region Publics

        [SerializeField] private float _jumpForce;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private bool _inGround = true;
        [SerializeField] private bool _isJump;
        [SerializeField] private UnityEvent _onJump;
        [SerializeField] private UnityEvent <bool> _onJumpChanged;

        #endregion


        #region Unity API
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                _inGround = true;
                _isJump = false;
            }
        }
        #endregion


        #region Main Methods
        public void SetJumpingState(bool isJump)
        {
            if (_isJump != isJump && isJump && _inGround)
            {
                _onJumpChanged.Invoke(isJump);
                _isJump = true;
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _onJump.Invoke();
                _inGround = false;
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

