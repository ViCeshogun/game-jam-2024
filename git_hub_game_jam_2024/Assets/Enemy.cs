using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Transform player;
    private Rigidbody2D rb;
    private bool isMovingRandomly = true;

    public float randomMoveDuration = 5f; // Adjust the duration for random movement
    private float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        timer = randomMoveDuration;

        // Start the coroutine for random movement
        StartCoroutine(RandomMovement());
    }

    void Update()
    {
        if (isMovingRandomly)
        {
            // Update the timer for random movement
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                // Switch to moving towards the player
                isMovingRandomly = false;
                StopCoroutine(RandomMovement());
                StartCoroutine(MoveTowardsPlayer());
            }
        }
    }

    IEnumerator RandomMovement()
    {
        while (isMovingRandomly)
        {
            // Move randomly
            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            rb.velocity = randomDirection * moveSpeed;

            // Wait for a short duration before changing direction
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    IEnumerator MoveTowardsPlayer()
    {
        while (true)
        {
            // Move towards the player
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;

            // Wait for a short duration before recalculating direction
            yield return new WaitForSeconds(0.5f);
        }
    }
}
