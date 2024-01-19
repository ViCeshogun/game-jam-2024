using
    System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book_appire : MonoBehaviour
{
    public GameObject book;
    public book_animation book_script;
    public bool book_time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E)) { book_script.book_true = false; }
        book_script.book_swap = true;

    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.tag == "Player")
        {

            
            Debug.Log("found");

        }

    }

   
}
