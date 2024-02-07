using System.Collections;

using System.Diagnostics.SymbolStore;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class camra : MonoBehaviour
{
    public GameObject bob;
    public Vector2 player_pos;
    public Transform bullet;
    public GameObject player;
    public GameObject camra_pos;
    public int random;
    public bool is_on;
    public bool is_chasing;
    public float rotate_value;
    public void Update()
    {
        if (is_on == true) { StartCoroutine(shoot()); is_on = false;  }
        bullet.transform.position = bullet.transform.position;
        if (is_chasing == true)
        {
           
            bullet.position = Vector3.MoveTowards(bullet.position, player_pos, 0.05f); 
        }

     

        
    }


    public void Start()
    {

      


    }
    
    IEnumerator shoot()
    {
        
        Debug.Log("1");
        player_pos = player.transform.position;
       
        is_chasing = true;
        yield return new WaitForSeconds(2f);
        is_chasing = false;
        bullet.tag = "";
        yield return new WaitForSeconds(0.5f);
        bullet.tag = "Enamy";
        is_back();
        bullet.position = bob.transform.position;
        StartCoroutine(shoot());
        yield return new WaitForSeconds(1);


    }


    public void is_back() 
    {
        random = Random.Range(1, 4);
    if (random== 2) { above(); random = Random.Range(1, 3); }
    if (random== 1) { left(); random = Random.Range(1, 3); }
    if (random== 3) { right(); random = Random.Range(1, 3); }

    }


    public void above() 
    {

        bob.transform.position = new Vector2(camra_pos.transform.position.x+ Random.Range(-10,10), camra_pos.transform.position.y+7.5f);
      
    }

    public void left() 
    {
        if (Random.Range(1, 3) == 2) 
        {  
            bob.transform.position = new Vector2(camra_pos.transform.position.x-9f, camra_pos.transform.position.y+ Random.Range(1, 10));
           
        }
       

    }
    public void right() 
    {
        if (Random.Range(1, 3) == 2)
        {
            bob.transform.position = new Vector2(camra_pos.transform.position.x+9f, camra_pos.transform.position.y+ Random.Range(1, 10));
      
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        
    }

}