using System;
using System.Collections.Generic;
using EventsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerRunTime
{
    public class Player : MonoBehaviour
    {

        #region Publics

        //

        #endregion


        #region Unity API

        void OnEnable()
        {
            EnemyEvents.OnHit += TakeDamage;
        }

        void OnDisable()
        {
            EnemyEvents.OnHit -= TakeDamage;
        }

        void Awake()
        {
            DisableAllSkills();
        }

        #endregion


        #region Main Methods

        public void OnJumpSelected()
        {
            if(_skillSelected == EnumSkill.Jump) return;
            Debug.Log("Jump");
            _skillSelected = EnumSkill.Jump;
            UpdateSkill(_skillSelected);
        }

        public void OnAttackSelected()
        {
            if(_skillSelected == EnumSkill.Attack) return;
            Debug.Log("Atk");
            _skillSelected = EnumSkill.Attack;
            UpdateSkill(_skillSelected);
        }

        public void OnPlaneSelected()
        {
            if (_skillSelected == EnumSkill.Plane) return;
            Debug.Log("Plane");
            _skillSelected = EnumSkill.Plane;
            UpdateSkill(_skillSelected);
        }

        public void OnScaleSelected()
        {
            if(_skillSelected == EnumSkill.Scale) return;
            Debug.Log("Scale");
            _skillSelected = EnumSkill.Scale;
            UpdateSkill(_skillSelected);
        }

        #endregion


        #region Utils

        /* Fonctions privées utiles */
        void TakeDamage(GameObject attacker)
        {
            Debug.Log($"Attaqué par {attacker.name} !");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        void DisableAllSkills()
        {
            foreach (var script in _skillScripts)
            {
                script.Script.enabled = false;
            }
        }

        void UpdateSkill(EnumSkill skill)
        {
            var script = _skillScripts.Find(s => s.Skill == skill);
            
            if(script != null && script.Script != null)
            {
                script.Script.enabled = true;
                EnemyEvents.RaiseChangeSkill(skill);
            }
        }

        #endregion


        #region Privates and Protected

        // Variables privées
        //[SerializeField] List<EnumSkill> _skillsList = new List<EnumSkill>();
        [SerializeField] List<SkillToScript> _skillScripts = new List<SkillToScript>();
        
        public EnumSkill _skillSelected;

        #endregion
    }
    
    [Serializable]
    public class SkillToScript
    {
        public EnumSkill Skill;
        public MonoBehaviour Script;
    }
}

