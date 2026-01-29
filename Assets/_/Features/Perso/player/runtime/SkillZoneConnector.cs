using UnityEngine;

namespace PlayerRunTime
{
    public class SkillZoneConnector : MonoBehaviour
    {
        #region Publics

        //

        #endregion


        #region Unity API

        public void ApplyZoneRules()
        {
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

        public void ReleaseZoneRules()
        {
            SkillFilter.Instance.ActivateAllMask();    
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