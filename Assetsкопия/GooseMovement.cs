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
    public bool nearToPlayer = false;
    public float cooldown = 0;
    public Transform target;
    private Animator animator;
    private NavMeshAgent agent;

    private void Start() {
        cooldown = 0;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if(cooldown >= 1f)
        {
            if(nearToPlayer)
            {
                animator.SetTrigger("Fight");
                Debug.Log("Goose is atacking");
            }
            else
            {
                animator.SetTrigger("Walk");
            }
        }
        cooldown += Time.deltaTime;
        agent.destination = target.position;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            nearToPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            nearToPlayer = false;
        }
    }

}
