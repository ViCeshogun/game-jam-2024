using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_jump : MonoBehaviour
{
    public GameObject self;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D tag)
    {
        if (tag.gameObject.tag == "Player")
        {
            

        }
    }


}
