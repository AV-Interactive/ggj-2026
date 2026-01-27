using UnityEngine;

namespace PlayerRunTime
{
    public class Jump : MonoBehaviour
    {

        #region Publics

        [SerializeField] public float JumpForce;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private bool InGround = true;

        #endregion


        #region Unity API

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && InGround)
            {
                rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
                InGround = false;
            }
        }

        #endregion


        #region Main Methods

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                InGround = true;
            }
        }

        #endregion


        #region Utils

        /* Fonctions privées utiles */

        #endregion


        #region Privates and Protected

        // Variables privées

        #endregion
    }
}

