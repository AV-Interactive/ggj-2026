using System;
using UnityEngine;
using UnityEngine.Events;

namespace TriggerByAxis
{
    public class TriggerByAxisX : MonoBehaviour
    {

        public Transform m_leftPoint;
        public Transform m_rightPoint;
        public Transform m_observed;
        public bool m_isObservedInRange;
        public bool m_findPlayerWithTagAtAwake= false;

        public UnityEvent <bool> m_onObservedInRangeChanged;
        public UnityEvent m_onObserverEnterFromLeftZone;
        public UnityEvent m_onObserverEnterZone;
        public UnityEvent m_onObserverExitZone;
        public UnityEvent m_onObserverExitFromRigthZone;

        public bool m_useDrawLine = true;
        public Color m_lineColorLeft = Color.green;
        public Color m_lineColorRight = Color.red;
        public float m_distanceToDrawUp = 10f;

        public void Awake()
        {
            if (m_findPlayerWithTagAtAwake)
                FindPlayerWithTag();
        }

        private void FindPlayerWithTag()
        {
            if (m_observed == null)
            {
                    m_observed = GameObject.FindGameObjectWithTag("Player")?.transform;
            }
        }

        Vector3 m_previousPosition;
        public void Update()
        {
            if (m_observed == null || m_leftPoint == null || m_rightPoint == null)
                return;

            Vector3 observedPosition = m_observed.position;
            Vector3 leftPosition = m_leftPoint.position;
            Vector3 rightPosition = m_rightPoint.position;
            bool isInRange = observedPosition.x >= leftPosition.x && observedPosition.x <= rightPosition.x;
            if (isInRange != m_isObservedInRange)
            {

                bool previous = m_isObservedInRange;
                bool current = isInRange;
               if (previous != current)
                {
                    m_isObservedInRange = current;
                    m_onObservedInRangeChanged?.Invoke(current);
                    if (current)
                    {
                        m_onObserverEnterZone?.Invoke();
                        if (m_previousPosition.x < leftPosition.x)
                        {
                            m_onObserverEnterFromLeftZone?.Invoke();
                        }
                    }
                    else
                    {
                        m_onObserverExitZone?.Invoke();
                        if (m_previousPosition.x < rightPosition.x)
                        {
                            m_onObserverExitFromRigthZone?.Invoke();
                        }
                    }
                }
            }
            if (m_useDrawLine)
            {
                DrawLineFor(Time.deltaTime);
            }

            m_previousPosition = observedPosition;
        }

        private void OnValidate()
        {
            DrawLineFor(5);
        }
        private void DrawLineFor(float timeInSeconds)
        {
            Debug.DrawLine(new Vector3(m_leftPoint.position.x, m_leftPoint.position.y - m_distanceToDrawUp, m_leftPoint.position.z), new Vector3(m_leftPoint.position.x, m_leftPoint.position.y + m_distanceToDrawUp, m_leftPoint.position.z), m_lineColorLeft, timeInSeconds);
            Debug.DrawLine(new Vector3(m_rightPoint.position.x, m_rightPoint.position.y - m_distanceToDrawUp, m_rightPoint.position.z), new Vector3(m_rightPoint.position.x, m_rightPoint.position.y + m_distanceToDrawUp, m_rightPoint.position.z), m_lineColorRight, timeInSeconds);
        }
    }
}
