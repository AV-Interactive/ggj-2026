using UnityEngine;

namespace PlayerRunTime
{
    public class CursorInGame : MonoBehaviour
    {
        #region Publics

        //

        #endregion

        #region Unity API

        private void Awake()
        {
            _rectTransform =GetComponent<RectTransform>();
            Cursor.visible = false;
        }

        private void Update()
        {
            _rectTransform.position = Input.mousePosition;
        }

        #endregion

        #region Main Methods

        // 

        #endregion

        #region Utils

        /* Fonctions privées utiles */

        #endregion

        #region Privates and Protected

        private RectTransform _rectTransform;

        #endregion
    }
}

