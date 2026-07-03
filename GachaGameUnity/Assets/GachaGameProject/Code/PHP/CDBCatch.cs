using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;

public class CDBData
{
    public int id;
    public string name;
    public string type;
    public string rarity;
    public int value;
    public string image_url;
}

public class CDBCatch : MonoBehaviour
{
    public TextMeshProUGUI m_text;

    [SerializeField] private int m_id;

    [SerializeField] private RawImage displlayImage;

    private string m_ServerAddress = "http://localhost/PHPGameProject/CDB/select.php";

    [SerializeField] private CharTestDB m_testDB;

    //onclick event
    public void OnSendSignel()
    {
        StartCoroutine("Access");
    }

    private IEnumerator Access()
    {
        Dictionary<string, int> dic = new();

        dic.Add("id", m_id);

        StartCoroutine(Post(m_ServerAddress, dic));

        yield return 0;
    }

    private IEnumerator Post(string url, Dictionary<string, int> post)
    {
        WWWForm form = new();
        Debug.Log(url);
        foreach (KeyValuePair<string, int> post_arg in post)
        {
            form.AddField(post_arg.Key, post_arg.Value);
        }
        UnityWebRequest www = UnityWebRequest.Post(url,form);

        yield return www.SendWebRequest();

        //yield return StartCoroutine(CheckTimeOut(www, 3f));

        if(www.error != null)
        {
            Debug.Log("HttpPost NG: " + www.error); 
        }
        else if(www.isDone)
        {
            //m_text.GetComponent<TextMeshProUGUI>().text = www.downloadHandler.text;
            CDBData data = JsonUtility.FromJson<CDBData>(www.downloadHandler.text);

            m_testDB.id = data.id;
            m_testDB.m_name = data.name;

            if(System.Enum.TryParse(data.type, true, out TestType typeState))
            {
                m_testDB.type = typeState;
            }
            else
            {
                Debug.LogWarning($"Failure:'{data.type}'not existent in TestType");
            }

            if (System.Enum.TryParse(data.rarity, true, out TestRarity rarityState))
            {
                m_testDB.rarity = rarityState;
            }
            else
            {
                Debug.LogWarning($"Failure:'{data.rarity}'not existent in TestRarity");
            }

            m_testDB.value = data.value;

            StartCoroutine(LoadImage(data.image_url));

        }
    }

    private IEnumerator CheckTimeOut(UnityWebRequest www, float timeout)
    {
        float requestTime = Time.time;

        while (!www.isDone)
        {
            if (Time.time - requestTime < timeout)
            {
                yield return null;
            }
            else
            {
                Debug.Log("TimeOut");
                break;
            }
        }

        yield return null;
    }

    private IEnumerator LoadImage(string url)
    {
        Debug.Log("Image URL :" + url);

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        Debug.Log($"Result : {request.result}");
        Debug.Log($"Error  : {request.error}");
        Debug.Log($"Code   : {request.responseCode}");

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("API Get Failure:" + request.error);
            yield break;
        }

        //byte[] imageData = File.ReadAllBytes(url);
        //Texture2D texture = new Texture2D(2, 2);
        Texture2D texture = DownloadHandlerTexture.GetContent(request);

        displlayImage.texture = texture;


        //if(texture.LoadImage(imageData))
        //{
        //    displlayImage.texture = texture;
        //}
    }
}
