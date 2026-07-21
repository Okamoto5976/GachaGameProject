using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    [SerializeField] private List<int> m_gachanumber;

    [SerializeField] private List<GachaCharaPanel> m_gachaPanel;

    [SerializeField] private int m_pullGacha;

    [SerializeField] private GameObject m_gachaUI;

    public void OnHideGachaUI()
    {
        m_gachaUI.SetActive(false);

        for(int i = 0; i < m_gachaPanel.Count; i++)
        {
            m_gachaPanel[i].gameObject.SetActive(false);
        }
    }

    public void GetGachaList(List<int> index)
    {
        int pull = index.Count;

        List<MasterCharacterData> list = new();


        for (int i = 0; i < pull; i++)
        {

            Enum_RarityType rarity;

            switch (index[i])
            {
                case 1:
                    rarity = Enum_RarityType.C;
                    break;
                case 2:
                    rarity = Enum_RarityType.U;
                    break;
                case 3:
                    rarity = Enum_RarityType.R;
                    break;
                default:
                    rarity = Enum_RarityType.C;
                    break;

            }

            MasterCharacterData data = CharacterManager.Instance.GachaGetChara(rarity);

            list.Add(data);
        }

        GetChara(pull, list);

    }

    public void GetChara(int index, List<MasterCharacterData> list)
    {
        //if Debug 
        for(int i = 0;i < list.Count;i++)
        {
            CharacterManager.Instance.AddGachaChara(list[i].ID);

        }

        OnViewChara(index, list);
    }

    public void OnViewChara(int index, List<MasterCharacterData> list)
    {
        for(int i = 0; i < index; i++)
        {
            m_gachaPanel[i].gameObject.SetActive(true);
            m_gachaPanel[i].SetGachaCharaData(list[i]);
        }
    }

    //public void OnDebugClick()
    //{
    //    //Debug.Log("gacha");
    //    OnGacha(m_pullGacha);
    //}

    //public void OnGacha(int pull)
    //{
    //    List<MasterCharacterData> list = new();

    //    for(int i = 0;i < pull;i++)
    //    {
    //        int number;

    //        if(m_gachanumber.Count <= 0)
    //        {
    //            number = Random.Range(0, 3);

    //        }
    //        else
    //        {
    //            number = m_gachanumber[i];
    //        }

    //        Enum_RarityType rarity;

    //        switch (number)
    //        {
    //            case 0:
    //                rarity = Enum_RarityType.C;
    //                break;
    //            case 1:
    //                rarity = Enum_RarityType.U;
    //                break;
    //            case 2:
    //                rarity = Enum_RarityType.R;
    //                break;
    //            default:
    //                rarity = Enum_RarityType.C;
    //                break;

    //        }

    //        MasterCharacterData data = CharacterManager.Instance.GachaGetChara(rarity);

    //        list.Add(data);
    //    }

    //    OnViewChara(pull, list);


    //}

}
