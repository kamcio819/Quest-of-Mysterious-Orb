using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChargeEnemy : EnemyGameObject<ChargeEnemyData>, IUpdatable, ILateUpdatable, IFixedUpdateable, IEnableable, IDisaable
{
    [SerializeField]
    private Rigidbody rigidbodyComponet;

    [SerializeField]
    private Transform target;
 
    protected override void OnCollisionEnter(Collision collision)
    {
    }

    protected override void OnTriggerEneter(Collider collider)
    {
    }

    public void OnIUpdate()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance < 15f) {  
            Vector3 direction = target.position - transform.position;
            rigidbodyComponet.velocity += direction * 0.5f * Time.deltaTime;
        }
    }

    public void OnILateUpdate()
    {
    }

    public void OnIFixedUpdate()
    {
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
            //DROP ORB
            //SOUND
        }
    }

    private void Die()
    {
       throw new NotImplementedException();
    }
}

