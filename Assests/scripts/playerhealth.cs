using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public Image healthFillImage; // Drag the red image here in inspector

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        float fillAmount = currentHealth / maxHealth;
        healthFillImage.fillAmount = fillAmount;

        // ✅ Log to check if damage is received
        Debug.Log("Player took damage! Current Health: " + currentHealth);
    }
}



