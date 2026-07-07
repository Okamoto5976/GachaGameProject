using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class RegisterResult
{
    public bool success;
    public string message;
    public int userId;
    public string token;
}

public class ADBRegister : MonoBehaviour
{
    private string m_ServerAddress = "http://localhost/PHPGameProject/ADB/register.php";

    [SerializeField] private string m_userName;
    [SerializeField] private string m_password;

    [SerializeField] private LoginCash m_cash;
    [SerializeField] private AccountData m_accountData;

    public void OnClick()
    {
        CreateAccount(m_userName, m_password);
    }

    public void CreateAccount(string user, string password)
    {
        StartCoroutine(RegisterCoroutine(user, password));
    }

    private IEnumerator RegisterCoroutine(string user, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", user);
        form.AddField("password", password);

        UnityWebRequest request = UnityWebRequest.Post(m_ServerAddress, form);

        yield return request.SendWebRequest();

        if(request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Failure: " + request.error);
        }
        else
        {
            RegisterResult result =
               JsonUtility.FromJson<RegisterResult>(request.downloadHandler.text);

            if (result.success)
            {
                Debug.Log("ìoò^ê¨å˜");
                m_cash.SaveLoginCash(result.token);

                //SO save id
                m_accountData.SetAccountID(result.userId);
            }
            else
            {
                Debug.Log(result.message);
            }
        }
    }
}
