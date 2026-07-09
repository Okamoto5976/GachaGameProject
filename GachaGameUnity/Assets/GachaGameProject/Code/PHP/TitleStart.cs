using UnityEngine;

public class TitleStart : MonoBehaviour
{
    [SerializeField] private AccountData m_accountData;

    [SerializeField] private DebugMode m_debug;

    private void Awake()
    {
        m_accountData.ResetData();
    }

    public void OnClick()
    {
        if(m_debug.debugMode == true)
        {
            Debug.Log("DebugMode: 強制的に始めます。セーブデータは作られません");
            return;
        }

        if (m_accountData.AccountID <= -1)
        {
            Debug.Log("ログインできていません");
            return;
        }

        Debug.Log("ログインできているね！ゲームをスタートします！");
    }
}
