using System;
using EventsRuntime;
using PlayerRunTime;
using UnityEngine;

namespace TutorialRuntime._.Features.Tutorial.Runtime
{
    public class TriggerZone : MonoBehaviour
    {

        #region Publics

        //

        #endregion


        #region Unity API

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
            SkillFilter.Instance.DeactivateAllMasks();

            switch (_alowedSkill)
            {
                case EnumSkill.Scale:
                    SkillFilter.Instance.ActivateScale(true);
                    break;
                case EnumSkill.Plane:
                    SkillFilter.Instance.ActivatePlane(true);
                    break;
                case EnumSkill.Attack:
                    SkillFilter.Instance.ActivateAttack(true);
                    break;
                case EnumSkill.Jump:
                    SkillFilter.Instance.ActivateJump(true);
                    break;
            }
        }

        #endregion


        #region Main Methods

        // 

        #endregion


        #region Utils

        /* Fonctions privées utiles */

        #endregion


        #region Privates and Protected
        
        [Header("Quel est le seul skill autorisé dans la zone ?")]
        [SerializeField] EnumSkill _alowedSkill;
        
        #endregion
    }
}

