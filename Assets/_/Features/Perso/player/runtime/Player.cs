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
                script.enabled = false;
            }
        }

        void UpdateSkill(EnumSkill skill)
        {
            DisableAllSkills();
            EnemyEvents.RaiseChangeSkill(skill);
            _skillScripts[(int)skill].enabled = true;
            int skillI = (int)skill;
            Debug.Log($"SkillName : {skill}, index : {skillI.ToString()}");
        }

        #endregion


        #region Privates and Protected

        // Variables privées
        //[SerializeField] List<EnumSkill> _skillsList = new List<EnumSkill>();
        [SerializeField] List<MonoBehaviour> _skillScripts = new List<MonoBehaviour>();
        
        int _indexSkill = 0;
        EnumSkill _skillSelected;

        #endregion
    }
}

