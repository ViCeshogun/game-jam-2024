using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using static UnityEngine.GraphicsBuffer;
using System.Diagnostics;


public class swing : MonoBehaviour
{
    public Transform anchor;
    public GameObject self;
    public float swing_val;
    public bool is_swining;
    public int swings;
    public int has_swung;
    public int spin_cap;
    public int Finished_swinign;
    // Start is called before the first frame update
    public void Start()
    {
        spin_cap = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Finished_swinign == 0) { anchor.rotation = Quaternion.Euler(0, 0, swing_val); }
       if (swing_val > -10&& swing_val< 10) { spin_cap =60- swings; }
       if (spin_cap == 0) { spin_cap = 60; Finished_swinign = 1; swing_val = 0; swings = 0; }
    }

    private void OnCollisionEnter2D(Collision2D collsion)
    {
        
        if (collsion.gameObject.tag == "Player") 
        {
            
            StartCoroutine(spin());
            anchor.rotation = Quaternion.Euler(0, 0, swing_val);
            is_swining = true;
            Finished_swinign = 0;
            swing_val = swing_val - collsion.relativeVelocity.x+ collsion.relativeVelocity.y;
            
        }


    }


    IEnumerator spin()
    {
        yield return new WaitForSeconds(0.01f);


        if (swing_val <= 0- spin_cap) { 
            is_swining = false;
            has_swung = 1;
            if (has_swung == 1) { swings += 3; has_swung = 0;  }
        }
        if (swing_val >= spin_cap) 
        { is_swining = true; 
            has_swung = 1;
            if (has_swung == 1) { swings += 3; has_swung = 0; }
        }
        if (is_swining == true)
        { 
            swing_val = swing_val - 1;
           
        }

        if (is_swining == false) 
        { 
            swing_val = swing_val + 1;
           

        }

        if (Finished_swinign == 0) { StartCoroutine(spin()); }
    }


}


