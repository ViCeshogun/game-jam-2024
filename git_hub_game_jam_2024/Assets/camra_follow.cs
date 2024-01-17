using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camra_follow : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D self;
    public Rigidbody2D player;

  

    private void Update()
    {
        self.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,-10);



    }
}
