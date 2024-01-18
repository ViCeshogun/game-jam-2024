using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_script : MonoBehaviour
{public GameObject bullet;
    public GameObject player;
    public vector2D player_pos;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player_pos = player.transform.position;



    }
}
