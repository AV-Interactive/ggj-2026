using System;
using UnityEngine;

namespace EventsRuntime
{
    public class TutoEvents : MonoBehaviour
    {
        public static event Action<bool, GameObject> OnZoneCompleted;

        public static void RaiseZoneCompleted(bool completed, GameObject zone)
        {
            OnZoneCompleted?.Invoke(completed, zone);
        }
    }
}

