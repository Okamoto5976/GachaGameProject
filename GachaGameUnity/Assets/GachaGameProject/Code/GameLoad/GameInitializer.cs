using System.Collections;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private ADBPostSaveFile m_postSaveFile;
    [SerializeField] private AccountData m_accountData;
    [SerializeField] private CDBMaster m_masterDB;

    public IEnumerator OnLoadingData()
    {


        //ADBÇÃfilepathÇ©ÇÁSaveÇÉçÅ[Éh
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

                Debug.Log($"{chara}Ç™Ç†ÇÈ");

                CharacterManager.Instance.AdddataList(chara);
            }

            //money set
            CharacterManager.Instance.SetMoney(m_postSaveFile.LoadSaveDataFile.m_money);
            //ticket set
            CharacterManager.Instance.SetTicket(m_postSaveFile.LoadSaveDataFile.m_ticket);

            //mainchara set
            CharacterManager.Instance.SetMainCharacters(m_postSaveFile.LoadSaveDataFile.m_mainCharaData);

            Debug.Log("1 chara data setäÆóπ");
        }
        else
        {
            Debug.Log("save file not found");
        }

        //LoadMasterData();
        yield return StartCoroutine(m_masterDB.Post());
        Debug.Log("2 master data setäÆóπ");


    }
}