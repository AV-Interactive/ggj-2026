using UnityEngine;
using UnityEngine.Events;

namespace Eloi.Audio { 
public class RandomAudioClipPlayer : MonoBehaviour
{
        public AudioClip[] m_audioClip;
        public UnityEvent<AudioClip> m_onAudioClipPushed;
        public bool m_playOnEnable = true;

        private void OnEnable()
        {
            if (m_playOnEnable)
                PushRandomAudioClip();
        }
        [ContextMenu("Push Random Audio Clip")]
        public void PushRandomAudioClip() { 
            if (m_audioClip.Length == 0)
                return;
            m_onAudioClipPushed.Invoke(m_audioClip[Random.Range(0, m_audioClip.Length)]);
        }
}

}