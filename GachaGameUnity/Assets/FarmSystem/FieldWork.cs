using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FieldWork : MonoBehaviour
{
    [SerializeField] private FarmManager m_farmManager;
    //[SerializeField] private GaugeSO m_gauge;

    [Header("GaugeObject")]
    [SerializeField] private RectTransform m_gaugeBackgroundImage;
    [SerializeField] private RectTransform m_gaugeImage;
    [SerializeField] private TextMeshProUGUI m_gaugeRateText;
    //[SerializeField] private TextMeshProUGUI m_stateText;

    private float m_gaugeLength;

    private float m_gaugeFrameLength;
    private float m_gaugeMaxLength;
    private float m_margin;


    //キャラレベル
    //キャラデータのデータ
    //


    private void Awake()
    {
        Application.targetFrameRate = m_farmManager.FPS;
    }

    //First, set up the CharaWork's m_canvas in FarmManager.
    private void Start()
    {
        InitializeGaugeSize();
        GaugeRender();
        StateRender();
    }

    public void UpdateState()
    {
        GaugeRender();
        StateRender();
    }


    // Reflect the progress in the gauge.
    private void GaugeRender()
    {
        m_gaugeLength = (float)m_farmManager.Progress / m_farmManager.MaxProgress;
        float _leftAlignetX = -m_gaugeFrameLength * 0.5f + m_margin + m_gaugeLength * m_gaugeMaxLength * 0.5f;

        m_gaugeImage.localScale = new Vector2(m_gaugeLength, m_gaugeImage.localScale.y);
        m_gaugeImage.localPosition = new Vector2(_leftAlignetX, m_gaugeImage.localPosition.y);
    }

    // Display character information above the gauge.
    private void StateRender()
    {
        m_gaugeRateText.text = Mathf.Floor(m_gaugeLength * 100).ToString() + " / 100";
        //m_stateText.text = "Lv." + m_charaData.Level.ToString() + "    MPS " + m_charaData.MPS.ToString() + "/s";
        //m_stateText.text = "Value " + m_charaData.CharaWork.Value.ToString();
    }

    private void InitializeGaugeSize()
    {
        m_gaugeFrameLength = m_gaugeBackgroundImage.rect.size.x;
        m_gaugeMaxLength = m_gaugeImage.rect.size.x;
        if (m_gaugeFrameLength > m_gaugeMaxLength)
        {
            Debug.LogWarning("'m_gaugeFrameLength' must be greater than the value of 'm_gaugeMaxLength'.");
        }
        m_margin = (m_gaugeFrameLength - m_gaugeMaxLength) / 2;
    }

    //public void SetLocalPosition(Vector2 _position)
    //{
    //    this.transform.localPosition = _position;
    //}
}
