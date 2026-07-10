using UnityEngine;

public class StageButtonUI : MonoBehaviour
{
    [SerializeField]
    private bool m_isUnlocked = false;

    [SerializeField]
    private UIManager m_uiManager;

    public void OnClickStage()
    {
        if (!m_isUnlocked)
        {
            m_uiManager.ShowUnlockPanel();
            return;
        }

        m_uiManager.ShowStage();
    }
  
}