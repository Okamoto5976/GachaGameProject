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

    //---use Gacha chara view---------

    //public void SetGachaCharaData(MasterCharacterData data)
    //{
    //    ID = data.ID;
    //    //OnViewImage(data.Texture);
    //    m_image.sprite = data.GachaImage;

    //}

    //public void OnViewImage(Texture2D image)
    //{
    //    Sprite sprite = Sprite.Create(
    //        texture,
    //        new Rect((texture.width - 300) / 2, 0, 300, texture.height),
    //        new Vector2(0.5f, 0.5f)
    //        );

    //    m_image.sprite = sprite;
    //}
}
