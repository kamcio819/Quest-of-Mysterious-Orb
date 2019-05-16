using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HomingOrb : OrbGameObject<HomingOrbData>, IEnableable, IUpdatable, IDisaable
{
   [SerializeField]
   private EnemyObject nearestEnemyObject;
   public void OnIDisable()
   {
      
   }

   public void OnIEnable()
   {
      
   }

   public void OnIUpdate()
   {
      
   }

   protected override void OnCollisionEnter(Collision collision)
   {
      
   }

   protected override void OnTriggerEneter(Collider collider)
   {
      
   }

   public override OrbObject Pick() {
      return this;
   }
}