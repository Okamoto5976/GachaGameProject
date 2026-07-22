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

    private string m_SaveServerAddress = "http://10.219.32.121/PHPGameProject/ADB/savejsonfile.php";
    private string m_LoadServerAddress = "http://10.219.32.121/PHPGameProject/ADB/loadjsonfile.php";


    private void Awake()
    {
        //m_filePath = Application.persistentDataPath + "/";
    }

    public void SaveFile(int id, SaveDataFile data)
    {
        //data setting
        
        string json = JsonUtility.ToJson(data, true);

        StartCoroutine(SaveFileCoroutine(json, id));

        
    }

    //public void LoadFile()
    //{
    //    StartCoroutine(LoadFileCoroutine());
    //}

    private IEnumerator SaveFileCoroutine(string json, int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("userId", id);
        form.AddField("saveData", json);

        UnityWebRequest request = UnityWebRequest.Post(m_SaveServerAddress, form);

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

    public SaveDataFile LoadSaveDataFile { get; private set; }


    public IEnumerator LoadFileCoroutine(int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("userId", id);

        UnityWebRequest request = UnityWebRequest.Post(m_LoadServerAddress, form);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Failure: " + request.error);
            LoadSaveDataFile = null;
        }
        else
        {
            RegisterResult result = JsonUtility.FromJson<RegisterResult>(
                    request.downloadHandler.text);

            if (result.success)
            {
                Debug.Log("get save file");
                LoadSaveDataFile = result.saveData;
                SaveManager.Instance.SetSaveData(LoadSaveDataFile);
            }
            else
            {
                Debug.Log("sava file not found, new Data get");
                LoadSaveDataFile = result.saveData;
                SaveManager.Instance.SetSaveData(LoadSaveDataFile);

            }


        }
    }
}
//新規登録後、セーブファイル作成　サーバーに設置
//ログイン後　サーバーのjsonをおろす、　dataを獲得しLoadをする
//