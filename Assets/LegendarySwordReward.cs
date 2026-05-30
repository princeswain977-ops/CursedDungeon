using UnityEngine;

public class LegendarySwordReward : MonoBehaviour
{
    public int swordDamageIncrease = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            WeaponDamage weapon =
                FindObjectOfType<WeaponDamage>();

            PlayerHealth health =
                collision.GetComponent<PlayerHealth>();

            PlayerMovement movement =
                collision.GetComponent<PlayerMovement>();

            if (weapon != null)
            {
                weapon.damage += swordDamageIncrease;
            }

            if (health != null)
            {
                health.health = 5;
            }

            if (movement != null)
            {
                movement.maxStamina = 10;
            }

            Destroy(gameObject);
        }
    }
}