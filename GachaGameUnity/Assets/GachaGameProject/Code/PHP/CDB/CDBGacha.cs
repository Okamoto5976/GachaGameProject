using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;



public class CDBGacha : MonoBehaviour
{
    [System.Serializable]
    public class GachaResults
    {
        public List<int> results;
    }

    //[SerializeField] private int m_rarity;


    private string m_ServerAddress = "http://10.219.32.121/PHPGameProject/CDB/gacha.php";

    //onclick event
    //public void OnSendSignel()
    //{
    //    StartCoroutine("Access");
    //}

    //private IEnumerator Access()
    //{

    //    StartCoroutine(Post(m_rarity));

    //    yield return 0;
    //}

    //use Gacha view
    public GachaResults Results { get; private set; }

    public IEnumerator Post(List<int> list)
    {
        WWWForm form = new();
     
        for(int i = 0;  i < list.Count; i++)
        {
            form.AddField($"rarities[{i}]", list[i]);

        }


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

            foreach (int result in data.results)
            {
                Debug.Log("Žæ“¾ID : " + result);
                CharacterManager.Instance.AddGachaChara(result);

            }

            Results = data;

        }
    }
}
