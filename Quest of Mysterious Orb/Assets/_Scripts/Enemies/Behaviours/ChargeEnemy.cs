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

    private float time;

    private void OnEnable() {
        time = 0f;
        target = GameObject.FindGameObjectWithTag("Player").transform;      
    }

 
    protected override void OnCollisionEnter(Collision collision)
    {
    }

    protected override void OnTriggerEnter(Collider collider)
    {
        base.OnTriggerEnter(collider);
        var player = collider.GetComponent<PlayerObject>();
        if(player != null) {
            rigidbodyComponet.AddTorque(transform.up * 80f);
        }  
    }

    public void OnIUpdate()
    {
        enemyAnimator.SetBool("isMoving", false);
        enemyAnimator.SetBool("isAttacking", false);

        float distance = Vector3.Distance(target.position, transform.position);
        if(distance < 15f) {

            enemyAnimator.SetBool("isMoving", true);
            enemyAnimator.SetBool("isAttacking", false);

            Vector3 dir = (target.position - transform.position).normalized;
            dir.y = 0;
            Quaternion quaternionToRotate = Quaternion.FromToRotation(transform.forward, dir) * transform.rotation;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, quaternionToRotate, 20f);

            rigidbodyComponet.velocity += dir * EnemyData.MovingSpeed * Time.deltaTime;

            if(dir.x < 0.5f || dir.z < 0.5f) {
                enemyAnimator.SetBool("isAttacking", true);
                enemyAnimator.SetBool("isMoving", false);
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
        var position = gameObject.transform.position;
        StartCoroutine(DieBehaviour(position));
    }

    private IEnumerator DieBehaviour(Vector3 position)
    {
        DestroyEffect.time = 0;
        DestroyEffect.Play();
        yield return new WaitForSeconds(0.15f);
        this.gameObject.SetActive(false);
        var objectToSpawn = MyObjectPoolManager.Instance.GetObject("BounceOrb", true);
        objectToSpawn.transform.position = position;
    }
}

