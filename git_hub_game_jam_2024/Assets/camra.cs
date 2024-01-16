using UnityEngine;

public class camra : MonoBehaviour
{
    private Vector3 offset = new Vector3(1f, 1f, -10f);
    private float smoothTime = 1.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}