using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class video : MonoBehaviour
{
    public GameObject vide;

    private void Start()
    {
        StartCoroutine(video_end());
    }

    IEnumerator video_end() 
    {
        yield return new WaitForSeconds(5);

        Destroy(vide);


    }

}