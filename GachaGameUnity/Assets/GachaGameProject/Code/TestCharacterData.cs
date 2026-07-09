using System.Security;
using UnityEngine;

public enum TestType
{
    Grass,
    Onsen
}

public enum TestRarity
{
    C
}

public class CharaStateData
{
    public int ID;
    public string Name;
    public TestType Type;
    public TestRarity Rarity;
    public int Value;
    public Texture2D Image;

    public int Level;
}

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
