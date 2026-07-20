using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomEntityMove : MonoBehaviour
{
    //[SerializeField] private EntityDataSO m_entityData;

    public int ID { get; private set; }

    private Vector3 m_moveDirection;
    private float m_timer;
    private Image m_image;

    private float m_moveSpeed;

    public enum EntityState
    {
        Idle,
        Move
    }

    private EntityState m_state;

    void Start()
    {
        m_image = GetComponentInChildren<Image>();

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

                // 移動
                transform.position +=
                    m_moveDirection * m_moveSpeed * Time.deltaTime;

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
        ID = data.ID;
        m_image.sprite = data.image;
    }
}