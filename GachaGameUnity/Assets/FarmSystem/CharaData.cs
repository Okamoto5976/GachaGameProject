using UnityEngine;

[System.Serializable]
public class CharaData
{
    //example
    //enum Map
    //{
    //  Pasture,
    //  Volcano
    //}
    [Header("Base")]
    [SerializeField] int m_id;
    //[SerializeField] private Map m_workplace; // It might be used during map transitions.
    //public Map Workplace => m_workplace
    //[SerializeField] private Sprite m_sprite;

    [Header("Default state")]
    [SerializeField] private int m_maxLevel;
    [SerializeField] private float m_defaultMPS;
    [SerializeField] private float m_mPW;   // money per work

    [Header("State")]
    [SerializeField] private bool m_owned;
    [SerializeField] private int m_level = 0;
    [SerializeField] private float m_mPS;   // money per second
    [SerializeField] private float m_wPS;   // work per second
    [SerializeField] private float m_progress;

    public int ID => m_id;
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

    public void SetLevel(int value)
    {
        m_level = value;
        SetMPS();
    }

    public void UpLevel(int value)
    {
        m_level += value;
        if (m_level > m_maxLevel)
        {
            m_level = m_maxLevel;
        }
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

    public void SetProgress(float value)
    {
        m_progress = value;
    }

    public void AddProgress(float value)
    {
        m_progress += value;
    }
}
