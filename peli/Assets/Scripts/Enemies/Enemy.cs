using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    private EnemySpawner spawner; // Reference to the spawner
    [System.NonSerialized]
    public Player playerInRadius = null;

    private void Start()
    {
        this.maxHP = 100;
        HP = maxHP;
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
        Debug.Log("died");
        Destroy(gameObject);
    }
}