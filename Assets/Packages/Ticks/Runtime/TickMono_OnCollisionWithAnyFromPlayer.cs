using UnityEngine;
using UnityEngine.Events;
namespace Eloi.Tick
{

    public class TickMono_OnCollisionWithAnyFromPlayer : TickMono_AbstractDefault
    {

        [TextArea(2, 10)]
        public string m_contextDescription;

        [Tooltip("Specify which layers should trigger the event.")]
        public LayerMask m_layerMask = ~0;

        public bool m_useCollision = true;
        public bool m_useTrigger = true;


        private void OnCollisionEnter(Collision collision)
        {
            if (m_useCollision && IsInLayerMask(collision.gameObject))
            {
                m_onTick?.Invoke();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (m_useTrigger && IsInLayerMask(other.gameObject))
            {
                m_onTick?.Invoke();
            }
        }

        private bool IsInLayerMask(GameObject obj)
        {
            return (m_layerMask.value & (1 << obj.layer)) != 0;
        }
    }

   
}