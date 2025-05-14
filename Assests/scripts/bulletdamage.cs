using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if object has EnemyHealth script
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        // Destroy bullet on any collision
        Destroy(gameObject);
    }
}
