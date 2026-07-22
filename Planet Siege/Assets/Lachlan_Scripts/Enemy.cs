using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            ScoreManager.instance.AddScore(1);
            Destroy(other.gameObject); // Destroy the bullet
            Destroy(gameObject);       // Destroy the enemy
        }
    }
}