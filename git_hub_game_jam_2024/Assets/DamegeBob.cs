using UnityEngine;

public class DamegeBob : MonoBehaviour
{
    public GameObject linkedObject;
    public int damageOnDestroy = 10;

    private void OnDestroy()
    {
        if (linkedObject != null)
        {
            // Assuming the linkedObject has an EnemyHealth script
            EnemyHealth enemyHealth = linkedObject.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                // Deal damage to the linked object
                enemyHealth.TakeDamage(damageOnDestroy);
            }
        }
    }
}

