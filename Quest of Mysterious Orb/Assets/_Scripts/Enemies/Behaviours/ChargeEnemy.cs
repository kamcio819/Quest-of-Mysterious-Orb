using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChargeEnemy : EnemyGameObject<ChargeEnemyData>, IUpdatable, ILateUpdatable, IFixedUpdateable, IEnableable, IDisaable
{
    // RED ORB
    [SerializeField]
    private Rigidbody rigidbodyComponet;

    [SerializeField]
    private Transform target;

    private float time;

    private void OnEnable() {
        time = 0f;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

 
    protected override void OnCollisionEnter(Collision collision)
    {
    }

    protected override void OnTriggerEneter(Collider collider)
    {
    }

    public void OnIUpdate()
    {
        enemyAnimator.SetBool("isMoving", false);
        enemyAnimator.SetBool("isAttacking", false);

        float distance = Vector3.Distance(target.position, transform.position);
        if(distance < 15f) {
            time += Time.deltaTime;

            enemyAnimator.SetBool("isMoving", true);
            enemyAnimator.SetBool("isAttacking", false);

            if(time < 5f) {

                time = 0f;
                Vector3 dir = (target.position - transform.position).normalized;
                dir.y = 0;
                Quaternion quaternionToRotate = Quaternion.FromToRotation(transform.forward, dir) * transform.rotation;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, quaternionToRotate, 20f);

                Vector3 direction = target.position - transform.position;
                direction.y = 0;
                rigidbodyComponet.velocity += direction * 0.5f * Time.deltaTime;

                if(direction.x < 0.5f || direction.z < 0.5f) {
                    enemyAnimator.SetBool("isAttacking", true);
                    enemyAnimator.SetBool("isMoving", false);
                }
                
            }
            
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
        enemyHealth -= orbData.DamageGiven;
        if(enemyHealth < 0f) {
            Die();
        }
        else {
            Hit();
        }
    }

    private void Hit()
    {
        enemyAnimator.SetTrigger("isHit");
        HitEffect.time = 0;
        HitEffect.Play();
    }

    private void Die()
    {
       var objectToSpawn = MyObjectPoolManager.Instance.GetObject("ChargingOrb", true);
       objectToSpawn.transform.position = gameObject.transform.position;
       StartCoroutine(DieBehaviour());
    }

    private IEnumerator DieBehaviour()
    {
        DestroyEffect.time = 0;
        DestroyEffect.Play();
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}

