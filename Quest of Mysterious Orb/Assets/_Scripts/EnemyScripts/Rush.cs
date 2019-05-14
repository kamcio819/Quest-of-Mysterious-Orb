using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent agent;
    Transform target;
    public float lookRadius = 10f;
    private static bool aggro = false;
    public float attackCooldown = 1f;
    private bool attackAbility = true;
    public float speedMax = 10f;
    public float speedDecrease = 1f;
    public float attackRange = 3f;
    public float rushTime = 1f;
    public float rushDelay = 2f;
    private float initialRushDelay = 1f;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartRush());
    }

    IEnumerator StartRush()
    {
        attackAbility = true;
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= attackRange)
        {
            FaceTarget();
            if (attackAbility == true)
            {
                attack();
                Debug.Log("Make attack");
            }
        }
        agent.autoBraking = true;
        GetComponent<Patrol>().enabled = false;
        agent.stoppingDistance = attackRange;
        agent.SetDestination(target.position);
        agent.isStopped = true;
        yield return new WaitForSeconds(initialRushDelay);
        agent.isStopped = false;
        agent.speed = speedMax;
        yield return new WaitForSeconds(rushTime);
        initialRushDelay = rushDelay;

        Debug.Log("koniec");
        StartCoroutine(StartRush());
    }




    void attack()
    {
        //attack animation, sound, damage to the player
    }


    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}