using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharaPlacePanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private CharaUIEventSO m_charaUIEvent;

    [SerializeField] private Enum_CharaUIShow m_type;

    [SerializeField] private Image m_image;
    public int ID { get; private set; }

    [SerializeField] private PlaceSelectSO m_placeSelectSO;

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
        ID = data.ID;
        OnViewUI(data);

        m_image.sprite = data.PanelImage;
    }

    private void OnViewUI(MasterCharacterData data)
    {

        UI ui = m_UIclass.Find(x => x.RarityType == data.RarityType);

        m_frontUI.sprite = ui.FrontUI;
        m_backUI.sprite = ui.BackUI;
        m_rarityUI.sprite = ui.RarityUI;
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
            m_placeSelectSO.GetID(ID);
        }

        m_isPressing = false;
    }
}
