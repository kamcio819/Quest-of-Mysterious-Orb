using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform targetPosition;
    private GameObject target;
    private bool targetLocked = false;
    private bool shotReady = true;
    public float shotTimer = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (targetLocked)
        {
            transform.LookAt(target.transform);
            shotTimer += Time.deltaTime;
            if (shotTimer >= 1f)
                Shoot();
        
        }

        
    }

    void Shoot()
    {
        //Shooting the player.
    }

    
    private void OnTriggerEnter(Collider other)
    {
        target = other.gameObject;
        targetLocked = true;
    }
}
