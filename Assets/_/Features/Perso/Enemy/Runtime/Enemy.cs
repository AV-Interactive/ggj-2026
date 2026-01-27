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

        //

        #endregion


        #region Main Methods

        // 

        #endregion


        #region Utils

        /* Fonctions privées utiles */
        [SerializeField] int enemyHp;
        [SerializeField] EnemyType  type;

        #endregion


        #region Privates and Protected

        // Variables privées

        #endregion
    }
}

