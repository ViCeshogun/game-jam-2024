using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scan_for_player : MonoBehaviour
{
    public GameObject self;
    public timer timer_script;
    public int run_scan;
    public int scale;
    public bool grow;
    // Start is called before the first frame update
    public void Start()
    {
        run_scan = 0;
        grow = true;
    }

    // Update is called once per frame
    public void Update()
    {
        //self.transform.localScale = new Vector3(scale,10, 0);

        if (timer_script.time >= 10 && run_scan != 1)
        {
            run_scan = 1;
            Debug.Log("grow and shrink");
            StartCoroutine(scan());
        }
        if (self.transform.localScale == new Vector3(64, 10, 0)) { grow = false; Debug.Log("grow and shrink"); self.transform.position = new Vector2(16,0); }
       if ( scale < 1) { }

    }

    public IEnumerator scan() 
    {
        Debug.Log("grow and shrink");
        yield return new WaitForSeconds(1f);


      //if (grow == true) scale =scale+ 1;
      //if (grow == false) scale =scale- 1;
        StartCoroutine(scan());
    }
}
