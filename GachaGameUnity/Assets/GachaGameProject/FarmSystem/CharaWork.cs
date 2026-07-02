using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CharaWork : MonoBehaviour
{
    private const int FPS = 60;

    [SerializeField] private CharaData m_charaData;
    [SerializeField] private MainDataSO m_mainData;
    [SerializeField] private GaugeSO m_gauge;
    [SerializeField] private Canvas m_canvas;

    [SerializeField] private int m_frame;
    [SerializeField] private int m_workTimer;
    public int WorkTimer => m_workTimer; // Debug

    [Header("Debug")]
    [SerializeField] private int m_money;

    private GameObject m_gaugeBackgroundImage;
    private GameObject m_gaugeImage;
    private Vector3 m_gaugeLocalPos;

    private void Awake()
    {
        Application.targetFrameRate = FPS;

        GetComponent<Image>().sprite = m_charaData.Sprite;
        InstantiateGauge();
    }

    void Update()
    {
        Timer();
        SetGaugePosition();
        GaugeRender();
        m_money = m_mainData.Money;
    }

    private void Timer()
    {
        if (m_frame < FPS)
        {
            m_frame++;
        }
        else
        {
            m_frame = 0;
            m_workTimer++;
        }

        if (m_workTimer < m_charaData.SPW)
        {
            // gauge
        }
        else
        {
            m_workTimer = 0;
            m_mainData.Money += m_charaData.MPW;
        }
    }

    private void InstantiateGauge()
    {
        m_gaugeBackgroundImage = Instantiate(m_gauge.GaugeBackgroundImage, transform.position, Quaternion.identity);
        m_gaugeImage = Instantiate(m_gauge.GaugeImage, transform.position, Quaternion.identity);

        m_gaugeBackgroundImage.transform.SetParent(m_canvas.transform, false);
        m_gaugeImage.transform.SetParent(m_canvas.transform, false);

        SetGaugePosition();
    }

    private void SetGaugePosition()
    {
        m_gaugeLocalPos = new Vector3(transform.position.x, 
                                      transform.position.y - m_charaData.Size - m_gauge.GaugeDistance,
                                      transform.position.z);

        m_gaugeBackgroundImage.transform.position = m_gaugeLocalPos;
        m_gaugeImage.transform.position = m_gaugeLocalPos;
    }

    private float Progress()
    {
        return (float)m_workTimer / m_charaData.SPW;
    }

    private void GaugeRender()
    {
        float _progress = Progress();
        float _leftAlignetX = - m_gauge.GaugeFrameLength * 0.5f + m_gauge.Margin + _progress * 0.5f * m_gauge.GaugeMaxLength;

        m_gaugeImage.transform.localScale = new Vector2(_progress, m_gaugeImage.transform.localScale.y);
        m_gaugeImage.transform.position = new Vector3(m_gaugeLocalPos.x + _leftAlignetX,
                                                      m_gaugeLocalPos.y,
                                                      m_gaugeLocalPos.z);
    }
}
