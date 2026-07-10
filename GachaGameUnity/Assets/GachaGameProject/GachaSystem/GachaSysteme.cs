using UnityEngine;
using System.Collections.Generic;

public class GachaSysteme : MonoBehaviour
{
    public enum Grade
    {
        c = 1,
        r = 2,
        sr = 3
    }

    public enum Rarity
    {
        C = 60,
        R = 30,
        SR = 10
    }
    private class CharaData
    {
        public int m_id;
        public int m_grade;
        public string m_rarity;
        public string m_name;
        public float m_rate;
    }
    private enum Character
    {
        ID,
        Glade,
        Rarity,
        Name,
        Rate,
    }
    //public List<CharaData> m_AraadyData = new();
    public List<Rarity> m_RarityList = new();
    private int m_RollNum = 0;
    private int m_LotteryType;//0=1,1=10
    public List<Grade> m_GradeList = new();
    private List<CharaData> m_DropChara = new();
    private int m_Coine;
    private float m_tickets = 20;
    private float m_Gettickets = 0;


    private void GhachaGet()
    {

        for (int i = 0; i < m_RollNum; i++)
        {

            if (i%10 == 9)
            {
                m_LotteryType = 1;

            }
            else if (m_RollNum == 1)
            {
                m_LotteryType = 0;
            }

            GetDropChara();
            Debug.Log($"You currently have {m_tickets} tickets.");
        }
        m_RollNum = 0;
        return;
    }

    private void GetDropChara()
    {
        //int Rate = GetRarity();
        //m_RarityList.Add(GetRarity);





        m_tickets += m_Gettickets;
        Debug.Log($"チケットを{m_Gettickets}枚手に入れた。");
        m_Gettickets = 0f;
    }

    public void GetCharaSorting()
    {

        //Debug.Log($"'{m_CharInfo[(int)Character.Name, charaId]}が出ました！");
        //already Charactur check
        // Compare the characters you have here with the ones you got from the gacha.
        //if (m_DropChara.Exists(chara => chara.m_name ==/* m_[(int)Character.Name, charaId]*/))
        //{

            //    Debug.Log($"Already acquired character: {[(int)Character.Name, charaId]}");
            //ChiketsGet();
            Debug.Log("It has been converted into a gacha ticket!" );
        //}
        //else
        //{
            CharaData newChara = new()
            {
                //m_id = int.Parse(m_CharInfo[(int)Character.id, charaId]),
                    //m_rarity=string.IsNullOrEmpty(m_CharInfo[(int)Character.Rarity, charaId]),
                    //m_name = m_CharInfo[(int)Character.Name, charaId],
                    //m_grade = int.Parse(m_CharInfo[(int)Character.Glade, charaId]),
                    //m_rate = float.Parse(m_CharInfo[(int)Character.Rate, charaId])
            };
            //m_DropChara.Add(newChara);
            //
            //Debug.Log($"newCharactur {Character.Name, charaId]}が追加されました。");
        //}

    }


    public int GetRarity()
    {
        //確率の合計値を格納
        float total = 0;

        //確率を合計する
        //for (int i = 0; i <m_RarityList[i]; i++)
        //{   //total += m_RarityList[i, ];
        //}
        //Random.valueでは1から3までのfloat値を返すので
        //そこにドロップ率の合計を掛ける
        //float randomPoint = Random.value * total;

        //randomPointの位置に該当するキーを返す
        //for (int i = 0; i < m_RarityList[i]; i++)
        //{
        //    if (randomPoint < m_RartiyList[i, m_LotteryType])
        //    {
        //        return i;
        //    }
        //    else
        //    {
        //        randomPoint -= m_RarityList[i, m_LotteryType];
        //    }
        //}
        return 0;
    }

    public void ChiketsGet()
    {
        m_tickets += 1;
        return;
    }
    public void LotteryTypeOne()
    {

        if (m_tickets >= 2)
        {
            m_tickets -= 2;
            m_RollNum = 1;
        }
        else
        {
            Debug.Log("チケットが足りません");
        }

    }

    public void LotteryTypeTen()
    {
        if (m_tickets >= 20)
        {
            m_tickets -= 20;
            m_RollNum = 10;
        }
        else
        {
            Debug.Log("チケットが足りません");
        }

    }
    public void PayTicket(int pay)
    {
        m_tickets -= pay;
        return;
    }


}


