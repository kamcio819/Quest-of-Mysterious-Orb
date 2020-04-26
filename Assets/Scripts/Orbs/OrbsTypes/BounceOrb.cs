using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOrb : OrbGameObject<BounceOrbData>, IEnableable, IUpdatable, IDisaable, IAwakable
{
    private float speedAdder = 1f;
    private float timeTaken;

    public void OnIAwake()
    {
        timeTaken = 0f;
    }
    public void OnIEnable()
    {
    }

    private void OnEnable()
    {
        timeTaken = 0f;
    }

    public void Update()
    {
        if (isSpawned)
        {
            GetComponent<SphereCollider>().isTrigger = false;
            timeTaken += Time.deltaTime;
            Vector3 newPos = transform.position;
            newPos += transform.forward * (OrbData as BounceOrbData).MovingSpeed * speedAdder * 3f * Time.deltaTime;
            transform.position = newPos;
            if (timeTaken > OrbData.CooldownTime)
            {
                isSpawned = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void OnIDisable()
    {

    }
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        speedAdder += (OrbData as BounceOrbData).BounceSpeed;
        Vector3 newDirection = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
        transform.rotation = Quaternion.LookRotation(newDirection);

    }

    protected override void OnTriggerEnter(Collider collider)
    {
        base.OnTriggerEnter(collider);
    }

    public override OrbObject Pick()
    {
        return this;
    }

    public void OnIUpdate()
    {

    }
}