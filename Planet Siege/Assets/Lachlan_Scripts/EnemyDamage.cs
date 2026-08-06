using UnityEngine;
using UnityEngine.Events;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;

    public UnityEvent playerHit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if collided object has the tag "Player" (your spaceship)
        if (collision.gameObject.CompareTag("Player"))
        {
            // Try to get the SpaceShipHealthManager component
            SpaceShipHealthManager healthManager = collision.gameObject.GetComponent<SpaceShipHealthManager>();

            if (healthManager != null)
            {
                // Apply damage
                healthManager.TakeDamage(damageAmount);
            }

            playerHit.Invoke();
        }
    }
}