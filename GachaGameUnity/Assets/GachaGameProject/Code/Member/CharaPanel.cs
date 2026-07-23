using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaPanel : MonoBehaviour
{
    [SerializeField] private CharaUIEventSO m_charaUIEvent;

    [SerializeField] private Enum_CharaUIShow m_type;

    [SerializeField] private Image m_image;
    public int ID { get; private set; }

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

    //Back Scene have
    [Header("Audio")]
    [SerializeField] private AudioEventSO m_SEEvent;
    [SerializeField] private AudioData m_peta;

    private void PlaySE()
    {
        m_SEEvent.Raise(m_peta);
    }

    public void OnClickViewCharaUI()
    {
        PlaySE();

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
