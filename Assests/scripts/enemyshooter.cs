using UnityEngine;

public class enemyshooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public Transform player;
    public float projectileSpeed = 20f;
    public float fireRate = 2f;
    private float fireTimer;

    void Update()
    {
        if (player == null) return;

        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            fireTimer = 0f;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = (player.position - firePoint.position).normalized;
            rb.linearVelocity = direction * projectileSpeed;
        }

        Destroy(projectile, 5f); // cleanup
    }
}
