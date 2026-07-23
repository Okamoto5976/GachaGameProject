using UnityEngine;
using UnityEngine.UI;

public class ConfigUI : MonoBehaviour
{
    [SerializeField] private Slider m_BGMSlider;
    [SerializeField] private Slider m_SESlider;

    [SerializeField] private GameObject m_ConfigCanvas;

    [Header("RunTime")]
    [SerializeField] private FloatRunTime m_AudioBGMVolume;
    [SerializeField] private FloatRunTime m_AudioSEVolume;

    [Header("Audio")]
    [SerializeField] private AudioEventSO m_SEEvent;
    [SerializeField] private AudioData m_papeSE;

    private void Start()
    {
        m_BGMSlider.value = m_AudioBGMVolume.Value;
        m_SESlider.value = m_AudioSEVolume.Value;
    }

    public void SetBGMVolume(float volume)
    {
        //m_BGMSlider.value = volume;
        //audioManager
        AudioManager.Instance.SetBGMVolume(volume);
    }

    public void SetSEVolume(float volume)
    {
        //m_BGMSlider.value = volume;
        AudioManager.Instance.SetSEVolume(volume);
    }

    public void OnCancel()
    {
        PlaySE();

        m_ConfigCanvas.SetActive(false);
    }

    private void PlaySE()
    {
        m_SEEvent.Raise(m_papeSE);
    }


    public void OnTitleMove()
    {
        PlaySE();

        LoadManager.Instance.OnTitle("TitleScene");
    }

    //---------title scene---------
    public void OnView()
    {
        PlaySE();


        m_ConfigCanvas.SetActive(true);
    }
}
