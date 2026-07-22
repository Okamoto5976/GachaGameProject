using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_characterPrefabs;

    [SerializeField] private RectTransform m_stageArea;

    [SerializeField] private int m_spawnCount = 5;

    void Start()
    {
        SpawnCharacters();
    }

    private void SpawnCharacters()
    {
        for (int i = 0; i < m_spawnCount; i++)
        {
            // ランダムなプレハブを選ぶ
            GameObject prefab =
                m_characterPrefabs[Random.Range(0, m_characterPrefabs.Count)];

            // 生成
            GameObject character =
                Instantiate(prefab, m_stageArea);

            // ランダムな座標
            Rect rect = m_stageArea.rect;

            float x = Random.Range(rect.xMin, rect.xMax);
            float y = Random.Range(rect.yMin, rect.yMax);

            character.GetComponent<RectTransform>().anchoredPosition =
                new Vector2(x, y);
        }
    }
}