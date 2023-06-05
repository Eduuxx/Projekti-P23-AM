using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public Player target;
    public bool triesToTarget = true;
    private Animator animator;
    private Enemy self;
    private Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        self = GetComponentInParent<Enemy>();
        targetTransform = GameObject.FindWithTag("GroundChecker").transform;
    }

    private void rotateToTarget()
    {
        transform.LookAt(targetTransform);

        // Vector3 direction = targetTransform.position - transform.position; // Find out where player is relative to zombie's position
        // Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        // transform.rotation = rotation;
    }

    private void moveToTarget()
    {
        agent.isStopped = false;
        agent.SetDestination(targetTransform.position);
        animator.Play("Spotted player");
        rotateToTarget();
    }

    private void idle()
    {
        agent.isStopped = true;
        animator.Play("No players spotted");
    }


    // Update is called once per frame
    void Update()
    {
        if (triesToTarget && self.playerInRadius)
        {
            moveToTarget();
        }
        else if (triesToTarget && !self.playerInRadius)
        {
            idle();
        }
    }
}
