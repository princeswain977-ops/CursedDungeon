using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 8f;

    public int damage = 1;

    private Transform player;

    private Vector2 direction;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        direction =
            (player.position - transform.position).normalized;

        Destroy(gameObject, 4f);
    }

    void Update()
    {
        transform.position +=
            (Vector3)(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth =
                collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}