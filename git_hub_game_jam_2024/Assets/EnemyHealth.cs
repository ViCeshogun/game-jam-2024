using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    int hp = 10;
    private void Update()
    {
        
    }

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "No harm"&& hp!=0) 
        {
            hp = hp - 1;
        }
        if (hp == 0) 
        {
        
        
        }
    }


}
