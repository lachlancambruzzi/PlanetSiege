using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the SpaceShipHealthManager script
        SpaceShipHealthManager healthManager = collision.gameObject.GetComponent<SpaceShipHealthManager>();

        if (healthManager != null)
        {
            healthManager.TakeDamage(damageAmount);

            // Optionally, destroy the bullet after hitting the spaceship
            Destroy(gameObject);
        }
    }
}