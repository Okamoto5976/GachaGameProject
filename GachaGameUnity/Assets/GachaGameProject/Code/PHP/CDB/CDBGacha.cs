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

    public TextMeshProUGUI m_text;

    [SerializeField] private int m_id;

    [SerializeField] private RawImage displlayImage;

    private string m_ServerAddress = "http://localhost/PHPGameProject/CDB/gacha.php";

    //onclick event
    public void OnSendSignel()
    {
        StartCoroutine("Access");
    }

    private IEnumerator Access()
    {

        StartCoroutine(Post(m_id));

        yield return 0;
    }

    private IEnumerator Post(int id)
    {
        WWWForm form = new();
     
        form.AddField("rarities[0]", 1);
        form.AddField("rarities[1]", 1);
        form.AddField("rarities[2]", 1);
        form.AddField("rarities[3]", 1);
        form.AddField("rarities[4]", 1);
        form.AddField("rarities[5]", 1);

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
            }
        }
    }
}
