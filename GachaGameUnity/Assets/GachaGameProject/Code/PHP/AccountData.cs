using UnityEngine;

[CreateAssetMenu(fileName = "AccountData", menuName = "Scriptable Objects/AccountData")]
public class AccountData : ScriptableObject
{
    [SerializeField] private int m_accountID = -1;

    public int AccountID => m_accountID;

    public void SetAccountID(int id)
    {
        m_accountID = id;
    }

    public void ResetData()
    {
        m_accountID = -1;
    }
}
