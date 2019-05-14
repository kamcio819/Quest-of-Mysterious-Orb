using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Charge : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    Transform target;
    public float lookRadius = 10f;
    private static bool aggro = false;
    public float attackCooldown = 1f;
    private float attackTimer = 1f;
    public float speedMax = 10;
    public float speedDecrease = 1f;
    public float attackRange = 2f;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
       
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (aggro == false && distance <= lookRadius)
        {
            aggro = true;
            GetComponent<Patrol>().enabled = false;

        }
        if (aggro == true)
        {
            Rush();
            GetComponent<Rush>().enabled = true;
            GetComponent<Charge>().enabled = false;
        }

    }
    IEnumerator Rush()
    {
        GetComponent<Patrol>().enabled = false;
        agent.stoppingDistance = attackRange;
        float distance = Vector3.Distance(target.position, transform.position);
        attackTimer += Time.deltaTime;
        agent.SetDestination(target.position);
        agent.isStopped = true;
        yield return new WaitForSeconds(3);
        agent.isStopped = false;
        agent.speed = speedMax;

        if (distance <= attackRange)
        {
            FaceTarget();
            if (attackTimer >= attackCooldown)
            {
                attack();
                attackTimer = 0;
            }
        }
        Rush();
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

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Charge : MonoBehaviour
{
    // Start is called before the first frame update

    Transform target;
    NavMeshAgent agent;
    public float lookRadius = 10f;
    private static bool aggro = false;
    public float attackCooldown = 1f;
    private float attackTimer = 1f;
    public float chargeDelay = 1f;
    public float chargeSpeed = 15f;
    public float chargeTime = 2f;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    IEnumerator StartCharge()
    {
        FaceTarget();
        Vector3 dir = (target.position - transform.position).normalized;
        yield return new WaitForSeconds(chargeDelay);
        transform.position += Vector3.forward * Time.deltaTime * chargeSpeed;
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
        else if (aggro == true)
        {
            StartCharge();
        }

    }


    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 100);

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
*/
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Charge : MonoBehaviour
{
    // Start is called before the first frame update

    Transform target;
    NavMeshAgent agent;
    public float lookRadius = 10f;
    private static bool aggro = false;
    public float attackCooldown = 1f;
    private float attackTimer = 1f;
    public float chargeDelay = 1f;
    public float chargeSpeed = 15f;
    public float chargeTime = 2f;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(StartCharge());
    }

    IEnumerator StartCharge()
    {
        Debug.Log("tak");
        FaceTarget();
        Vector3 dir = (target.position - transform.position).normalized;
        yield return new WaitForSeconds(chargeDelay);
        float timer = 2f;
        while (timer >= 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            transform.position += Vector3.forward * Time.deltaTime * chargeSpeed;
            timer -= Time.deltaTime;
        }
        StartCharge();
        GetComponent<RepeatedCharge>().enabled = true;
        GetComponent<Charge>().enabled = false;

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
        else if (aggro == true)
        {
            FaceTarget();
            Debug.Log("kek");
            StartCharge();
            Debug.Log("hy");
        }
    }


    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 100);

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
*/