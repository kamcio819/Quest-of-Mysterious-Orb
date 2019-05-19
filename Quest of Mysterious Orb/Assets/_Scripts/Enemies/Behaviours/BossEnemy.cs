using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : EnemyGameObject<BossEnemyData>, IUpdatable, ILateUpdatable, IFixedUpdateable, IEnableable, IDisaable
{
    // BLUE ORB
    [SerializeField]
    private Transform target;

    [SerializeField]
    private LayerMask layerMask;

    private bool targetLocked = false;
    private float timer = 0f;

    protected override void OnCollisionEnter(Collision collision)
    {
        
    }

    protected override void OnTriggerEneter(Collider collider)
    {
        
    }

    private void OnEnable() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void OnIUpdate()
    { 
        Vector3 dir = target.position - transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir , out hit, 50f, layerMask)) {

        }
        else {
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= (EnemyData as BossEnemyData).LookRadius)
            { 
                targetLocked = true;
            }
            else {
                targetLocked = false;
            }

            if (targetLocked)
            {
                FaceTarget();
                timer += Time.deltaTime;
                if (timer >= 5f)
                {
                    Shoot();
                    timer = 0;
                }
 
            }
            else {
                enemyAnimator.SetBool("Attack", false);
            }
        }       
    }

    private void Shoot() {
        enemyAnimator.SetBool("Attack", true);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0;
        Quaternion quaternionToRotate = Quaternion.FromToRotation(transform.forward, direction) * transform.rotation;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, quaternionToRotate, 20f);
        enemyAnimator.SetFloat("X", Mathf.Clamp(quaternionToRotate.x, -1, 1));
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
        enemyAnimator.SetTrigger("HitFromBack");
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
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
        var objectToSpawn = MyObjectPoolManager.Instance.GetObject("HomingOrb", true);
        objectToSpawn.transform.position = position;
    }
} 
