using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CharaUIEventSO", menuName = "Scriptable Objects/Events/CharaUIEventSO")]
public class CharaUIEventSO : ScriptableObject
{
    private event Action<Enum_CharaUIShow, int> m_event;
    public void Raise(Enum_CharaUIShow type, int id)
    {
        m_event?.Invoke(type, id);
    }

    public void Register(Action<Enum_CharaUIShow, int> d_event)
    {
        m_event += d_event;
    }

    public void Unregister(Action<Enum_CharaUIShow, int> d_event)
    {
        m_event -= d_event;
    }
}
