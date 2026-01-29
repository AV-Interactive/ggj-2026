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
            _skillSelected = EnumSkill.None;
            DisableAllSkills();
        }

        #endregion


        #region Main Methods

        public void OnJumpSelected()
        {
            if (!SkillFilter.Instance.CanJump) return;
            SetSkill(EnumSkill.Jump);   
        }
        public void OnAttackSelected()
        {
            if (!SkillFilter.Instance.CanAttack) return;
            SetSkill(EnumSkill.Attack);
        }
        public void OnPlaneSelected()
        {
            if(!SkillFilter.Instance.CanPlane) return;
            SetSkill(EnumSkill.Plane);
        }
        public void OnScaleSelected()
        {
            if(!SkillFilter.Instance.CanScale) return;
            SetSkill(EnumSkill.Scale);
        }

        private void SetSkill(EnumSkill skill)
        {
            if (_skillSelected == skill)
            {
                Debug.Log($"[Player] Skill {skill} déjà sélectionné.");
                return;
            }

            Debug.Log($"[Player] Sélection du skill : {skill}");
            _skillSelected = skill;
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
            if (_skillScripts == null) return;

            foreach (var config in _skillScripts)
            {
                if (config != null && config.Script != null)
                {
                    config.Script.enabled = false;
                }
            }
        }

        void UpdateSkill(EnumSkill skill)
        {
            DisableAllSkills();

            if (skill == EnumSkill.None) return;

            var config = _skillScripts.Find(s => s.Skill == skill);
            
            if (config != null && config.Script != null)
            {
                config.Script.enabled = true;
                EnemyEvents.RaiseChangeSkill(skill);
                Debug.Log($"[Player] Skill switché vers : {skill}");
            }
            else
            {
                Debug.LogWarning($"[Player] Impossible de trouver le script pour le skill : {skill}");
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

