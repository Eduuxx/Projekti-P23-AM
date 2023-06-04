using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    private EnemySpawner spawner; // Reference to the spawner

    private void Start()
    {
        this.maxHP = 100;
        HP = maxHP;
        InvokeRepeating("UpdateDestination", 0f, 0.5f);
    }

    private void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.DecreaseEnemyCount(); // Notify the spawner when the enemy is destroyed
        }
    }

    public void SetSpawner(EnemySpawner spawner)
    {
        this.spawner = spawner;
    }

    public override void onDeath() 
    {
        Destroy(gameObject);
    }
}