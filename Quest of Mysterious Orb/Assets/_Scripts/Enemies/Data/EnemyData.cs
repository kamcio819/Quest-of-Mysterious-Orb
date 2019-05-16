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

    [SerializeField]
    private float enemyDamage;

    public float EnemyDamage { get => enemyDamage; set => enemyDamage = value; }
}

