using UnityEngine;
using System.Collections.Generic;

public class DebugGachaSystem : MonoBehaviour
{
    [SerializeField] private List<int> m_gachanumber;

    [SerializeField] private List<testimage> m_gachaImage;

    [SerializeField] private int m_pullGacha;

    public void OnClick()
    {
        Debug.Log("gacha");
        OnGacha(m_pullGacha);
    }

    public void OnGacha(int pull)
    {
        List<MasterCharacterData> list = new();

        for(int i = 0;i < pull;i++)
        {
            int number;

            if(m_gachanumber.Count <= 0)
            {
                number = Random.Range(0, 3);

            }
            else
            {
                number = m_gachanumber[i];
            }

            Enum_RarityType rarity;

            switch (number)
            {
                case 0:
                    rarity = Enum_RarityType.C;
                    break;
                case 1:
                    rarity = Enum_RarityType.U;
                    break;
                case 2:
                    rarity = Enum_RarityType.R;
                    break;
                default:
                    rarity = Enum_RarityType.C;
                    break;

            }

            MasterCharacterData data = CharacterManager.Instance.GachaGetChara(rarity);

            list.Add(data);
        }

        OnViewChara(pull, list);


    }

    public void OnViewChara(int index, List<MasterCharacterData> list)
    {
        for(int i = 0; i < index; i++)
        {
            m_gachaImage[i].gameObject.SetActive(true);
            m_gachaImage[i].OnViewImage(list[i].Texture);
        }
    }
}
