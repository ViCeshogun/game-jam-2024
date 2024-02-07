using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book_animation : MonoBehaviour
{


    public bool book_true;
    public GameObject self;
    public Animator animat;
    public bool book_swap;
    public bool run_once;
    public int check_1;
    public int check_2;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    public void Update()
    {

        
        check_1 = check_2 + 3;
        if (Input.GetKey(KeyCode.E) && check_1 >= 5) { book_true = true;  StartCoroutine(end()); }
        animat.SetBool("bookopen", book_true);
        animat.SetBool("NewBool", book_swap);
        StartCoroutine(book_relay());
        
    }


    IEnumerator book_relay()
    {
        yield return new WaitForSeconds(1.8f);
        book_swap = true;
        check_2 = 7;
    }

    IEnumerator end()
    {
        yield return new WaitForSeconds(1f);
        book_swap = false;
        book_true = false;
        check_1 = 0;
        check_2 = 0;
        self.SetActive(false);
        
    }
}
