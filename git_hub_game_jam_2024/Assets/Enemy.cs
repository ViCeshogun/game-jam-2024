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
    public timer timer_script;
    public Animator animtor;
    public int is_walking;
    public bool evil;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        timer = randomMoveDuration;
        StartCoroutine(Randomiser());
        // Start the coroutine for random movement
        StartCoroutine(RandomMovement());
    }

    void Update()
    {
       
        animtor.SetInteger("speed", is_walking);
        animtor.SetBool("evil", evil);
        if (isMovingRandomly)
        {
            // Update the timer for random movement
            timer -= Time.deltaTime;

            if (timer_script.time >= 10)
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
            
            pos = transform.position;

            if (random == 1 && can_move == 1) { rb.AddForce(new Vector2(2, 0)); rb.drag = 1; is_walking = 2; }
            if (random == 2 && can_move == 1) { rb.AddForce(new Vector2(-2, 0)); rb.drag = 1; is_walking = 2; }
            if (random == 3 && can_move == 1) { rb.drag = 1000; is_walking = 0; }

            if (transform.position.x > pos.x + 7)
            {
                can_move = 0;
                StartCoroutine(Return());
                rb.AddForce(new Vector2(-2, 0));
            }

            if (transform.position.x < pos.x - 7)
            {
                can_move = 0;
                StartCoroutine(Return());
                rb.AddForce(new Vector2(2, 0));
            }

            yield return null;
        }
    }

    IEnumerator Randomiser()
    {
        yield return new WaitForSeconds(2);
        random = Random.Range(1, 4);
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
            evil = true;
            rb.transform.tag = "Enamy";
            // Move towards the player
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;

            // Wait for a short duration before recalculating direction
            yield return new WaitForSeconds(0.5f);
        }
    }
}
