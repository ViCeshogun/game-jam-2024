using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 20;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Perform actions when the enemy dies, e.g., play death animation, spawn particles, etc.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
