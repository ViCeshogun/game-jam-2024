using System.Collections;
using UnityEngine;

public class OpenBook : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Trigger the animation
            animator.SetBool("1", true);
        }
    }
}
