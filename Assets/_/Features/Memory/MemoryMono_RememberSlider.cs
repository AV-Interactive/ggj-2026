using UnityEngine;
using UnityEngine.UI;

public class MemoryMono_RememberSlider : MonoBehaviour
{

    public Slider m_targetSlider;
    public float m_defaultValue=1;

    public string m_fileNameWithExtension ;

    private void Reset()
    {
        m_fileNameWithExtension = System.Guid.NewGuid().ToString() + ".txt";
        m_targetSlider = GetComponent<Slider>();
    }
    public string GetFilePath()
    {
        return Application.persistentDataPath + "/" + m_fileNameWithExtension;
    }

    private void OnEnable()
    {
        LoadPreferencesInPeristanceFile();
    }
    private void OnDisable()
    {
        SavePreferencesInPeristanceFile();
    }
    private void OnApplicationQuit()
    {
        SavePreferencesInPeristanceFile();
    }
    public void SavePreferencesInPeristanceFile() {

        float valueToSave = m_targetSlider.value;
        System.IO.File.WriteAllText(GetFilePath(), valueToSave.ToString());
    }
    public void LoadPreferencesInPeristanceFile() {
        string filePath = GetFilePath();
        if (System.IO.File.Exists(filePath))
        {
            string valueString = System.IO.File.ReadAllText(filePath);
            if (float.TryParse(valueString, out float loadedValue))
            {
                m_targetSlider.value = loadedValue;
            }
        }
        else
        {
            m_targetSlider.value = m_defaultValue;
        }
    }
}
