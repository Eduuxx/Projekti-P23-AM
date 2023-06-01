using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 10;
    public float spawnDelay = 2f;

    private int currentEnemies = 0;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnDelay);
    }

    private void SpawnEnemy()
    {
        if (currentEnemies >= maxEnemies)
            return;

        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * 5;
        spawnPosition.y = 0; // Ensure enemies spawn at ground level

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        enemyScript.SetSpawner(this); // Pass a reference to the spawner to the enemy

        currentEnemies++;
    }

    public void DecreaseEnemyCount()
    {
        currentEnemies--;
    }
}
