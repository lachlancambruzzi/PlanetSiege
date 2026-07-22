using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int healAmount = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collected the pickup
        if (other.CompareTag("Player"))
        {
            // Find the Earth in the scene
            EarthHealthManager earth = FindObjectOfType<EarthHealthManager>();
            if (earth != null)
            {
                earth.Heal(healAmount);
            }

            Destroy(gameObject); // Destroy the pickup after collection
        }
    }
}