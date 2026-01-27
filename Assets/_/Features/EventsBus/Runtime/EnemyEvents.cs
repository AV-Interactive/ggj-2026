using System;
using UnityEngine;

namespace EventsRuntime
{
    public class EnemyEvents : MonoBehaviour
    {
        public static event Action<GameObject> OnHit;

        public static void RaiseHit(GameObject gameObject)
        {
            OnHit?.Invoke(gameObject);
        }
    }
}

