using UnityEngine;

public class TitleStart : MonoBehaviour
{
    [SerializeField] private AccountData m_accountData;

    private void Awake()
    {
        m_accountData.ResetData();
    }

    public void OnClick()
    {
        if (m_accountData.AccountID <= -1)
        {
            Debug.Log("ログインできていません");
            return;
        }

        Debug.Log("ログインできているね！ゲームをスタートします！");
    }
}
