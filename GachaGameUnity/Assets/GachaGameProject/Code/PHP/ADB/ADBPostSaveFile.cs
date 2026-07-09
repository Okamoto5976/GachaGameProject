using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ADBPostSaveFile : MonoBehaviour
{
    //[System.Serializable]
    //public class ResultSaveFile
    //{
    //    public bool success;
    //    public string message;
    //    public SaveDataFile saveFile;
    //}


    //private string m_filePath;

    private string m_ServerAddress = "http://localhost/PHPGameProject/ADB/jsonfile.php";


    private void Awake()
    {
        //m_filePath = Application.persistentDataPath + "/";
    }

    public void SaveFile(int id)
    {
        SaveDataFile data = new();
        //data setting
        
        string json = JsonUtility.ToJson(data, true);

        StartCoroutine(SaveFileCoroutine(json, id));

        
    }

    public void LoadFile(System.Action<SaveDataFile> callback)
    {
        StartCoroutine(LoadFileCoroutine(callback));
    }

    private IEnumerator SaveFileCoroutine(string json, int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("userId", id);
        form.AddField("saveData", json);

        UnityWebRequest request = UnityWebRequest.Post(m_ServerAddress, form);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Failure: " + request.error);
        }
        else
        {
            RegisterResult result =
               JsonUtility.FromJson<RegisterResult>(request.downloadHandler.text);

            if (result.success)
            {
                Debug.Log("保存成功");
                
            }
            else
            {
                Debug.Log(result.message);
            }
        }
    }

    private IEnumerator LoadFileCoroutine(System.Action<SaveDataFile> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("userId", "1001");

        UnityWebRequest request = UnityWebRequest.Post(m_ServerAddress, form);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Failure: " + request.error);
        }
        else
        {
            SaveDataFile data =
                JsonUtility.FromJson<SaveDataFile>(
                    request.downloadHandler.text);

            callback(data);
        }
    }
}
//新規登録後、セーブファイル作成　サーバーに設置
//ログイン後　サーバーのjsonをおろす、　dataを獲得しLoadをする
//