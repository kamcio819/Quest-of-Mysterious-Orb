using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingOrb : OrbGameObject<ChargingOrbData>, IEnableable, IUpdatable, IDisaable
{
   public void OnIDisable()
   {
      
   }

   public void OnIEnable()
   {
      
   }

   public void OnIUpdate()
   {
      if(isSpawned) {
         Vector3 newPos = transform.position;
         newPos += transform.forward * Mathf.Lerp(0f, 2f, (OrbData as ChargingOrbData).AcceleretaionFactor * 3f *  Time.deltaTime);
         transform.position = newPos;
      }
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