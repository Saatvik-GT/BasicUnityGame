using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public float damage = 10f;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Projectile hit: " + collision.gameObject.name); // 💥 Check what it hits

        // Check if hit object has PlayerHealthUI
        PlayerHealthUI playerHealth = collision.gameObject.GetComponent<PlayerHealthUI>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }

        Destroy(gameObject); // Destroy the projectile after hitting
    }
}
