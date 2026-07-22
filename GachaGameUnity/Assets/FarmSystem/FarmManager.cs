using UnityEngine;
using System.Collections.Generic;
using System;

[System.Serializable]
public class CharaWork
{
    [NonSerialized] public int ID;
    public int Value;
}

[System.Serializable]
public class Modifier
{
    public List<CharaData> m_charaWorkers;
}


public class FarmManager : MonoBehaviour
{
    public int FPS { get => 60; }

    [SerializeField] private MainDataSO m_mainData;
    //[SerializeField] private CharacterParamSO m_characterParam;
    //[SerializeField] private GaugeSO m_gauge;
    [SerializeField] private Modifier m_modifier;
    //[SerializeField] private Canvas m_canvas;

    [Header("State")]
    //[SerializeField] private int m_frame;
    [SerializeField] private int m_checkMoney;
    //[SerializeField] private float m_fMoney; // Maintained while FarmManager is active
    //[SerializeField] private int m_saving;  // Uncollected money.

    //[Header("Debug")]
    //[SerializeField] private List<CharaData> m_charaDataList = new();
    //private List<CharaWork> m_charaWorkList = new();

    private void Awake()
    {
        //m_fMoney = 0;
        //m_saving = 0;
        for (int i = 0; i < m_modifier.m_charaWorkers.Count; i++)
        {
            m_modifier.m_charaWorkers[i].CharaWork.ID = i;
            m_modifier.m_charaWorkers[i].FieldWork.SetCharaData(m_modifier.m_charaWorkers[i]);
        }
    }

    private void Update()
    {
        //Timer();
    }

    public void OnClick()
    {
        for (int i = 0; i < m_modifier.m_charaWorkers.Count; i++)
        {
            if (m_modifier.m_charaWorkers[i].Owned == false) continue;

            int _conpleteCount;
            CalculateProgress(m_modifier.m_charaWorkers[i], out _conpleteCount);
            m_mainData.Money += m_modifier.m_charaWorkers[i].CharaWork.Value * _conpleteCount;

            m_modifier.m_charaWorkers[i].FieldWork.UpdateState();
        }
        m_checkMoney = m_mainData.Money;
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
    private void CalculateProgress(CharaData _charaData, out int _completeCount)
    {
        _charaData.AddProgress(_charaData.WPC, out _completeCount);

        //_charaData.SetProgress(_progress % 1.0f);
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
