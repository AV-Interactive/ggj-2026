using UnityEngine;
using UnityEngine.Events;

namespace Eloi.InputType
{
    public partial class InputTypeMono_ListenToInputChanged :MonoBehaviour
    {
        public UnityEvent m_onKeyboardSelected;
        public UnityEvent m_onGamepadSelected;
        public UnityEvent<bool> m_onGamepadTouched;
        public UnityEvent<bool> m_onKeyboardTouched;

        [Header("Debug")]
        public KeyPadInputType m_debugInputState;


        public void OnEnable()
        {
            InputTypeMono_IsGamepadOrKeyboard.m_onInputTypeChanged += OnInputTypeChanged;
        }
        public void OnDisable()
        {
            InputTypeMono_IsGamepadOrKeyboard.m_onInputTypeChanged -= OnInputTypeChanged;

        }

        private void OnInputTypeChanged(KeyPadInputType type)
        {
            m_debugInputState = type;
            if (type == KeyPadInputType.Gamepad)
            {
                m_onGamepadSelected.Invoke();
                m_onGamepadTouched.Invoke(true);
                m_onKeyboardTouched.Invoke(false);
            }
            else if (type == KeyPadInputType.Keyboard)
            {
                m_onKeyboardSelected.Invoke();
                m_onKeyboardTouched.Invoke(true);
                m_onGamepadTouched.Invoke(false);
            }
        }
    }
}
