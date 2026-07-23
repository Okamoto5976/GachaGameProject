using UnityEngine;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;

[System.Serializable]
public class CharaWork
{
    [NonSerialized] public int ID;
    public int Value;
}

[System.Serializable]
public class Modifier
{
    public List<CharaWork> m_charaWorkers;

    public Modifier()
    {
        m_charaWorkers = new();
    }
}


public class FarmManager : MonoBehaviour
{
    public int FPS { get => 60; }

    private int m_money;
    [SerializeField] private Modifier m_modifier = new();
    [SerializeField] private FieldWork m_fieldWork;

    [Header("Setting")]
    [SerializeField] private int m_mPW;   // Money Per completed Work;
    [SerializeField] private int m_maxProgress;

    [Header("State")]
    [SerializeField] private int m_progress;
    //[SerializeField] private float m_fMoney; // Maintained while FarmManager is active

    public int Progress => m_progress;
    public int MaxProgress => m_maxProgress;

    [Header("Audio")]
    [SerializeField] private AudioEventSO m_SEEvent;
    [SerializeField] private AudioData m_moneySE;

    private void PlaySE()
    {
        m_SEEvent.Raise(m_moneySE);
    }

    private void Awake()
    {
        
    }


    public void OnClick()
    {
        PlaySE();

        int completeCount;  // Number of times the gauge reached its maximum
        CalculateProgress(m_modifier, out completeCount);

        m_money = CharacterManager.Instance.Money;
        //Debug.Log($"completeCount: {completeCount}");
        m_money += m_mPW * completeCount;

        CharacterManager.Instance.SetMoney(m_money);


        m_fieldWork.UpdateState();


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
     //out int completeCount
    private void CalculateProgress(Modifier modifier, out int completeCount)
    {


        int sum = 0;
        for (int i = 0; i < modifier.m_charaWorkers.Count; i++)
        {
            //if (charaWorks[i].Owned == false) continue;
            sum += modifier.m_charaWorkers[i].Value;
        }

        AddProgress(sum, out completeCount);
    }


     //out int completeCount
    public void AddProgress(int value, out int completeCount)
    {
        Debug.Log($"{value}");

        int _progress = m_progress + value;
        completeCount = _progress / m_maxProgress;

        m_progress = _progress % m_maxProgress;
    }

    public void SetCharacter(List<int> list)
    {

        Modifier modifier = new();

        for(int i = 0; i < list.Count; i++)
        {
            if (list[i] == 0) continue;


            MasterCharacterData data = CharacterManager.Instance.GetMasterCharaData(list[i]);

            if (data == null)
            {
                Debug.LogError($"MasterData‚ª‚ ‚è‚Ü‚¹‚ñ ID:{list[i]}");
                continue;
            }


            CharaWork charaWork = new CharaWork
            {
                ID = data.ID,
                Value = data.Value,
            };

            modifier.m_charaWorkers.Add(charaWork);
        }

        m_modifier = modifier;
    }
}
