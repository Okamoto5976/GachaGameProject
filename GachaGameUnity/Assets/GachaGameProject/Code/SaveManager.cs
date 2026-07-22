using UnityEngine;
using System.Collections;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    [SerializeField] private AccountData m_accountData;

    [SerializeField] private ADBPostSaveFile m_postSaveFile;

    private SaveDataFile m_saveData;

    [SerializeField] private float m_autoSaveInterval = 300f; // 5•ª
    private float m_timer;

    private Coroutine m_autoSaveCoroutine;
    //----------Debug
    [SerializeField] private DebugMode m_debug;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void StartAutoSave()
    {
        if (m_debug.debugMode) return;

        m_autoSaveCoroutine = StartCoroutine(AutoSave());
    }

    public void StopAutoSave()
    {
        if (m_autoSaveCoroutine != null)
        {
            StopCoroutine(m_autoSaveCoroutine);
            m_autoSaveCoroutine = null;
        }
    }


    private IEnumerator AutoSave()
    {
        while (true)
        {
            yield return new WaitForSeconds(300f); // 5•ª
            OnAutoSave();
        }
    }

    public void SetSaveData(SaveDataFile data)
    {
        m_saveData = data;
    }

    private void OnAutoSave()
    {
        if(m_saveData != null)
        {
            m_saveData = new();
        }

        foreach (var data in CharacterManager.Instance.DataList)
        {
            m_saveData.SaveCharaData(data);

        }

        m_saveData.SetMoney(CharacterManager.Instance.Money);
        m_saveData.SetTicket(CharacterManager.Instance.Ticket);

        m_saveData.SaveMainChara(CharacterManager.Instance.MainCharacters);

        m_postSaveFile.SaveFile(m_accountData.AccountID, m_saveData);

    }

    public void OnGachaSave()
    {
        if (m_debug.debugMode) return;


        if (m_saveData != null)
        {
            m_saveData = new();
        }

        foreach (var data in CharacterManager.Instance.DataList)
        {
            m_saveData.SaveCharaData(data);

        }
        m_saveData.SaveMainChara(CharacterManager.Instance.MainCharacters);


        m_saveData.SetMoney(CharacterManager.Instance.Money);
        m_saveData.SetTicket(CharacterManager.Instance.Ticket);

        m_postSaveFile.SaveFile(m_accountData.AccountID, m_saveData);

        m_timer = 0f;
    }

    public void OnMainCharaSave()
    {
        if (m_debug.debugMode) return;


        if (m_saveData != null)
        {
            m_saveData = new();
        }

        foreach (var data in CharacterManager.Instance.DataList)
        {
            m_saveData.SaveCharaData(data);

        }
        m_saveData.SaveMainChara(CharacterManager.Instance.MainCharacters);


        m_saveData.SetMoney(CharacterManager.Instance.Money);
        m_saveData.SetTicket(CharacterManager.Instance.Ticket);

        m_postSaveFile.SaveFile(m_accountData.AccountID, m_saveData);

        m_timer = 0f;
    }
}
