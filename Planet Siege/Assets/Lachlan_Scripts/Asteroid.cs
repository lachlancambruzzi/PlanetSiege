using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject healthPickupPrefab;
    public float healthPickupSpawnChance = 0.3f; // 30% chance

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Earth"))
        {
            // Get the EarthHealthManager from the object we hit
            EarthHealthManager healthManager = collision.gameObject.GetComponent<EarthHealthManager>();
            if (healthManager != null)
            {
                healthManager.TakeDamage(10); // Apply damage
                Debug.Log("✅ Asteroid hit Earth and applied damage.");
            }
            else
            {
                Debug.LogWarning("⚠️ EarthHealthManager not found on Earth object!");
            }

            Destroy(gameObject); // Destroy the asteroid
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("✅ Asteroid hit by bullet.");
            TrySpawnHealthPickup();
            Destroy(collision.gameObject); // Destroy the bullet
            Destroy(gameObject);           // Destroy the asteroid

            GameManager.instance.gameSoundPlayer.PlayMeteorSound();
        }
    }

    void TrySpawnHealthPickup()
    {
        Debug.Log("🔄 TrySpawnHealthPickup called");

        if (healthPickupPrefab == null)
        {
            Debug.LogWarning("⚠️ healthPickupPrefab is NOT assigned in the Inspector!");
            return;
        }

        float chance = Random.value;
        Debug.Log("🎲 Random value: " + chance + " | Spawn threshold: " + healthPickupSpawnChance);

        if (chance < healthPickupSpawnChance)
        {
            Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, 0); // Force Z = 0
            GameObject spawnedPickup = Instantiate(healthPickupPrefab, spawnPos, Quaternion.identity);
            Debug.Log("✅ Health pickup spawned at: " + spawnedPickup.transform.position);
        }
        else
        {
            Debug.Log("⛔ Health pickup NOT spawned (chance too low).");
        }
    }
}