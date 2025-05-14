using UnityEngine;

public class EnemyFlyer : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float hoverDistance = 10f;
    public float rotateSpeed = 75f; // Try 50+

    private float currentAngle = 0f;

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player not assigned!");
            return;
        }

        // Increase angle over time
        currentAngle += rotateSpeed * Time.deltaTime;

        // Calculate new position in a circle around player
        float radians = currentAngle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Cos(radians), 0, Mathf.Sin(radians)) * hoverDistance;

        // Set position to orbit + fixed height
        Vector3 desiredPosition = player.position + offset + Vector3.up * 5f;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, moveSpeed * Time.deltaTime);

        // Face the player
        transform.LookAt(player);
transform.Rotate(0, 180f, 0); // Flips the look direction


        Debug.DrawLine(transform.position, player.position, Color.red); // Debug line
    }
}
