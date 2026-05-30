using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit Something");

        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");

            EnemyHealth enemy =
                collision.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                Debug.Log("Enemy Took Damage");

                enemy.TakeDamage(damage);
            }
        }
    }
}