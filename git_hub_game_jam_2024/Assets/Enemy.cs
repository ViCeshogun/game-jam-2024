using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Transform player;
    private Rigidbody2D rb;
    private bool isMovingRandomly = true;
    public float random;
    public Vector2 pos;
    public int can_move;
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
            can_move = 1;
            StartCoroutine(Randomiser());
            pos = transform.position;

            if (random == 1 && can_move == 1) { rb.AddForce(new Vector2(5, 0)); rb.drag = 1; }
            if (random == 2 && can_move == 1) { rb.AddForce(new Vector2(-5, 0)); rb.drag = 1; }
            if (random == 3 && can_move == 1) { rb.drag = 1000; }

            if (transform.position.x > pos.x + 7)
            {
                can_move = 0;
                StartCoroutine(Return());
                rb.AddForce(new Vector2(-5, 0));
            }

            if (transform.position.x < pos.x - 7)
            {
                can_move = 0;
                StartCoroutine(Return());
                rb.AddForce(new Vector2(5, 0));
            }

            yield return null;
        }
    }

    IEnumerator Randomiser()
    {
        yield return new WaitForSeconds(1);
        random = Random.Range(1, 10);
        StartCoroutine(Randomiser());
    }

    IEnumerator Return()
    {
        yield return new WaitForSeconds(1);
        can_move = 1;
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