using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ADBLogin : MonoBehaviour
{
    private string m_ServerAddressLogin = "http://localhost/PHPGameProject/ADB/login.php";
    private string m_ServerAddressCash = "http://localhost/PHPGameProject/ADB/cashlogin.php";

    [SerializeField] private string m_userName;
    [SerializeField] private string m_password;

    [SerializeField] private LoginCash m_cash;
    [SerializeField] private AccountData m_accountData;

    //gameStart patarn

    //1,use cash login
    //2,not cash, login or create account
    //3,already cash, but new create account

    private void Start()
    {
        LoginData data = m_cash.Load();

        if(data == null)
        {
            Debug.Log("cashがないので通常のログインへ");
            //login display move
        }
        else
        {
            StartCoroutine(CashLoginCoroutine(data.token));

        }

    }

    public void OnClick()
    {
        OnLogIn(m_userName, m_password);
    }

    //normal login or change account login => no token
    public void OnLogIn(string user, string password)
    {
        StartCoroutine(LoginCoroutine(user, password));
    }

    private IEnumerator CashLoginCoroutine(string token)
    {
        WWWForm form = new WWWForm();
        form.AddField("token", token);


        UnityWebRequest request = UnityWebRequest.Post(m_ServerAddressCash, form);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Failure: " + request.error);
        }
        else
        {
            RegisterResult result =
              JsonUtility.FromJson<RegisterResult>(request.downloadHandler.text);

            if (result.success)
            {
                Debug.Log("キャッシュログイン成功");

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

    private IEnumerator LoginCoroutine(string user, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", user);
        form.AddField("password", password);


        UnityWebRequest request = UnityWebRequest.Post(m_ServerAddressLogin, form);

        yield return request.SendWebRequest();

        if(request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Failure: " +  request.error);
        }
        else
        {
            RegisterResult result =
              JsonUtility.FromJson<RegisterResult>(request.downloadHandler.text);

            if (result.success)
            {
                Debug.Log("ログイン成功");

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

//ゲームスタート時、サーバーのIDを取っているか確認
//取れていない＝＞ログインまたアカウント登録してください。
//もしキャッシュでログインできているが、スタートせず　別のアカウントに変えた際
//（別のにログイン、また新規登録）　idなどのサーバーのデータを書き換え
//取れている＝＞ゲームスタート　ロード中に取れたsavefileがあればロード
//スタートを押した際、アカウント変更不可（ゲーム終了してもらって）そしてメインゲームへ