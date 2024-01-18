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

    public void Update()
    {


        float number = Mathf.Atan2(bob_pos.y - player_pos.y, bob_pos.x - player_pos.x);
        if (time == 1) {
            player_pos = player.transform.position;
            
            bullet_spin.rotation = Quaternion.Euler(0,0,number);

        }
        bullet.transform.position = bullet.transform.position;
       

        if (time > 1&& time<3)
        {
            bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, player_pos, 0.05f);

        }
       
        

        if (time > 4&& time<6) 
        {
            bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, bob_pos, 0.05f);
        }
        
        
        
        
        if (time == 6) { 
            time = 0; 
            random_check = 0; }
        if (random == 1) { bob_pos = new Vector2(-11.5f+camra_.transform.position.x, 0+ camra_.transform.position.y); }
        if (random == 2) { bob_pos = new Vector2(11.5f + camra_.transform.position.x, 0 + camra_.transform.position.y); }
        if (random == 3) { bob_pos = new Vector2(0 + camra_.transform.position.x, 5.5f + camra_.transform.position.y); }
        if (random == 4) { bob_pos = new Vector2(11.5f + camra_.transform.position.x, 5.5f + camra_.transform.position.y); }
        if (random == 5) { bob_pos = new Vector2(-11.5f + camra_.transform.position.x, 5.5f + camra_.transform.position.y); }
        if (random_check == 0) { random = Random.Range(1, 6); random_check = 1; }


    }


    public void Start()
    {
        random = Random.Range(1, 6);
        StartCoroutine(time_randomiser());
        if (random == 1) { bob_pos = new Vector2(-11.5f, 0); random = 0; bullet.transform.position = bob_pos; }
        if (random == 2) { bob_pos = new Vector2(11.5f, 0); random = 0; bullet.transform.position = bob_pos; }
        if (random == 3) { bob_pos = new Vector2(0, 5.5f); random = 0; bullet.transform.position = bob_pos; }
        if (random == 4) { bob_pos = new Vector2(11.5f, 5.5f); random = 0; bullet.transform.position = bob_pos; }
        if (random == 5) { bob_pos = new Vector2(-11.5f, 5.5f); random = 0; bullet.transform.position = bob_pos; }
    

       
        
      
    }
    




        IEnumerator time_randomiser() 
    {
        yield return new WaitForSeconds(1);
        time = time + 1;
        StartCoroutine(time_randomiser());

    }
  
}