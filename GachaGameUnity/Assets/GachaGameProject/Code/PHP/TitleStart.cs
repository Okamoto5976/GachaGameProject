using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleStart : MonoBehaviour
{
    [SerializeField] private AccountData m_accountData;
    [SerializeField] private StringEventSO m_loadEventSO;

    [SerializeField] private DebugMode m_debug;

    [SerializeField] private AudioEventSO m_BGMEventSO;

    [SerializeField] private AudioData m_titleBGM;

    [Header("Audio")]
    [SerializeField] private AudioEventSO m_SEEvent;
    [SerializeField] private AudioData m_peta;

    private void PlaySE()
    {
        m_SEEvent.Raise(m_peta);
    }

    private void Awake()
    {
        m_accountData.ResetData();
    }

    private void Start()
    {
        m_BGMEventSO.Raise(m_titleBGM);
    }

    public void OnClick()
    {
        PlaySE();

        if(m_debug.debugMode == true)
        {
            Debug.Log("DebugMode: 強制的に始めます。セーブデータは作られません");
            m_loadEventSO.Raise("MainScene");

            return;
        }

        if (m_accountData.AccountID <= -1)
        {
            Debug.Log("ログインできていません");
            return;
        }

        Debug.Log("ログインできているね！ゲームをスタートします！");

        //SceneManager.LoadScene("MainScene");
        m_loadEventSO.Raise("MainScene");
    }
}
