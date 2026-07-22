using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Asteroid Settings")]
    public GameObject asteroidPrefab;

    [Header("Spawn Timing")]
    public float startSpawnInterval = 3f;
    public float minSpawnInterval = 1f;
    public float spawnDecreaseRate = 0.1f;
    public float intervalDecreaseTime = 10f;

    [Header("Spawn Area (X-axis)")]
    public float minX = -8f;
    public float maxX = 8f;
    public float spawnY = 6f; // Y-position at top of screen

    private float currentSpawnInterval;
    private float nextSpawnTime;
    private float lastDecreaseTime;

    void Start()
    {
        ResetSpawner();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnAsteroid();
            nextSpawnTime = Time.time + currentSpawnInterval;
        }

        if (Time.time >= lastDecreaseTime + intervalDecreaseTime && currentSpawnInterval > minSpawnInterval)
        {
            currentSpawnInterval -= spawnDecreaseRate;
            currentSpawnInterval = Mathf.Max(currentSpawnInterval, minSpawnInterval); // Clamp to min
            lastDecreaseTime = Time.time;
        }
    }

    void SpawnAsteroid()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), spawnY, 0f);
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
    }

    public void ResetSpawner()
    {
        currentSpawnInterval = startSpawnInterval;
        nextSpawnTime = Time.time + currentSpawnInterval;
        lastDecreaseTime = Time.time;
    }
}
