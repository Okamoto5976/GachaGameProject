using UnityEngine;
using System.Collections.Generic;
using System.Linq;

//[System.Serializable]
//public class DebugMasterData
//{
//    public int ID;
//    public string Name;
//    public Enum_CharaType CharaType;
//    public Enum_RarityType RarityType;
//    public int Value;
//    public Texture2D Texture;
//}

//[System.Serializable]
//public class DebugCharaData
//{
//    public int ID;
//    public int Level;
//    public Enum_PlaceType PlaceType;
//}

public class DebugCharaManager : MonoBehaviour
{
    //public static DebugCharaManager Instance;


    //[SerializeField] private MasterCharacterList m_masterDataList = new();

    //public List<CharacterData> DebugCharaDataList { get; private set; }

    //public MasterCharacterList DebugMasterDataList => m_masterDataList;


    //[SerializeField] private MemberManager m_memberManager;

    ////--------Debug-------------
    //[SerializeField] private DebugMode m_debug;

    //private void Awake()
    //{
    //    if (!m_debug.debugMode) return;


    //    //if (Instance != null)
    //    //{
    //    //    Destroy(gameObject);
    //    //    return;
    //    //}

    //    //Instance = this;
    //    //DontDestroyOnLoad(gameObject);

    //    DebugCharaDataList = new();

    //    CharacterData data = new CharacterData()
    //    {
    //        ID = 1,
    //        Level = 1,
    //        PlaceType = Enum_PlaceType.Grass
    //    };

    //    DebugCharaDataList.Add(data);
    //}

    //private void Start()
    //{
    //    m_memberManager.DebugInitialize(DebugCharaDataList.Count);
    //}


    //public MasterCharacterList GachaGetChara(Enum_RarityType rarity)
    //{
    //    var dates = DebugMasterDataList.Where(x => x.RarityType != rarity).ToList();

    //    if(dates.Count <= 0) return null;

    //    return dates[Random.Range(0, dates.Count)];
    //}
}
