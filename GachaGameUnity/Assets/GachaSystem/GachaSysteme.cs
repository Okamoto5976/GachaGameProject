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
    TextAsset RarityData = default;
    [SerializeField]
    TextAsset CharacterData = default;

    private float[,] m_RarityInfo;
    private string[,] m_CharInfo;
    private int m_RollNum = 0;
    private int m_LotteryType;//0=1,1=10
    private List<CharaData> m_DropChara = new();
    string[] m_Raw;
    string[] m_Column;
    

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
                m_LotteryType = 1;
            else
                m_LotteryType = 0;

            GetDropChara();
        }
        m_RollNum = 0;
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

            //Debug.Log("ガチャチケットを獲得しました！");
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



    public void LotteryTypeOne()
    {
        m_RollNum = 1;
    }

    public void LotteryTypeTen()
    {
        m_RollNum = 10;
    }

}


