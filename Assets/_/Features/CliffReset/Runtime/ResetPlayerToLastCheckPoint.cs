using UnityEngine;
using UnityEngine.Events;

public class ResetPlayerToLastCheckPoint : MonoBehaviour
{
    [SerializeField] private float m_heightToResetInY = -2f;
    [SerializeField] private Transform m_pointToOverwatch;
    [SerializeField] private Transform m_pointToMove;
    [SerializeField] private UnityEvent m_onTeleportPlayerToLastCliffPoint;

    private void Update()
    {
        if (m_pointToOverwatch == null || m_pointToMove == null)
            return;

        if (m_pointToOverwatch.position.y < m_heightToResetInY)
        {
            CliffPointTag.FetchLastCliffPointFromAxisX(
                m_pointToOverwatch,
                out bool found,
                out Transform point
            );

            if (found)
            {
                m_pointToMove.position = point.position;
                m_onTeleportPlayerToLastCliffPoint?.Invoke();
            }
        }
    }
}
