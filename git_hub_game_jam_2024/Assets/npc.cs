using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{

    public Rigidbody2D self;
    public float random;
    public Vector2 pos;
    public int can_move;
    // Start is called before the first frame update
    public void Start()
    {
        can_move = 1;
        StartCoroutine(randomiser());
        pos = self.transform.position;
    }

    // Update is called once per frame
  public void Update()
    {
       if (random == 1 && can_move==1) { self.AddForce (new Vector2(1, 0)); self.drag = 1; } 
       if (random == 2 && can_move == 1) { self.AddForce (new Vector2(-1, 0)); self.drag = 1; } 
       if (random == 3 && can_move == 1) { self.drag = 1000; } 

       if (self.transform.position.x >pos.x +7) 
        { 
            can_move = 0;
            StartCoroutine(retern());
            self.AddForce(new Vector2(-2, 0));
        }

       if (self.transform.position.x <pos.x -7) 
        {
           can_move = 0; 
            StartCoroutine(retern());
            self.AddForce(new Vector2(2, 0));
        }
    }


    public IEnumerator randomiser()
    {
        
        yield return new WaitForSeconds(1);
        random = Random.Range(1, 4);
        StartCoroutine(randomiser());

    }

    public IEnumerator retern() 
    {
        yield return new WaitForSeconds(2);
        can_move = 1;
    }
}
