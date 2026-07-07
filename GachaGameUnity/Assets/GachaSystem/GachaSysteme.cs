using UnityEngine;
using System.Collections.Generic;

public class GachaSysteme : MonoBehaviour
{

    private class CharaData
    {

        public int m_glade;
        public string m_rarity;
        public string m_name;
        public float m_rate;
    }
    private enum Character
    {
        Glade,
        Rarity,
        Name,
        Rate,
    }

    [SerializeField]
    private TextAsset RarityData = default;
    [SerializeField]
    private TextAsset CharacterData = default;

    private float[,] m_RarityInfo;
    private string[,] m_CharInfo;
    private int m_RollNum = 0;
    private int m_LotteryType;//0=1,1=10
    private List<CharaData> m_DropChara = new();
    private string[] m_Raw;
    private string[] m_Column;
    private float m_tickets = 20;
    private float m_Coine=0;
    private float m_Gettickets = 0;
    private void Start()
    {
        //Loading text

        m_Raw = RarityData.text.Split('\n');
        m_Column = m_Raw[0].Split(',');
        m_RarityInfo = new float[m_Column.Length, m_Raw.Length];
        for (int i = 0; i < m_Raw.Length; i++)
        {
            m_Column = m_Raw[i].Split(',');
            for (int j = 0; j < m_Column.Length; j++)
                m_RarityInfo[j, i] = float.Parse(m_Column[j]);
        }
       
        m_Raw = CharacterData.text.Split(char.Parse("\n"));
        m_Column = m_Raw[0].Split(char.Parse(","));
        m_CharInfo = new string[m_Column.Length, m_Raw.Length];
        for (int i = 0; i < m_Raw.Length; i++)
        {
            m_Column = m_Raw[i].Split(char.Parse(","));
            for (int j = 0; j < m_Column.Length; j++)
                m_CharInfo[j, i] = m_Column[j];
        }
    }

    private void Update()
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
            Debug.Log($"現在のチケット枚数は{m_tickets}枚です。");
        }
        m_RollNum = 0;
        return;
    }

    private void GetDropChara()
    {
        //Rarity lottery
        int CharRarity = ChooseRarity();

        //Character lottery
        int charaId = ChooseChar(CharRarity);
        Debug.Log($"'{m_CharInfo[(int)Character.Name, charaId]}が出ました！");
        //already Charactur check
        if (m_DropChara.Exists(chara => chara.m_name == m_CharInfo[(int)Character.Name, charaId]))
        {
            Debug.Log($"既に取得済みのキャラクター: {m_CharInfo[(int)Character.Name, charaId]}");
            ChiketsGet();
            Debug.Log("ガチャチケットを獲得しました！" );
        }
        else
        {
            //GetList
            CharaData newChara = new CharaData
            {
                //m_id = int.Parse(m_CharInfo[(int)Character.id, charaId]),
                m_glade = int.Parse(m_CharInfo[(int)Character.Glade, charaId]),
                m_name = m_CharInfo[(int)Character.Name, charaId],
                m_rate = float.Parse(m_CharInfo[(int)Character.Rate, charaId])
            };
            m_DropChara.Add(newChara);
            Debug.Log($"新キャラ {m_CharInfo[(int)Character.Name, charaId]}が追加されました。");
           
        }
        m_tickets += m_Gettickets;
        Debug.Log($"チケットを{m_Gettickets}枚手に入れた。");
        m_Gettickets = 0f;
    }

    private int ChooseRarity()
    {
        //prot total
        float total = 0;

        //total probability 
        for (int i = 0; i < m_RarityInfo.GetLength(0); i++)
            total += m_RarityInfo[i, m_LotteryType];

        //Random.valueでは0から1までのfloat値を返すので
        //そこにドロップ率の合計を掛ける
        float randomPoint = Random.value * total;

        //randomPointの位置に該当するキーを返す
        for (int i = 0; i < m_RarityInfo.GetLength(0); i++)
        {
            if (randomPoint < m_RarityInfo[i, m_LotteryType])
            {
                return i;
            }
            else
            {
                randomPoint -= m_RarityInfo[i, m_LotteryType];
            }
        }
        return 0;
    }
    private int ChooseChar(int rarity)
    {
        float total = 0;

        for (int i = 0; i < m_CharInfo.GetLength(1); i++)
            if (int.Parse(m_CharInfo[(int)Character.Glade, i]).Equals(rarity))
                total += float.Parse(m_CharInfo[(int)Character.Rate, i]);

        float randomPoint = Random.value * total;

        for (int i = 0; i < m_CharInfo.GetLength(1); i++)
        {
            if (int.Parse(m_CharInfo[(int)Character.Glade, i]).Equals(rarity))
            {
                if (randomPoint < float.Parse(m_CharInfo[(int)Character.Rate, i]))
                {
                    return i;
                }
                else
                {
                    randomPoint -= float.Parse(m_CharInfo[(int)Character.Rate, i]);
                }
            }
        }
        return 0;
    }
    public void ChiketsGet()
    {
        //m_GetChikets += 1;
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
        else if (m_Coine >= 10)
        {
            m_Coine -= 10;
            m_RollNum = 1;
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
        else if (m_Coine >= 100)
        {
            m_Coine -= 100;
            m_RollNum = 10;
        }
        else
        {
            Debug.Log("チケットまたはコインが足りません");
        }

    }

}


