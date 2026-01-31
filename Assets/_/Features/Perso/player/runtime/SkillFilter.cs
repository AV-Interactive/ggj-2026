using System;
using UnityEngine;

namespace PlayerRunTime
{
    public class SkillFilter : MonoBehaviour
    {

        #region Publics

        public static SkillFilter Instance { get; private set; }
        public Action<SkillFilter> _onChanged;

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

        #endregion


        #region Main Methods

        public void ActivateAllMask()
        {
            CanJump = true;
            CanAttack = true;
            CanScale = true;
            CanPlane = true;
            RaiseNotifyChange();
        }

        public void DeactivateAllMasks()
        {
            CanJump = false;
            CanAttack  = false;
            CanScale = false;
            CanPlane = false;
            RaiseNotifyChange();
        }

        public void RaiseNotifyChange()
        {
            _onChanged?.Invoke(this);
        }

        public void ActivateJump(bool isActive)
        {
            DeactivateAllMasks();
            CanJump = isActive;
            RaiseNotifyChange();
        }
        
        public void ActivateAttack(bool isActive)
        {
            DeactivateAllMasks();
            CanAttack =  isActive;
            RaiseNotifyChange();
        }
        
        public void ActivateScale(bool isActive)
        {
            DeactivateAllMasks();
            CanScale = isActive;
            RaiseNotifyChange();
        }
        
        public void ActivatePlane(bool isActive)
        {
            DeactivateAllMasks();
            CanPlane = isActive;
            RaiseNotifyChange();
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

