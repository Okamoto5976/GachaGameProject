using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class RegisterResult
{
    public bool success;
    public string message;
    public int userId;
    public string token;
    public SaveDataFile saveData;
}

public class ADBRegister : MonoBehaviour
{
    private string m_ServerAddress = "http://10.219.32.121/PHPGameProject/ADB/register.php";

    [SerializeField] private TMP_InputField m_userName;
    [SerializeField] private TMP_InputField m_password;

    [SerializeField] private LoginCash m_cash;
    [SerializeField] private AccountData m_accountData;

    public void OnClick()
    {
        if(m_userName == null)
        {
            Debug.Log("userNameÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒ");

            return;
        }

        if(m_password == null)
        {
            Debug.Log("passwordÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒ");
        }

        CreateAccount(m_userName.text, m_password.text);
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
