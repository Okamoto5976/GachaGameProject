using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FieldWork : MonoBehaviour
{
    [SerializeField] private FarmManager m_farmManager;
    [SerializeField] private GaugeSO m_gauge;

    [Header("GaugeObject")]
    [SerializeField] private GameObject m_gaugeBackgroundImage;
    [SerializeField] private GameObject m_gaugeImage;
    [SerializeField] private TextMeshProUGUI m_gaugeRateText;
    [SerializeField] private TextMeshProUGUI m_stateText;

    //private Canvas m_canvas;
    private CharaData m_charaData;

    public CharaData CharaData => m_charaData;

    private float m_progress;


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
        //GetComponent<Image>().sprite = m_charaData.Sprite;
        //gameObject.transform.SetParent(m_canvas.transform, false);
    }

    void Update()
    {
        
    }

    public void UpdateState()
    {
        GaugeRender();
        StateRender();
        m_progress = m_charaData.Progress;
    }

    // Reflect the progress in the gauge.
    private void GaugeRender()
    {
        float _leftAlignetX = -m_gauge.GaugeFrameLength * 0.5f + m_gauge.LeftMargin + m_progress * m_gauge.GaugeMaxLength * 0.5f;

        m_gaugeImage.transform.localScale = new Vector2(m_progress, m_gaugeImage.transform.localScale.y);
        m_gaugeImage.transform.localPosition = new Vector2(_leftAlignetX, m_gaugeImage.transform.localPosition.y);
    }

    // Display character information above the gauge.
    private void StateRender()
    {
        m_gaugeRateText.text = Mathf.Floor(m_progress * 100).ToString() + " / 100";
        //m_stateText.text = "Lv." + m_charaData.Level.ToString() + "    MPS " + m_charaData.MPS.ToString() + "/s";
        m_stateText.text = "Value " + m_charaData.CharaWork.Value.ToString();
    }

    public void SetCharaData(CharaData _charaData)
    {
        m_charaData = _charaData;
    }

    public void Test(int num)
    {
        Debug.Log("Test" + num.ToString());
    }

    public void SetLocalPosition(Vector2 _position)
    {
        this.transform.localPosition = _position;
    }

    //public void SetCanvas(Canvas canvas)
    //{
    //    m_canvas = canvas;
    //}
}
