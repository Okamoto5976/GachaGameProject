using UnityEngine;
using System.Collections.Generic;

public class FarmManager : MonoBehaviour
{
    public int FPS { get => 60; }

    [SerializeField] private CharactersParamSO m_charactersParam;
    [SerializeField] private MainDataSO m_mainData;
    [SerializeField] private GaugeSO m_gauge;
    [SerializeField] private Canvas m_canvas;
    [SerializeField] private List<GameObject> m_charaObjs;
    public Canvas Canvas => m_canvas;

    [Header("State")]
    [SerializeField] private int m_frame;
    [SerializeField] private float m_fMoney; // Maintained while FarmManager is active
    [SerializeField] private int m_saving;  // Uncollected money.

    private List<CharaWork> m_charaWorks = new();

    private void Awake()
    {
        m_fMoney = 0;
        m_saving = 0;

        for (int i = 0; i < m_charactersParam.CharaDataList.Count; i++)
        {
            SetParam(m_charaObjs[i]);
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
            if (_charaData.Owned == false) continue;

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
        m_saving += _increase;
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

    // Use this only when objects have already been placed in the scene.
    private void SetParam(GameObject _charaObj)
    {
        m_charaWorks.Add(_charaObj.GetComponent<CharaWork>());
        int index = m_charaWorks.Count - 1;
        m_charaWorks[index].SetCharaData(m_charactersParam.CharaDataList[index]);
        if (m_charactersParam.CharaDataList[index].MPW == 0)
        {
            m_charactersParam.CharaDataList[index].SetMPW(1);   // initialize
        }
    }

    // Press button to call.
    public void CollectedMoney()
    {
        m_mainData.Money += m_saving;
        m_saving = 0;
    }

    /*
    private void AddCharacter(GameObject _charaObj)
    {
        m_charaObjs.Add(_charaObj);
        m_charaWorks.Add(_charaObj.GetComponent<CharaWork>());
        int index = m_charaWorks.Count - 1;
        m_charaWorks[index].SetCharaData(m_charactersParam.CharaDataList[index]);
        m_charaObjs[index].transform.SetParent(m_canvas.transform, false);
        if (m_charactersParam.CharaDataList[index].MPW == 0)
        {
            m_charactersParam.CharaDataList[index].SetMPW(1);   // initialize
        }
    }
    */
}
