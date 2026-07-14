using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioEventSO m_audioBGMEvent;
    [SerializeField] private AudioEventSO m_audioSEEvent;

    [SerializeField] private AudioSource m_BGMSource;
    [SerializeField] private AudioSource m_SESource;

    private Dictionary<AudioClip, float> m_lastPlayTimes = new();

    //RuntimeSO
    [SerializeField] private FloatRunTime m_AudioBGMVolume;
    [SerializeField] private FloatRunTime m_AudioSEVolume;

    //option slider
    //[SerializeField] private Slider m_audioSlider;

    private float m_masterVolume;

    //BGMがフェードするのにかかる時間
    [SerializeField] private float m_bgmFadeSpeed;


    //次流すBGM名
    private AudioData m_nextBGM;

    //BGMをフェードアウト中か
    private bool m_isFadeOut = false;

    private void OnEnable()
    {
        m_audioSEEvent.Register(PlaySE);
        m_audioBGMEvent.Register(PlayBGM);

        SetBGMVolume(m_AudioBGMVolume.Value);
        SetSEVolume(m_AudioSEVolume.Value);
    }

    private void OnDisable()
    {
        m_audioSEEvent.Unregiste(PlaySE);
        m_audioBGMEvent.Unregiste(PlayBGM);
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //m_audioSlider.value = m_AudioVolume.Value;
    }

    private void PlaySE(AudioData data)
    {
        if (m_lastPlayTimes.TryGetValue(data.Clip, out float lastTime))
        {
            if (Time.unscaledTime - lastTime < 0.05f) return;
        }

        m_lastPlayTimes[data.Clip] = Time.unscaledTime;

        m_SESource.PlayOneShot(data.Clip);
    }

    private void PlayBGM(AudioData data)
    {
        //同じクリップが既に流れているなら
        if (m_BGMSource.isPlaying && m_BGMSource.clip == data.Clip)
            return;
        ApplyBGM(data);

        //if (!m_BGMSource.isPlaying)
        //{

        //}
        //else
        //{
        //    Debug.Log("BGM");

        //    m_nextBGM = data;
        //    //fade start
        //    FadeOutBGM();
        //}
    }

    private void ApplyBGM(AudioData data)
    {
        m_BGMSource.clip = data.Clip;
        m_BGMSource.loop = data.Loop;
        m_BGMSource.Play();

    }

    public void FadeOutBGM()
    {
        m_isFadeOut = true;
    }

    private void Update()
    {
        if (!m_isFadeOut) return;


        //徐々にボリュームを下げていき、ボリュームが0になったらボリュームを戻し次の曲を流す
        m_BGMSource.volume -= Time.deltaTime * m_bgmFadeSpeed;
        if (m_BGMSource.volume <= 0)
        {
            m_BGMSource.Stop();
            //var loadAudio = m_save.AudioLoad();
            //m_BGMSource.volume = loadAudio.data.BGMVolume;
            //m_at    tachSESource.volume = loadAudio.data.SEVolume;
            m_isFadeOut = false;

            if (m_nextBGM != null)
            {
                ApplyBGM(m_nextBGM);
                m_nextBGM = null;
            }
        }
    }


    //=================================================================================
    //音量変更
    //=================================================================================

    public void SetBGMVolume(float volume)
    {
        m_masterVolume = volume;
        m_BGMSource.volume = m_masterVolume;
        m_AudioBGMVolume.SetValue(volume);
    }

    public void SetSEVolume(float volume)
    {
        m_masterVolume = volume;
        m_SESource.volume = m_masterVolume;
        m_AudioSEVolume.SetValue(volume);
    }
}
