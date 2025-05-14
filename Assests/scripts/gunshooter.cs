using UnityEngine;

public class GunShooter : MonoBehaviour
{
    [SerializeField] private Camera fpsCam;       // Assign this in the Inspector
    [SerializeField] private float range = 100f;   // Shooting distance
    [SerializeField] private float damage = 10f;   // Damage amount

    [SerializeField] private GameObject bulletPrefab; // Bullet visual
    [SerializeField] private Transform gunMuzzle;     // Bullet spawn point
    [SerializeField] private float bulletSpeed = 20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if (fpsCam == null)
        {
            Debug.LogError("fpsCam is not assigned in the Inspector!");
            return;
        }

        // ✅ Raycast forward
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            // ✅ Try to apply damage
            EnemyHealth enemy = hit.transform.GetComponentInParent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        FireBullet(); // ✅ Visual effect
    }

    void FireBullet()
    {
        if (bulletPrefab == null || gunMuzzle == null)
        {
            Debug.LogError("BulletPrefab or GunMuzzle is not assigned!");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, gunMuzzle.position, gunMuzzle.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = gunMuzzle.forward * bulletSpeed;
        }

        Destroy(bullet, 5f); // Optional cleanup
    }
}

