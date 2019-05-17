using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using DG.Tweening;
using System;

public class PatrolEnemy : EnemyGameObject<PatrolEnemyData>, IUpdatable, ILateUpdatable, IFixedUpdateable, IEnableable, IDisaable
{
    [SerializeField]
    private Transform[] points;

    [SerializeField]
    private Transform target;
    private int destPoint = 0;
    private int index = 0;

    private Tween moveTween;
    private bool followPlayer = false;

    private float startTime;

    private float distance;

    private void Awake() {
        startTime = Time.time;
    }

    private void RotateTowardsPoint(Vector3 targetPos, float rotationSpeed)
    {
        Vector3 dir = targetPos - transform.position;

        var quaternionToRotate = Quaternion.FromToRotation(transform.forward, dir) * transform.rotation;

        transform.rotation = Quaternion.Lerp(transform.rotation, quaternionToRotate, rotationSpeed);
    }


    protected override void OnCollisionEnter(Collision collision)
    {
        
    }

    protected override void OnTriggerEneter(Collider collider)
    {
        
    }

    public void OnILateUpdate()
    {
        
    }

    public void OnIFixedUpdate()
    {
        
    }

    public void OnIUpdate()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if(distance > 10f) {
            transform.position = Vector3.Lerp(transform.position, points[index].position, (EnemyData as PatrolEnemyData).MovingSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, points[index].position) < 0.5f) { 
                index++;
                index %= 3;
            }
        }
        else {
            if(distance > 2.5f) {
                transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * (EnemyData as PatrolEnemyData).MovingSpeed/2);
            }
        }
    }

    public void OnIDisable() {

    }

    public void OnIEnable() {

    }

    public override void ProcessHitOrb(OrbData orbData) {
        EnemyData.EnemyHealth -= orbData.DamageGiven;
        if(EnemyData.EnemyHealth < 0f) {
            Die();
        }
        else {
            //Animation
            //DROP ORB
            //SOUND
        }
    }

   private void Die()
   {
      
   }
}