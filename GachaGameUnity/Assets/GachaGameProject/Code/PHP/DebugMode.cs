using UnityEngine;

[CreateAssetMenu(fileName = "DebugMode", menuName = "Scriptable Objects/DebugMode")]
public class DebugMode : ScriptableObject
{
    [SerializeField] private bool m_debugMode;

    public bool debugMode => m_debugMode;
}
