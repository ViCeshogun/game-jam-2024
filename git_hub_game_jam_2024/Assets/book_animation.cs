using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book_animation : MonoBehaviour
{

   
    public bool book_true;
    public GameObject self;
    public Animator animat;
    public bool book_swap;
    // Start is called before the first frame update
    void Start()
    {
        self.SetActive (false);

    }

    // Update is called once per frame
   public void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)) { book_true = false; }
        animat.SetBool("openbook", book_true);
        animat.SetBool("NewBool", book_swap);
        StartCoroutine(book_relay());
    }


    IEnumerator book_relay()
    {
        yield return new WaitForSeconds(3);
       self.SetActive(true);
        book_true = true;
       book_swap = false;
    }
}
