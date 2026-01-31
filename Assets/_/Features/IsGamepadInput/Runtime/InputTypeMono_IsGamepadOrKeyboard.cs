using System;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.InputType { 
    public enum KeyPadInputType
    {
        Gamepad,
        Keyboard
    }

    public class InputTypeMono_IsGamepadOrKeyboard : MonoBehaviour
    {
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
            m_onSwitchToKeyboardInput.Invoke();
            if (wasGamepad) { 
                m_onSwitchToGamepadInputChanged.Invoke(false);
                m_onSwitchToKeyboardInputChanged.Invoke(true);
            }
        }

        [ContextMenu("Use Gamepad")]
        public void NotifyAsUsingGamepad()
        {
            bool wasKeyboard = m_currentInputType == KeyPadInputType.Keyboard;
            m_currentInputType = KeyPadInputType.Gamepad;
            m_onSwitchToGamepadInput.Invoke();
            if (wasKeyboard)
            {
                m_onSwitchToKeyboardInputChanged.Invoke(false);
                m_onSwitchToGamepadInputChanged.Invoke(true);
            }
        }

    }
}
