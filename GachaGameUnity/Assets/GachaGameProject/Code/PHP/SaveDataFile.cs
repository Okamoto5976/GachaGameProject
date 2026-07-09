using UnityEngine;
using System.Collections.Generic;

public class SaveDataFile
{
    //save timing
    //5m
    //quite application
    //gacha
    //level

    //saveData=============================
    public List<CharacterData> m_charaDatas = new();

    public int m_money;



    //Data method==========================

    public void SaveCharaData(int id, int level)
    {
        CharacterData chara = m_charaDatas.Find(x => x.ID== id);

        if(chara != null)
        {
            chara.Level = level;
        }
        else
        {
            SetCharaData(id, level);
        }
    }

    public void SetCharaData(int id, int level)
    {
        CharacterData newChara = new CharacterData();

        newChara.ID = id;
        newChara.Level = level;

        m_charaDatas.Add(newChara);
    }

    public void SetMoney(int money)
    {
        m_money = money;
    }
}
