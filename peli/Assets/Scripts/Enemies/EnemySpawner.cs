using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 10;
    public float spawnDelay = 2f;
    public bool playersInRadius = false;

    private int currentEnemies = 0;
    private bool isSpawningOnCooldown = false;

    private void Update()
    {
        if (playersInRadius && !isSpawningOnCooldown)
        {
            StartCoroutine(spawnEnemy());
        }
    }

    private IEnumerator spawnEnemy()
    {
        if (currentEnemies < maxEnemies)
        {
            isSpawningOnCooldown = true;

            // Calculate a random position within a sphere around the transform position
            Vector3 randomSpreadOffset = Random.insideUnitSphere * 30;
            randomSpreadOffset.y = 0; // Ignore the y-coordinate to keep enemies on the ground level

            Vector3 spawnPosition = transform.position + randomSpreadOffset;

            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.SetSpawner(this); // Pass a reference to the spawner to the enemy

            currentEnemies++;

            yield return new WaitForSeconds(spawnDelay);

            isSpawningOnCooldown = false;
        }
    }

    public void DecreaseEnemyCount()
    {
        currentEnemies--;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") playersInRadius = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") playersInRadius = false;
    }
}
