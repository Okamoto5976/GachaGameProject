using UnityEngine;
using System.Collections.Generic;


public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;

    private List<CharacterData> m_dataList = new();

    //SO
    private int m_money;

    //--------propaty-----------
    public List<CharacterData> DataList => m_dataList;

    public CharacterList MasterData {  get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //get save file data
    public void AdddataList(CharacterData data)
    {
        m_dataList.Add(data);
        //並べ替える（一応）
    }

    public void AddGachaChara(int id)
    {
        if(DataList.Find(x => x.ID == id) != null)
        {
            Debug.Log("既に持っています");
            return;
        }


        CharacterData data = new CharacterData
        {
            ID = id,
            Level = 1,
        };

        m_dataList.Add(data);
    }

    public void CheckHaveCharacter()
    {
        Debug.Log("以下持ってるキャラ:");
        foreach(var data in DataList)
        {
            Debug.Log($"ID:{data.ID} Level:{data.Level}");
        }
        Debug.Log("以下マスターデータ:");
        foreach(var data in MasterData.characters)
        {
            Debug.Log($"ID:{data.id} Name:{data.name}");
        }
    }

    //idからdataを渡す
    public CharacterData GetCharaData(int id)
    {
        return null;
    }

    //icon + id キャラ選択や　図鑑のため
    public CharacterData GetCharaImage(int id)
    {
        //１から順に取っていき、
        //受け取り手がidとimageをもつことで図鑑ができる
        //ないときは受け取り手が真っ黒にする図鑑を

        //キャラ選択のとき
        //図鑑のときもそうだけど更新のとき
        //Coroutine（非同期処理）でimageとデータを更新しよう

        return null;
    }

    public void SetMasterData(CharacterList list)
    {
        MasterData = list;
    }
}
