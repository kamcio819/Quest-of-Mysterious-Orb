using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : EnemyGameObject<PatrolEnemyData>, IEnableable, IUpdatable, IDisaable, IAwakable, ILateUpdatable
{
    [SerializeField]
    private Rigidbody rigidbodyComponet;
    private float time;

    private void OnEnable()
    {
        time = 0f;
    }


    protected override void OnCollisionEnter(Collision collision)
    {
    }

    protected override void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<PlayerObject>() != null)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnIUpdate()
    {
        if (isSpawned)
        {
            time += Time.deltaTime;
            Vector3 newPos = transform.position;
            newPos += transform.forward * 3f * Time.deltaTime;
            transform.position = newPos;
            if (time > 10f)
            {
                isSpawned = false;
                gameObject.SetActive(false);
            }
        }
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
    }

    public void OnIAwake()
    {

    }
}
