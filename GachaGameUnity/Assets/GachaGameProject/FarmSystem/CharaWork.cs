using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CharaWork : MonoBehaviour
{
    [SerializeField] private CharactersParamSO m_charactersParam;
    [SerializeField] private MainDataSO m_mainData;
    [SerializeField] private FarmManager m_farmManager;
    [SerializeField] private GaugeSO m_gauge;
    [SerializeField] private Canvas m_canvas;

    private CharaData m_charaData;

    private GameObject m_gaugeBackgroundImage;
    private GameObject m_gaugeImage;
    private TextMeshProUGUI m_gaugeRateText;
    private TextMeshProUGUI m_stateText;
    private Vector2 m_gaugeLocalPos;

    private void Awake()
    {
        Application.targetFrameRate = m_farmManager.FPS;
    }

    // First, set up the CharaWork's m_canvas in FarmManager.
    private void Start()
    {
        GetComponent<Image>().sprite = m_charaData.Sprite;
        InstantiateGauge();
        this.m_charaData.InitializeState();
    }

    void Update()
    {
        SetGaugePosition();
        GaugeRender();
        StateRender();
    }


    private void InstantiateGauge()
    {
        // Instantiate
        m_gaugeBackgroundImage = Instantiate(m_gauge.GaugeBackgroundImage, transform.position, Quaternion.identity);
        m_gaugeImage = Instantiate(m_gauge.GaugeImage, transform.position, Quaternion.identity);

        m_gaugeRateText = Instantiate(m_gauge.GaugeRateText, transform.position, Quaternion.identity);
        m_stateText = Instantiate(m_gauge.StateText, transform.position, Quaternion.identity);
        
        // SetParent
        m_gaugeBackgroundImage.transform.SetParent(m_canvas.transform, false);
        m_gaugeImage.transform.SetParent(m_canvas.transform, false);

        m_gaugeRateText.transform.SetParent(m_canvas.transform, false);
        m_stateText.transform.SetParent(m_canvas.transform, false);

        SetGaugePosition();
    }

    // Set the gauge position at the character's local position.
    private void SetGaugePosition()
    {
        // Gauge
        m_gaugeLocalPos = new Vector2(transform.position.x, 
                                      transform.position.y + m_gauge.GaugeDistance);

        m_gaugeBackgroundImage.transform.position = m_gaugeLocalPos;
        m_gaugeImage.transform.position = m_gaugeLocalPos;

        // Text
        m_gaugeRateText.transform.position = m_gaugeLocalPos + m_gauge.GaugeRateTextPos;
        m_stateText.transform.position = m_gaugeLocalPos + m_gauge.StateTextPos;
    }

    // Calculate the progress of the work.
    private float Progress()
    {
        return (float)m_charaData.WorkTimer / m_charaData.SPW;
    }

    // Reflect the progress in the gauge.
    private void GaugeRender()
    {
        float _progress = Progress();
        float _leftAlignetX = - m_gauge.GaugeFrameLength * 0.5f + m_gauge.Margin + _progress * 0.5f * m_gauge.GaugeMaxLength;

        m_gaugeImage.transform.localScale = new Vector2(_progress, m_gaugeImage.transform.localScale.y);
        m_gaugeImage.transform.position = new Vector2(m_gaugeLocalPos.x + _leftAlignetX,
                                                      m_gaugeLocalPos.y);
    }

    // Display character information above the gauge.
    private void StateRender()
    {
        m_charaData.UpdateMPS();
        m_gaugeRateText.text = (Progress()*100).ToString() + " / 100";
        m_stateText.text = "Lv." + m_charaData.Level.ToString() + "    MPS " + m_charaData.MPS.ToString() + "/s";
    }

    public void SetCharaData(CharaData charaData)
    {
        m_charaData = charaData;
    }

    public void SetCanvas(Canvas canvas)
    {
        m_canvas = canvas;
    }
}
