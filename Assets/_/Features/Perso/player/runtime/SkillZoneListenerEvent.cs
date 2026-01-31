using System;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerRunTime
{
    public class SkillZoneListenerEvent : MonoBehaviour
    {

        #region Publics

        [SerializeField] UnityEvent<bool> _onMaskProjectileSelected;
        [SerializeField] UnityEvent<bool> _onMaskJumpSelected;
        [SerializeField] UnityEvent<bool> _onMaskPlaneSelected;
        [SerializeField] UnityEvent<bool> _onMaskScaleSelected;

        void OnEnable()
        {
            SkillFilter.Instance._onChanged += OnStateChange;
        }

        void OnDisable()
        {
            SkillFilter.Instance._onChanged -= OnStateChange;
        }

        void OnStateChange(SkillFilter obj)
        {
            if (obj)
            {
                _onMaskJumpSelected.Invoke(obj.CanJump);
                _onMaskProjectileSelected.Invoke(obj.CanAttack);
                _onMaskPlaneSelected.Invoke(obj.CanPlane);
                _onMaskScaleSelected.Invoke(obj.CanScale);
            }
        }

        #endregion


        #region Unity API

        //

        #endregion


        #region Main Methods

        // 

        #endregion


        #region Utils

        /* Fonctions privées utiles */

        #endregion


        #region Privates and Protected

        // Variables privées

        #endregion
    }
}

