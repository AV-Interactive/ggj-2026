using System;
using UnityEngine;

namespace PlayerRunTime
{
    public class SkillFilter : MonoBehaviour
    {

        #region Publics

        public static SkillFilter Instance { get; private set; }

        public bool CanJump { get; private set; } = false;
        public bool CanAttack { get; private set; } = false;
        public bool CanScale { get; private set; } = false;
        public bool CanPlane { get; private set; } = false;

        #endregion


        #region Unity API

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        void Start()
        {
            if(_activateAll) ActivateAllMask(); else DeactivateAllMasks();
        }

        #endregion


        #region Main Methods

        public void ActivateAllMask()
        {
            CanJump = true;
            CanAttack = true;
            CanScale = true;
            CanPlane = true;
        }

        public void DeactivateAllMasks()
        {
            CanJump = false;
            CanAttack  = false;
            CanScale = false;
            CanPlane = false;
        }

        public void ActivateJump(bool isActive)
        {
            DeactivateAllMasks();
            CanJump = isActive;
        }
        
        public void ActivateAttack(bool isActive)
        {
            DeactivateAllMasks();
            CanAttack =  isActive;
        }
        
        public void ActivateScale(bool isActive)
        {
            DeactivateAllMasks();
            CanScale = isActive;
        }
        
        public void ActivatePlane(bool isActive)
        {
            DeactivateAllMasks();
            CanPlane = isActive;
        }

        #endregion


        #region Utils

        /* Fonctions privées utiles */

        #endregion


        #region Privates and Protected

        // Variables privées
        [SerializeField] bool _activateAll = false;

        #endregion
    }
}

