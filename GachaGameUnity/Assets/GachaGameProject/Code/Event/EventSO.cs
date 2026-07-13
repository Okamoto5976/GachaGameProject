using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EventSO", menuName = "Scriptable Objects/Events/EventSO")]
public class EventSO : ScriptableObject
{
    private event Action m_event;
    public void Raise()
    {
        m_event?.Invoke();
    }

    public void Register(Action d_event)
    {
        m_event += d_event;
    }

    public void Unregister(Action d_event)
    {
        m_event -= d_event;
    }
}
