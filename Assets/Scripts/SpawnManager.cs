using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject playerPrefab; // Player prefab to spawn
    public GameObject[] enemyPrefabs; // Array of enemy prefabs to spawn
    public float spawnInterval = 2f; // Time between spawns

    // Define min and max ranges for x and z positions
    public float x_min = -7f;
    public float x_max = 7f;
    public float z_min = -2f;
    public float z_max = 13f;

    public Vector3 playerSpawnPosition; // The position where the player should spawn
    private bool spawning = true; // Control spawning

    void Start()
    {
        // Spawn the player once at the start
        // SpawnPlayer();

        // Start the enemy spawning coroutine
        StartCoroutine(SpawnEnemies());
    }

    void SpawnPlayer()
    {
        if (playerPrefab != null)
        {
            Instantiate(playerPrefab, playerSpawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Player prefab is not assigned.");
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (spawning)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(spawnInterval);

            // Select a random enemy prefab from the array
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyPrefab = enemyPrefabs[randomIndex];

            // Generate random x and z positions within the specified range
            float x = Random.Range(x_min, x_max);
            float z = Random.Range(z_min, z_max);
            Vector3 spawnPosition = new Vector3(x, 0, z); // Ensure the y position is 0 for ground level

            // Instantiate the random enemy at the generated position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // Optionally, a method to stop spawning if needed
    public void StopSpawning()
    {
        spawning = false;
    }

    // Optionally, a method to start spawning again if needed
    public void StartSpawning()
    {
        if (!spawning)
        {
            spawning = true;
            StartCoroutine(SpawnEnemies());
        }
    }
}