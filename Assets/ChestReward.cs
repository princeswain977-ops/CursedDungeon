using UnityEngine;

public class ChestReward : MonoBehaviour
{
    public int healthReward = 1;

    public float staminaReward = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth health =
                collision.GetComponent<PlayerHealth>();

            PlayerMovement movement =
                collision.GetComponent<PlayerMovement>();

            if (health != null)
            {
                health.health += healthReward;

                if (health.health > 5)
                {
                    health.health = 5;
                }
            }

            if (movement != null)
            {
                movement.maxStamina += staminaReward;

                if (movement.maxStamina > 10)
                {
                    movement.maxStamina = 10;
                }
            }

            Destroy(gameObject);
        }
    }
}