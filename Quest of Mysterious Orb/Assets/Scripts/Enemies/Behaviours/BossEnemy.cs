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
    private bool roar = false;

    protected override void OnCollisionEnter(Collision collision)
    {

    }

    protected override void OnTriggerEnter(Collider collider)
    {

    }

    private void OnEnable()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        FindObjectOfType<EnemyController>().EnemiesObject.Add(this);
    }

    public void OnIUpdate()
    {
        Vector3 dir = target.position - transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir, out hit, 50f, layerMask))
        {

        }
        else
        {
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= (EnemyData as BossEnemyData).LookRadius)
            {
                if (!roar)
                {
                    SoundManager.Instance.PlaySound("LAG - Dragon_roar-002", GetComponent<AudioSource>());
                    roar = true;
                }
                targetLocked = true;
            }
            else
            {
                roar = false;
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
                else
                {
                    FaceTarget();
                }
            }
            else
            {
                enemyAnimator.SetBool("Attack", false);
            }
        }
    }

    private void Shoot()
    {
        StartCoroutine(ShootAnimation());
    }

    private IEnumerator ShootAnimation()
    {
        enemyAnimator.SetBool("Attack", true);
        SoundManager.Instance.PlaySound("LAG - Dragon_attack-002", GetComponent<AudioSource>());
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

    public void OnIDisable()
    {

    }

    public void OnIEnable()
    {

    }

    public override void ProcessHitOrb(OrbData orbData)
    {
        Health -= orbData.DamageGiven;
        if (Health < 0f)
        {
            Die();
        }
        else
        {
            Hit();
        }
    }

    private void Hit()
    {
        SoundManager.Instance.PlaySound("LAG - Dragon_hit-001", GetComponent<AudioSource>());
        enemyAnimator.SetTrigger("HitFromBack");
        HitEffect.time = 0;
        HitEffect.Play();
        rotateSpeeder += 0.6f;
    }

    private void Die()
    {
        SoundManager.Instance.PlaySound("LAG - Dragon_die", GetComponent<AudioSource>());
        var position = gameObject.transform.position;
        StartCoroutine(DieBehaviour(position));
    }

    private IEnumerator DieBehaviour(Vector3 position)
    {
        DestroyEffect.time = 0;
        DestroyEffect.Play();
        yield return new WaitForSeconds(0.15f);
        this.isSpawned = false;
        this.gameObject.SetActive(false);
        var objectToSpawn = MyObjectPoolManager.Instance.GetObject("HomingOrb", true);
        objectToSpawn.GetComponent<OrbObject>().isSpawned = false;
        objectToSpawn.transform.position = position;
        objectToSpawn.GetComponent<SphereCollider>().isTrigger = true;
        SoundManager.Instance.PlaySound("LAG - Orb_appearing", GetComponent<AudioSource>());
    }
}
