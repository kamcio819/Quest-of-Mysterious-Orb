using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Helper script for Charge enemy interactions.

public class Rush : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent agent;
    Transform target;
    public float attackDamage = 10f;
    public float lookRadius = 10f;
    public float attackCooldown = 1f;
    public float speedMax = 20f;
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
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= attackRange)
        {
            FaceTarget();
            Debug.Log("Make attack");
            attack();
        }
        agent.autoBraking = true;
        this.GetComponent<Patrol>().enabled = false;
        agent.stoppingDistance = attackRange;
        agent.SetDestination(target.position);
        //tutaj mozna wstawic jakas animacje przygotoywania sie do ataku (boostery czy cos tam)
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
        //Tutaj bedzie animacja ataku, ogdlos ataku, obrazenia dla gracza itp.
    }

    /*private void OnTriggerEnter(Collider collision) //     nie chce to dzialac
    {
        if (collision.tag.Equals("Player"))
        {
            Debug.Log("hit");
            //Tutaj mozna dac odglos walniecia, obrazenia dla gracza, itd.
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hitObject) //      to tez qq
    {
        if (hitObject.collider.tag.Equals("Player"))
        {
            Debug.Log("hit");
            //Tutaj mozna dac odglos walniecia, obrazenia dla gracza, itd.
        }
    }*/

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