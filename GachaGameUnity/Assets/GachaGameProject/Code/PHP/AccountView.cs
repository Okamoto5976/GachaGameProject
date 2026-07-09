using UnityEngine;

public class AccountView : MonoBehaviour
{
    [SerializeField] private GameObject m_registerView;
    [SerializeField] private GameObject m_loginView;

    public void OnViewRegister()
    {
        m_registerView.SetActive(true);
        m_loginView.SetActive(false);
    }

    public void OnViewLogin()
    {
        m_registerView.SetActive(false);
        m_loginView.SetActive(true);
    }

    public void OnHideView()
    {
        m_registerView.SetActive(false);
        m_loginView.SetActive(false);
    }
}
