using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Aggro: MonoBehaviour
{
    // Start is called before the first frame update
    Transform target;
    NavMeshAgent agent;
    public float lookRadius = 10f;
    private static bool aggro = false;
    public float attackCooldown = 1f;
    private float attackTimer = 1f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (aggro == false && distance <= lookRadius)
        {
            aggro = true;
            agent.stoppingDistance = 2f;
            GetComponent<Patrol>().enabled = false;

        }
        if (aggro == true)
        {
            attackTimer += Time.deltaTime;
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                if (attackTimer >= attackCooldown)
                {
                    attack();
                    attackTimer = 0;
                }

            }
        }

        void attack()
        {
            //attack animation, sound, damage to the player
        }
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
