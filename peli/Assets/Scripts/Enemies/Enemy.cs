using System.Collections;
using System.Collections.Generic;
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

    private float bodyDestroyDelay = 10f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        biter = GetComponentInChildren<BiteRadius>();
        aiController = GetComponent<EnemyAI>();
        collider = GetComponent<CapsuleCollider>();
        this.maxHP = 100;
        HP = maxHP;
    }

    public void SetSpawner(EnemySpawner spawner)
    {
        this.spawner = spawner;
    }

    public void incrementKills()
    {
        int oldKills = int.Parse(GameObject.Find("KillCounter").GetComponent<UnityEngine.UI.Text>().text);
        GameObject.Find("KillCounter").GetComponent<UnityEngine.UI.Text>().text = (++oldKills).ToString();
    }

    public override void onDeath() 
    {
        if (spawner != null)
        {
            spawner.DecreaseEnemyCount(); // Notify the spawner when the enemy is destroyed
        }

        aiController.triesToTarget = false;
        biter.triesToBite = false;
        collider.enabled = false;
        animator.Play("Died");

        incrementKills();
        StartCoroutine(destroyBody()); // Destroy body after 10 seconds
    }

    IEnumerator destroyBody() 
    {
        yield return new WaitForSeconds(bodyDestroyDelay);
        Destroy(gameObject);
    }
}
