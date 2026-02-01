using UnityEngine;
using UnityEngine.Events;
namespace Eloi.FollowIt
{


    public class FollowItMono_TransformExactMono : MonoBehaviour
    {
        public Transform m_target;
        public Transform m_whatToMove;

        public void SetWhatToMove(Transform whatToMove)
        {
            m_whatToMove = whatToMove;
        }

        public void SetTargetToFollow(Transform target)
        {

            m_target = target;
        }

        private void Reset()
        {
            m_whatToMove = transform;

        }
        public bool m_useLateUpdate;
        void Update()
        {
            if (!m_useLateUpdate)
                UpdateLerp();
        }
        void LateUpdate()
        {
            if (m_useLateUpdate)
                UpdateLerp();
        }

        [ContextMenu("Move to target")]
        public void UpdateLerp()
        {
            if (m_target != null && m_whatToMove != null)
            {
                m_whatToMove.position = m_target.position;
                m_whatToMove.rotation = m_target.rotation;
            }
        }
    }
}