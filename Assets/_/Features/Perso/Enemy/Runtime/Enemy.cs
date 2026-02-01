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

        #region Unity

        void Awake()
        {
            _maxGoalPoints = _goalPoints.Length;
        }

        void Start()
        {
            if (_goalPoints.Length > 0)
            {
                LookAtTarget(_goalPoints[_indexGoalPoint].transform.position);
            }
        }

        void FixedUpdate()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            
            if (_goalPoints.Length == 0) return;

            Vector3 targetPosition = _goalPoints[_indexGoalPoint].transform.position;
            
            //targetPosition.y = transform.position.y;
            
            transform.LookAt(targetPosition);
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
            if (other.gameObject == _goalPoints[_indexGoalPoint])
            {
                GoToNextPoint();
            }
        }

        #endregion

        #region Main Methods

        void GoToNextPoint()
        {
            _indexGoalPoint++;

            if (_indexGoalPoint >= _goalPoints.Length)
            {
                _indexGoalPoint = 0;
            }

            Vector3 nextPosition = _goalPoints[_indexGoalPoint].transform.position;
            
            LookAtTarget(nextPosition);
        }

        void LookAtTarget(Vector3 target)
        {
            //target.y = transform.position.y;
            transform.LookAt(target);
        }

        #endregion

        #region Privates and Protected

        [Header("The Enemy")]
        [SerializeField] int _enemyHp;
        [SerializeField] EnemyType  _type;
        [SerializeField] float _speed = 10f;
        
        [Header("Goal Patrol Points")]
        [SerializeField] GameObject[] _goalPoints;
        
        int _indexGoalPoint = 0;
        int _maxGoalPoints;

        #endregion
    }
}