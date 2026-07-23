using TMPro;
using UnityEngine;

public class AccountView : MonoBehaviour
{
    [SerializeField] private GameObject m_registerView;
    [SerializeField] private GameObject m_loginView;

    [Header("Audio")]
    [SerializeField] private AudioEventSO m_SEEvent;
    [SerializeField] private AudioData m_peta;

    [SerializeField] private TextMeshProUGUI m_accountText;


    private void PlaySE()
    {
        m_SEEvent.Raise(m_peta);
    }
    
    public void OnViewRegister()
    {
        PlaySE();
        m_accountText.text = "";


        m_registerView.SetActive(true);
        m_loginView.SetActive(false);
    }

    public void OnViewLogin()
    {
        m_accountText.text = "";

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
    

    public void OnSetAccount(string text)
    {
        m_accountText.text = text;
        OnHideView();

    }
}
