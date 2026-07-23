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

    [SerializeField] private float m_moveSpeed = 300f;
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



        m_timer = Random.Range(0f, 3f);

        //m_moveSpeed = 300f;

    }

    void Update()
    {
        m_timer -= Time.deltaTime;

        switch (m_state)
        {
            case EntityState.Idle:

                if (m_timer <= 0f)
                {
                    float angle = Random.Range(0f, Mathf.PI * 2f);

                    m_moveDirection = new Vector3(
                        Mathf.Cos(angle),
                        0f,
                        Mathf.Sin(angle)
                    );

                    m_state = EntityState.Move;
                    m_timer = Random.Range(0f, 3f);

                }

                break;

            case EntityState.Move:

                Vector2 pos = m_rectTransform.anchoredPosition;

                float speedRate = Mathf.Lerp(0.1f, 1.0f, Mathf.Abs(m_moveDirection.x));
                // x=0 → 0.1
                // x=1 → 1.0

                Vector2 delta = new Vector2(m_moveDirection.x, m_moveDirection.z) * 
                    (m_moveSpeed * speedRate) * Time.deltaTime;

                Vector2 nextPos = pos + delta;

                // 壁に当たるなら反射
                if (nextPos.x < m_minX || nextPos.x > m_maxX)
                {
                    m_moveDirection.x *= -1;
                }

                if (nextPos.y < m_minY || nextPos.y > m_maxY)
                {
                    m_moveDirection.z *= -1;
                }

                //制限をかける
                nextPos.x = Mathf.Clamp(nextPos.x, m_minX, m_maxX);
                nextPos.y = Mathf.Clamp(nextPos.y, m_minY, m_maxY);

                m_rectTransform.anchoredPosition = nextPos;

                //m_rectTransform.anchoredPosition = pos;

                if (m_timer <= 0f)
                {
                    m_state = EntityState.Idle;

                    m_timer = Random.Range(0f, 3f);

                    //m_timer = 3f;
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
        Vector2 randomPos = new Vector2(
        Random.Range(m_minX, m_maxX),
        Random.Range(m_minY, m_maxY)
        );

        m_rectTransform.anchoredPosition = randomPos;

        if (data == null)
        {
            Debug.Log("Data null");
        }

        m_id = data.ID;
        m_image.sprite = data.Image;

        m_timer = Random.Range(0f, 3f);

    }
}