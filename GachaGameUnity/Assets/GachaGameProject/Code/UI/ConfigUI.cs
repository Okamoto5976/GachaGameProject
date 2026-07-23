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
        m_ConfigCanvas.SetActive(false);
    }


    //---------title scene---------
    public void OnView()
    {
        m_ConfigCanvas.SetActive(true);
    }
}
