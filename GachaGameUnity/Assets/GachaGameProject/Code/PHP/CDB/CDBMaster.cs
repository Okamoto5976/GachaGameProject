using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;
[System.Serializable]
public class MasterCharacterData
{
    public int id;
    public string name;
    public string type;
    public string rarity;
    public int value;
    public string image_url;
    public Sprite gachaImage;
    public Sprite image;
}


[System.Serializable]
public class CharacterList
{
    public MasterCharacterData[] characters;
}
public class CDBMaster : MonoBehaviour
{
    

    private string m_ServerAddress = "http://10.219.32.121/PHPGameProject/CDB/getMasterCDB.php";

    public CharacterList MasterDataList { get; private set; }

    //onclick event
    public void OnSendSignel()
    {
        StartCoroutine(Post());
    }

    public IEnumerator Post()
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
            //Debug.Log(www.downloadHandler.text);
            CharacterList list = JsonUtility.FromJson<CharacterList>(www.downloadHandler.text);

            foreach(MasterCharacterData c in list.characters)
            {
                //Debug.Log(
                //    c.id + " "+
                //    c.name + " "+
                //    c.type + " "+
                //    c.rarity + " "+
                //    c.value);

                yield return StartCoroutine(LoadImage(c));
            }

            MasterDataList = list;

            CharacterManager.Instance.SetMasterData(MasterDataList);

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

    private IEnumerator LoadImage(MasterCharacterData c)
    {
        string url = c.image_url;

        //Debug.Log("Image URL :" + url);

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        //Debug.Log($"Result : {request.result}");
        //Debug.Log($"Error  : {request.error}");
        //Debug.Log($"Code   : {request.responseCode}");

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("API Get Failure:" + request.error);
            yield break;
        }

        Texture2D texture = DownloadHandlerTexture.GetContent(request);

        //c.texture = texture;

        c.image = Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));

    }
}
