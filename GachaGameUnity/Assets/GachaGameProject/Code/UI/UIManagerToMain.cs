using UnityEngine;
using UnityEngine.UI;

public enum CurrentSceneUI
{ 
    Main,
    Member,
    Placement,
    Gacha
}

public class UIManagerToMain : MonoBehaviour
{
    [SerializeField] private GameObject m_configUI;

    [SerializeField] private GameObject m_mainUI;

    [SerializeField] private GameObject m_memberUI;

    [SerializeField] private GameObject m_charaUI;

    [SerializeField] private GameObject m_placementUI;

    [SerializeField] private GameObject m_gachaUI;

    [SerializeField] private GameObject m_pullGachaUI;

    //Event
    [Header("Event")]
    [SerializeField] private CharaUIEventSO m_charaUIEvent;

    private void Start()
    {
        OnViewMainUI();
    }

    private void OnEnable()
    {
        m_charaUIEvent.Register(OnViewCharaUI);
    }

    private void OnDisable()
    {
        m_charaUIEvent.Unregister(OnViewCharaUI);
    }

    public void OnViewConfigUI()
    {
        ViewConfigUI(true);
    }

    //public void OnHideConfigUI()
    //{

    //}

    public void OnViewMainUI()
    {
        ViewMainUI(true);
        ViewMemberUI(false);
        ViewPlacementUI(false);
        ViewPullGachaUI(false);
    }

    public void OnViewMemberUI()
    {
        ViewMainUI(false);
        ViewMemberUI(true);
        ViewPlacementUI(false);
        ViewPullGachaUI(false);
    }

    public void OnViewPlacementUI()
    {
        ViewMainUI(false);
        ViewMemberUI(false);
        ViewPlacementUI(true);
        ViewPullGachaUI(false);
    }

    public void OnViewPullGachaUI()
    {
        ViewMainUI(false);
        ViewMemberUI(false);
        ViewPlacementUI(false);
        ViewPullGachaUI(true);
    }

    public void OnViewCharaUI(Enum_CharaUIShow type)
    {
        switch(type)
        {
            case Enum_CharaUIShow.ToMain:

                break;
            case Enum_CharaUIShow.ToMember:
                break;
            case Enum_CharaUIShow.ToChara:
                break;
        }
    }

    //-----UI SetActive--------------

    private void ViewConfigUI(bool value)
    {
        m_configUI.SetActive(value);
    }

    private void ViewMainUI(bool value)
    {
        m_mainUI.SetActive(value);
    }

    private void ViewMemberUI(bool value)
    {
        m_memberUI.SetActive(value);
    }

    private void ViewCharaUI(bool value)
    {
        m_charaUI.SetActive(value);
    }

    private void ViewPlacementUI(bool value)
    {
        m_placementUI.SetActive(value);
    }

    private void ViewPullGachaUI(bool value)
    {
        m_pullGachaUI.SetActive(value);
    }
}
