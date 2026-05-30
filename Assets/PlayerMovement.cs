using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public float dashSpeed = 15f;

    public float dashDuration = 0.2f;

    public float dashCooldown = 1f;

    public float maxStamina = 100f;

    public float staminaCost = 25f;

    public float staminaRegen = 20f;

    private float currentStamina;

    private bool canDash = true;

    private bool isDashing = false;

    private Rigidbody2D rb;

    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentStamina = maxStamina;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        movement.y = Input.GetAxisRaw("Vertical");

        currentStamina += staminaRegen * Time.deltaTime;

        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

        if (Input.GetKeyDown(KeyCode.LeftShift)
            && canDash
            && currentStamina >= staminaCost)
        {
            StartCoroutine(Dash());
        }
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.MovePosition(
                rb.position +
                movement.normalized * speed * Time.fixedDeltaTime
            );
        }
    }

    IEnumerator Dash()
    {
        canDash = false;

        isDashing = true;

        currentStamina -= staminaCost;

        Vector2 dashDirection = movement.normalized;

        float startTime = Time.time;

        while (Time.time < startTime + dashDuration)
        {
            rb.MovePosition(
                rb.position +
                dashDirection * dashSpeed * Time.fixedDeltaTime
            );

            yield return new WaitForFixedUpdate();
        }

        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }
}