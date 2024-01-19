using System.Collections;
using System.Diagnostics.SymbolStore;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class camra : MonoBehaviour
{


    public GameObject bob;
    public GameObject bullet;
    public GameObject player;
    public Vector3 player_pos;
    public Vector3 bob_pos;
    public float random;
    public int time;
    public Transform bullet_spin;
    public float random_check;
    public GameObject camra_;
    public Vector3 hate;
    public float Move_speed;

    public void Update()
    {
        hate = bob.transform.position;

        
            if (time > 1) { bullet.transform.position = bullet.transform.position; }


            float number = Mathf.Atan2(bob_pos.y - player_pos.y, bob_pos.x - player_pos.x);
            if (time == 1) {
                player_pos = player.transform.position;
                bullet.transform.position = bob_pos;
                bullet_spin.rotation = Quaternion.Euler(0, 0, number);

            }



            if (time > 1 && time < 3)
            {
                Debug.Log("time");

                bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, player_pos, 0.5f);

            }



            if (time > 4 && time < 6)
            {

                bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, bob_pos, 0.5f);
            }




            if (time == 7) {
                time = 0;
                random_check = 0; }
            if (random == 1) { bob_pos = new Vector2(-21+hate.x, 4 + hate.y); }
            if (random == 2) { bob_pos = new Vector2(19+hate.x, 4 + hate.y); }
            if (random == 3) { bob_pos = new Vector2(-2+hate.x, 17 + hate.y); }
            if (random == 4) { bob_pos = new Vector2(-21+hate.x, 16 + hate.y); }
            if (random == 5) { bob_pos = new Vector2(-16+hate.x, 16 + hate.y); }
            if (random_check == 0) { random = Random.Range(1+hate.x, 6); random_check = 1; }
        

    }


    public void Start()
    {
        random = Random.Range(1, 6);
        StartCoroutine(time_randomiser());

        if (random == 1) { bob_pos = new Vector2(-21 + hate.x, 4 + hate.y); }
        if (random == 2) { bob_pos = new Vector2(19 + hate.x, 4 + hate.y); }
        if (random == 3) { bob_pos = new Vector2(-2 + hate.x, 17 + hate.y); }
        if (random == 4) { bob_pos = new Vector2(-21 + hate.x, 16 + hate.y); }
        if (random == 5) { bob_pos = new Vector2(-16 + hate.x, 16 + hate.y); }





    }
    




        IEnumerator time_randomiser() 
    {
        yield return new WaitForSeconds(1);
        time = time + 1;
        StartCoroutine(time_randomiser());

    }
  
}