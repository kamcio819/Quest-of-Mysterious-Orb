using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : EnemyGameObject<BossEnemyData>, IUpdatable, ILateUpdatable, IFixedUpdateable, IEnableable, IDisaable
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private ParticleSystem flameParticle;

    private bool targetLocked = false;
    private float timer = 0f;
    private float rotateSpeeder = 1f;

    protected override void OnCollisionEnter(Collision collision)
    {
        
    }

    protected override void OnTriggerEnter(Collider collider)
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
                
                timer += Time.deltaTime;
                if (timer >= 5f)
                {
                    Shoot();
                    timer = 0;
                }
                else {
                    FaceTarget();
                }
            }
            else {
                enemyAnimator.SetBool("Attack", false);
            }
        }       
    }

    private void Shoot() {       
        StartCoroutine(ShootAnimation());     
    }

    private IEnumerator ShootAnimation()
    {
        enemyAnimator.SetBool("Attack", true);
        yield return new WaitForSeconds(1.75f);
        flameParticle.Play();
        yield return new WaitForSeconds(1.25f);
        flameParticle.Stop();
        rotateSpeeder = 1f;
        flameParticle.time = 0f;

    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0;
        Quaternion quaternionToRotate = Quaternion.FromToRotation(transform.forward, direction) * transform.rotation;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, quaternionToRotate, 1.2f * rotateSpeeder);
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
        rotateSpeeder += 0.6f;
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
        var objectToSpawn = MyObjectPoolManager.Instance.GetObject("HomingOrb", true);
        objectToSpawn.GetComponent<OrbObject>().isSpawned = false;
        objectToSpawn.transform.position = position;
    }
} 
