using UnityEngine;
using UnityEngine.UI;

public class CharaPanel : MonoBehaviour
{
    [SerializeField] private CharaUIEventSO m_charaUIEvent;

    [SerializeField] private Enum_CharaUIShow m_type;

    [SerializeField] private Image m_image;
    public int ID { get; private set; }

    private Sprite m_sprite;

    

    //Back Scene have

    public void OnClickViewCharaUI()
    {

        switch(m_type)
        {
            case Enum_CharaUIShow.ToMain:
                break;
            case Enum_CharaUIShow.ToMember:
                m_charaUIEvent.Raise(Enum_CharaUIShow.ToMember, ID);

                break;
            case Enum_CharaUIShow.ToChara:
                break;
        }


    }

    public void SetCharaData(MasterCharacterData data)
    {
        ID = data.ID;
        m_image.sprite = data.image;
    }
}
