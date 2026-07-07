using UnityEngine;
using UnityEngine.Networking;

public class DataSave : MonoBehaviour
{
    private string m_filePath;
    [SerializeField] private AccountData m_accountData;

    private string m_ServerAddress = "http://localhost/PHPGameProject/ADB/jsonfile.php";


    private void Awake()
    {
        m_filePath = Application.persistentDataPath + "/";
    }

    public void SaveFile()
    {
        GameData data = new();
        //data setting
        
        string json = JsonUtility.ToJson(data, true);

        WWWForm form = new WWWForm();
        form.AddField("userId", m_accountData.AccountID);
        form.AddField("saveData", json);

        UnityWebRequest request = UnityWebRequest.Post(m_ServerAddress, form);

        //yield return request.SendWebRequest();
    }
}
//新規登録後、セーブファイル作成　サーバーに設置
//ログイン後　サーバーのjsonをおろす、　dataを獲得しLoadをする
//