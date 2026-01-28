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

        void Update()
        {
            // Test de switch entre sorts
            if (Input.GetKeyDown(KeyCode.S))
            {
                DisableAllSkills();
                if (_indexSkill == _skillsList.Count)
                {
                    _indexSkill = 0;
                }
                EnemyEvents.RaiseChangeSkill(_skillsList[_indexSkill]);
                _skillScripts[_indexSkill].enabled = true;
                _indexSkill++;
            }
        }

        #endregion


        #region Main Methods

        // 

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

        #endregion


        #region Privates and Protected

        // Variables privées
        [SerializeField] List<EnumSkill> _skillsList = new List<EnumSkill>();
        [SerializeField] List<MonoBehaviour> _skillScripts = new List<MonoBehaviour>();
        
        int _indexSkill = 0;

        #endregion
    }
}

