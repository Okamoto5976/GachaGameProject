using System.Security;
using UnityEngine;



public class TestCharacterData : MonoBehaviour
{
    [SerializeField] private int m_id;
    [SerializeField] private string m_name;
    [SerializeField] private TestType m_type;
    [SerializeField] private TestRarity m_rarity;
    [SerializeField] private int m_value;
    [SerializeField] private Texture2D m_image;

    private int m_level;

    public void SetData(CharaStateData data)
    {
        m_id = data.ID;
        m_name = data.Name;
        m_type = data.Type;
        m_rarity = data.Rarity;
        m_value = data.Value;
        m_image = data.Image;

        m_level = data.Level;
    }
}
