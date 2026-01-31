using UnityEngine;
using UnityEngine.Events;

public class InputTypeMono_GamepadToMaskGameFacade : MonoBehaviour
{
    public UnityEvent<float> m_onProjectileAngleChanged;
    public UnityEvent m_onMaskGlideRequested;
    public UnityEvent m_onMaskJumpRequested;
    public UnityEvent m_onMaskScaleRequested;
    public UnityEvent m_onMaskProjectileRequested;
    public UnityEvent m_onMaskActionRequested;

    public UnityEvent m_onMenuLeftCalled;
    public UnityEvent m_onMenuRightCalled;

    [ContextMenu("TriggerMaskGlide")]
    public void TriggerMaskGlide() {
        m_onMaskGlideRequested?.Invoke();
    }
    [ContextMenu("TriggerMaskJump")]
    public void TriggerMaskJump() {

        m_onMaskJumpRequested?.Invoke();
    }
    [ContextMenu("TriggerMaskSize")]
    public void TriggerMaskScale() {

        m_onMaskScaleRequested?.Invoke();
    }
    [ContextMenu("TriggerMaskProjectile")]
    public void TriggerMaskProjectile() {

        m_onMaskProjectileRequested?.Invoke();
    }

    [ContextMenu("TrigerMaskAction")]
    public void TriggerMaskAction() {

        m_onMaskActionRequested?.Invoke();
    }

    [ContextMenu("TriggerMenuLeftCall")]
    public void TriggerMenuLeftCall()
    {
        m_onMenuLeftCalled?.Invoke();
    }
    [ContextMenu("TriggerMenuRightCall")]
    public void TriggerMenuRightCall()
    {
        m_onMenuRightCalled?.Invoke();
    }


    public void RelayJoystickAngleFromGroundToTop(float value) {
        m_onProjectileAngleChanged?.Invoke(value);
    }
    public float m_currentAngleFromGroundToTop = 0f;
    public void RelayJoystickAngleFromTopToGround(Vector2 value)
    {
        float angle = Mathf.Atan2(value.y, value.x) * Mathf.Rad2Deg;
        m_currentAngleFromGroundToTop= angle;
        RelayJoystickAngleFromGroundToTop(angle);
    }




}
