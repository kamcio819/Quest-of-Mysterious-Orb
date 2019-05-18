using System;
using UnityEngine;

public abstract class EnemyObject : MonoBehaviour
{
   [SerializeField]
   protected Animator enemyAnimator;

   [SerializeField] [Range(0f, 100f)]
   protected float enemyHealth = 100f;

   [SerializeField]
   private ParticleSystem hitEffect;

   [SerializeField]
   private ParticleSystem destroyEffect;

   public ParticleSystem HitEffect { get => hitEffect; }
   public ParticleSystem DestroyEffect { get => destroyEffect; }
   
   public bool isSpawned;
   public virtual EnemyData GetData()
   {
      return null;
   }

   public virtual void ProcessHitOrb(OrbData orbData)
   {
      
   }
}