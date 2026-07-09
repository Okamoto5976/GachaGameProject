using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "Scriptable Objects/Data/AudioData")]
public class AudioData : ScriptableObject
{
    [SerializeField] private AudioClip m_clip;
    [SerializeField] private bool m_loop;

    public AudioClip Clip { get => m_clip; }
    public bool Loop { get => m_loop; }
}
