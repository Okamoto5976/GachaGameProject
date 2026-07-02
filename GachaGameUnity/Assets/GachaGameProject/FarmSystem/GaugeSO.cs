using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GaugeSO", menuName = "Scriptable Objects/GaugeSO")]
public class GaugeSO : ScriptableObject
{
    [Header("Setting")]
    [SerializeField] private int m_gaugeFrameLength = 120;
    [SerializeField] private int m_gaugeMaxLength = 116;
    [SerializeField] private int m_margin = 2;  // Frame border thickness.((m_gaugeFameLength - m_gaugeMaxLength) / 2)

    [Header("Object")]
    [SerializeField] private GameObject m_gaugeBackgroundImage;
    [SerializeField] private GameObject m_gaugeImage;
    [SerializeField] private int m_gaugeDistance;

    public int GaugeFrameLength { get => m_gaugeFrameLength; }
    public int GaugeMaxLength { get => m_gaugeMaxLength; }
    public int Margin { get => m_margin; }
    public GameObject GaugeBackgroundImage { get => m_gaugeBackgroundImage; }
    public GameObject GaugeImage { get => m_gaugeImage; }
    public int GaugeDistance { get => m_gaugeDistance; }
}
