using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    private float maxHP = 100;
    private Transform player;
    public NavMeshAgent navMeshAgent;
    private EnemySpawner spawner; // Reference to the spawner

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        HP = maxHP;
        InvokeRepeating("UpdateDestination", 0f, 0.5f);
    }

    private void UpdateDestination()
    {
        if (player != null && navMeshAgent != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
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
}