using System;
using UnityEngine.Events;
using UnityEngine;

namespace Eloi.InputType
{
    public enum KeyPadInputType
    {
        Gamepad,
        Keyboard
    }

    public class InputTypeMono_IsGamepadOrKeyboard : MonoBehaviour
    {
        public static KeyPadInputType m_staticCurrentInputType;

        public static Action<KeyPadInputType> m_onInputTypeChanged;

        public KeyPadInputType m_currentInputType = KeyPadInputType.Keyboard;
        public UnityEvent m_onSwitchToKeyboardInput;
        public UnityEvent m_onSwitchToGamepadInput;
        public UnityEvent<bool> m_onSwitchToKeyboardInputChanged;
        public UnityEvent<bool> m_onSwitchToGamepadInputChanged;

        [ContextMenu("Use Keyboard")]
        public void NotifyAsUsingKeyboard()
        {
            bool wasGamepad = m_currentInputType == KeyPadInputType.Gamepad;
            m_currentInputType = KeyPadInputType.Keyboard;
            m_staticCurrentInputType = m_currentInputType;
            m_onInputTypeChanged.Invoke(m_currentInputType);
            m_onSwitchToKeyboardInput.Invoke();
            if (wasGamepad)
            {
                m_onSwitchToGamepadInputChanged.Invoke(false);
                m_onSwitchToKeyboardInputChanged.Invoke(true);
            }
        }

        [ContextMenu("Use Gamepad")]
        public void NotifyAsUsingGamepad()
        {
            bool wasKeyboard = m_currentInputType == KeyPadInputType.Keyboard;
            m_currentInputType = KeyPadInputType.Gamepad;

            m_staticCurrentInputType = m_currentInputType;
            m_onInputTypeChanged.Invoke(m_currentInputType);
            m_onSwitchToGamepadInput.Invoke();
            if (wasKeyboard)
            {
                m_onSwitchToKeyboardInputChanged.Invoke(false);
                m_onSwitchToGamepadInputChanged.Invoke(true);
            }
        }

    }
}
