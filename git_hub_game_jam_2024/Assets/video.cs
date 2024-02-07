using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class video : MonoBehaviour
{
    public GameObject vide;
    public GameObject open;
    public Enemy enamy_script;

    private void Start()
    {
        StartCoroutine(video_end());
    }

    IEnumerator video_end() 
    {
        yield return new WaitForSeconds(5);
        enamy_script.time = 0;
        Destroy(open);
        Destroy(vide);


    }

}