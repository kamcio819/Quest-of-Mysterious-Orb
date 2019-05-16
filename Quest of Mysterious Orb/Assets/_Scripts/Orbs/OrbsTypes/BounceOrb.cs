using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOrb : OrbGameObject<BounceOrbData>, IEnableable, IUpdatable, IDisaable
{
   private float speedAdder = 1f;
   public void OnIEnable()
   {
   }

   private void OnEnable() {
      if(isSpawned) {
         GetComponent<SphereCollider>().isTrigger = false;
      }
   }

   public void OnIUpdate()
   {
      if(isSpawned) {
         Vector3 newPos = transform.position;
         newPos += transform.forward * (OrbData as BounceOrbData).MovingSpeed * speedAdder * 3f * Time.deltaTime;
         transform.position = newPos;
      }
   }

   public void OnIDisable()
   {
      
   }
   protected override void OnCollisionEnter(Collision collision)
   {
      speedAdder += (OrbData as BounceOrbData).BounceSpeed;
      Vector3 newDirection = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
        
      transform.rotation = Quaternion.LookRotation(newDirection);
   }

   protected override void OnTriggerEneter(Collider collider)
   {
      
   }

   public override OrbObject Pick() {
      return this;
   }
   
}