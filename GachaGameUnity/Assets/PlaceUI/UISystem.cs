using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject m_homePanel;
    [SerializeField] private GameObject m_stageSelectPanel;
    [SerializeField] private GameObject m_stagePanel;
    [SerializeField] private GameObject m_gachaPanel;
    [SerializeField] private GameObject m_unlockPanel;

    void Awake()
    {
        ShowHome();
    }
    public void ShowHome()
    {
        HideAll();
        m_homePanel.SetActive(true);
    }

    public void ShowStageSelect()
    {
        HideAll();
        m_stageSelectPanel.SetActive(true);
    }

    public void ShowStage()
    {
        HideAll();
        m_stagePanel.SetActive(true);
    }

    public void ShowGacha()
    {
        HideAll();
        m_gachaPanel.SetActive(true);
    }

    private void HideAll()
    {
        m_homePanel.SetActive(false);
        m_stageSelectPanel.SetActive(false);
        m_stagePanel.SetActive(false);
        m_gachaPanel.SetActive(false);
        m_unlockPanel.SetActive(false);

    }

    public void ShowUnlockPanel()
    {
        m_unlockPanel.SetActive(true);
    }

    public void HideUnlockPanel()
    {
        m_unlockPanel.SetActive(false);
    }
    public void OnClickYes()
    {
        Debug.Log("äJï˙èàóùÇÕÇ‹Çæñ¢é¿ëï");
    }
    public void OnClickNo()
    {
        HideUnlockPanel();
    }
}