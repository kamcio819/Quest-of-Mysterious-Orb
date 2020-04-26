using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingClosestEnemy : MonoBehaviour
{
    private EnemyObject closestEnemy;

    public EnemyObject ClosestEnemy { get => closestEnemy; }

    private bool locked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!locked)
        {
            var enemyObject = other.GetComponent<EnemyObject>();
            if (enemyObject != null)
            {
                locked = true;
                closestEnemy = enemyObject;
            }
        }
    }
}
