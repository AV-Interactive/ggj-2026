using UnityEngine;
using System.IO;

namespace PlayerRunTime
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        [SerializeField] private AudioSource _sfxSource;

        private string filePath;
        private float volume = 1f;

        [System.Serializable]
        class VolumeData
        {
            public float volume;
        }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Sécurité si oublié dans l’Inspector
            if (_sfxSource == null)
            {
                _sfxSource = gameObject.AddComponent<AudioSource>();
                _sfxSource.playOnAwake = false;
            }

            filePath = Path.Combine(Application.persistentDataPath, "volume.json");

            LoadVolume();
            ApplyVolume();
        }

        // 🎚️ Volume global
        public void SetVolume(float newVolume)
        {
            volume = Mathf.Clamp01(newVolume);
            ApplyVolume();
            SaveAudio();
        }

        void ApplyVolume()
        {
            AudioListener.volume = volume;
        }

        // 🔊 SFX
        public void PlaySFX(AudioClip clip)
        {
            if (clip == null) return;
            _sfxSource.PlayOneShot(clip);
        }

        void SaveAudio()
        {
            VolumeData data = new VolumeData { volume = volume };
            File.WriteAllText(filePath, JsonUtility.ToJson(data));
        }

        void LoadVolume()
        {
            if (!File.Exists(filePath))
            {
                volume = 1f;
                return;
            }

            string json = File.ReadAllText(filePath);
            VolumeData data = JsonUtility.FromJson<VolumeData>(json);
            volume = Mathf.Clamp01(data.volume);
        }
    }
}
