using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharaWork : MonoBehaviour
{
    [SerializeField] private CharactersParamSO m_charactersParam;
    [SerializeField] private MainDataSO m_mainData;
    [SerializeField] private FarmManager m_farmManager;
    [SerializeField] private GaugeSO m_gauge;

    private CharaData m_charaData;

    private GameObject m_gaugeBackgroundImage;
    private GameObject m_gaugeImage;
    private TextMeshProUGUI m_gaugeRateText;
    private TextMeshProUGUI m_stateText;
    [SerializeField] private Vector2 m_gaugeLocalPos;
    [SerializeField] private float m_progress;

    private void Awake()
    {
        Application.targetFrameRate = m_farmManager.FPS;
    }

    // First, set up the CharaWork's m_canvas in FarmManager.
    private void Start()
    {
        this.GetComponent<Image>().sprite = m_charaData.Sprite;
        InstantiateGauge();
        this.m_charaData.SetMPS();
        this.m_charaData.SetProgress(0);
        SetGaugePosition();
    }

    void Update()
    {
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
        m_gaugeBackgroundImage.transform.SetParent(this.transform, false);
        m_gaugeImage.transform.SetParent(this.transform, false);

        m_gaugeRateText.transform.SetParent(this.transform, false);
        m_stateText.transform.SetParent(this.transform, false);

        SetGaugePosition();
    }

    // Set the gauge position at the character's local position.
    private void SetGaugePosition()
    {
        // Gauge
        m_gaugeLocalPos = new Vector2(0.0f, m_gauge.GaugePosUp);

        m_gaugeBackgroundImage.transform.localPosition = m_gaugeLocalPos;
        m_gaugeImage.transform.localPosition = m_gaugeLocalPos;

        // Text
        m_gaugeRateText.transform.localPosition = m_gaugeLocalPos + m_gauge.GaugeRateTextPos;
        m_stateText.transform.localPosition = m_gaugeLocalPos + m_gauge.StateTextPos;
    }

    // Reflect the progress in the gauge.
    private void GaugeRender()
    {
        float _leftAlignetX = - m_gauge.GaugeFrameLength * 0.5f + m_gauge.Margin + m_progress * m_gauge.GaugeMaxLength * 0.5f;

        m_gaugeImage.transform.localScale = new Vector2(m_progress, m_gaugeImage.transform.localScale.y);
        m_gaugeImage.transform.localPosition = new Vector2(_leftAlignetX, m_gaugeLocalPos.y);
    }

    // Display character information above the gauge.
    private void StateRender()
    {
        m_gaugeRateText.text = Mathf.Floor(m_progress * 100).ToString() + " / 100";
        m_stateText.text = "Lv." + m_charaData.Level.ToString() + "    MPS " + m_charaData.MPS.ToString() + "/s";
    }

    public void SetCharaData(CharaData charaData)
    {
        m_charaData = charaData;
    }

    public void SetProgress(float value)
    {
        m_progress = value;
    }
}
