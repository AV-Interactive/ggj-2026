using UnityEngine;
using UnityEngine.UI;
using System.IO;

namespace PlayerRunTime
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager _Instance;
        [SerializeField] private AudioSource _sfxSource;
        [SerializeField] private Slider _volumeSlider; // ← Ajout du slider
        private string _filePath;
        [SerializeField] private float _volume = 1f;

        [System.Serializable]
        class VolumeData
        {
            public float volume;
        }

        private void Awake()
        {
            if (_Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            _Instance = this;
            DontDestroyOnLoad(gameObject);

            // Sécurité si oublié dans l'Inspector
            if (_sfxSource == null)
            {
                _sfxSource = gameObject.AddComponent<AudioSource>();
                _sfxSource.playOnAwake = false;
            }

            _filePath = Path.Combine(Application.persistentDataPath, "volume.json");
            LoadVolume();
            ApplyVolume();
        }

        private void Start()
        {
            // Initialiser le slider avec la valeur chargée
            InitializeSlider();
        }

        void InitializeSlider()
        {
            if (_volumeSlider != null)
            {
                _volumeSlider.value = _volume;
                _volumeSlider.onValueChanged.AddListener(SetVolume);
            }
        }

        // 🎚️ Volume global
        public void SetVolume(float newVolume)
        {
            _volume = Mathf.Clamp01(newVolume);
            ApplyVolume();
            SaveAudio();
        }

        void ApplyVolume()
        {
            AudioListener.volume = _volume;
        }

        // 🔊 SFX
        public void PlaySFX(AudioClip clip)
        {
            if (clip == null) return;
            _sfxSource.PlayOneShot(clip);
        }

        void SaveAudio()
        {
            VolumeData data = new VolumeData { volume = _volume };
            File.WriteAllText(_filePath, JsonUtility.ToJson(data));
        }

        void LoadVolume()
        {
            if (!File.Exists(_filePath))
            {
                return;
            }
            string json = File.ReadAllText(_filePath);
            VolumeData data = JsonUtility.FromJson<VolumeData>(json);
            _volume = Mathf.Clamp01(data.volume);
        }

        private void OnDestroy()
        {
            // Nettoyer l'événement du slider
            if (_volumeSlider != null)
            {
                _volumeSlider.onValueChanged.RemoveListener(SetVolume);
            }
        }
    }
}