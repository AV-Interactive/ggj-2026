using UnityEngine;

public class RotateMono_RotateOnAxis : MonoBehaviour
{
    public Vector3 m_rotationAxis = Vector3.up;
    public float m_minRotationStep = 5;
    public float m_maxRotationStep = 45;
    public int m_rotateStepsAtAwake = 1;
    public bool m_rotateOnAllAxisAtAwake = false;
    public bool m_destroyScriptAfterAwake = true;
    public void Reset()
    {
        m_toRotate = GetComponent<Transform>();
    }

    public Transform m_toRotate;


    public void Awake()
    {
        for (int i = 0; i < m_rotateStepsAtAwake; i++)
        {
                RotateRandomlyOneStepOnAxis();
            
        }
        if (m_rotateOnAllAxisAtAwake)
        {
            RotateRandomlyOneStepAllAxis();
        }
        if (m_destroyScriptAfterAwake)
        {
            Destroy(this);
        }
    }

    [ContextMenu("Rotate Randomly One Step On Axis")]
    public void RotateRandomlyOneStepOnAxis() {

        float randomStep = Random.Range(m_minRotationStep, m_maxRotationStep);
        m_toRotate.Rotate(m_rotationAxis, randomStep, Space.Self);
    }

    [ContextMenu("Rotate Randomly One Step All Axis")]
    public void RotateRandomlyOneStepAllAxis() {

        float randomStepX = Random.Range(m_minRotationStep, m_maxRotationStep);
        float randomStepY = Random.Range(m_minRotationStep, m_maxRotationStep);
        float randomStepZ = Random.Range(m_minRotationStep, m_maxRotationStep);
        m_toRotate.Rotate(new Vector3(randomStepX, randomStepY, randomStepZ), Space.Self);

    }


    [ContextMenu("Remove The Rotation Script")]
    public void RemoveTheRotationScript()
    {
        if (Application.isPlaying)
            Destroy(this);
        else
            DestroyImmediate(this);

    }
}


