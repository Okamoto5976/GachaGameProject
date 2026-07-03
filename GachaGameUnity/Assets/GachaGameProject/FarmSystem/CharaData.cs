using UnityEngine;

[System.Serializable]
public class CharaData
{
    [Header("Base")]
    [SerializeField] private int m_rarity;
    [SerializeField] private string m_name;
    [SerializeField] private Sprite m_sprite;

    [Header("Default state")]
    [SerializeField] private int m_maxLevel;
    [SerializeField] private int m_defaultMPW;
    [SerializeField] private int m_defaultSPW;

    [Header("State")]
    [SerializeField] private int m_level = 1;
    [SerializeField] private int m_mPW; // money per work
    [SerializeField] private int m_sPW; // second per work
    [SerializeField] private float m_mPS; // money per second

    public int WorkTimer;

    public Sprite Sprite => m_sprite;
    public int Level => m_level;
    public int MPW => m_mPW;
    public int SPW => m_sPW;
    public float MPS => m_mPS;

    public void UpdateMPS()
    {
        m_mPS = (float)m_mPW / m_sPW;
    }

    public int GetDefaultMPW()
    {
        return m_defaultMPW;
    }

    public int GetDefaultSPW()
    {
        return m_defaultSPW;
    }

    public void InitializeState()
    {
        Debug.Log("Initialize");
        m_mPW = m_defaultMPW;
        m_sPW = m_defaultSPW;
    }
}
