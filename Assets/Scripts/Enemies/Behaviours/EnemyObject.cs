using System;
using UnityEngine;

public abstract class EnemyObject : MonoBehaviour
{
    [SerializeField]
    protected Animator enemyAnimator;

    [SerializeField]
    [Range(0f, 100f)]
    private float enemyHealth = 100f;

    [SerializeField]
    private ParticleSystem hitEffect;

    [SerializeField]
    private ParticleSystem destroyEffect;

    public ParticleSystem HitEffect { get => hitEffect; }
    public ParticleSystem DestroyEffect { get => destroyEffect; }
    public float Health { get => enemyHealth; set => enemyHealth = value; }

    public bool isSpawned;
    public virtual EnemyData GetData()
    {
        return null;
    }

    public virtual void ProcessHitOrb(OrbData orbData)
    {

    }
}