using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class CharaData
{
    public int CharaID;
    public int CharaLevel;
}

public class SaveDataFile
{
    //save timing
    //5m
    //quite application
    //gacha
    //level

    //saveData=============================
    public List<CharaData> m_charaDatas = new();

    public int m_money;



    //Data method==========================

    public void SaveCharaData(int id, int level)
    {
        CharaData chara = m_charaDatas.Find(x => x.CharaID == id);

        if(chara != null)
        {
            chara.CharaLevel = level;
        }
        else
        {
            SetCharaData(id, level);
        }
    }

    public void SetCharaData(int id, int level)
    {
        CharaData newChara = new CharaData();

        newChara.CharaID = id;
        newChara.CharaLevel = level;

        m_charaDatas.Add(newChara);
    }

    public void SetMoney(int money)
    {
        m_money = money;
    }
}
