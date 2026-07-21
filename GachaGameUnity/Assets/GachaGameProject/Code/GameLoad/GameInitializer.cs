using System.Collections;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private ADBPostSaveFile m_postSaveFile;
    [SerializeField] private AccountData m_accountData;
    [SerializeField] private CDBMaster m_masterDB;

    public IEnumerator OnLoadingData()
    {


        //ADBのfilepathからSaveをロード
        //data is SaveDataFile class
        //have chara or money in data
        yield return StartCoroutine(m_postSaveFile.LoadFileCoroutine(m_accountData.AccountID));

        if (m_postSaveFile.LoadSaveDataFile != null)
        {
            //charadata set
            foreach (var chara in m_postSaveFile.LoadSaveDataFile.m_charaDatas)
            {
                //CharacterData charadata = new CharacterData
                //{
                //    ID = chara.ID,
                //    Level = chara.Level,
                //};

                CharacterManager.Instance.AdddataList(chara);
            }

            //money set
            CharacterManager.Instance.SetMoney(m_postSaveFile.LoadSaveDataFile.m_money);

        }
        else
        {
            Debug.Log("save file not found");
        }

        //LoadMasterData();
        StartCoroutine(m_masterDB.Post());

        //AutoSave開始Data

    }
}