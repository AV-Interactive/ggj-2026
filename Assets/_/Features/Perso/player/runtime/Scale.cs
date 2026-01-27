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
        #endregion

        #region Unity API

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
                StartScaling(ref _isScalingDown, ref _isScalingUp);
            }
        }

        public void OnScaleUp(bool scaleUpAction)
        {
            if (!_hasScaledUp)
            {
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
                _scaleTransform.localScale += scaleChange;
                _currentScaleTime--;
                _timer = 0f;

                if (_currentScaleTime < 1f)
                {
                    isScaling = false;
                    hasScaled = true;
                }
            }
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