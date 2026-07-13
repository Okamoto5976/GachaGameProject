using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CharaUIEventSO", menuName = "Scriptable Objects/Events/CharaUIEventSO")]
public class CharaUIEventSO : ScriptableObject
{
    private event Action<Enum_CharaUIShow> m_event;
    public void Raise(Enum_CharaUIShow type)
    {
        m_event?.Invoke(type);
    }

    public void Register(Action<Enum_CharaUIShow> d_event)
    {
        m_event += d_event;
    }

    public void Unregister(Action<Enum_CharaUIShow> d_event)
    {
        m_event -= d_event;
    }
}
