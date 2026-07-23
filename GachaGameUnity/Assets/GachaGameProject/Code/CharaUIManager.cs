using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharaUIManager : MonoBehaviour
{
    [SerializeField] private Image m_charaImage;

    [SerializeField] private TextMeshProUGUI m_nameText;

    //[SerializeField] private TextMeshProUGUI m_charaTypeText;

    //[SerializeField] private TextMeshProUGUI m_levelText;

    [SerializeField] private TextMeshProUGUI m_valueText;

    [SerializeField] private Image m_rarityImage;

    private int m_currentID;


    [SerializeField] private GameObject m_CharaUI;

    //[SerializeField] private GameObject m_Arrow;

    //[SerializeField] private GameObject m_levelUpButton;


    [SerializeField] private Sprite m_common;
    [SerializeField] private Sprite m_uncommon;
    [SerializeField] private Sprite m_rare;

    [Header("Audio")]
    [SerializeField] private AudioEventSO m_SEEvent;
    [SerializeField] private AudioData m_peta;

    public void OnViewCharaUI(Enum_CharaUIShow type, int id)
    {
        OnViewArrowUI(false);
        OnViewLevelUpUI(false);

        //get charadata from charaManager
        var masterData = CharacterManager.Instance.GetMasterCharaData(id);
        var data = CharacterManager.Instance.GetCharaData(id);

        if (masterData == null)
        {
            Debug.LogError("Not Found Master Data");

            return;
        }

        if (data == null)
        {
            Debug.LogError("Not Found Character Data");

            return;
        }

        m_currentID = id;

        m_charaImage.sprite = masterData.Image;

        m_nameText.text = masterData.Name;

        //m_charaTypeText.text = masterData.CharaType.ToString();

        //m_levelText.text = data.Level.ToString();

        m_valueText.text = masterData.Value.ToString();


        switch(masterData.RarityType)
        {
            case Enum_RarityType.C:
                m_rarityImage.sprite = m_common;
                break;
            case Enum_RarityType.U:
                m_rarityImage.sprite = m_uncommon;

                break;
            case Enum_RarityType.R:
                m_rarityImage.sprite = m_rare;

                break;
            default:
                m_rarityImage.sprite = m_common;

                break;
        }

        switch (type)
        {
            case Enum_CharaUIShow.ToMain:
                //OnViewLevelUpUI(true);

                break;
            case Enum_CharaUIShow.ToMember:
                //OnViewLevelUpUI(true);
                //OnViewArrowUI(true);
                break;
            case Enum_CharaUIShow.ToChara:
                break;
        }
    }

    private void OnViewLevelUpUI(bool value)
    {
        //m_levelUpButton.SetActive(value);   
    }

    private void OnViewArrowUI(bool value)
    {
        //m_Arrow.SetActive(value);
    }

    private void PlaySE()
    {
        m_SEEvent.Raise(m_peta);
    }

    public void OnLevelUp()
    {

    }

    public void OnLeftArrow()
    {

    }

    public void OnRightArrow()
    {

    }

    public void OnBackButton()
    {
        PlaySE();

        m_CharaUI.SetActive(false);
    }
}
