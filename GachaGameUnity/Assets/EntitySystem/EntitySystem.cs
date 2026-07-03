using UnityEngine;
using System.Collections;

public class RandomEntityMove : MonoBehaviour
{
    [SerializeField]
    private EntityData m_entityData;

    private Vector3 m_moveDirection;
    private float m_timer;
    private Rigidbody m_rb;
    private SpriteRenderer m_renderer;

    private float m_moveSpeed;

    public enum EntityState
    {
        Idle,
        Move
    }

    private EntityState m_state;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_renderer = GetComponentInChildren<SpriteRenderer>();

        if (m_entityData == null)
        {
            Debug.LogError("EntityDataが設定されていません");
            return;
        }

        // EntityDataから値を取得
        m_moveSpeed = m_entityData.Value;

        Debug.Log("ID : " + m_entityData.Id);
        Debug.Log("名前 : " + m_entityData.Name);
        Debug.Log("タイプ : " + m_entityData.Type);
        Debug.Log("レア度 : " + m_entityData.Rarity);

        // Texture表示
        if (m_entityData.Sprite != null)
        {
            m_renderer.sprite = m_entityData.Sprite;
        }


        m_state = EntityState.Idle;
        m_timer = 3f;
    }

    void Update()
    {
        m_timer -= Time.deltaTime;

        switch (m_state)
        {
            case EntityState.Idle:

                if (m_timer <= 0f)
                {
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

                if (m_timer <= 0f)
                {
                    m_state = EntityState.Idle;
                    m_timer = 3f;
                }

                break;
        }
    }

    void FixedUpdate()
    {
        switch (m_state)
        {
            case EntityState.Idle:
                m_rb.linearVelocity = Vector3.zero;
                break;

            case EntityState.Move:
                m_rb.linearVelocity =
                    m_moveDirection * m_moveSpeed;
                break;
        }
    }
}