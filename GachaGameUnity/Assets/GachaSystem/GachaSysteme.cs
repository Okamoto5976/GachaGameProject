using UnityEngine;

public class GachaSysteme : MonoBehaviour
{
    [SerializeField] 
    TextAsset RarityData = default;

    private float[,] m_RarityInfo;
    private int m_RollNum;
    private int m_LotteryType;

    private string[ ] m_Raw;
    private string[ ] m_Column;
    
    
    void Start()
    {
        m_Raw  = RarityData.text.Split('\n');
        m_Column = m_Raw[0].Split(',');
        m_RarityInfo = new float[m_Column.Length,m_Raw.Length];
        for (int i = 0; i < m_Raw.Length; i++)
        {
            m_Column = m_Raw[i].Split(',');
            for (int j = 0; j < m_Column.Length; j++)
                m_RarityInfo[j,i] = float.Parse(m_Column[j]);
        }
    }


    // Update is called once per frame
    void Update()
    {
            for (int i = 0; i < m_RollNum; i++)
            {
                if (i == 9)
                    m_LotteryType = 1;
                else
                    m_LotteryType = 0;
                GetDropItem();
            }
            m_RollNum = 0;

    }

    void GetDropItem()
    {
        int itemRarity = ChooseRarity()+2;

        Debug.Log(itemRarity);
    }
    int ChooseRarity()
    {
        float total = 0;

        for (int i = 0; i < m_RarityInfo.GetLength(0); i++)
        {
            total += m_RarityInfo[i,m_LotteryType] ;
        }
        float randomPoint = Random.value * total;

        for (int i = 0; i < m_RarityInfo.GetLength(0); i++)
        {
            if(randomPoint < m_RarityInfo[i,m_LotteryType])
            {
                return i;
            }
            else
            {
                randomPoint -= m_RarityInfo[i,m_LotteryType];
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


