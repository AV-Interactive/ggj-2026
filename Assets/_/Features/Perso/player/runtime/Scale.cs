using UnityEngine;

namespace PlayerRunTime
{
    public class Scale : MonoBehaviour
    {
        #region Publics
        [SerializeField] private Transform _scaleTransform;
        [SerializeField] private float _scaleX;
        [SerializeField] private float _scaleY;
        [SerializeField] private float _scaleZ;
        [SerializeField] private float _scaleTime = 5f;
        [SerializeField] private float _speedScale = 1f;
        [SerializeField] private bool _scaleDownAction;
        [SerializeField] private bool _scaleUpAction;
        [SerializeField] private LayerMask _obstacleLayer;
        [SerializeField] private AudioClip _scaleSound;
        #endregion

        #region Unity API
        private void OnEnable()
        {
            _hasScaledUp = false;
            _hasScaledDown = false;
            OnScaleDown(true);
        }

        private void OnDisable()
        {
            if (_scaleTransform != null)
            {
                _scaleTransform.localScale = Vector3.one;
            }
            _hasScaledDown = false;
            _hasScaledUp = false;
            _isScalingDown = false;
            _isScalingUp = false;
        }

        private void Update()
        {
            ResetIfBothActionsCompleted();
            ProcessScaling();
        }
        #endregion

        #region Main Methods
        public void OnScaleDown(bool scaleDownAction)
        {
            if (!_hasScaledDown)
            {
                AudioManager.Instance.PlaySFX(_scaleSound);
                StartScaling(ref _isScalingDown, ref _isScalingUp);
            }
        }

        public void OnScaleUp(bool scaleUpAction)
        {
            if (!_hasScaledUp)
            {
                AudioManager.Instance.PlaySFX(_scaleSound);
                StartScaling(ref _isScalingUp, ref _isScalingDown);
            }
        }

        private void StartScaling(ref bool activeScaling, ref bool inactiveScaling)
        {
            activeScaling = true;
            inactiveScaling = false;
            _timer = 0f;
            _currentScaleTime = _scaleTime;
        }

        private void ProcessScaling()
        {
            if (_isScalingDown)
            {
                ApplyScaling(-1f, ref _isScalingDown, ref _hasScaledDown);
            }
            if (_isScalingUp)
            {
                ApplyScaling(1f, ref _isScalingUp, ref _hasScaledUp);
            }
        }

        private void ApplyScaling(float direction, ref bool isScaling, ref bool hasScaled)
        {
            _timer += Time.deltaTime * _speedScale;
            if (_timer >= 1f && _currentScaleTime >= 1f)
            {
                Vector3 scaleChange = new Vector3(_scaleX, _scaleY, _scaleZ) * direction;
                Vector3 newScale = _scaleTransform.localScale + scaleChange;

                // Vérifier s'il y a assez d'espace pour grandir
                if (direction > 0 && CanScale(newScale))
                {
                    _scaleTransform.localScale = newScale;
                    _currentScaleTime--;
                    _timer = 0f;
                }
                else if (direction < 0) // Toujours permettre de rétrécir
                {
                    _scaleTransform.localScale = newScale;
                    _currentScaleTime--;
                    _timer = 0f;
                }
                else if (direction > 0 && !CanScale(newScale))
                {
                    _timer = 0f; // Reset le timer pour réessayer
                    // Ne pas décrémenter _currentScaleTime pour garder les tentatives
                }

                if (_currentScaleTime < 1f)
                {
                    isScaling = false;
                    hasScaled = true;
                }
            }
        }

        private bool CanScale(Vector3 newScale)
        {
            // Calculer la taille du collider basé sur la nouvelle échelle
            Collider collider = _scaleTransform.GetComponent<Collider>();

            if (collider == null)
                return true; // Pas de collider, autoriser

            // Vérifier avec un OverlapBox si un objet bloque
            Vector3 center = _scaleTransform.position;
            Vector3 halfExtents = newScale * 0.5f;

            Collider[] overlaps = Physics.OverlapBox(center, halfExtents, _scaleTransform.rotation, _obstacleLayer);

            // Filtrer pour ignorer le collider de l'objet lui-même
            foreach (Collider overlap in overlaps)
            {
                if (overlap.transform != _scaleTransform && overlap.transform.parent != _scaleTransform)
                {
                    return false; // Obstacle détecté
                }
            }

            return true; // Pas d'obstacle
        }

        private void ResetIfBothActionsCompleted()
        {
            if (_hasScaledDown && _hasScaledUp)
            {
                _hasScaledDown = false;
                _hasScaledUp = false;
            }
        }
        #endregion

        #region Utils
        /* Fonctions privées utiles */
        #endregion

        #region Privates and Protected
        private float _timer = 0f;
        private bool _isScalingDown = false;
        private bool _isScalingUp = false;
        private float _currentScaleTime = 0f;
        private bool _hasScaledDown = false;
        private bool _hasScaledUp = false;
        #endregion
    }
}