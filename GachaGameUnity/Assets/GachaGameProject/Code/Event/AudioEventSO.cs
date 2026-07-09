using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioEventSO", menuName = "Scriptable Objects/Events/AudioEventSO")]
public class AudioEventSO : ScriptableObject
{
    private event Action<AudioData> m_event;

    public void Raise(AudioData data)
    {
        m_event?.Invoke(data);
    }

    public void Register(Action<AudioData> d_event)
    {
        m_event += d_event;
    }

    public void Unregiste(Action<AudioData> d_event)
    {
        m_event -= d_event;
    }
}
