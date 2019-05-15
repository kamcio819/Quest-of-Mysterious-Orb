using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Patrol : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        agent.stoppingDistance = 0;
        GotoNextPoint();

    }


    void GotoNextPoint()
    {
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }



    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }

}