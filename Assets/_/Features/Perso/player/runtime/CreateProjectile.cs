using UnityEngine;

namespace PlayerRunTime
{
    public class CreateProjectile : MonoBehaviour
    {
        #region Publics

        [SerializeField] private GameObject _projectilPrefab;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Camera _camera;
        [SerializeField] private float _maxDistance = 100f;
        [SerializeField] private Vector2 _mousePosition ;


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

        public void SetMousePosition(Vector2 mousePosition)
        {
            _mousePosition = mousePosition;
        }

        public void OnShoot(bool shootAction)
        {
            if(this.enabled)
            {
                if (shootAction)
                Shoot();
            }
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
            // Créer un plan au niveau Z=0 (le plan de jeu)
            Plane gamePlane = new Plane(Vector3.forward, Vector3.zero);

            // Créer un ray depuis la caméra vers la position de la souris
            Ray ray = _camera.ScreenPointToRay(_mousePosition);

            // Trouver l'intersection entre le ray et le plan
            if (gamePlane.Raycast(ray, out float distance))
            {
                // Point d'intersection sur le plan Z=0
                Vector3 mouseWorldPos = ray.GetPoint(distance);
                mouseWorldPos.z = 0f; // Forcer Z à 0 pour être sûr

                // Position du joueur
                Vector3 playerPos = _firePoint.position;
                playerPos.z = 0f;

                // Direction
                Vector3 direction = (mouseWorldPos - playerPos).normalized;

                // Debug
                Debug.DrawLine(playerPos, mouseWorldPos, Color.red, 2f);
                Debug.DrawRay(playerPos, direction * 3f, Color.green, 2f);

                return direction;
            }

            // Fallback au cas où le raycast échoue (ne devrait jamais arriver)
            Debug.LogWarning("Raycast sur le plan a échoué!");
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