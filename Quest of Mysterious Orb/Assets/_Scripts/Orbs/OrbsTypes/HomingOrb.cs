using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HomingOrb : OrbGameObject<HomingOrbData>, IEnableable, IUpdatable, IDisaable
{
   [SerializeField]
   private EnemyObject nearestEnemyObject;

   [SerializeField]
   private Rigidbody rigidbodyComponet;
   public void OnIDisable()
   {
      
   }

   public void OnIEnable()
   {
      
   }

   public void OnIUpdate()
   {
      Vector3 direction = nearestEnemyObject.transform.position - transform.position;
      rigidbodyComponet.velocity += direction * 0.5f * Time.deltaTime;
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