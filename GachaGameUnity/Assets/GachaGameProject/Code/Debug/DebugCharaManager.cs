using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class DebugMasterData
{
    public int ID;
    public string Name;
    public Enum_CharaType CharaType;
    public Enum_RarityType RarityType;
    public int Value;
    public Texture2D Texture;
}

[System.Serializable]
public class DebugCharaData
{
    public int ID;
    public int Level;
    public Enum_PlaceType PlaceType;
}

public class DebugCharaManager : MonoBehaviour
{
    

    [SerializeField] private List<DebugMasterData> m_masterDataList = new();

    public List<DebugCharaData> DebugCharaDataList { get; private set; }

    public List<DebugMasterData> DebugMasterDataList => m_masterDataList;

    private void Awake()
    {
        DebugCharaDataList = new();

        DebugCharaData data = new DebugCharaData()
        {
            ID = 1,
            Level = 1,
            PlaceType = Enum_PlaceType.Grass
        };

        DebugCharaDataList.Add(data);
    }

    public DebugMasterData GachaGetChara(Enum_RarityType rarity)
    {
        var dates = DebugMasterDataList.Where(x => x.RarityType != rarity).ToList();

        if(dates.Count <= 0) return null;

        return dates[Random.Range(0, dates.Count)];
    }
}
