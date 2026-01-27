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

        #endregion


        #region Unity API


        void Update()
        {
            if (hasScaledDown && hasScaledUp)
            {
                hasScaledDown = false;
                hasScaledUp = false;
            }

            if (Input.GetKeyDown(KeyCode.Z) && !hasScaledDown)
            {
                isScalingDown = true;
                isScalingUp = false;
                timer = 0f;
                currentScaleTime = scaleTime;
            }

            if (Input.GetKeyDown(KeyCode.X) && !hasScaledUp)
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
                        hasScaledDown = true;
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
                        hasScaledUp = true;
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

        private float timer = 0f;
        private bool isScalingDown = false;
        private bool isScalingUp = false;
        private float currentScaleTime = 0f;
        private bool hasScaledDown = false;
        private bool hasScaledUp = false;

        #endregion
    }
}

