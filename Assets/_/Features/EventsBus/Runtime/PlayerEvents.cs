using System;
using UnityEngine;

namespace EventsRuntime
{
    public class PlayerEvents : MonoBehaviour
    {
        public static event Action<bool> OnJump;
        public static event Action OnFall;

        public static void RaiseJump(bool isActive)
        {
            OnJump?.Invoke(isActive);
        }

        public static void RaiseFall()
        {
            OnFall?.Invoke();
        }
    }
}

