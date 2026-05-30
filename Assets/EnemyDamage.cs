using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 1;

    public float damageCooldown = 1f;

    private float lastDamageTime;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time > lastDamageTime + damageCooldown)
            {
                PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();

                if (player != null)
                {
                    player.TakeDamage(damage);

                    lastDamageTime = Time.time;
                }
            }
        }
    }
}