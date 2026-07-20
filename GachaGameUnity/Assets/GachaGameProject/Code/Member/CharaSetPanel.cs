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

    private float m_pressTime;
    private bool m_isPressing;

    [SerializeField] private float m_longPressTime = 1.0f;

    private void Start()
    {
        m_image.sprite = m_nullSprite;
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
                m_isPressing = false; // 1âÒÇæÇØé¿çs
            }
        }
    }

    //Back Scene have

    public void OnClickViewCharaUI()
    {

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
        m_image.sprite = data.PanelImage;
    }

    public void ResetData()
    {
        m_image.sprite = m_nullSprite;

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
            if (m_placeSelectSO.NowID == 0) return;

            int id = m_placeSelectSO.NowID;

            m_id = id;

            m_placementManager.CheckCharaSetPanelList(id, m_num);

            SetCharaData(CharacterManager.Instance.GetMasterCharaData(id));
        }

        m_isPressing = false;
    }
}
