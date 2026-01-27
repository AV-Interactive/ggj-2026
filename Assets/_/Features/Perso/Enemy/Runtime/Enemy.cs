using UnityEngine;

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


        #region Unity API

        Upd

        #endregion


        #region Main Methods

        // 

        #endregion


        #region Utils

        /* Fonctions privées utiles */
        [SerializeField] int _enemyHp;
        [SerializeField] EnemyType  _type;
        [Header("Goal X Left")]
        [SerializeField] float _goalXLeft = 5f;
        [Header("Goal X Right")]
        [SerializeField] float _goalXRight = 5f;
        
        Vector3 _initialPosition;

        #endregion


        #region Privates and Protected

        // Variables privées

        #endregion
    }
}

