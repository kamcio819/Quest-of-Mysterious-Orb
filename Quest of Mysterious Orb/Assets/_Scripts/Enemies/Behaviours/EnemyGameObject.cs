using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyGameObject<T> : EnemyObject
    where T : EnemyData
{
    [SerializeField]
    private T enemyData;

    public T EnemyData { get => enemyData; set => enemyData = value; }

    protected abstract void OnCollisionEnter(Collision collision);
    protected abstract void OnTriggerEneter(Collider collider);

    public override EnemyData GetData() {
        return enemyData;
    } 

}

public abstract class EnemyGameObject: EnemyObject
{
    [SerializeField]
    private EnemyData enemyData;

    public EnemyData EnemyData { get => enemyData; set => enemyData = value; }

    protected abstract void OnCollisionEnter(Collision collision);
    protected abstract void OnTriggerEneter(Collider collider);

    public override EnemyData GetData() {
        return enemyData;
    } 

}