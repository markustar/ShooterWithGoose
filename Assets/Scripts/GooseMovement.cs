using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GooseMovement : MonoBehaviour
{   
    // public Transform target;
    // public float speed;
    // public float attackRange;
    // public float resetRange;

    // private Animator animator;
    // private bool isAttacking;

    // private void Start() {
    //     animator = GetComponent<Animator>();
    // }

    // private void Update() {
    //     transform.LookAt(target.position);
    //     float distanceToTarget = Vector3.Distance(transform.position, target.position);

    //     if (!isAttacking)
    //     {
    //         if (distanceToTarget > attackRange)
    //         {
    //             MoveToTarget();
    //         }
    //         else
    //         {
    //             isAttacking = true;
    //             animator.SetTrigger("Fight");
    //         }
    //     }
    //     else 
    //     {
    //         if (distanceToTarget > resetRange)
    //         {
    //             isAttacking = false;
    //             animator.SetTrigger("Walk");
    //         }
                
    //     }
    // }

    // void MoveToTarget()
    // {
    //     transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);
    // }
    public PlayerHealth DamagePlayer;
    public float nearToPlayer;
    public float cooldown = 0;
    public Transform target;
    private Animator animator;
    private NavMeshAgent agent;
    public float Health = 50f;

    private void Start() {
        Health = 50f;
        cooldown = 0;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        // Example: Find target by tag and assign its transform
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() {
        if(Health <= 0)
        {
            Destroy(this.gameObject);
        }
        if(cooldown >= 1f)
        {
            nearToPlayer = Vector3.Distance(target.position, transform.position);
            if(nearToPlayer <= 2f)
            {
                DamagePlayer.PlayerTakeDamage();
                animator.SetTrigger("Fight");
                Debug.Log("Goose is atacking");
                cooldown = 0f;
            }
            else
            {
                animator.SetTrigger("Walk");
            }
        }
        cooldown += Time.deltaTime;
        agent.destination = target.position;
    }


    public void TakeDamage()
    {
        Health -= 10;
    }

}
