using UnityEngine;

[System.Serializable]
public class CharaData
{
    [Header("Base")]
    [SerializeField] private int m_rarity;
    [SerializeField] private string m_name;
    // Use only when generating using a script.
    //[SerializeField] private Sprite m_sprite;

    [Header("Default state")]
    [SerializeField] private int m_maxLevel;
    [SerializeField] private float m_defaultMPS;
    [SerializeField] private float m_mPW;   // money per work

    [Header("State")]
    [SerializeField] private bool m_owned;
    [SerializeField] private int m_level = 1;
    [SerializeField] private float m_mPS;   // money per second
    [SerializeField] private float m_wPS;   // work per second
    [SerializeField] private float m_progress;

    //public Sprite Sprite => m_sprite;
    public float DefaultMPS => m_defaultMPS;
    public bool Owned => m_owned;
    public int Level => m_level;
    public float MPS => m_mPS;
    public float WPS => m_wPS;
    public float MPW => m_mPW;
    public float Progress => m_progress;

    public void SetOwned(bool value)
    {
        m_owned = value;
    }

    public void UpLevel(int value)
    {
        m_level += value;
        SetMPS();
    }

    public void SetMPS()
    {
        m_mPS = DefaultMPS * m_level;
    }

    public void UpdateWPS()
    {
        m_wPS = m_mPW / m_mPS;
    }

    public void SetMPW(int value)
    {
        m_mPW = value;
    }

    public void SetProgress(float value)
    {
        m_progress = value;
    }

    public void AddProgress(float value)
    {
        m_progress += value;
    }
}
