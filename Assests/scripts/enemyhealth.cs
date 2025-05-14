using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    // ADD THIS: Drag the red cube (HealthFill) here in Inspector
    public Transform healthFill;

    private Vector3 initialScale;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthFill != null)
            initialScale = healthFill.localScale;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // ADD THIS: Shrink red bar
        if (healthFill != null)
        {
            float percent = currentHealth / maxHealth;
            healthFill.localScale = new Vector3(initialScale.x * percent, initialScale.y, initialScale.z);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
