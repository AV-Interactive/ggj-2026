using LevelDesignScript;
using PlayerRunTime;
using UnityEngine;

public class GamePadToGameGGJ : MonoBehaviour
{

    
    public bool m_killSwitch = false;

    public void SetAsActive(bool active) {

        this.m_killSwitch =! active;
    }

    public void SetAsActiveOn()
    {SetAsActive(true);
    }
    public void SetAsActiveOff()
    {
        SetAsActive(false);
    }


    public PlayerRunTime.Player m_playerToAffect;
    public PlayerRunTime.CreateProjectile m_actionProjectile;
    public PlayerRunTime.Jumps m_actionJump;
    public PlayerRunTime.Scale m_actionScale;
    public PlayerRunTime.Planneur m_actionPlane;
    public PauseManager m_pauseManager;

    public RestartLevel m_restartLevel;

    public bool m_isInMenuPause = false;

    public Transform m_cursorDebug;
    public Camera m_cameraDebug;

    public void PushFakeMousePositionFromAngleN90p90(float angleN90p90)
    {
        if (m_killSwitch) return;
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;
        float x = Mathf.Cos(angleN90p90 * Mathf.Deg2Rad);
        float y = Mathf.Sin(angleN90p90 * Mathf.Deg2Rad);
        Vector2 directionRelativeInPx = new Vector2(x * (screenWidth / 2f), y * (screenHeight / 2f));
        Vector2 screenCenter = new Vector2(screenWidth / 2f, screenHeight / 2f);
        Vector2 mousePosition = screenCenter + directionRelativeInPx;
        if (m_actionProjectile)
            m_actionProjectile.SetMousePosition(mousePosition);
        if (m_cursorDebug != null && m_cameraDebug != null)
        {
            Ray ray = m_cameraDebug.ScreenPointToRay(mousePosition);
            Plane plane = new Plane(Vector3.forward, Vector3.zero);
            if (plane.Raycast(ray, out float enter))
            {
                Vector3 hitPoint = ray.GetPoint(enter);
                if(m_cursorDebug)
                m_cursorDebug.position = hitPoint;
            }
        }
    }

    public void PushFakeMousePosition(Vector2 mousePosition) {

        if (m_killSwitch) return;
        if(m_actionProjectile)
        m_actionProjectile.SetMousePosition(mousePosition);
    }

    [ContextMenu("Auto Join")]
    public void AutoJoin() {

        m_playerToAffect = FindFirstObjectByType<PlayerRunTime.Player>();
        m_actionProjectile = FindFirstObjectByType<PlayerRunTime.CreateProjectile>();
        m_actionJump = FindFirstObjectByType<PlayerRunTime.Jumps>();
        m_actionScale = FindFirstObjectByType<PlayerRunTime.Scale>();
        m_actionPlane = FindFirstObjectByType<PlayerRunTime.Planneur>();
        m_pauseManager = FindFirstObjectByType<PauseManager>();
        m_restartLevel = FindFirstObjectByType<RestartLevel>();

    }
    public void CallMenuPause()
    {
        if (m_killSwitch) return;

        m_isInMenuPause = !m_isInMenuPause;
        if (m_pauseManager)
            m_pauseManager.PauseGame(m_isInMenuPause);
    }
    public void RestartLevel()
    {
        if (m_killSwitch) return;
        if (m_restartLevel)
            m_restartLevel.RestartCurrentLevel();
    }

    public void RequestMaskAction()
    {
        if (m_killSwitch) return;
        if(m_actionProjectile)
        m_actionProjectile.OnShoot(true);
        if (m_actionJump)
            m_actionJump.OnJump(true);
        if (m_actionScale)
            m_actionScale.OnScaleDown(true);
        if (m_actionPlane)
            m_actionPlane.SetGliderActive(true);
    }

    public void RequestMaskJump() {

        if (m_killSwitch) return;
        if (m_playerToAffect)
            m_playerToAffect.OnJumpSelected();
    }
    public void RequestMaskProjectile() {  
        if (m_killSwitch) return;

        if (m_playerToAffect)
            m_playerToAffect.OnAttackSelected();
    }
    public void RequestMaskGlide()
    {
        if (m_killSwitch) return;
        if (m_playerToAffect)
            m_playerToAffect.OnPlaneSelected();

    }
    public void RequestMaskScale()
    {
        if (m_killSwitch) return;
        if(m_playerToAffect)
        m_playerToAffect.OnScaleSelected();

    }


}
