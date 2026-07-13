using UnityEngine;

public class MemberManager : MonoBehaviour
{
    [SerializeField] private EventSO m_initializeEvent;

    [SerializeField] private GameObject m_panelPrefab;

    [SerializeField] private GameObject m_MemberPanel;

    //----debug--------
    [SerializeField] private DebugMode m_debug;

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
            Instantiate(m_panelPrefab, m_MemberPanel.transform);

        }

    }

    public void AddMemberPanel()
    {
        Instantiate(m_panelPrefab, m_MemberPanel.transform);
    }

    public void PostDataToCharaUI()
    {

    }
}
