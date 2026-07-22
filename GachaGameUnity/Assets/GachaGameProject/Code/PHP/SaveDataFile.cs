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

    public int m_ticket;

    public List<int> m_mainCharaData = new();

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

    private void SetCharaData(CharacterData data)
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

    public void SetTicket(int ticket)
    {
        m_ticket = ticket;
    }

    public void SaveMainChara(List<int> list)
    {
        m_mainCharaData = list;
    }
}
