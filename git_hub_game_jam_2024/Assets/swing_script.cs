using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using static UnityEngine.GraphicsBuffer;
using System.Diagnostics;
using TMPro;
using UnityEditor.UIElements;

public class swing_script : MonoBehaviour
{
    public GameObject slef;
    public Transform anchor;
    public float swing_val;
    public bool swing_true_false;
    public bool can_swing;
    public int swing_cap;
    public int swing_back;
    public int swing_change;
    public float swing_force;
    public Collider2D self;
    public string player;
    // Start is called before the first frame update
  public  void Start()
    {
        swing_cap = 60;
        swing_force = 1;
        
        player = "Player";
    }

    // Update is called once per frame
   public void Update()
    {


        if (Input.GetKey(KeyCode.Backspace) && player == "nothing") {
            self.isTrigger = true;
            StartCoroutine(trigger_on_off());
        }


        if (swing_val > -10 && swing_val < 10) { swing_cap = 60 - swing_back; }
     if (can_swing == false) { anchor.rotation = Quaternion.Euler(0, 0, swing_val); }   
     if (swing_cap <= 0) { swing_val = 0; can_swing = true; swing_back = 0; swing_cap = 60; player = "Player"; }
     if (swing_cap <= 42&& swing_force>20) { swing_force = 0.5f; }
     if (swing_cap <= 20&& swing_force>11) { swing_force = 0.4f; }
     if (swing_cap <= 11) { swing_force = 0.3f; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == player) 
        {
            player = "nothing";
            can_swing = false;
            StartCoroutine(swinging());
        
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        self.isTrigger = true;
        StartCoroutine(trigger_on_off());
    }

    public IEnumerator swinging()
    {
        yield return new WaitForSeconds(0.01f);
        
        if (swing_val > swing_cap && swing_change == 0) { swing_true_false = true; swing_change = 1; }
        if (swing_val < -swing_cap && swing_change == 1) { swing_true_false = false; swing_back += 8; swing_change = 0; }

        if (swing_true_false == false&& can_swing == false) {swing_val = swing_val + swing_force;  }
        if (swing_true_false == true && can_swing == false) { swing_val = swing_val - swing_force;   } 
        StartCoroutine(swinging());
    }

    public IEnumerator trigger_on_off()
    {
        yield return new WaitForSeconds(1f);
        self.isTrigger = false;

    }
}
