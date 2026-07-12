using UnityEngine;
using UnityEngine.UI;

public class ConfigUI : MonoBehaviour
{
    [SerializeField] private Slider m_BGMSlider;
    [SerializeField] private Slider m_SESlider;

    public void SetBGMVolume(float volume)
    {
        m_BGMSlider.value = volume;
        //audioManager
    }

    public void SetSEVolume(float volume)
    {
        m_BGMSlider.value = volume;
    }
}
