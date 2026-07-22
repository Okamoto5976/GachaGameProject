using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    [SerializeField] private List<int> m_gachanumber;

    [SerializeField] private List<GachaCharaPanel> m_gachaPanel;

    [SerializeField] private int m_pullGacha;

    [SerializeField] private GameObject m_gachaUI;

    [SerializeField] private CDBGacha m_CDBGacha;

    [SerializeField] private UIManagerToMain m_UIManager;


    //------event

    [SerializeField] private BoolEventSO m_canTachPanelEvent;

    //-----------------

    [SerializeField] private DebugMode m_debug;

    public void OnHideGachaUI()
    {
        m_gachaUI.SetActive(false);

        for(int i = 0; i < m_gachaPanel.Count; i++)
        {
            m_gachaPanel[i].gameObject.SetActive(false);
        }
    }

    public void CallGetChara(List<int> list)
    {
        if(m_debug.debugMode)
        {
            Debug.Log("Debug Gacha");
            DebugGetCharaList(list);
        }
        else
        {
            StartCoroutine(GetGachaList(list));
        }
    }

    //-------------Debug-------------------
    private void DebugGetCharaList(List<int> index)
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

            MasterCharacterData data = CharacterManager.Instance.DebugGachaGetChara(rarity);

            Debug.Log($"{data.RarityType}‚ÌƒLƒƒƒ‰‚ª‹A‚Á‚Ä‚«‚½");

            list.Add(data);
        }

        DebugGetChara(list);
    }

    private void DebugGetChara(List<MasterCharacterData> list)
    {
        //if Debug 
        for (int i = 0; i < list.Count; i++)
        {
            CharacterManager.Instance.AddGachaChara(list[i].ID);

        }

        OnViewChara(list);
    }

    //----------------------

    private IEnumerator GetGachaList(List<int> index)
    {

        yield return StartCoroutine(m_CDBGacha.Post(index));

        List<int> list = m_CDBGacha.Results.results;

        //php‚Å‚â‚Á‚Ä‚é
        //for (int i = 0; i < list.Count; i++)
        //{
        //    CharacterManager.Instance.AddGachaChara(list[i]);

        //}

        SaveManager.Instance.OnGachaSave();

        //save‚ð‹²‚Þ
        //‰‰o
        ViewGachaChara(list);
        

    }
        
    public void ViewGachaChara(List<int> list)
    {
        List<MasterCharacterData> masterList = new();


        for (int i = 0; i < list.Count;i++)
        {
            MasterCharacterData data = CharacterManager.Instance.GetMasterCharaData(list[i]);

            masterList.Add(data);
        }

        OnViewChara(masterList);
    }

    public void OnViewChara(List<MasterCharacterData> list)
    {
        m_UIManager.OnViewGachaUI();

        m_canTachPanelEvent.Raise(false);


        for (int i = 0; i < list.Count; i++)
        {
            m_gachaPanel[i].gameObject.SetActive(true);
            m_gachaPanel[i].SetGachaCharaData(list[i]);
        }
    }


}
