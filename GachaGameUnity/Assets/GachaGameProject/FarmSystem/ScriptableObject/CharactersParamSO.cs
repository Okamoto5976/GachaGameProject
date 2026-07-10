using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CharactersParamSO", menuName = "Scriptable Objects/CharactersParamSO")]
public class CharactersParamSO : ScriptableObject
{
    public List<CharaData> CharaDataList = new();
}
