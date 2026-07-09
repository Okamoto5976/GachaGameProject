using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject m_homePanel;
    [SerializeField] private GameObject m_stageSelectPanel;
    [SerializeField] private GameObject m_stage1Panel;
    [SerializeField] private GameObject m_stage2Panel;
    [SerializeField] private GameObject m_stage3Panel;

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

    public void ShowStage1()
    {
        HideAll();
        m_stage1Panel.SetActive(true);
    }

    public void ShowStage2()
    {
        HideAll();
        m_stage2Panel.SetActive(true);
    }

    public void ShowStage3()
    {
        HideAll();
        m_stage3Panel.SetActive(true);
    }

    private void HideAll()
    {
        m_homePanel.SetActive(false);
        m_stageSelectPanel.SetActive(false);
        m_stage1Panel.SetActive(false);
        m_stage2Panel.SetActive(false);
        m_stage3Panel.SetActive(false);
    }
}