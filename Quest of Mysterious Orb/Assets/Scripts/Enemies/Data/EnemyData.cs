using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    PATROL,
    CHARGE,
    TURRET,
    BOSS
}

public class EnemyData : Data
{
    [SerializeField]
    private EnemyType enemyType;

    [SerializeField]
    private float enemyDamage;

    [SerializeField]
    private float enemyHealth;

    public float EnemyDamage { get => enemyDamage; set => enemyDamage = value; }
    public float EnemyHealth { get => enemyHealth; set => enemyHealth = value; }
    public EnemyType EnemyType { get => enemyType; set => enemyType = value; }

}

