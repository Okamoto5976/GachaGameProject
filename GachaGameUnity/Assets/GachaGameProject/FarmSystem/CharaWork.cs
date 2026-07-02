using UnityEngine;

public class CharaWork : MonoBehaviour
{
    private const int FPS = 60;

    [SerializeField] private CharaData m_charaData;
    [SerializeField] private MainDataSO m_mainData;

    [SerializeField] private int m_frame;
    [SerializeField] private int m_workTimer;

    [Header("Debug")]
    [SerializeField] private int m_money;

    private void Awake()
    {
        Application.targetFrameRate = FPS;
    }

    void Update()
    {
        Timer();
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
}
