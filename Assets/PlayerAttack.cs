using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform weapon;
    public Collider2D weaponCollider;
    public float rotationSpeed = 500f;

    private bool attacking = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !attacking)
        {
            StartCoroutine(SwingSword());
        }
    }

    System.Collections.IEnumerator SwingSword()
    {
        attacking = true;

        weaponCollider.enabled = true;

        float angle = 0;

        while (angle < 90)
        {
            float step = rotationSpeed * Time.deltaTime;

            weapon.Rotate(0, 0, -step);

            angle += step;

            yield return null;
        }

        angle = 0;

        while (angle < 90)
        {
            float step = rotationSpeed * Time.deltaTime;

            weapon.Rotate(0, 0, step);

            angle += step;

            yield return null;
        }

        weaponCollider.enabled = false;

        attacking = false;
    }
}