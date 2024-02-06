using
    System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book_appire : MonoBehaviour
{
    public GameObject book;
    public book_animation book_script;
    public bool book_time;
    public bool Is_here;
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        book_script.self.SetActive(false);
        name = "Player";
    }

    // Update is called once per frame
    void Update()
    {
        if (Is_here == true) { 
            
            
            
            if (Input.GetKey(KeyCode.E)== true) { book_script.book_true = true; book.SetActive(true); book_script.book_swap = false;  Debug.Log("why"); } 
        
        
        
        }
        if (book_script.book_true == true && book_script.book_swap == true) { name = "Player"; }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.tag == name)
        {

            name = "";
            if (book_script.self.active == false) { book_script.self.SetActive(true); }
            Debug.Log("found");
            Is_here = true;

        }
      
    }
    public void OnTriggerExit2D(Collider2D other)
    {
       

            Is_here = false;
        
    }


    


}
