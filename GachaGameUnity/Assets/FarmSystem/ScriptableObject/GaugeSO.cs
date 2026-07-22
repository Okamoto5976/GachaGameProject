using UnityEngine;

[CreateAssetMenu(fileName = "GaugeSO", menuName = "Scriptable Objects/GaugeSO")]
public class GaugeSO : ScriptableObject
{
    [Header("Setting")]
    [SerializeField] private int m_gaugeFrameLength = 120;
    [SerializeField] private int m_gaugeMaxLength = 116;
    [SerializeField] private int m_leftMargin = 2;  // Frame border thickness.((m_gaugeFameLength - m_gaugeMaxLength) / 2)
    //[SerializeField] private int m_updateIntervalFrame = 30;    //Gauge update frequency.

    public int GaugeFrameLength => m_gaugeFrameLength;
    public int GaugeMaxLength => m_gaugeMaxLength;
    public int LeftMargin => m_leftMargin;
    //public int UpdateIntervalFrame => m_updateIntervalFrame;
}
