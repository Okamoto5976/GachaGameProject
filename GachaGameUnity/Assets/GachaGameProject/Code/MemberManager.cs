using UnityEngine;
using System.Collections.Generic;

public class MemberManager : MonoBehaviour
{
    [SerializeField] private EventSO m_initializeEvent;

    [SerializeField] private GameObject m_panelPrefab;

    [SerializeField] private GameObject m_MemberPanel;

    private List<CharaPanel> m_PanelList = new();

    //----debug--------
    //[SerializeField] private DebugMode m_debug;

    private void OnEnable()
    {
        m_initializeEvent.Register(Initialize);
    }

    private void OnDisable()
    {
        m_initializeEvent.Unregister(Initialize);
    }

    public void Initialize()
    {
        Debug.Log("Member Manager Initialize");

        int index = CharacterManager.Instance.DataList.Count;

        for (int i = 0; i < index; i++)
        {
            var obj = Instantiate(m_panelPrefab, m_MemberPanel.transform);

            CharaPanel panel = obj.GetComponent<CharaPanel>();

            if(panel == null)
            {
                Debug.LogError("this panel not have CharaPanel");

                continue;
            }

            m_PanelList.Add(panel);
        }

    }

    public void AddMemberPanel()
    {
        var obj = Instantiate(m_panelPrefab, m_MemberPanel.transform);

        CharaPanel panel = obj.GetComponent<CharaPanel>();

        if (panel == null)
        {
            Debug.LogError("this panel not have CharaPanel");

            return;
        }

        m_PanelList.Add(panel);
    }

    //開いたときに　リセットをする（順番をID順にする）
    public void OnViewPanel()
    {
        int index = CharacterManager.Instance.DataList.Count;

        for(int i = 0; i < index;i++)
        {
            int ID = CharacterManager.Instance.DataList[i].ID;

            MasterCharacterData masterData = CharacterManager.Instance.GetMasterCharaData(ID);

            m_PanelList[i].SetCharaData(masterData);
        }
    }


    //public void PostDataToCharaPanel()
    //{

    //}
}
