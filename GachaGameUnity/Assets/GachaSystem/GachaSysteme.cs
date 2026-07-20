using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[System.Serializable]
public class Rate
{
    public float rateC;
    public float rateU;
    public float rateR;
}

public class GachaSysteme : MonoBehaviour
{
    //[SerializeField] private int m_RollNum = 0;
    public List<int> m_RarityList = new();
    [SerializeField] public Rate rate;

    [SerializeField] private int m_NeedMoney;
    [SerializeField] private int m_NeedTicket;
    //SO
    [SerializeField] private int m_Coine;
    [SerializeField]private float m_Ticket;

    [SerializeField] private GachaManager m_gachaView;
    [SerializeField] private UIManagerToMain m_UIManager;

    public void OneGacha()
    {


        if (m_NeedTicket <= m_Ticket)
        {
            if (!IsCheakTicket(m_NeedTicket))
            {
                Debug.Log("you do not have ticket");
                return;
            }
            GachaGet(1);
        }
        else if (m_NeedMoney <= m_Coine)
        {
            if (!IsCheakMoney(m_NeedMoney))
            {
                Debug.Log("you do not have money");
                return;
            }
            GachaGet(1);
        }
        else
        {
            Debug.Log("you do not have to ticket and Coine");
        }
            
    }

    public void TenGacha()
    {
        //Do you have Money?
        //LotteryTypeTen();
        if (m_NeedTicket * 10 <= m_Ticket)
        {
            if (!IsCheakTicket(m_NeedTicket * 10))
            {
                Debug.Log("you do not have ticket");
                return;
            }
            GachaGet(10);
        }
        else if (m_NeedMoney * 10 <= m_Coine)
        {
            if (!IsCheakMoney(m_NeedMoney * 10))
            {
                Debug.Log("you do not have money");
                return;
            }
            GachaGet(10);
        }
        else
        {
            Debug.Log("you do not have to ticket and Coine");
        }


    }



    private void GachaGet(int num)
    {
        m_RarityList.Clear();

        for(int i  = 0; i < num; i++)
        {
            float randomPoint = Random.Range(0, 100);
            int rarity = 0;


            if(randomPoint  < rate.rateR )
            {
                rarity = 3;
            }
            else if( rate.rateR < randomPoint && randomPoint < rate.rateU )
            {
                rarity = 2;
            }
            else
            {
                rarity = 1;
            }

            Debug.Log($"{randomPoint}");

            m_RarityList.Add(rarity);

        }

        //Post PHP data "m_RarityList";

        m_gachaView.GetGachaList(m_RarityList);

        m_UIManager.OnViewGachaUI();
    }

    public void ChiketsGet()
    {
        m_Ticket += 1;

    }

    private bool IsCheakMoney(int money)
    {
        if(m_Coine < money)
        {
            return false;
        }
        else
        {
            m_Coine -= money;
            return true;
        }
    }

    private bool IsCheakTicket(int ticket)
    {
        if (m_Ticket < ticket)
        {
            return false;
        }
        else
        {
            m_Ticket -= ticket;
            return true;
        }
    }


    //public void PayTicket(int pay)
    //{
    //    m_Ticket -= pay;
    //    return;
    //}

    //public void GetCharaSorting(int Index)
    //{
    //    CharaData chara = m_DropChara[Index];
    //    already Charactur check
    //     Compare the characters you have here with the ones you got from the gacha.
    //        if (m_DropChara.Exists(name == chara.m_name))
    //    {

    //        //    //Debug.Log($"Already acquired character: {[(int)Character.Name, charaId]}");
    //        ChiketsGet();
    //        //    Debug.Log("It has been converted into a gacha ticket!" );
    //    }
    //    else
    //    {
    //        m_DropChara.Add(chara);

    //        //Debug.Log($"newCharactur {}‚ª’Ç‰Á‚³‚ê‚Ü‚µ‚½B");
    //    }

    //}
}

