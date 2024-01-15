using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class wall_jump : MonoBehaviour
{// the wal
    public GameObject self;
    // the player script
    public player_movent player_script;
    public PhysicsMaterial2D wall_friciton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collsion)
    {
        
        if (collsion.gameObject.tag == "Player")
        {
            // this changes the jump force
            player_script.wall_jump = true;
            // starts the ienumerator line
            
          
        }
        
    }
   

}
