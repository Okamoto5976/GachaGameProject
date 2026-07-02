using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private MainDataSO m_mainData;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = m_mainData.Money.ToString();
    }
}
