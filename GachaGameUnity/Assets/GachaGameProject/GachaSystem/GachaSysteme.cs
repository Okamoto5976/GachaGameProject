using UnityEngine;
using System.Collections.Generic;

public class GachaSysteme : MonoBehaviour
{
  
    public enum Rarity
    {
        C = 60,
        R = 30,
        SR = 10
    }
    public class CharaData
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
    private Character m_character;
    public List<Rarity> m_RarityList = new();

    private int m_RollNum = 0;
    private int m_LotteryType;//0=1,1=10
    public List<int> m_GradeList = new();
    public List<CharaData> m_DropChara = new();
    private int m_Coine;
    private float m_tickets = 0;
    private float m_Gettickets = 0;


    private void GhachaGet()
    {

        for (int i = 0; i < m_RollNum; i++)
        {

            if (i % 10 == 9)
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
        int chara = GetRarity(GetM_GradeList());

        GetCharaSorting(chara);
        m_tickets += m_Gettickets;
        Debug.Log($"チケットを{m_Gettickets}枚手に入れた。");
        m_Gettickets = 0f;
    }

    public void GetCharaSorting(int Index)
    {
        CharaData chara= m_DropChara[Index];
        //already Charactur check
        // Compare the characters you have here with the ones you got from the gacha.
        //if (m_DropChara.Exists(name==chara.m_name))
        //{

        ////    //Debug.Log($"Already acquired character: {[(int)Character.Name, charaId]}");
        //    ChiketsGet();
        ////    Debug.Log("It has been converted into a gacha ticket!" );
        //}
        //else
        //{
        //    m_DropChara.Add(chara);
            
        //    //Debug.Log($"newCharactur {}が追加されました。");
        //}

    }

    public List<int> GetM_GradeList()
    {
        return m_GradeList;
    }

    public int GetRarity(List<int> m_GradeList)
    {
        //確率の合計値を格納
        float total = 0;

        //確率を合計する
        //for (int i = 0; i < m_GradeList(i); i++)
        //{   
            //total += m_GradeList[i,rate];
        //}
        //Random.valueでは1から3までのfloat値を返すので
        //そこにドロップ率の合計を掛ける
        float randomPoint = Random.value * total;

        for (int i = 0; i < m_RollNum; i++)
        {
            if (randomPoint <=10)
            {
                m_GradeList.Add(1);
            }
            else if (randomPoint <= 30)
            {
                m_GradeList.Add(2);
            }
            else
            {
                m_GradeList.Add(3);
            }
        }

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
        else if(m_Coine>=10)
        {
            m_RollNum = 1;
            m_Coine -= 10;
        }
        else
        {
            Debug.Log("チケットまたはコインが足りません");
        }

    }

    public void LotteryTypeTen()
    {
        if (m_tickets >= 20)
        {
            m_tickets -= 20;
            m_RollNum = 10;
        }
        else if(m_Coine>=100)
        {
            m_Coine = 100;
            m_RollNum = 10;

        }
        else
                {
                    Debug.Log("チケットまたはコインが足りません");
                }

    }
    public void PayTicket(int pay)
    {
        m_tickets -= pay;
        return;
    }


}


