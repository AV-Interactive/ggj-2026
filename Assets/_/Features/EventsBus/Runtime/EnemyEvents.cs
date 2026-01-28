using System;
using UnityEngine;

namespace EventsRuntime
{
    public class EnemyEvents : MonoBehaviour
    {
        public static event Action<GameObject> OnHit;

        public static void RaiseHit(GameObject gameObject)
        {
            Debug.Log($"On a reçu la demande d'event pour {gameObject.name}");
            OnHit?.Invoke(gameObject);
        }
    }
}

