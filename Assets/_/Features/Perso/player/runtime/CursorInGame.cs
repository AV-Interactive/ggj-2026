using UnityEngine;

namespace PlayerRunTime
{
    public class CursorInGame : MonoBehaviour
    {
        #region Publics

        public Vector2 _mousePosition;

        #endregion

        #region Unity API

        private void Awake()
        {
            _rectTransform =GetComponent<RectTransform>();
            Cursor.visible = true;
        }

        private void Update()
        {
            _rectTransform.position = _mousePosition;
        }

        #endregion

        #region Main Methods

        public void SetMousePositon(Vector2 mousePosition)
        {
            _mousePosition = mousePosition;
        }

        #endregion

        #region Utils

        /* Fonctions privées utiles */

        #endregion

        #region Privates and Protected

        private RectTransform _rectTransform;

        #endregion
    }
}

