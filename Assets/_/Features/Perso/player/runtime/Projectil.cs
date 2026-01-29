using UnityEngine;

namespace PlayerRunTime
{
    public class Projectil : MonoBehaviour
    {
        #region Publics
        [SerializeField] private float _speed = 10f;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _lifeTime = 5f;
        [SerializeField] private LayerMask _enemyLayer;
        [SerializeField] private GameObject _explosionVFXPrefab;
        [SerializeField] private AudioClip _hitSound;
        #endregion

        #region Unity API
        private void Start()
        {
            if (_rigidbody == null)
            {
                _rigidbody = GetComponent<Rigidbody>();
            }

            // Détruire le projectile après un certain temps
            Destroy(gameObject, _lifeTime);

            // Appliquer la force une seule fois au départ
            _rigidbody.AddForce(transform.forward * _speed, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision collision)
        {
            AudioManager.Instance.PlaySFX(_hitSound);

            // Instancier l'explosion à la position de la collision
            if (_explosionVFXPrefab != null)
            {
                Instantiate(_explosionVFXPrefab, collision.contacts[0].point, Quaternion.identity);
            }

            // Vérifier si l'objet touché est sur le layer Enemy
            if (((1 << collision.gameObject.layer) & _enemyLayer) != 0)
            {
                Destroy(collision.gameObject); // Détruire l'ennemi
            }

            Destroy(gameObject); // Détruire le projectile
        }
        #endregion

        #region Main Methods
        // Méthode plus nécessaire
        #endregion

        #region Utils
        /* Fonctions privées utiles */
        #endregion

        #region Privates and Protected
        // Variables privées
        #endregion
    }
}