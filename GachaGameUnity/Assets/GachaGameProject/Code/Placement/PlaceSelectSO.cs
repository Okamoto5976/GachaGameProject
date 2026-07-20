using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlaceSelectSO", menuName = "Scriptable Objects/PlaceSelectSO")]
public class PlaceSelectSO : ScriptableObject
{

    [SerializeField] private int m_nowID;

    public int NowID => m_nowID;

    public void GetID(int value)
    {
        m_nowID = value;
    }

    public void Reset()
    {
        m_nowID = 0;
    }
}
