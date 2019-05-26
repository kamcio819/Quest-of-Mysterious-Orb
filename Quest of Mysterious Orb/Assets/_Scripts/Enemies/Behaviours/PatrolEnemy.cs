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

    private float startTime;

    private float distance;
    private bool locked = false;

    private void OnEnable() {
        startTime = Time.time;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void RotateTowardsPoint(Vector3 targetPos, float rotationSpeed)
    {
        Vector3 dir = targetPos - transform.position;

        var quaternionToRotate = Quaternion.FromToRotation(transform.right, dir) * transform.rotation;

        transform.rotation = Quaternion.Lerp(transform.rotation, quaternionToRotate, rotationSpeed);
    }


    protected override void OnCollisionEnter(Collision collision)
    {
        
    }

    protected override void OnTriggerEnter(Collider collider)
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
        if(isSpawned) {
            float distance = Vector3.Distance(transform.position, target.position);

            if(distance > 6f) {
                if(!locked) {   
                    SoundManager.Instance.PlaySound("LAG - Dron_movement", GetComponent<AudioSource>());
                    locked = true;
                }
                enemyAnimator.SetBool("isMoving", true);
                enemyAnimator.SetBool("isShooting", false);
                RotateTowardsPoint(points[index].position, 5f * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, points[index].position, (EnemyData as PatrolEnemyData).MovingSpeed * Time.deltaTime);
                if(Vector3.Distance(transform.position, points[index].position) < 1f) { 
                    index++;
                    index %= 3;
                }
            }
            else {
                locked = false;
                if(distance > 0.5f) {
                    enemyAnimator.SetBool("isShooting", false);
                    enemyAnimator.SetBool("isMoving", true);
                    RotateTowardsPoint(target.position, 10f * Time.deltaTime);
                    transform.position = Vector3.MoveTowards(transform.position, target.position, (EnemyData as PatrolEnemyData).MovingSpeed * Time.deltaTime);
                }
                else {
                    enemyAnimator.SetBool("isMoving", false);
                    enemyAnimator.SetBool("isShooting", true);
                    SoundManager.Instance.PlaySound("LAG - Dron_attack", GetComponent<AudioSource>());
                }
            }
        }
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
        SoundManager.Instance.PlaySound("LAG - Dron_attack", GetComponent<AudioSource>());
        enemyAnimator.SetTrigger("isHit");
        HitEffect.time = 0;
        HitEffect.Play();
    }

    private void Die()
    {
        SoundManager.Instance.PlaySound("LAG - Dron_die", GetComponent<AudioSource>());
        var position = gameObject.transform.position;
        StartCoroutine(DieBehaviour(position));
    }

    private IEnumerator DieBehaviour(Vector3 position)
    {
        DestroyEffect.time = 0;
        DestroyEffect.Play();
        yield return new WaitForSeconds(0.15f);
        this.gameObject.SetActive(false);
        var objectToSpawn = MyObjectPoolManager.Instance.GetObject("ChargingOrb", true);
        objectToSpawn.GetComponent<OrbObject>().isSpawned = false;
        objectToSpawn.transform.position = position;
        SoundManager.Instance.PlaySound("LAG - Orb_appearing", GetComponent<AudioSource>());
    }
}