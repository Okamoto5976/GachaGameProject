using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class MainManager : MonoBehaviour
{
    [SerializeField] private List<RandomEntityMove> m_characters = new();

    [SerializeField] private EventSO m_initializeEvent;

    [SerializeField] private FarmManager m_farmManager;


    //セーブデータで設置ずみのものを設置

    private void OnEnable()
    {
        m_initializeEvent.Register(MainInitialize);
    }

    private void OnDisable()
    {
        m_initializeEvent.Unregister(MainInitialize);
    }

    public void MainInitialize()
    {
        SetCharacter();
    }

    public void SetCharacter()
    {
        for (int i = 0; i < m_characters.Count; i++)
        {
            m_characters[i].gameObject.SetActive(false);
        }

        List<int> list = CharacterManager.Instance.MainCharacters;



        for(int i = 0;  i < list.Count; i++)
        {
            if (list[i] == 0) continue;


            MasterCharacterData data = CharacterManager.Instance.GetMasterCharaData(list[i]);

            Debug.Log($"{list[i]}が入ってるmainchara ");
            
            if( data == null )
            {
                Debug.Log("dataが null");
                continue;
            }


            m_characters[i].SetData(data);
            m_characters[i].gameObject.SetActive(true);
        }

        m_farmManager.SetCharacter(list);
    }
}
