using UnityEngine;
using System.Collections.Generic;
using System;

[System.Serializable]
public class CharaWork
{
    [NonSerialized] public int ID;
    public float Value;
    public bool Owned;
}

[System.Serializable]
public class Modifier
{
    public List<CharaWork> m_charaWorkers;
}


public class FarmManager : MonoBehaviour
{
    public int FPS { get => 60; }

    [SerializeField] private MainDataSO m_mainData;
    [SerializeField] private Modifier m_modifier;
    [SerializeField] private FieldWork m_fieldWork;

    [Header("Setting")]
    [SerializeField] private int m_mPW;   // Money Per completed Work;

    [Header("State")]
    [SerializeField] private float m_progress;
    [SerializeField] private int m_checkMoney;
    //[SerializeField] private float m_fMoney; // Maintained while FarmManager is active
    //[SerializeField] private int m_saving;  // Uncollected money.

    public float Progress => m_progress;

    private void Awake()
    {
        //m_fMoney = 0;
        //m_saving = 0;
        for (int i = 0; i < m_modifier.m_charaWorkers.Count; i++)
        {
            m_modifier.m_charaWorkers[i].ID = i;
            //m_modifier.m_charaWorkers[i].FieldWork.SetCharaData(m_modifier.m_charaWorkers[i]);
        }
    }


    public void OnClick()
    {

        int conpleteCount;
        CalculateProgress(m_modifier.m_charaWorkers, out conpleteCount);

        m_mainData.Money += m_mPW * conpleteCount;

        m_fieldWork.UpdateState();
        m_checkMoney = m_mainData.Money;    // for check
    }

    // return true per UpdateIntervalFrame frame.
    //private bool Timer()
    //{
    //    if (m_frame < m_gauge.UpdateIntervalFrame)
    //    {
    //        m_frame++;
    //        return false;
    //    }
    //    else
    //    {
    //        m_frame = 0;
    //        WorkResults();
    //        return true;
    //    }
    //}

    //private void WorkResults()
    //{
    //    CharaData _charaData;
    //    for (int i = 0; i < m_characterParam.CharaDataList.Count; i++)
    //    {
    //        _charaData = m_characterParam.CharaDataList[i];
    //        if (_charaData.Owned == false) continue;

    //        _charaData.UpdateWPS();
    //        int _completeCount;

    //        _charaData.SetProgress(CalculateProgress(_charaData, out _completeCount));

    //        if (_completeCount != 0)
    //        { 
    //            m_fMoney += _charaData.MPW * _completeCount;
    //        }
    //    }
    //    int _increase = (int)m_fMoney;  // (int)Mathf.Floor(m_fMoney)
    //    m_saving += _increase;
    //    if (_increase != 0)
    //    {
    //        m_fMoney %= _increase;
    //    }
    //}

    // Calculate the progress of the work.
    private void CalculateProgress(List<CharaWork> charaWorks, out int completeCount)
    {
        float sum = 0;
        for (int i = 0; i < charaWorks.Count; i++)
        {
            if (charaWorks[i].Owned == false) continue;
            sum += charaWorks[i].Value;
        }

        AddProgress(sum, out completeCount);
    }

    // Use this only when objects have already been placed in the scene.
    //public void SetCharacter(int id)
    //{
    //    GameObject obj = Instantiate(m_characterParam.CharaPrefab);

    //    CharaWork charaWork = obj.GetComponent<CharaWork>();
    //    //charaWork.SetCanvas(m_canvas);
    //    //m_charaWorkList.Add(charaWork);

    //    charaWork.SetCharaData(m_characterParam.CharaDataList[id]);
    //    m_characterParam.CharaDataList[id].SetLevel(1);   // initialize

    //}

    public void AddProgress(float value, out int completeCount)
    {
        float _progress = m_progress + value;
        completeCount = (int)Mathf.Floor(_progress);    // Mathf.Floor is unnecessary
        
        m_progress = _progress % 1.0f;
        m_progress = Mathf.Floor(m_progress * 10000) / 10000;   // Eliminate errors in decimal calculations.
    }

    public void AddCharacter(int id)
    {

    }

    public void RemoveCharacter(int id)
    {

    }


    // Press button to call.
    //public void CollectedMoney()
    //{
    //    m_mainData.Money += m_saving;
    //    m_saving = 0;
    //}
}
