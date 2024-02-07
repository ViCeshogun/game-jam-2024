using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Transform player;
    public Rigidbody2D rb;
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
    public int walk;
    public bool can_walk;
    public Transform self;
    public int wait_time;
    public Collider2D me;
    public int time;
    public void Start()
    {
        time = 120;
        pos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        timer = randomMoveDuration;
        StartCoroutine(Randomiser());
        StartCoroutine(RandomMovement());
        // Start the coroutine for random movement

    }

    public void Update()
    {
        if (walk == 0) { rb.drag = 1000; can_walk = false; }
        if (walk == 2) { rb.drag = 3; rb.AddForce(new Vector2(-5, 0)); self.rotation = Quaternion.Euler(0, 0, 0); }
        if (walk == 1) { rb.drag = 3; rb.AddForce(new Vector2(5, 0)); self.rotation = Quaternion.Euler(0, 180, 0); }
        if (walk == 3) { rb.AddForce(new Vector2(-6, 0)); self.rotation = Quaternion.Euler(0, 0, 0); }
        if (walk == 4) { rb.AddForce(new Vector2(6, 0)); self.rotation = Quaternion.Euler(0, 180, 0);}


        animtor.SetBool("walking", can_walk);
        animtor.SetBool("evil", evil);
       
            // Update the timer for random movement
            timer -= Time.deltaTime;

            if (timer_script.time >= 120)
            {
     
                // Switch to moving towards the player
                isMovingRandomly = true;
                StopCoroutine(RandomMovement());
            StartCoroutine(MoveTowardsPlayer());
        }
        
    }

    IEnumerator RandomMovement()
    {
        yield return new WaitForSeconds(2);
        
        can_move = 1;
            
            

            if (random == 1 && can_move == 1) { walk = 1;  is_walking = 2; can_walk = true; }
            if (random == 2 && can_move == 1) { walk = 2;  is_walking = 2; can_walk = true; }
            if (random == 3 && can_move == 1) { can_walk = false; walk = 0;  is_walking = 0;}

            if (transform.position.x > pos.x + 7)
            {
            can_walk = true;
            can_move = 0;
            walk = 3;
            StartCoroutine(Return());
            
                
            }

            if (transform.position.x < pos.x - 7)
            {
            can_walk = true;
            can_move = 0;
            walk = 4;
            StartCoroutine(Return());
                
            }

        StartCoroutine(RandomMovement());

    }

   


    IEnumerator Randomiser()
    {
        yield return new WaitForSeconds(2);
        random = Random.Range(1, 4);
        StartCoroutine(Randomiser());
    }

    IEnumerator Return()
    {
        yield return new WaitForSeconds(2);
        can_move = 1;
        random = Random.Range(1, 4);
    }

    IEnumerator MoveTowardsPlayer()
    {
        yield return new WaitForSeconds(1);

        me.isTrigger = false;

      
            evil = true;
            rb.transform.tag = "Enamy";
            // Move towards the player
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;

            // Wait for a short duration before recalculating direction
            yield return new WaitForSeconds(0.5f);
        
    }
}
