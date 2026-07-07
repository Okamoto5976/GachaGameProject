using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework.Constraints;

public class FarmManager : MonoBehaviour
{
    public int FPS { get => 60; }

    //[SerializeField] private CharaData m_charaData;
    [SerializeField] private CharactersParamSO m_charactersParam;
    [SerializeField] private MainDataSO m_mainData;
    [SerializeField] private GaugeSO m_gauge;
    [SerializeField] private Canvas m_canvas;
    [SerializeField] private GameObject m_charaPrefab;
    public Canvas Canvas => m_canvas;

    [Header("State")]
    [SerializeField] private int m_frame;
    [SerializeField] private float m_fMoney; // Maintained while FarmManager is active

    [SerializeField] private List<GameObject> m_charaObjs = new();
    [SerializeField] private List<CharaWork> m_charaWorks = new();
    //[SerializeField] private List<float> m_progressList = new();

    private void Awake()
    {
        m_canvas = Instantiate(m_canvas);
        m_fMoney = 0;
        for (int i = 0; i < m_charactersParam.CharaDataList.Count; i++)
        {
            m_charaObjs.Add(Instantiate(m_charaPrefab));
            m_charaWorks.Add(m_charaObjs[i].GetComponent<CharaWork>());
            m_charaWorks[i].SetCharaData(m_charactersParam.CharaDataList[i]);
            m_charaWorks[i].SetCanvas(m_canvas);
            m_charaObjs[i].transform.SetParent(m_canvas.transform, false);
            if (m_charactersParam.CharaDataList[i].MPW == 0)
            {
                m_charactersParam.CharaDataList[i].SetMPW(1);   // initialize
            }
        }
    }

    private void Update()
    {
        Timer();
    }

    // return true per UpdateIntervalFrame frame.
    private bool Timer()
    {
        if (m_frame < m_gauge.UpdateIntervalFrame)
        {
            m_frame++;
            return false;
        }
        else
        {
            m_frame = 0;
            WorkResults();
            return true;
        }
    }

    private void WorkResults()
    {
        CharaData _charaData;
        for (int i = 0; i < m_charactersParam.CharaDataList.Count; i++)
        {
            _charaData = m_charactersParam.CharaDataList[i];
            _charaData.UpdateWPS();
            int _completeCount;

            _charaData.SetProgress(CalculateProgress(_charaData, out _completeCount));
            m_charaWorks[i].SetProgress(_charaData.Progress);

            if (_completeCount != 0)
            { 
                m_fMoney += _charaData.MPW * _completeCount;
            }
        }
        int _increase = (int)m_fMoney;  // (int)Mathf.Floor(m_fMoney)
        m_mainData.Money += _increase;
        if (_increase != 0)
        {
            m_fMoney %= _increase;
        }
    }

    // Calculate the progress of the work.
    private float CalculateProgress(CharaData _charaData, out int _completeCount)
    {
        _charaData.AddProgress(_charaData.MPS / _charaData.MPW * ((float)m_gauge.UpdateIntervalFrame / FPS));
        _completeCount = (int)_charaData.Progress;

        _charaData.SetProgress(_charaData.Progress % 1.0f);
        return _charaData.Progress % 1.0f;
    }
}
