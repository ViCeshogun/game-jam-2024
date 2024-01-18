using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scan_for_player : MonoBehaviour
{
    public GameObject self;
    public timer timer_script;
    public int run_scan;
    public float scale;
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

        self.transform.localScale = new Vector2(scale,10);
        if (timer_script.time >= 10 && run_scan != 1)
        {
            run_scan = 1;

            StartCoroutine(scan());
        }
        if (scale>48) { grow = false;  self.transform.position = new Vector2(16,0); }
       if ( scale < 0) { grow = true; self.transform.position = new Vector2(-16, 0); }

    }

    public IEnumerator scan() 
    {
       
        yield return new WaitForSeconds(0.1f);


        if (grow == true) scale = scale + 1;
        if (grow == false) scale = scale - 1;
        StartCoroutine(scan());
    }
}
