using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FieldWork : MonoBehaviour
{
    [SerializeField] private FarmManager m_farmManager;
    //[SerializeField] private GaugeSO m_gauge;

    [Header("GaugeObject")]
    //[SerializeField] private RectTransform m_gaugeBackgroundImage;
    [SerializeField] private Image m_gaugeImage;
    [SerializeField] private TextMeshProUGUI m_gaugeRateText;
    //[SerializeField] private TextMeshProUGUI m_stateText;

    private float m_gaugeLength;


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
        m_gaugeImage.fillAmount = m_gaugeLength;

        //m_gaugeImage.localScale = new Vector2(m_gaugeLength, m_gaugeImage.localScale.y);
        //m_gaugeImage.localPosition = new Vector2(_leftAlignetX, m_gaugeImage.localPosition.y);
    }

    // Display character information above the gauge.
    private void StateRender()
    {
        m_gaugeRateText.text = Mathf.Floor(m_gaugeLength * 100).ToString() + " / 100";
        //m_stateText.text = "Lv." + m_charaData.Level.ToString() + "    MPS " + m_charaData.MPS.ToString() + "/s";
        //m_stateText.text = "Value " + m_charaData.CharaWork.Value.ToString();
    }

    //public void SetLocalPosition(Vector2 _position)
    //{
    //    this.transform.localPosition = _position;
    //}
}
