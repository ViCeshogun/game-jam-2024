using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_wall : MonoBehaviour
{
    public Collider2D self;
    public Collider2D self2;
    public camra bob;
    // Start is called before the first frame update
    void Start()
    {
        self.isTrigger = true;
        bob.bob.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        self.isTrigger = false;
        bob.bob.SetActive(true);
    }
}
