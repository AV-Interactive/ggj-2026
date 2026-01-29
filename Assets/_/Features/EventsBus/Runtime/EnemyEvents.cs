using System;
using PlayerRunTime;
using UnityEngine;

namespace EventsRuntime
{
    public class EnemyEvents : MonoBehaviour
    {
        public static event Action<GameObject> OnHit;
        public static event Action<EnumSkill> OnSkillChange;

        public static void RaiseHit(GameObject gameObject)
        {
            Debug.Log($"On a reçu la demande d'event pour {gameObject.name}");
            OnHit?.Invoke(gameObject);
        }

        public static void RaiseChangeSkill(EnumSkill skill)
        {
            OnSkillChange?.Invoke(skill);
        }
    }
}

