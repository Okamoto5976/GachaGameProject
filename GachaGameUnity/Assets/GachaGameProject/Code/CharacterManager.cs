using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class CharacterData
{
    public int ID;
    public int Level;
    public Enum_PlaceType PlaceType;
}

[System.Serializable]
public class MasterCharacterData
{
    public int ID;
    public string Name;
    public Enum_CharaType CharaType;
    public Enum_RarityType RarityType;
    public int Value;
    public Texture2D Texture;
    //public Sprite gachaImage;
    public Sprite image;
}

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;

    private List<CharacterData> m_dataList = new();

    public List<MasterCharacterData> m_masterDataList = new();

    //SO
    [SerializeField] private IntRunTime m_money;

    //--------propaty-----------
    public List<CharacterData> DataList => m_dataList;

    public List<MasterCharacterData> MasterDataList => m_masterDataList;
    //--------Debug------------
    [SerializeField] private DebugMode m_debug;

    [SerializeField] private List<CharacterData> m_debugCharacterDataList;

    [SerializeField] private List<MasterCharacterData> m_debugMasterDataList;

    [SerializeField] private EventSO m_initializeEvent;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if(m_debug.debugMode)
        {
            m_dataList = m_debugCharacterDataList;

            m_masterDataList = m_debugMasterDataList;

            m_initializeEvent.Raise();
        }
    }

    private void Start()
    {
        if (m_debug.debugMode)
        {

            m_initializeEvent.Raise();
        }
    }

    //get save file data
    public void AdddataList(CharacterData data)
    {
        m_dataList.Add(data);
        //並べ替える（一応）
        m_dataList.Sort((a,b) => a.ID.CompareTo(b.ID));
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

    [ContextMenu("Now check Data")]
    public void CheckHaveCharacter()
    {
        Debug.Log("以下持ってるキャラ:");
        foreach(var data in DataList)
        {
            Debug.Log($"ID:{data.ID} Level:{data.Level}");
        }
        Debug.Log("以下マスターデータ:");
        foreach(var data in m_masterDataList)
        {
            Debug.Log($"ID:{data.ID} Name:{data.Name}");
        }
    }

    //idからdataを渡す
    public CharacterData GetCharaData(int id)
    {
        var data = DataList.Find(x => x.ID == id);

        if (data != null) return data;

        return null;
    }

    //icon + id キャラ選択や　図鑑のため
    public MasterCharacterData GetMasterCharaData(int id)
    {
        var data = MasterDataList.Find(x => x.ID == id);

        //１から順に取っていき、
        //受け取り手がidとimageをもつことで図鑑ができる
        //ないときは受け取り手が真っ黒にする図鑑を

        //キャラ選択のとき
        //図鑑のときもそうだけど更新のとき
        //Coroutine（非同期処理）でimageとデータを更新しよう

        if (data != null) return data;

        return null;
    }

    public MasterCharacterData GachaGetChara(Enum_RarityType rarity)
    {
        var dates = MasterDataList.Where(x => x.RarityType != rarity).ToList();

        if (dates.Count <= 0) return null;

        return dates[Random.Range(0, dates.Count)];
    }

    public void SetMasterData(List<MasterCharacterData> list)
    {
        m_masterDataList = list;
    }
}
