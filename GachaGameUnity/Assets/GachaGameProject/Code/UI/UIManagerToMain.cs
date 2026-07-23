using TMPro;
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
    [SerializeField] private MainManager m_mainManager;

    [SerializeField] private GameObject m_memberUI;
    [SerializeField] private MemberManager m_memberManager;

    [SerializeField] private GameObject m_charaUI;
    [SerializeField] private CharaUIManager m_charaUIManager;

    [SerializeField] private GameObject m_placementUI;
    [SerializeField] private PlacementManager m_placementManager;

    [SerializeField] private GameObject m_gachaUI;

    [SerializeField] private GameObject m_pullGachaUI;

    [SerializeField] private TextMeshProUGUI m_money;
    [SerializeField] private TextMeshProUGUI m_ticket;


    [SerializeField] private GameObject m_CanTachPanelUI;

    //Event
    [Header("Event")]
    [SerializeField] private CharaUIEventSO m_charaUIEvent;

    [SerializeField] private BoolEventSO m_CanTachUIEvent;

    [SerializeField] private EventSO m_moneyEvent;
    [SerializeField] private EventSO m_ticketEvent;

    public bool m_IsSetMainChara = false;

    [Header("Audio")]
    [SerializeField] private AudioEventSO m_SEEvent;
    [SerializeField] private AudioData m_papeSE;

    private void Start()
    {
        OnStartView();
        SetTextMoney();
        SetTextTicket();
    }

    private void OnEnable()
    {
        m_charaUIEvent.Register(OnViewCharaUI);
        m_moneyEvent.Register(SetTextMoney);
        m_ticketEvent.Register(SetTextTicket);
        m_CanTachUIEvent.Register(ViewCanTachPanelUI);
    }

    private void OnDisable()
    {
        m_charaUIEvent.Unregister(OnViewCharaUI);
        m_moneyEvent.Unregister(SetTextMoney);
        m_ticketEvent.Unregister(SetTextTicket);
        m_CanTachUIEvent.Unregister(ViewCanTachPanelUI);

    }

    public void SetTextMoney()
    {
        m_money.text = CharacterManager.Instance.Money.ToString();
    }

    public void SetTextTicket()
    {
        m_ticket.text = CharacterManager.Instance.Ticket.ToString();
    }

    public void DebugAddMoney()
    {
        int money = CharacterManager.Instance.Money;

        money += 100;

        CharacterManager.Instance.SetMoney(money);
    }

    public void OnViewConfigUI()
    {
        PlaySE();

        ViewConfigUI(true);

        IsSetMainChara();

    }

    //public void OnHideConfigUI()
    //{

    //}

    public void OnStartView()
    {
        ViewMainUI(true);
        ViewMemberUI(false);
        ViewPlacementUI(false);
        ViewPullGachaUI(false);
    }

    public void OnViewMainUI()
    {
        PlaySE();


        ViewMainUI(true);
        m_mainManager.SetCharacter();
        ViewMemberUI(false);
        ViewPlacementUI(false);
        ViewPullGachaUI(false);

        IsSetMainChara();

    }

    public void OnViewMemberUI()
    {
        PlaySE();


        ViewMainUI(false);
        ViewMemberUI(true);
        m_memberManager.OnViewPanel();
        ViewPlacementUI(false);
        ViewPullGachaUI(false);

        IsSetMainChara();

    }

    public void OnViewPlacementUI()
    {
        PlaySE();


        ViewMainUI(false);
        ViewMemberUI(false);
        ViewPlacementUI(true);
        m_placementManager.OnViewPanel();
        ViewPullGachaUI(false);

        IsSetMainChara();

    }

    public void OnViewGachaUI()
    {

        ViewGachaUI(true);
    }

    public void OnViewPullGachaUI()
    {
        PlaySE();


        ViewMainUI(false);
        ViewMemberUI(false);
        ViewPlacementUI(false);
        ViewPullGachaUI(true);

        IsSetMainChara();
    }

    public void OnViewCharaUI(Enum_CharaUIShow type, int id)
    {
        ViewCharaUI(true);
        m_charaUIManager.OnViewCharaUI(type, id);


    }

    private void IsSetMainChara()
    {
        if(m_IsSetMainChara)
        {
            //save
            SaveManager.Instance.OnMainCharaSave();
            m_IsSetMainChara = false;
        }
    }

    private void PlaySE()
    {
        m_SEEvent.Raise(m_papeSE);
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

    private void ViewGachaUI(bool value)
    {
        m_gachaUI.SetActive(value);
    }

    private void ViewPullGachaUI(bool value)
    {
        m_pullGachaUI.SetActive(value);
    }

    private void ViewCanTachPanelUI(bool value)
    {
        m_CanTachPanelUI.SetActive(value);
    }
}
