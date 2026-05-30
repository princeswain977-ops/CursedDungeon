using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;

    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log("Player Health: " + health);

        if (health <= 0)
        {
            Debug.Log("PLAYER DIED");

            Destroy(gameObject);
        }
    }
}