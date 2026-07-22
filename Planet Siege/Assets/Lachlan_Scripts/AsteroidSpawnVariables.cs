using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject objectToSpawn;                    // Prefab to spawn
    public Vector3 spawnAreaSize = new Vector3(5, 0, 5); // Dimensions of the spawn area box

    [Header("Spawn Rate Control")]
    public float initialSpawnInterval = 2f;             // Time between spawns at the start
    public float minSpawnInterval = 0.2f;               // Fastest spawn interval
    public float difficultyRampTime = 60f;              // Time over which the spawn rate speeds up

    void Start()
    {
        StartCoroutine(SpawnObjects()); // Start the spawning loop
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Calculate time since game start
            float elapsedTime = Time.time;

            // Interpolate spawn interval based on how long the game has been running
            float t = Mathf.Clamp01(elapsedTime / difficultyRampTime);
            float currentSpawnInterval = Mathf.Lerp(initialSpawnInterval, minSpawnInterval, t);

            SpawnObject();
            yield return new WaitForSeconds(currentSpawnInterval);
        }
    }

    void SpawnObject()
    {
        // Generate a random position inside the defined spawn area
        Vector3 randomOffset = new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        Vector3 spawnPosition = transform.position + randomOffset;

        // Instantiate the object at the calculated position
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        // Draw the spawn area box in the scene view for visual debugging
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}