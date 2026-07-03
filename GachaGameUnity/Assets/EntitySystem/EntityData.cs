using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "Scriptable Objects/EntityData")]
public class EntityData : ScriptableObject
{
    [SerializeField] private int m_id;
    [SerializeField] private string m_name;
    [SerializeField] private int m_Value;
    [SerializeField] private int m_Type;
    [SerializeField] private int m_Rarity;
    [SerializeField] private Sprite m_sprite;
    public int Id => m_id;
    public string Name => m_name;
    public int Value => m_Value;
    public int Type => m_Type;
    public int Rarity => m_Rarity;
    public Sprite Sprite => m_sprite;
}
