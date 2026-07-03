using UnityEngine;
using System.Collections.Generic;

public class FarmManager : MonoBehaviour
{
    public int FPS { get => 60; }

    //[SerializeField] private CharaData m_charaData;
    [SerializeField] private CharactersParamSO m_charactersParam;
    [SerializeField] private MainDataSO m_mainData;
    [SerializeField] private Canvas m_canvas;
    [SerializeField] private GameObject m_charaPrefab;
    public Canvas Canvas => m_canvas;

    [Header("State")]
    [SerializeField] private int m_frame;

    [SerializeField] private List<GameObject> m_charaObjs = new();
    [SerializeField] private List<CharaWork> m_charaWorks = new();

    private void Awake()
    {
        m_canvas = Instantiate(m_canvas);
        for (int i = 0; i < m_charactersParam.CharaDataList.Count; i++)
        {
            Debug.Log($"[FM] i: {i}");
            m_charaObjs.Add(Instantiate(m_charaPrefab));
            m_charaWorks.Add(m_charaObjs[i].GetComponent<CharaWork>());
            //m_charaWorks[i].SetCharaData(m_charactersParam.CharaDataList[i]);
            m_charaWorks[i].CharaIndex = i;
            m_charaObjs[i].transform.SetParent(m_canvas.transform, false);
        }
    }

    private void Update()
    {
        for (int i = 0; i < m_charactersParam.CharaDataList.Count; i++)
        {
            Timer(m_charactersParam.CharaDataList[i]);
        }
    }


    private void Timer(CharaData charaData)
    {
        if (m_frame < FPS)
        {
            m_frame++;
        }
        else
        {
            m_frame = 0;
            charaData.WorkTimer++;
        }

        if (charaData.WorkTimer >= charaData.SPW)
        {
            charaData.WorkTimer = 0;
            m_mainData.Money += charaData.MPW;
        }
    }
}
