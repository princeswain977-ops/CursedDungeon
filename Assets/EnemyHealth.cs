using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;

    public GameObject rewardObject;

    private SpriteRenderer spriteRenderer;

    private Color originalColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        originalColor = spriteRenderer.color;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        StartCoroutine(HitFlash());

        if (health <= 0)
        {
            if (rewardObject != null)
            {
                rewardObject.SetActive(true);
            }

            Destroy(gameObject);
        }
    }

    IEnumerator HitFlash()
    {
        spriteRenderer.color = Color.white;

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = originalColor;
    }
}