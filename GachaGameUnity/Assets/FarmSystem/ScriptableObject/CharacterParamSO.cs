using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CharacterParamSO", menuName = "Scriptable Objects/CharacterParamSO")]
public class CharacterParamSO : ScriptableObject
{
    [SerializeField] private GameObject m_charaPrefab;
    public GameObject CharaPrefab => m_charaPrefab;
    public List<CharaData> CharaDataList = new();
}
