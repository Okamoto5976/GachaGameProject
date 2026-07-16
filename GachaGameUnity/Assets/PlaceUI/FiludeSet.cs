using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public enum FiludeType
{
    A,
    B,
    C

} 

[System.Serializable]
public class FiludeData
{
    public FiludeType Filude;
    public bool m_LockSituation;

}

public class FiludeSet :MonoBehaviour
{
    [SerializeField] private List<FiludeData> m_LockSituationList = new();
    public int Lock_Situation { get; private set; }
    public int Money;

    public void Start()
    {
        InitializeFiludeData();
    }

    public void Update()
    {
        
        
    }


    public void ChecckLock()
    {

    }

    private void InitializeFiludeData()
    {

        FiludeData data = new FiludeData()
        {
            Filude = FiludeType.A,
            m_LockSituation = false

        };
        m_LockSituationList.Add(data);

        //FiludeData data = new FiludeData()
        //{
        //    Filude = FiludeType.b,
        //    m_LockSituation = false

        //};
        //m_LockSituationList.Add(data);

        //m_LockSituationList.Clear();
    }
    
}
