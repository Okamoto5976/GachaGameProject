using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;



public class CDBGacha : MonoBehaviour
{
    [System.Serializable]
    public class GachaResult
    {
        public int id;
    }


    [System.Serializable]
    public class GachaResults
    {
        public GachaResult[] results;
    }

    [SerializeField] private int m_rarity;


    private string m_ServerAddress = "http://10.219.32.121/PHPGameProject/CDB/gacha.php";

    //onclick event
    public void OnSendSignel()
    {
        StartCoroutine("Access");
    }

    private IEnumerator Access()
    {

        StartCoroutine(Post(m_rarity));

        yield return 0;
    }

    //use Gacha view
    public GachaResults Results { get; private set; }

    private IEnumerator Post(int rarity)
    {
        WWWForm form = new();
     
        form.AddField("rarities[0]", rarity);

        UnityWebRequest www = UnityWebRequest.Post(m_ServerAddress,form);

        yield return www.SendWebRequest();

        if(www.error != null)
        {
            Debug.Log("HttpPost NG: " + www.error); 
        }
        else if(www.isDone)
        {
            //m_text.GetComponent<TextMeshProUGUI>().text = www.downloadHandler.text;
            GachaResults data = JsonUtility.FromJson<GachaResults>(www.downloadHandler.text);

            foreach (GachaResult result in data.results)
            {
                Debug.Log("Žæ“¾ID : " + result.id);
                CharacterManager.Instance.AddGachaChara(result.id);

            }

            Results = data;

        }
    }
}
