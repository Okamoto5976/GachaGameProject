using UnityEngine;
using System.Collections;

public class RandomEntityMove : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Vector3 moveDirection;
    private bool isMoving = false;

    public enum EntityState
    {
        Idle,
        Move
    }

    private EntityState m_state;

    void Start()
    {
        //StartCoroutine(MoveCycle());
    }

    void Update()
    {
        switch(m_state)
        {
            case EntityState.Idle:
                //3s wait
                //return 
                //random direction 
                //m_state = EntityState.Move;
                break;
            case EntityState.Move:
                //3s wait
                //Move();
                break;
        }

        if (isMoving)
        {
            transform.Translate(
                moveDirection * moveSpeed * Time.deltaTime,
                Space.World
            );
        }
    }

    IEnumerator MoveCycle()
    {
        while (true)
        {
            // ƒ‰ƒ“ƒ_ƒ€‚È•ûŒü‚ðŒˆ’è
            moveDirection = new Vector3(
                Random.Range(-1f, 1f),
                0f,
                Random.Range(-1f, 1f)
            ).normalized;

            // 3•bˆÚ“®
            isMoving = true;
            yield return new WaitForSeconds(3f);

            // 3•b’âŽ~
            isMoving = false;
            yield return new WaitForSeconds(3f);
        }
    }
}