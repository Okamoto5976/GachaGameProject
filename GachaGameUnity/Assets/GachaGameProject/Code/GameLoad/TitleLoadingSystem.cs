using UnityEngine;

public class TitleLoadingSystem : MonoBehaviour
{
    [SerializeField] private ADBPostSaveFile m_postSaveFile;
    [SerializeField] private AccountData m_accountData;

    [SerializeField] private DebugMode m_debug;

    public void OnLoadingData()
    {
        if(!m_debug.debugMode)
        {
            //ADBのfilepathからSaveをロード
            m_postSaveFile.LoadFile(data =>
            {
                if (data == null)
                {
                    Debug.Log("not found data");
                    return;
                }

                //CreatePlayer();

                foreach(var chara in data.m_charaDatas)
                {
                    //CharacterManager.Instance.S
                }

                //マスターデータをデータベースから引く
                //このデータは使わない　図鑑のみに使う



            });

            //EntityDataManagerにセット
            //データをDataBaseから引いて　Set
            //キャラlevelSet
            //お金etc...セット
        }



        //Game開始 ここからオートセーブ開始
    }
}
