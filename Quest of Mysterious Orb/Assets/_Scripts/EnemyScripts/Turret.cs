using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform targetPosition;
    private GameObject target;
    private bool targetLocked = false;
    public float shotTimer = 1f;
    public float lookRadius = 10f;
    public float rotationSpeed = 5f;
    private float timer = 1f;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetLocked)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            if (distance <= lookRadius) targetLocked = true;
        }

        if (targetLocked)
        {
            FaceTarget();
            timer += Time.deltaTime;
            if (timer >= shotTimer)
            {
                Shoot();
                timer = 0;
            }
        }
    }

    void Shoot()
    {
        //Shooting the player.
        //Add shoot particle, shot sound, bullet object
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

    }

}
