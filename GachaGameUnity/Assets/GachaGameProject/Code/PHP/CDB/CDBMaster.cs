using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;

public class CDBMaster : MonoBehaviour
{
    [System.Serializable]
    public class CharacterData
    {
        public int id;
        public string name;
        public string type;
        public string rarity;
        public int value;
        public string image_url;
    }


    [System.Serializable]
    public class CharacterList
    {
        public CharacterData[] characters;
    }

    public TextMeshProUGUI m_text;

    [SerializeField] private int m_id;

    [SerializeField] private RawImage displlayImage;

    private string m_ServerAddress = "http://localhost/PHPGameProject/CDB/getMasterCDB.php";

    //onclick event
    public void OnSendSignel()
    {
        StartCoroutine(Post());
    }

    private IEnumerator Post()
    {
        WWWForm form = new();

        UnityWebRequest www = UnityWebRequest.Get(m_ServerAddress);

        yield return www.SendWebRequest();

        //yield return StartCoroutine(CheckTimeOut(www, 3f));

        if(www.error != null)
        {
            Debug.Log("HttpPost NG: " + www.error); 
        }
        else if(www.isDone)
        {
            //m_text.GetComponent<TextMeshProUGUI>().text = www.downloadHandler.text;
            CharacterList list = JsonUtility.FromJson<CharacterList>(www.downloadHandler.text);

            foreach(CharacterData c in list.characters)
            {
                Debug.Log(
                    c.id + " "+
                    c.name + " "+
                    c.type + " "+
                    c.rarity + " "+
                    c.value);
            }

            //EntityData charaData = new();


            //charaData.ID = data.id;
            //charaData.Name = data.name;

            //if(System.Enum.TryParse(data.type, true, out Enum_PlaceType typeState))
            //{
            //    charaData.Type = typeState;
            //}
            //else
            //{
            //    Debug.LogWarning($"Failure:'{data.type}'not existent in TestType");
            //}

            //if (System.Enum.TryParse(data.rarity, true, out Enum_RarityType rarityState))
            //{
            //    charaData.Rarity = rarityState;
            //}
            //else
            //{
            //    Debug.LogWarning($"Failure:'{data.rarity}'not existent in TestRarity");
            //}

            //charaData.Value = data.value;

            //StartCoroutine(LoadImage(data.image_url));

        }
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

        Texture2D texture = DownloadHandlerTexture.GetContent(request);

        displlayImage.texture = texture;

    }
}
