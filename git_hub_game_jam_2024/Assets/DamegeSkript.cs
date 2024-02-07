using UnityEngine;

public class DamegeSkript : MonoBehaviour
{
    public int damageAmount = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                // Deal damage to the enemy
               

                // Optionally, perform other actions when the player damages the enemy
            }
        }
    }
}
