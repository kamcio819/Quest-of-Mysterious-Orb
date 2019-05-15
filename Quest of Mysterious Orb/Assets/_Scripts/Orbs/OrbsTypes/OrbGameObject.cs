using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OrbGameObject<T> : OrbObject
    where T : OrbData
{
    [SerializeField]
    private T orbData;

    public T OrbData { get => orbData; set => orbData = value; }

    protected abstract void OnCollisionEnter(Collision collision);
    protected abstract void OnTriggerEneter(Collider collider);

    public override OrbData GetData() {
        return orbData;
    } 

}

public abstract class OrbGameObject : OrbObject
{
    [SerializeField]
    private OrbData orbData;

    public OrbData OrbData { get => orbData; set => orbData = value; }

    protected abstract void OnCollisionEnter(Collision collision);
    protected abstract void OnTriggerEneter(Collider collider);

    public override OrbData GetData() {
        return orbData;
    } 
}
