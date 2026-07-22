using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    [SerializeField] private EventSO m_initializeEvent;

    [SerializeField] private GameObject m_panelPrefab;

    [SerializeField] private GameObject m_PlacementPanel;

    private List<CharaPlacePanel> m_PanelList = new();

    [SerializeField] private EventSO m_getCharaEvent;

    [SerializeField] private UIManagerToMain m_uiManager;

    //----debug--------
    //[SerializeField] private DebugMode m_debug;

    private void OnEnable()
    {
        m_getCharaEvent.Register(AddPlacementPanel);
        m_initializeEvent.Register(PlacementInitialize);
    }

    private void OnDisable()
    {
        m_getCharaEvent.Unregister(AddPlacementPanel);
        m_initializeEvent.Unregister(PlacementInitialize);
    }

    public void PlacementInitialize()
    {
        Debug.Log("Placement Manager Initialize");

        int index = CharacterManager.Instance.DataList.Count;

        for (int i = 0; i < index; i++)
        {
            var obj = Instantiate(m_panelPrefab, m_PlacementPanel.transform);

            CharaPlacePanel panel = obj.GetComponent<CharaPlacePanel>();

            if (panel == null)
            {
                Debug.LogError("this panel not have CharaPanel");

                continue;
            }

            m_PanelList.Add(panel);
        }

    }

    public void AddPlacementPanel()
    {
        var obj = Instantiate(m_panelPrefab, m_PlacementPanel.transform);

        CharaPlacePanel panel = obj.GetComponent<CharaPlacePanel>();

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

        for (int i = 0; i < index; i++)
        {
            int ID = CharacterManager.Instance.DataList[i].ID;

            MasterCharacterData masterData = CharacterManager.Instance.GetMasterCharaData(ID);

            m_PanelList[i].SetCharaData(masterData);
        }
    }


    [SerializeField] private List<CharaSetPanel> m_charaSetPanelList = new();

    //private List<int> m_mainCharaList = new();

    private void Start()
    {
        for (int i = 0; i < m_charaSetPanelList.Count; i++)
        {
            m_charaSetPanelList[i].Initialized(this);
        }
    }

    public void CheckCharaSetPanelList(int id, int num)
    {
        List<int> list = new();

        for(int i = 0; i < m_charaSetPanelList.Count; i++)
        {
            Debug.Log($"for文の初め{m_charaSetPanelList[i].ID}");

            //同じ番号のPanelは無視
            if (m_charaSetPanelList[i].Num != num)
            {
                if (m_charaSetPanelList[i].ID == id)
                {
                    m_charaSetPanelList[i].ResetData();
                }
            }

            
            Debug.Log($"for文の追加{m_charaSetPanelList[i].ID}");

            list.Add(m_charaSetPanelList[i].ID);
        }

        CharacterManager.Instance.SetMainCharacters(list);

        m_uiManager.m_IsSetMainChara = true;
    }

    //セーブデータから設置済みのキャラをセットする処理
}
