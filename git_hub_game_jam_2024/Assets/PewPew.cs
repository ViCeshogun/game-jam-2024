using System.Collections;
using UnityEngine;

public class PewPew : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public GameObject projectilePrefab; // Prefab of the projectile
    public float shootingCooldown = 2f; // Cooldown between shots
    public float projectileSpeed = 5f; // Set the projectile speed here

    private bool canShoot = true; // Flag to control shooting cooldown

    void Update()
    {
        // Check if the shooting cooldown is over
        if (canShoot)
        {
            ShootProjectile();
            StartCoroutine(ShootingCooldown());
        }
    }

    void ShootProjectile()
    {
        // Instantiate a projectile prefab and launch it towards the player
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (rb != null && player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * projectileSpeed; // Set projectile speed here
        }
    }

    IEnumerator ShootingCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootingCooldown);
        canShoot = true;
    }
}
