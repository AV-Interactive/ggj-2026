using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Enemy.Runtime
{
    public enum EnemyType
    {
        Trap,
        Beast
    }
    
    public class Enemy : MonoBehaviour
    {

        #region Publics

        //

        #endregion


        #region Unity

        void FixedUpdate()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }

        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                EventsRuntime.EnemyEvents.RaiseHit(gameObject);
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == _GPPRight.gameObject)
            {
                transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            }

            if (other.gameObject == _GPPLeft.gameObject)
            {
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            }
        }

        #endregion


        #region Main Methods

        // 

        #endregion


        #region Utils

        //

        float _currentX;

        #endregion


        #region Privates and Protected

        [Header("The Enemy")]
        [SerializeField] int _enemyHp;
        [SerializeField] EnemyType  _type;
        [SerializeField] float _speed = 10f;
        
        //[Header("Target")]
        //[SerializeField] GameObject _target;
        
        [Header("Goal Patrol Points")]
        [SerializeField] GameObject _GPPLeft;
        [SerializeField] GameObject _GPPRight;
        [SerializeField] GameObject _GPPUp;
        [SerializeField] GameObject _GPPDown;
        
        UnityEvent<GameObject> _collisionEvent = new UnityEvent<GameObject>();

        #endregion
    }
}

