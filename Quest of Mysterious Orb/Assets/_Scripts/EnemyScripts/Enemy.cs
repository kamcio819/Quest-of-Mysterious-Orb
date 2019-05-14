using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    PATROL,
    CHARGE,
    TURRET
}

public class EnemyData : Data
{
    [SerializeField]
    private EnemyType enemyType;
    public float hitpoints;
    public float damage;
    public float attackRange;
}

