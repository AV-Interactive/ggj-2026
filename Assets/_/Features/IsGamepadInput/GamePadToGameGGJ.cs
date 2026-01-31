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
        m_pauseManager.PauseGame(m_isInMenuPause);
    }
    public void RestartLevel()
    {
        if (m_killSwitch) return;
        m_restartLevel.RestartCurrentLevel();
    }

    public void RequestMaskAction()
    {
        if (m_killSwitch) return;
        m_actionProjectile.OnShoot(true);
        m_actionJump.OnJump(true);
        m_actionScale.OnScaleDown(true);
        m_actionPlane.SetGliderActive(true);
    }

    public void RequestMaskJump() {

        if (m_killSwitch) return;
        m_playerToAffect.OnJumpSelected();
    }
    public void RequestMaskProjectile() {  
        if (m_killSwitch) return;
    
        m_playerToAffect.OnAttackSelected();
    }
    public void RequestMaskGlide()
    {
        if (m_killSwitch) return;
    m_playerToAffect.OnPlaneSelected();

    }
    public void RequestMaskScale()
    {
        if (m_killSwitch) return;
    m_playerToAffect.OnScaleSelected();

    }


}
