using UnityEngine;

public class AccountView : MonoBehaviour
{
    [SerializeField] private GameObject m_registerView;
    [SerializeField] private GameObject m_loginView;

    [Header("Audio")]
    [SerializeField] private AudioEventSO m_SEEvent;
    [SerializeField] private AudioData m_peta;


    private void PlaySE()
    {
        m_SEEvent.Raise(m_peta);
    }
    
    public void OnViewRegister()
    {
        PlaySE();


        m_registerView.SetActive(true);
        m_loginView.SetActive(false);
    }

    public void OnViewLogin()
    {

        PlaySE();

        m_registerView.SetActive(false);
        m_loginView.SetActive(true);
    }

    public void OnHideView()
    {
        PlaySE();


        m_registerView.SetActive(false);
        m_loginView.SetActive(false);
    }
}
