using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadManager : MonoBehaviour
{
    public static LoadManager Instance;

    [SerializeField] private CanvasGroup m_canvas;
    //can click UI raytarget
    [SerializeField] private GameObject m_PanelObj;

    [SerializeField] private StringEventSO m_loadEvent;

    private Coroutine m_loadCoroutine;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

    }

    private void OnEnable()
    {
        m_loadEvent.Register(OnLoad);
        m_PanelObj.SetActive(false);
    }

    private void OnDisable()
    {
        m_loadEvent.Unregister(OnLoad);
    }

    public void OnLoad(string scenename)
    {
        if (m_loadCoroutine == null)
        {
            m_loadCoroutine = StartCoroutine(LoadSceneCoroutine(scenename));
            m_PanelObj.SetActive(true);
        }
    }

    //[SerializeField] private BoolRunTime m_IsStartGame;

    private IEnumerator LoadSceneCoroutine(string scenename)
    {
        yield return StartCoroutine(FadeIn(0.5f));

        //m_IsStartGame.SetValue(false);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scenename);

        asyncLoad.allowSceneActivation = false;

        float timer = 0f;

        float gameStartTimer = 0f;

        while (asyncLoad.progress < 0.9f)
        {
            timer += Time.unscaledDeltaTime;

            yield return null;
        }

        while (timer < 3f)
        {
            timer += Time.unscaledDeltaTime;

            yield return null;
        }

        asyncLoad.allowSceneActivation = true;

        Time.timeScale = 1f;

        while (gameStartTimer < 3f)
        {
            gameStartTimer += Time.unscaledDeltaTime;

            yield return null;
        }

        //1 frame wait
        yield return null;

        //m_IsStartGame.SetValue(true);

        yield return StartCoroutine(FadeOut(0.5f));

        m_loadCoroutine = null;
    }

    private IEnumerator FadeIn(float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.unscaledDeltaTime;

            m_canvas.alpha = Mathf.Lerp(0, 1, timer / duration);

            yield return null;
        }

        m_canvas.alpha = 1;
    }

    private IEnumerator FadeOut(float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.unscaledDeltaTime;

            m_canvas.alpha = Mathf.Lerp(1, 0, timer / duration);

            yield return null;
        }

        m_canvas.alpha = 0;

        m_PanelObj.SetActive(false);
    }
}
