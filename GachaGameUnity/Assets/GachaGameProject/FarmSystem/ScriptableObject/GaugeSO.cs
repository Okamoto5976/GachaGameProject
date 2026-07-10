using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "GaugeSO", menuName = "Scriptable Objects/GaugeSO")]
public class GaugeSO : ScriptableObject
{
    [Header("Setting")]
    [SerializeField] private int m_gaugeFrameLength = 120;
    [SerializeField] private int m_gaugeMaxLength = 116;
    [SerializeField] private int m_margin = 2;  // Frame border thickness.((m_gaugeFameLength - m_gaugeMaxLength) / 2)
    [SerializeField] private int m_gaugePosUp;
    [SerializeField] private int m_updateIntervalFrame = 30;    //Gauge update frequency.
    [SerializeField] private Vector2 m_gaugeRateTextPos;
    [SerializeField] private Vector2 m_stateTextPos;

    [Header("Object")]
    [SerializeField] private GameObject m_gaugeBackgroundImage;
    [SerializeField] private GameObject m_gaugeImage;
    [SerializeField] private TextMeshProUGUI m_gaugeRateText;
    [SerializeField] private TextMeshProUGUI m_stateText;

    public int GaugeFrameLength => m_gaugeFrameLength;
    public int GaugeMaxLength => m_gaugeMaxLength;
    public int Margin => m_margin;
    public int UpdateIntervalFrame => m_updateIntervalFrame;
    public Vector2 GaugeRateTextPos => m_gaugeRateTextPos;
    public Vector2 StateTextPos => m_stateTextPos;
    public int GaugePosUp => m_gaugePosUp;
    public GameObject GaugeBackgroundImage => m_gaugeBackgroundImage;
    public GameObject GaugeImage => m_gaugeImage;
    public TextMeshProUGUI GaugeRateText => m_gaugeRateText;
    public TextMeshProUGUI StateText => m_stateText;
}
