using UnityEngine;

public class FlyingEnemyAI : MonoBehaviour
{
    public float speed = 3.5f;

    public float stoppingDistance = 0.5f;

    private Transform player;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            float distance =
                Vector2.Distance(transform.position, player.position);

            if (distance > stoppingDistance)
            {
                Vector2 direction =
                    (player.position - transform.position).normalized;

                rb.MovePosition(
                    rb.position +
                    direction * speed * Time.fixedDeltaTime
                );
            }
        }
    }
}