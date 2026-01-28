using System;
using System.Collections.Generic;
using EventsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerRunTime
{
    public class SkillSwitch : MonoBehaviour
    {

        #region Publics

        //

        #endregion


        #region Unity API

        void OnEnable()
        {
            EnemyEvents.OnSkillChange += SelectSkill;
        }

        void OnDisable()
        {
            EnemyEvents.OnSkillChange -= SelectSkill;
        }

        #endregion


        #region Main Methods

        // 

        #endregion


        #region Utils

        /* Fonctions privées utiles */

        void SelectSkill(EnumSkill skill)
        {
            string skillName = "";
            switch (skill)
            {
                case EnumSkill.Jump:
                    skillName = "Jump";
                    break;
                case EnumSkill.Attack:
                    skillName = "Attack";
                    break;
                case EnumSkill.Plane:
                    skillName = "Plane";
                    break;
                case EnumSkill.Scale:
                    skillName = "Scale";
                    break;
                default:
                    skillName = "Aucun Skill";
                    break;
            }

            Debug.Log($"Skill séléctionné : {skillName}");
        }

        #endregion


        #region Privates and Protected

        // Variables privées

        #endregion
    }
}

