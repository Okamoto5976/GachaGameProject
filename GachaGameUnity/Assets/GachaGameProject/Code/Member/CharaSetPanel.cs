using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharaSetPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private CharaUIEventSO m_charaUIEvent;

    [SerializeField] private Enum_CharaUIShow m_type;

    [SerializeField] private Image m_image;

    [SerializeField] private Sprite m_nullSprite;

    [SerializeField] private int m_id;

    [SerializeField] private int m_num;

    public int ID => m_id;

    public int Num => m_num;

    [SerializeField] private PlaceSelectSO m_placeSelectSO;

    private PlacementManager m_placementManager;

    private bool m_isEnable;

    private Sprite m_sprite;

    [SerializeField] private Image m_frontUI;
    [SerializeField] private Image m_backUI;
    [SerializeField] private Image m_rarityUI;
    
    [System.Serializable]
    public class UI
    {
        [SerializeField] private Sprite m_FrontUI;
        [SerializeField] private Sprite m_BackUI;
        [SerializeField] private Sprite m_RarityUI;
        [SerializeField] private Enum_RarityType m_rarity;

        public Sprite FrontUI => m_FrontUI;
        public Sprite BackUI => m_BackUI;
        public Sprite RarityUI => m_RarityUI;
        public Enum_RarityType RarityType => m_rarity;
    }

    [SerializeField] private List<UI> m_UIclass = new();


    private float m_pressTime;
    private bool m_isPressing;

    [SerializeField] private float m_longPressTime = 1.0f;

    [Header("Audio")]
    [SerializeField] private AudioEventSO m_SEEvent;
    [SerializeField] private AudioData m_peta;

    private void PlaySE()
    {
        m_SEEvent.Raise(m_peta);
    }

    private void Start()
    {
        m_backUI.sprite = m_nullSprite;
        //m_frontUI.enabled = false;
        //m_rarityUI.enabled = false;
        //m_image.enabled = false;
    }

    public void Initialized(PlacementManager manager)
    {
        m_placementManager = manager;
    }


    private void Update()
    {
        if (m_isPressing)
        {
            m_pressTime += Time.deltaTime;

            if (m_pressTime >= m_longPressTime)
            {
                OnClickViewCharaUI();
                m_isPressing = false; // 1‰ñ‚¾‚¯ŽÀs
            }
        }
    }

    //Back Scene have

    public void OnClickViewCharaUI()
    {
        PlaySE();

        if (!m_isEnable) return;

        switch(m_type)
        {
            case Enum_CharaUIShow.ToMain:
                m_charaUIEvent.Raise(Enum_CharaUIShow.ToMain, ID);

                break;
            case Enum_CharaUIShow.ToMember:
                m_charaUIEvent.Raise(Enum_CharaUIShow.ToMember, ID);

                break;
            case Enum_CharaUIShow.ToChara:
                m_charaUIEvent.Raise(Enum_CharaUIShow.ToChara, ID);

                break;
        }


    }

    public void SetCharaData(MasterCharacterData data)
    {
        m_id = data.ID;
        OnViewUI(data);

        m_frontUI.enabled = true;
        m_rarityUI.enabled = true;
        m_image.enabled = true;

        m_image.sprite = data.PanelImage;
    }

    private void OnViewUI(MasterCharacterData data)
    {

        UI ui = m_UIclass.Find(x => x.RarityType == data.RarityType);

        m_frontUI.sprite = ui.FrontUI;
        m_backUI.sprite = ui.BackUI;
        m_rarityUI.sprite = ui.RarityUI;
    }

    public void ResetData()
    {
        m_backUI.sprite = m_nullSprite;
        m_frontUI.enabled = false;
        m_rarityUI.enabled = false;
        m_image.enabled = false;

        m_id = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_pressTime = 0;
        m_isPressing = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (m_pressTime < m_longPressTime)
        {
            PlaySE();

            if (m_placeSelectSO.NowID == 0) return;

            int id = m_placeSelectSO.NowID;

            m_id = id;

            m_placementManager.CheckCharaSetPanelList(id, m_num);

            SetCharaData(CharacterManager.Instance.GetMasterCharaData(id));
        }

        m_isPressing = false;
    }
}
