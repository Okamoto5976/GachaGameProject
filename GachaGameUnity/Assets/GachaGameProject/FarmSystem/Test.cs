using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private MainDataSO m_mainData;
    [SerializeField] private CharaWork m_charaWork;
    private string m_text;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        m_text = "Money: " + m_mainData.Money.ToString() + "\ntimer: " + m_charaWork.WorkTimer;
        this.GetComponent<TextMeshProUGUI>().text = m_text;
    }
}
