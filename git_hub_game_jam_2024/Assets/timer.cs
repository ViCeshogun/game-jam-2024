using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    // the value that will show up
    public float time;
    [SerializeField] private Text TimerText;

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
        yield return new WaitForSeconds(1f);
        // the values change
        time += 1f;
        StartCoroutine(Timer());
        TimerText.text = "Time: " + time;
        // the continuation of the timer
        

    }

}
