using UnityEngine;

public class GenshinEyeBoss : MonoBehaviour
{
    public float speed = 5f;

    public float stoppingDistance = 1f;

    public GameObject fireballPrefab;

    public float fireballCooldown = 3f;

    private float fireballTimer;

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

    void Update()
    {
        fireballTimer += Time.deltaTime;

        if (fireballTimer >= fireballCooldown)
        {
            ShootFireball();

            fireballTimer = 0f;
        }
    }

    void ShootFireball()
    {
        Instantiate(
            fireballPrefab,
            transform.position,
            Quaternion.identity
        );
    }
}