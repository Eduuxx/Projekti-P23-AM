using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    private EnemySpawner spawner; // Reference to the spawner
    private CapsuleCollider collider;
    private BiteRadius biter;
    private EnemyAI aiController;
    private Animator animator;
    [System.NonSerialized]
    public Player playerInRadius = null;

    private void Start()
    {
        animator = GetComponent<Animator>();
        biter = GetComponentInChildren<BiteRadius>();
        aiController = GetComponent<EnemyAI>();
        collider = GetComponent<CapsuleCollider>();
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
        aiController.triesToTarget = false;
        biter.triesToBite = false;
        collider.enabled = false;
        animator.Play("Died");
    }
}
