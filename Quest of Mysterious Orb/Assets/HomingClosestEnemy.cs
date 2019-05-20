using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingClosestEnemy : MonoBehaviour
{
    private EnemyObject closestEnemy;

    public EnemyObject ClosestEnemy { get => closestEnemy; }

    private void OnTriggerEnter(Collider other) {
        var enemyObject = other.GetComponent<EnemyObject>();
        if(enemyObject != null) {
            closestEnemy = enemyObject;
        }
    }
}
