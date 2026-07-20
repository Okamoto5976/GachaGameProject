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
                m_isPressing = false; // 1âÒÇæÇØé¿çs
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
        m_image.sprite = data.PanelImage;
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
