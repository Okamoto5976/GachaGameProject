using System;
using UnityEngine;

[CreateAssetMenu(fileName = "StringEventSO", menuName = "Scriptable Objects/Events/StringEventSO")]
public class StringEventSO : ScriptableObject
{
    private event Action<string> m_event;
    public void Raise(string d_event)
    {
        m_event?.Invoke(d_event);
    }

    public void Register(Action<string> d_event)
    {
        m_event += d_event;
    }

    public void Unregister(Action<string> d_event)
    {
        m_event -= d_event;
    }
}
