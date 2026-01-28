using UnityEngine;

namespace PlayerRunTime
{
    public class CreatProjectil : MonoBehaviour
    {
        #region Publics
        [SerializeField] private GameObject _projectilPrefab;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Camera _camera;
        [SerializeField] private float _maxDistance = 100f;
        #endregion

        #region Unity API
        private void Awake()
        {
            // Si pas de firePoint défini, utiliser la position du personnage
            if (_firePoint == null)
            {
                _firePoint = transform;
            }

            // Si pas de caméra définie, utiliser la caméra principale
            if (_camera == null)
            {
                _camera = Camera.main;
            }
        }
        #endregion

        #region Main Methods
        public void OnShoot(bool shootAction)
        {
            Shoot();
        }

        private void Shoot()
        {
            // Détruire le projectile existant s'il y en a un
            if (_currentProjectil != null)
            {
                Destroy(_currentProjectil);
            }

            // Créer un nouveau projectile
            if (_projectilPrefab != null)
            {
                // Calculer la direction vers la souris
                Vector3 mouseDirection = GetMouseWorldDirection();
                Quaternion rotation = Quaternion.LookRotation(mouseDirection);

                _currentProjectil = Instantiate(_projectilPrefab, _firePoint.position, rotation);
            }
            else
            {
                Debug.LogWarning("Projectil Prefab non assigné !");
            }
        }

        private Vector3 GetMouseWorldDirection()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance))
            {
                return (hit.point - _firePoint.position).normalized;
            }

            return _firePoint.forward;
        }
        #endregion

        #region Utils
        /* Fonctions privées utiles */
        #endregion

        #region Privates and Protected
        private GameObject _currentProjectil;
        #endregion
    }
}