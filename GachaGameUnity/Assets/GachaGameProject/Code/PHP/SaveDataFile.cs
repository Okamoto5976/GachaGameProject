using UnityEngine;
using System.Collections.Generic;



[System.Serializable]//if serializable not, can not json
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

    public void SaveCharaData(CharacterData data)
    {
        CharacterData chara = m_charaDatas.Find(x => x.ID== data.ID);

        if (chara != null)
        {
            //chara.Level = data.Level;
            return;
        }
        else
        {
            SetCharaData(data);
        }


    }

    public void SetCharaData(CharacterData data)
    {
        //CharacterData newChara = new CharacterData();

        //newChara.ID = id;
        //newChara.Level = level;

        m_charaDatas.Add(data);
    }

    public void SetMoney(int money)
    {
        m_money = money;
    }
}
