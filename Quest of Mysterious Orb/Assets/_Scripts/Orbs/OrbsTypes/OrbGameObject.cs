using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OrbGameObject<T> : OrbObject
    where T : OrbData
{
    [SerializeField]
    private T orbData;

    public T OrbData { get => orbData; set => orbData = value; }

    protected virtual void OnCollisionEnter(Collision collision) {
    }
    protected virtual void OnTriggerEnter(Collider collider) {
        var enemyObject = collider.GetComponent<EnemyObject>();
        if(enemyObject != null) {
            gameObject.SetActive(false);
            enemyObject.ProcessHitOrb(orbData);
        }
    }

    public override OrbData GetData() {
        return orbData;
    } 

}

public abstract class OrbGameObject : OrbObject
{
    [SerializeField]
    private OrbData orbData;

    public OrbData OrbData { get => orbData; set => orbData = value; }

    protected virtual void OnCollisionEnter(Collision collision) {
        var enemyObject = collision.collider.GetComponent<EnemyObject>();
        if(enemyObject != null) {
            gameObject.SetActive(false);
            enemyObject.ProcessHitOrb(orbData);
        }
    }
    protected virtual void OnTriggerEnter(Collider collider) {
        var enemyObject = collider.GetComponent<EnemyObject>();
        if(enemyObject != null) {
            gameObject.SetActive(false);
            enemyObject.ProcessHitOrb(orbData);
        }
    }

    public override OrbData GetData() {
        return orbData;
    } 
}
