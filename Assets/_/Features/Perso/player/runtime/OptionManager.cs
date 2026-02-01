using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PlayerRunTime
{
    public class OptionManager : MonoBehaviour
    {
        #region Publics
        [Header("Timer Settings")]
        [SerializeField] private float _timer = 5f; // Durée du timer en secondes
        [SerializeField] private string _sceneToLoad = "MainScene"; // Nom de la scène à charger
        [SerializeField] private bool _startTimerOnAwake = true; // Démarrer automatiquement

        [Header("Skip Button")]
        [SerializeField] private Button _skipButton; // Bouton pour passer
        #endregion

        #region Privates and Protected
        private float _currentTime;
        private bool _isTimerActive = false;
        #endregion

        #region Unity API
        private void Start()
        {
            // Associer le bouton skip si présent
            if (_skipButton != null)
            {
                _skipButton.onClick.AddListener(SkipTimer);
            }

            if (_startTimerOnAwake)
            {
                StartTimer();
            }
        }

        private void Update()
        {
            if (_isTimerActive)
            {
                _currentTime -= Time.deltaTime;

                if (_currentTime <= 0f)
                {
                    OnTimerComplete();
                }
            }
        }

        private void OnDestroy()
        {
            // Nettoyer l'événement du bouton
            if (_skipButton != null)
            {
                _skipButton.onClick.RemoveListener(SkipTimer);
            }
        }
        #endregion

        #region Main Methods
        /// <summary>
        /// Démarre le timer
        /// </summary>
        public void StartTimer()
        {
            _currentTime = _timer;
            _isTimerActive = true;
            Debug.Log($"Timer démarré : {_timer} secondes");
        }

        /// <summary>
        /// Arrête le timer
        /// </summary>
        public void StopTimer()
        {
            _isTimerActive = false;
            Debug.Log("Timer arrêté");
        }

        /// <summary>
        /// Réinitialise le timer
        /// </summary>
        public void ResetTimer()
        {
            _currentTime = _timer;
            Debug.Log("Timer réinitialisé");
        }

        /// <summary>
        /// Passe le timer et charge immédiatement la scène
        /// </summary>
        public void SkipTimer(bool skip)
        {
            if (!skip) return; // Ne rien faire si skip est false

            Debug.Log("Timer passé ! Chargement immédiat de la scène...");
            _isTimerActive = false;
            LoadScene();
        }

        /// <summary>
        /// Surcharge pour les boutons UI (sans paramètre)
        /// </summary>
        public void SkipTimer()
        {
            SkipTimer(true);
        }

        /// <summary>
        /// Appelé quand le timer se termine
        /// </summary>
        private void OnTimerComplete()
        {
            _isTimerActive = false;
            Debug.Log($"Timer terminé ! Chargement de la scène : {_sceneToLoad}");
            LoadScene();
        }

        /// <summary>
        /// Charge la scène spécifiée
        /// </summary>
        private void LoadScene()
        {
            if (!string.IsNullOrEmpty(_sceneToLoad))
            {
                SceneManager.LoadScene(_sceneToLoad);
            }
            else
            {
                Debug.LogWarning("Aucune scène spécifiée pour le chargement !");
            }
        }
        #endregion

        #region Utils
        /// <summary>
        /// Retourne le temps restant
        /// </summary>
        public float GetRemainingTime()
        {
            return _currentTime;
        }

        /// <summary>
        /// Retourne le pourcentage de progression (0-1)
        /// </summary>
        public float GetProgress()
        {
            return 1f - (_currentTime / _timer);
        }

        /// <summary>
        /// Vérifie si le timer est actif
        /// </summary>
        public bool IsTimerActive()
        {
            return _isTimerActive;
        }
        #endregion
    }
}