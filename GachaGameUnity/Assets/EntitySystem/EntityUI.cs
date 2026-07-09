using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EntityUI : MonoBehaviour
{
    [SerializeField]
    private EntityData m_entityData;

    [SerializeField]
    private Image m_image;

    [SerializeField]
    private TMP_Text m_nameText;

    [SerializeField]
    private TMP_Text m_valueText;

    [SerializeField]
    private TMP_Text m_rarityText;

    void Start()
    {
        if (m_entityData == null)
        {
            Debug.LogError("EntityData‚ªİ’è‚³‚ê‚Ä‚¢‚Ü‚¹‚ñ");
            return;
        }

        //‰æ‘œ•\¦
        m_image.sprite = m_entityData.Sprite;

        //•¶š•\¦
        m_nameText.text = "Name : " + m_entityData.Name;
        m_valueText.text = "Value : " + m_entityData.Value;
        m_rarityText.text = "Rarity : " + m_entityData.Rarity;
    }
}