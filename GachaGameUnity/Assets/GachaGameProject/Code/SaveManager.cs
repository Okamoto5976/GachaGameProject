using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    [SerializeField] private AccountData m_accountData;

    [SerializeField] private ADBPostSaveFile m_postSaveFile;

    private SaveDataFile m_saveData = new();

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

    public void OnAutoSave()
    {

        foreach (var data in CharacterManager.Instance.DataList)
        {
            m_saveData.SaveCharaData(data);

        }

        m_postSaveFile.SaveFile(m_accountData.AccountID, m_saveData);

    }

    public void OnGachaSave()
    {

    }
}
