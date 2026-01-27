using UnityEngine;

namespace PlayerRunTime
{
    public class Scale : MonoBehaviour
    {

        #region Publics

        [SerializeField] public Transform scaleTransfom;
        [SerializeField] public float scaleX;
        [SerializeField] public float scaleY;
        [SerializeField] public float scaleZ;
        [SerializeField] public float scaleTime = 5f;
        [SerializeField] public float speedScale;
        private float timer = 0f;
        private bool isScalingDown = false;
        private bool isScalingUp = false;
        private float currentScaleTime = 0f;


        #endregion


        #region Unity API


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                isScalingDown = true;
                isScalingUp = false;
                timer = 0f;
                currentScaleTime = scaleTime;
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                isScalingUp = true;
                isScalingDown = false;
                timer = 0f;
                currentScaleTime = scaleTime;
            }

            if (isScalingDown)
            {
                timer += Time.deltaTime * speedScale;
                if (timer >= 1f && currentScaleTime >= 1f)
                {
                    scaleTransfom.localScale -= new Vector3(scaleX, scaleY, scaleZ);
                    currentScaleTime--;
                    timer = 0f;
                    if (currentScaleTime < 1f)
                    {
                        isScalingDown = false;
                    }
                }
            }

            if (isScalingUp)
            {
                timer += Time.deltaTime * speedScale;
                if (timer >= 1f && currentScaleTime >= 1f)
                {
                    scaleTransfom.localScale += new Vector3(scaleX, scaleY, scaleZ);
                    currentScaleTime--;
                    timer = 0f;
                    if (currentScaleTime < 1f)
                    {
                        isScalingUp = false;
                    }
                }
            }
        }

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

