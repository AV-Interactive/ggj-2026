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
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundCheckDistance = 0.2f;
        [SerializeField] private Animator _animator;
        [Header("Debug")]
        [SerializeField] private float _currentGravityMultiplier = 1f; // ← Affichage de la gravité
        #endregion
        #region Unity API
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
            CheckGroundCollision();
            _currentGravityMultiplier = GetGravityMultiplier(); // ← Mise à jour de l'affichage
            bool isGrounded = IsGrounded();

            if (_animator != null && isGrounded)
            {
                _animator.SetBool("IsJumping", false);
                _animator.SetBool("IsGliding", false); // ← Arrête l'animation de planage
            }
        }
        private void OnDisable()
        {
            // Sécurité : remettre la gravité normale quand le script est désactivé
            _isGliderActive = false;
            _currentGravityMultiplier = 1f;
            if (_animator != null)
            {
                _animator.SetBool("IsGliding", false);
            }
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            // Vérifie si on touche le sol par le bas
            if (hit.normal.y > 0.7f && ((1 << hit.gameObject.layer) & _groundLayer) != 0)
            {
                _isGliderActive = false;

                if (_animator != null)
                {
                    _animator.SetBool("IsGliding", false);
                }
            }
        }
        #endregion
        #region Main Methods
        public float GetGravityMultiplier()
        {
            // Sécurité : si le script est désactivé, gravité normale
            if (!enabled)
            {
                return 1f;
            }
            // Sécurité : si on touche le sol, gravité normale
            if (IsGrounded())
            {
                return 1f;
            }
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
            if (IsGrounded())
            {
                _isGliderActive = false;

                // Arrête l'animation quand au sol
                if (_animator != null)
                {
                    _animator.SetBool("IsGliding", false);
                }
            }
        }
        private bool IsGrounded()
        {
            // Vérification du CharacterController
            if (_characterController.isGrounded)
            {
                return true;
            }
            // Vérification par Raycast avec le layer
            Vector3 origin = transform.position;
            return Physics.Raycast(origin, Vector3.down, _groundCheckDistance, _groundLayer);
        }
        public void SetGliderActive(bool isActive)
        {
            AudioManager._Instance.PlaySFX(_planeSound);
            _isGliderActive = true;
            // Active l'animation de planage
            if (_animator != null)
            {
                _animator.SetBool("IsGliding", true);
            }
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
    }
}