using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;
[System.Serializable]
public class PHPGetCharaData
{
    public int id;
    public string name;
    //public string type;
    public string rarity;
    public int value;
    public string image_url;
    public string panelimage_url;
    public string gachaimage_url;
    //public Texture2D texture;
    public Sprite image;
    public Sprite panelImage;
    public Sprite gachaImage;

}


[System.Serializable]
public class PHPGetCharaDataList
{
    public PHPGetCharaData[] characters;
}
public class CDBMaster : MonoBehaviour
{
    

    private string m_ServerAddress = "http://10.219.32.121/PHPGameProject/CDB/getMasterCDB.php";

    public List<MasterCharacterData> MasterDataList { get; private set; }

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
            PHPGetCharaDataList list = JsonUtility.FromJson<PHPGetCharaDataList>(www.downloadHandler.text);

            MasterDataList = new List<MasterCharacterData>();

            foreach (PHPGetCharaData c in list.characters)
            {
                //Debug.Log(
                //    c.id + " "+
                //    c.name + " "+
                //    c.type + " "+
                //    c.rarity + " "+
                //    c.value);

                yield return StartCoroutine(LoadImage(c));
                yield return StartCoroutine(LoadPanelImage(c));
                yield return StartCoroutine(LoadGachaImage(c));



                MasterCharacterData data = new();

                data.ID = c.id;
                data.Name = c.name;

                //if (System.Enum.TryParse(c.type, true, out Enum_CharaType typeState))
                //{
                //    //data.CharaType = typeState;
                //}
                //else
                //{
                //    Debug.LogWarning($"Failure:'{c.type}'not existent in TestType");
                //}

                if (System.Enum.TryParse(c.rarity, true, out Enum_RarityType rarityState))
                {
                    data.RarityType = rarityState;
                }
                else
                {
                    Debug.LogWarning($"Failure:'{c.rarity}'not existent in TestRarity");
                }

                data.Value = c.value;
                //data.Texture = c.texture;
                data.Image = c.image;
                data.PanelImage = c.panelImage;
                data.GachaImage = c.gachaImage;

                MasterDataList.Add(data);
            }




            Debug.Log($"MasterData çÏê¨êî : {MasterDataList.Count}");

            CharacterManager.Instance.SetMasterData(MasterDataList);

            Debug.Log("MasterData Set äÆóπ");

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

    private IEnumerator LoadImage(PHPGetCharaData c)
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

    private IEnumerator LoadPanelImage(PHPGetCharaData c)
    {
        string url = c.panelimage_url;

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

        c.panelImage = Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));

    }

    private IEnumerator LoadGachaImage(PHPGetCharaData c)
    {
        string url = c.gachaimage_url;

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

        c.gachaImage = Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));

    }
}
