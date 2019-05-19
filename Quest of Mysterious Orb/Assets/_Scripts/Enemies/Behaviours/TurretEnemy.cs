using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : EnemyGameObject<TurretEnemyData>, IUpdatable, ILateUpdatable, IFixedUpdateable, IEnableable, IDisaable
{
    // BLUE ORB
    [SerializeField]
    private Transform target;

    [SerializeField]
    private LayerMask layerMask;

    private bool targetLocked = false;
    private float timer = 0f;

    private void OnEnable() {
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
        Vector3 dir = target.position - transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir , out hit, 50f, layerMask)) {

        }
        else {
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= (EnemyData as TurretEnemyData).LookRadius)
            { 
                targetLocked = true;
            }
            else {
                targetLocked = false;
            }
            Debug.Log(distance + " " + targetLocked);
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
            }
        }       
    }

    private void Shoot()
    {
        enemyAnimator.SetTrigger("isShooting");
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0;
        Quaternion quaternionToRotate = Quaternion.FromToRotation(transform.forward, direction) * transform.rotation;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, quaternionToRotate, 20f);
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

    private void Hit() {
        HitEffect.time = 0;
        HitEffect.Play();
    }

    private void Die()
    {
       var objectToSpawn = MyObjectPoolManager.Instance.GetObject("HomingOrb", true);
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
