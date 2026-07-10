using System;
using UnityEngine;

[System.Serializable]
public enum LoadingStep
{
    LoadingSave,
    ApplyingSave,
    LoadingMaster,
    Complete
}

[CreateAssetMenu(fileName = "LoadMessageEventSO", menuName = "Scriptable Objects/Events/LoadMessageEventSO")]
public class LoadMessageEventSO : ScriptableObject
{
    

    private event Action<LoadingStep, float> m_event;

    public void Raise(LoadingStep data, float ber)
    {
        m_event?.Invoke(data, ber);
    }

    public void Register(Action<LoadingStep, float> d_event)
    {
        m_event += d_event;
    }

    public void Unregiste(Action<LoadingStep, float> d_event)
    {
        m_event -= d_event;
    }
}
