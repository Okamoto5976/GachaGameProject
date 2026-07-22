using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomEntityMove : MonoBehaviour
{
    //[SerializeField] private EntityDataSO m_entityData;

    [SerializeField] private int m_id;
    [SerializeField] private float m_minX = -900f;
    [SerializeField] private float m_maxX = 900f;
    [SerializeField] private float m_minY = -500f;
    [SerializeField] private float m_maxY = 500f;
    public int ID => m_id;

    private Vector3 m_moveDirection;
    private float m_timer;
    private Image m_image;

    private float m_moveSpeed;
    private RectTransform m_rectTransform;

    public enum EntityState
    {
        Idle,
        Move
    }

    private EntityState m_state;

    private void Awake()
    {
        m_image = GetComponent<Image>();
        m_rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        //if (m_entityData == null)
        //{
        //    Debug.LogError("EntityDataが設定されていません");
        //    return;
        //}

        // EntityDataから値を取得
        //m_moveSpeed = m_entityData.Value;

        //Debug.Log("ID : " + m_entityData.Id);
        //Debug.Log("名前 : " + m_entityData.Name);
        //Debug.Log("タイプ : " + m_entityData.Type);
        //Debug.Log("レア度 : " + m_entityData.Rarity);

        //// Sprite表示
        //if (m_entityData.Sprite != null)
        //{
        //    m_image.sprite = m_entityData.Sprite;
        //}

        m_state = EntityState.Idle;
        m_timer = 3f;
        m_moveSpeed = 300f;

    }

    void Update()
    {
        m_timer -= Time.deltaTime;

        switch (m_state)
        {
            case EntityState.Idle:

                if (m_timer <= 0f)
                {
                    // ランダムな方向を決定
                    m_moveDirection = new Vector3(
                        Random.Range(-1f, 1f),
                        0f,
                        Random.Range(-1f, 1f)
                    ).normalized;

                    m_state = EntityState.Move;
                    m_timer = 3f;
                }

                break;

            case EntityState.Move:

                Vector2 pos = m_rectTransform.anchoredPosition;
                pos += new Vector2(m_moveDirection.x, m_moveDirection.z) * m_moveSpeed * Time.deltaTime;

                // 壁に当たったら向きを変える
                if (pos.x <= m_minX)
                {
                    pos.x = m_minX;
                    m_moveDirection.x *= -1;
                }
                else if (pos.x >= m_maxX)
                {
                    pos.x = m_maxX;
                    m_moveDirection.x *= -1;
                }

                if (pos.y <= m_minY)
                {
                    pos.y = m_minY;
                    m_moveDirection.z *= -1;
                }
                else if (pos.y >= m_maxY)
                {
                    pos.y = m_maxY;
                    m_moveDirection.z *= -1;
                }

               m_rectTransform.anchoredPosition = pos;

                if (m_timer <= 0f)
                {
                    m_state = EntityState.Idle;
                    m_timer = 3f;
                }

                break;
        }
    }

    //public EntityDataSO GetEntityData()
    //{
    //    return m_entityData;
    //}

    public void SetData(MasterCharacterData data)
    {
        m_id = data.ID;
        m_image.sprite = data.Image;
    }
}