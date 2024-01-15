using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movent : MonoBehaviour
{
    public float speed = 5f;            // Movement speed
    public float jumpForce = 10f;       // Jump force
    public float dashDistance = 5f;     // Dash distance
    public float dashDuration = 0.2f;   // Dash duration
    public float dashCooldown = 1f;     // Dash cooldown
    public Transform groundCheck;       // Ground check object (empty GameObject at player's feet)
    public LayerMask groundLayer;       // Layer mask for the ground

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isDashing;
    private float dashTime;
    private float dashCooldownTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (groundCheck == null)
            Debug.LogError("Ground Check object not assigned in the inspector!");
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Player jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Update dash cooldown timer
        dashCooldownTimer -= Time.deltaTime;

        // Player dash (triggered by left Shift)
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && dashCooldownTimer <= 0f)
        {
            StartCoroutine(Dash(horizontalInput));
        }
    }

    IEnumerator Dash(float direction)
    {
        isDashing = true;
        float dashStartX = transform.position.x;

        while (dashTime < dashDuration)
        {
            float dashDistanceThisFrame = dashDistance * direction;
            rb.velocity = new Vector2(dashDistanceThisFrame / dashDuration, rb.velocity.y);
            dashTime += Time.deltaTime;
            yield return null;
        }

        isDashing = false;
        dashTime = 0f;

        // Start dash cooldown
        dashCooldownTimer = dashCooldown;

        rb.velocity = new Vector2(0f, rb.velocity.y);
    }
}