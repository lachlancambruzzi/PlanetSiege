using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public GameObject healthPickupPrefab;
    public float healthPickupSpawnChance = 0.3f; // 30% chance

    private GameObject player;
    private Vector2 faceDirection;

    private HealthSystemAttribute healthSys;

    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed;

    private AudioSource hitSound;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        healthSys = GetComponent<HealthSystemAttribute>();

        Debug.Log(healthSys.health);

        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocityY = moveSpeed;

        hitSound = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        faceDirection = player.transform.position - transform.position;
        transform.up = faceDirection;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Earth"))
        {
            /*
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
            */
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            
            Destroy(collision.gameObject); // Destroy the bullet

            Debug.Log(healthSys.health);

            if(healthSys.health <= 0)
            {
                TrySpawnHealthPickup();
                GameManager.instance.gameSoundPlayer.PlayEnemyShipExplodeSound();
            }

            hitSound.Play();
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
        //Debug.Log("🎲 Random value: " + chance + " | Spawn threshold: " + healthPickupSpawnChance);

        if (chance < healthPickupSpawnChance)
        {
            Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, 0); // Force Z = 0
            GameObject spawnedPickup = Instantiate(healthPickupPrefab, spawnPos, Quaternion.identity);
            //Debug.Log("✅ Health pickup spawned at: " + spawnedPickup.transform.position);
        }
        else
        {
            //Debug.Log("⛔ Health pickup NOT spawned (chance too low).");
        }
    }
}
