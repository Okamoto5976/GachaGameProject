using UnityEngine;

public class CharaData : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] private int m_rarity;
    [SerializeField] private string m_name;

    [Header("Default state")]
    [SerializeField] private int m_maxLevel;
    [SerializeField] private int m_defaultMPW;
    [SerializeField] private int m_defaultSPW;

    [Header("State")]
    [SerializeField] private int m_level;
    [SerializeField] private int m_mPW; // money per work
    [SerializeField] private int m_sPW; // second per work

    internal int Level => m_level;
    internal int MPW => m_mPW;
    internal int SPW => m_sPW;

    private void Awake()
    {
        m_level = 1;
        m_mPW = m_defaultMPW;
        m_sPW = m_defaultSPW;
    }
}
