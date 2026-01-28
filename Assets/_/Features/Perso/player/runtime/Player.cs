using System;
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

        #endregion


        #region Privates and Protected

        // Variables privées

        #endregion
    }
}

