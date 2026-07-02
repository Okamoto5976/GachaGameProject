using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharaData : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] private int m_rarity;
    [SerializeField] private string m_name;
    [SerializeField] private Sprite m_sprite;

    [Header("Detail")]
    [SerializeField] private float m_size;  // radius of the sprite size

    [Header("Default state")]
    [SerializeField] private int m_maxLevel;
    [SerializeField] private int m_defaultMPW;
    [SerializeField] private int m_defaultSPW;

    [Header("State")]
    [SerializeField] private int m_level;
    [SerializeField] private int m_mPW; // money per work
    [SerializeField] private int m_sPW; // second per work

    internal Sprite Sprite => m_sprite;
    internal float Size { get => m_size; }
    internal int Level => m_level;
    internal int MPW => m_mPW;
    internal int SPW => m_sPW;

    private void Awake()
    {
        m_level = 1;
        m_mPW = m_defaultMPW;
        m_sPW = m_defaultSPW;

        m_size = m_sprite.bounds.size.y * 0.5f;
    }
}
