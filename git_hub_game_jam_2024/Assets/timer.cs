using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    // the value that will show up
    public float time;

    // Start is called before the first frame update
    public void Start()
    {
        // what starts the timer 
        StartCoroutine(Timer());

    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator Timer()
    {
        // the time between the change in seconds 
        yield return new WaitForSeconds(0.1f);
        // the values change
        time += 0.1f;
        // the continuation of the timer
        StartCoroutine(Timer());

    }

}
