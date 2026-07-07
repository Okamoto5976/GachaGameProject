using UnityEngine;
using System.IO;

[System.Serializable]
public class LoginData
{
    public string token;
}

public class LoginCash : MonoBehaviour
{
    private string m_filePath;

    private void Awake()
    {
        m_filePath = Application.persistentDataPath + "/login.json";
    }

    public void SaveLoginCash(string token)
    {

        LoginData data = new();
        data.token = token;

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(m_filePath, json);
    }

    public LoginData Load()
    {
        if(File.Exists(m_filePath))
        {
            string json = File.ReadAllText(m_filePath);

            return JsonUtility.FromJson<LoginData>(json);
        }

        return null;
    }

    //Debug
    public void DeleteData()
    {
        if(File.Exists(m_filePath))
        {
            File.Delete(m_filePath);
            Debug.Log("CachLogin Delete");
        }
    }
}
