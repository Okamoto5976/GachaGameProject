using UnityEngine;

[System.Serializable]
public class CharaData
{
    [SerializeField] private CharaWork m_charaWork;
    [SerializeField] private FieldWork m_fieldWork;

    [Header("State")]
    [SerializeField] private bool m_owned;
    [SerializeField] private float m_wPC;   // work per click
    [Range(0, 1)]
    [SerializeField] private float m_progress;

    public CharaWork CharaWork => m_charaWork;
    public FieldWork FieldWork => m_fieldWork;
    //public Sprite Sprite => m_sprite;
    public bool Owned => m_owned;
    public float WPC => m_wPC;
    public float Progress => m_progress;

    public void SetOwned(bool value)
    {
        m_owned = value;
    }

    public void SetProgress(float value)
    {
        m_progress = value;
    }

    public void AddProgress(float value, out int completeCount)
    {
        float _progress = m_progress + value;
        completeCount = (int)Mathf.Floor(_progress);    // Mathf.Floor is unnecessary
        m_progress = _progress % 1.0f;
    }
}
