using UnityEngine;
using System.IO;

namespace PlayerRunTime
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        private string filePath;
        private float volume = 1f;

        [System.Serializable]
        class VolumeData
        {
            public float volume;
        }

        private void Awake()
        {
            // Singleton
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            filePath = Path.Combine(Application.persistentDataPath, "volume.json");

            LoadVolume();
            ApplyVolume();
        }

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