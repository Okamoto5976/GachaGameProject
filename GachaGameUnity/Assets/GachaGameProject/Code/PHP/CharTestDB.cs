using UnityEngine;

[CreateAssetMenu(fileName = "CharTestDB", menuName = "Scriptable Objects/CharTestDB")]
public class CharTestDB : ScriptableObject
{
    public int id;
    public string m_name;
    public TestType type;
    public TestRarity rarity;
    public int value;
    public int image;
}

public enum TestType
{
    Grass,
    Onsen
}

public enum TestRarity
{
    C
}
