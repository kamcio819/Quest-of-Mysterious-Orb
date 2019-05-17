using System;
using UnityEngine;

public abstract class EnemyObject : MonoBehaviour
{
   public bool isSpawned;
   public virtual EnemyData GetData()
   {
      return null;
   }

   public virtual void ProcessHitOrb(OrbData orbData)
   {
      
   }
}